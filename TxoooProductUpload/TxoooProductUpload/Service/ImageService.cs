using FSLib.Network.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TxoooProductUpload.Common;
using TxoooProductUpload.Common.Extended;
using TxoooProductUpload.Network;
using TxoooProductUpload.Service.Entities.Web;

namespace TxoooProductUpload.Service
{

    /// <summary>
    /// 图像服务
    /// </summary>
    public class ImageService : ServiceBase
    {
        Regex _txoooImgReg = new Regex("img.txooo.com");
        const string _sqlFormatInsertIMg = @"INSERT INTO iwenli_image(SourceUrl,ToooUrl,UserId,UploadType,Remard) values('{0}','{1}',{2},'{3}','{4}')";

        /*
         * 异常码说明：
         * 001：GetImageStreamByImgUrl异常
         * 001：GetImageStreamByImgUrl异常
         */
        public ImageService(ServiceContext context) : base(context)
        {
        }

        /// <summary>
        /// 根据URL获取图片  同步
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Image GetImageByUrl(string url)
        {
            var stCtx = NetClient.Create<byte[]>(HttpMethod.Get, url);
            stCtx.Send();
            if (!stCtx.IsValid())
            {
                throw new Exception("下载图片{0}异常002[远程服务器未响应]，请重试！".FormatWith(url));
            }
            return Image.FromStream(new MemoryStream(stCtx.Result));
        }

        /// <summary>
        /// 通过url获取图片字节流
        /// </summary>
        /// <param name="url">图片url</param>
        /// <returns></returns>
        public async Task<byte[]> GetImageStreamAsync(string url)
        {
            var stCtx = NetClient.Create<byte[]>(HttpMethod.Get, url, allowAutoRedirect: true);

            await stCtx.SendAsync();
            if (!stCtx.IsValid())
            {
                throw new Exception("下载图片{0}异常001[远程服务器未响应]，请重试！".FormatWith(url));
            }
            return stCtx.Result;
        }

        /// <summary>
        /// 上传图片,成功返回url,失败返回空字符串
        /// </summary>
        /// <param name="url">网络图片URL</param>
        /// <param name="uploadType">上传类型，0系统请求，1商品主图，2商品详情，3SKU图片，4商品评价图</param>
        /// <returns></returns>
        public async Task<string> UploadImgAsync(string url, int uploadType)
        {
            //如果已经是txooo的连接  不转换
            if (_txoooImgReg.IsMatch(url))
            {
                return url;
            }
            var imageStream = await GetImageStreamAsync(url);
            var imgUrl = await UploadFileForByteAsync(imageStream);
            if (imgUrl == "Error" || imgUrl.IsNullOrEmpty() || !_txoooImgReg.IsMatch(imgUrl))
            {
                throw new Exception("图片上传到创业赚钱失败!");
            }
            #region DB记录
            try
            {
                string uploadTypeStr = string.Empty;
                switch (uploadType)
                {
                    case 0:
                        uploadTypeStr = "系统请求";
                        break;
                    case 1:
                        uploadTypeStr = "商品主图";
                        break;
                    case 2:
                        uploadTypeStr = "商品详情";
                        break;
                    case 3:
                        uploadTypeStr = "SKU图片";
                        break;
                    case 4:
                        uploadTypeStr = "商品评价图";
                        break;
                }
                DbHelperOleDb.ExecuteSql(string.Format(_sqlFormatInsertIMg, url, imgUrl, ServiceContext.Session.Token.userid, uploadTypeStr, string.Empty));
            }
            catch (Exception ex)
            {
                throw new Exception("CommonService.DowloadImage.DbHelperOleDb异常" + ex.Message);
            }
            #endregion
            return imgUrl;
        }

        /// <summary>
        /// 上传图片,成功返回url,失败返回空字符串
        /// </summary>
        /// <param name="image">Image对象的图片</param>
        /// <returns></returns>
        public async Task<string> UploadImgAsync(Image image)
        {
            var imgUrl = await UploadFileForByteAsync(image.ToBytes(), image.GetExtension());
            if (imgUrl == "Error" || imgUrl.IsNullOrEmpty() || !_txoooImgReg.IsMatch(imgUrl))
            {
                throw new Exception("图片上传到创业赚钱失败!");
            }
            return imgUrl;
        }

        #region 备用 暂时使用主站服务上传
        /// <summary>
        /// 使用TXOOO服务上传图片,成功返回url,失败返回空字符串[备用 暂时使用主站服务上传]
        /// </summary>
        /// <param name="imageStream">Image的字节流</param>
        /// <returns></returns>
        async Task<string> UploadImg(byte[] imageStream)
        {
            var data = new
            {
                file = new HttpVirtualBytePostFile(Guid.NewGuid().ToString("N") + ".jpg", imageStream)
            };

            var stCtx = NetClient.Create<WebResponseResult<string>>(HttpMethod.Post, ApiList.UpdateImgFile, data: data);
            stCtx.Request.Timeout = 1000;

            await stCtx.SendAsync();
            if (!stCtx.IsValid())
            {
                throw new Exception("CommonService.UploadImg未能提交请求");
            }
            return stCtx.Result.msg;
        }
        #endregion

        /// <summary>
        /// 获取所有头像,如果有缓存数据，则从缓存中取值
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllHeadPicList()
        {
            DataSet ds = DbHelperOleDb.Query("SELECT * FROM iwenli_headPic");
            List<string> retList = new List<string>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                retList.Add(item["HeadUrl"].ToString());
            }
            return retList;
        }

        /// <summary>
        /// 向文件服务器上传文件
        /// </summary>
        /// <param name="file">文件流</param>
        /// <param name="fileExtension">文件类型</param>
        /// <returns>返回文件服务地址，错误返回：Error</returns>
        private static async Task<string> UploadFileForByteAsync(byte[] file, string fileExtension = "")
        {
            if (fileExtension.IsNullOrEmpty())
            {
                fileExtension = file.GetExtension();
            }
            NewWebClient myWebClient = new NewWebClient();
            myWebClient.Timeout = 10000;  //设置超时时间
            myWebClient.Credentials = CredentialCache.DefaultCredentials;
            myWebClient.Headers.Add("TxoooUploadFileType", fileExtension);
            byte[] getArray = await myWebClient.UploadDataTaskAsync("http://file.txooo.cc/UpLoadForByte.ashx", file);
            string getstr = Encoding.Default.GetString(getArray);
            return getstr.Replace("http:", "https:");
        }

        #region 同步方法
        /// <summary>
        /// 通过url上传图片到txooo服务器
        /// </summary>
        /// <param name="url"></param>
        /// <param name="timeOut">超时时间 默认30s</param>
        /// <returns></returns>
        public string UploadImg(string url,int timeOut = 30000)
        {
            //如果已经是txooo的连接  不转换
            if (_txoooImgReg.IsMatch(url))
            {
                return url;
            }
            var imageStream = GetImageStream(url);
            var imgUrl = UploadFileForByte(imageStream);
            if (imgUrl == "Error" || imgUrl.IsNullOrEmpty() || !_txoooImgReg.IsMatch(imgUrl))
            {
                throw new Exception("图片{0}上传到创业赚钱服务器失败!".FormatWith(url));
            }
            return imgUrl;
        }

        /// <summary>
        /// 上传图片,成功返回url,失败返回空字符串
        /// </summary>
        /// <param name="url">网络图片URL</param>
        /// <param name="uploadType">上传类型，0系统请求，1商品主图，2商品详情，3SKU图片，4商品评价图</param>
        /// <param name="timeOut">超时时间 默认30s</param>
        /// <returns></returns>
        public string UploadImg(string url, int uploadType, int timeOut = 30000)
        {
            var imgUrl = UploadImg(url);
            #region DB记录
            //try
            //{
            //    string uploadTypeStr = string.Empty;
            //    switch (uploadType)
            //    {
            //        case 0:
            //            uploadTypeStr = "系统请求";
            //            break;
            //        case 1:
            //            uploadTypeStr = "商品主图";
            //            break;
            //        case 2:
            //            uploadTypeStr = "商品详情";
            //            break;
            //        case 3:
            //            uploadTypeStr = "SKU图片";
            //            break;
            //        case 4:
            //            uploadTypeStr = "商品评价图";
            //            break;
            //    }
            //    DbHelperOleDb.ExecuteSql(string.Format(_sqlFormatInsertIMg, url, imgUrl, ServiceContext.Session.Token.userid, uploadTypeStr, string.Empty));
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("CommonService.DowloadImage.DbHelperOleDb异常" + ex.Message);
            //}
            #endregion
            return imgUrl;
        }
        /// <summary>
        /// 通过url获取图片字节流
        /// </summary>
        /// <param name="url">图片url</param>
        /// <returns></returns>
        public byte[] GetImageStream(string url)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    return webClient.DownloadData(url);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("下载图片{0}异常001[远程服务器未响应]，请重试！".FormatWith(url), ex);
            }
        }

        /// <summary>
        /// 向文件服务器上传文件
        /// </summary>
        /// <param name="file">文件流</param>
        /// <param name="fileExtension">文件类型</param>
        /// <param name="timeOut">超时时间  默认10秒</param>
        /// <returns>返回文件服务地址，错误返回：Error</returns>
        string UploadFileForByte(byte[] file, string fileExtension = "",int timeOut = 10000)
        {
            if (fileExtension.IsNullOrEmpty())
            {
                fileExtension = file.GetExtension();
            }
            NewWebClient myWebClient = new NewWebClient();
            myWebClient.Timeout = timeOut;  //设置超时时间
            myWebClient.Credentials = CredentialCache.DefaultCredentials;
            myWebClient.Headers.Add("TxoooUploadFileType", fileExtension);
            string resporseStr = string.Empty;
            try
            {
                byte[] getArray = myWebClient.UploadData("http://file.txooo.cc/UpLoadForByte.ashx", file);
                resporseStr = Encoding.Default.GetString(getArray);
            }
            catch (Exception ex)
            {
                throw new Exception("上传到图片服务底层接口异常，{0}".FormatWith(ex.Message));
            }
           
            return resporseStr.Replace("http:", "https:");
        }
        #endregion
    }
}

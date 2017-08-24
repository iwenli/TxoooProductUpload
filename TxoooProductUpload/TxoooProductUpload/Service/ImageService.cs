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
            var stCtx = ServiceContext.Session.NetClient
              .Create<byte[]>(HttpMethod.Get, url);
            stCtx.Send();
            if (!stCtx.IsValid())
            {
                throw new Exception("下载图片异常002[远程服务器未响应]，请重试！");
            }
            return Image.FromStream(new MemoryStream(stCtx.Result));
        }

        /// <summary>
        /// 通过url获取图片字节流
        /// </summary>
        /// <param name="url">图片url</param>
        /// <returns></returns>
        public async Task<byte[]> GetImageStreamByImgUrl(string url)
        {
            var stCtx = ServiceContext.Session.NetClient
              .Create<byte[]>(HttpMethod.Get, url);

            await stCtx.SendAsync();
            if (!stCtx.IsValid())
            {
                throw new Exception("下载图片异常001[远程服务器未响应]，请重试！");
            }
            return stCtx.Result;
        }

        /// <summary>
        /// 上传图片,成功返回url,失败返回空字符串
        /// </summary>
        /// <param name="url">网络图片URL</param>
        /// <param name="uploadType">上传类型，0系统请求，1商品主图，2商品详情，3SKU图片，4商品评价图</param>
        /// <returns></returns>
        public async Task<string> UploadImg(string url, int uploadType)
        {
            //如果已经是txooo的连接  不转换
            if (_txoooImgReg.IsMatch(url))
            {
                return url;
            }
            var imageStream = await GetImageStreamByImgUrl(url);
            var imgUrl = await UploadFileForByte(imageStream);
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
        public async Task<string> UploadImg(Image image)
        {
            var imgUrl = await UploadFileForByte(image.ToBytes(), image.GetExtension());
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

            var stCtx = ServiceContext.Session.NetClient
                .Create<WebResponseResult<string>>(HttpMethod.Post, ApiList.UpdateImgFile, data: data);
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
        public List<string> GetAllHeadPic()
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
        private static async Task<string> UploadFileForByte(byte[] file, string fileExtension = "")
        {
            await Task.Delay(10);
            if (fileExtension.IsNullOrEmpty())
            {
                fileExtension = file.GetExtension();
            }
            NewWebClient myWebClient = new NewWebClient();
            myWebClient.Timeout = 1000;  //设置超时时间
            myWebClient.Credentials = CredentialCache.DefaultCredentials;
            myWebClient.Headers.Add("TxoooUploadFileType", fileExtension);
            byte[] getArray = await myWebClient.UploadDataTaskAsync("http://file.txooo.cc/UpLoadForByte.ashx", file);
            string getstr = Encoding.Default.GetString(getArray);
            return getstr.Replace("http:", "https:");
        }
    }
}

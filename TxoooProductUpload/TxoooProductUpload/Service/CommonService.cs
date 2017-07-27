using FSLib.Network.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TxoooProductUpload.Common;
using TxoooProductUpload.Service.Entities.Web;

namespace TxoooProductUpload.Service
{
    class CommonService : ServiceBase
    {
        Regex _txoooImgReg = new Regex("img.txooo.com");
        const string _sqlFormatInsertIMg = @"INSERT INTO iwenli_image(SourceUrl,ToooUrl,UserId,UploadType,Remard) values('{0}','{1}',{2},'{3}','{4}')";

        public CommonService(ServiceContext context) : base(context)
        {
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
                throw new Exception("CommonService.DowloadImage未能提交请求");
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
            var imgUrl = await UploadImg(await GetImageStreamByImgUrl(url));
            if (imgUrl.IsNullOrEmpty() || !_txoooImgReg.IsMatch(imgUrl))
            {
                throw new Exception("图片上传失败,返回连接为空!");
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
            //MemoryStream ms1 = new MemoryStream();
            //image.Save(ms1, System.Drawing.Imaging.ImageFormat.Bmp);
            //return await UploadImg(ms1.GetBuffer());
            var imgUrl = await UploadImg(image.ToBytes());
            if (imgUrl.IsNullOrEmpty() || !_txoooImgReg.IsMatch(imgUrl))
            {
                throw new Exception("图片上传失败,返回连接为空!");
            }
            return imgUrl;
        }

        /// <summary>
        /// 上传图片,成功返回url,失败返回空字符串
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

            await stCtx.SendAsync();
            if (!stCtx.IsValid())
            {
                throw new Exception("CommonService.UploadImg未能提交请求");
            }
            return stCtx.Result.msg;
        }
    }
}

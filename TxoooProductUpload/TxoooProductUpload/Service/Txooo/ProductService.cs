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
using TxoooProductUpload.Service.Entities;
using TxoooProductUpload.Service.Entities.Commnet;
using TxoooProductUpload.Service.Entities.Web;

namespace TxoooProductUpload.Service
{
    /// <summary>
    /// 商品相关数据服务
    /// </summary>
    class ProductService : ServiceBase
    {
        const string _sqlFormatInsertProduct = @"INSERT INTO iwenli_product(ProductName,Source,SourceUrl,ShopName,DetailHtml,ProductPrice,SKU,Location,SalesCount"
                                        + @",RateTotals,product_id,product_imgs,product_details,product_brand,UserId) VALUES("
                                        + @"'{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}',{8},{9},{10},'{11}','{12}','{13}',{14})";

        public ProductService(ServiceContext context) : base(context)
        {
        }

        #region 评价使用
        /// <summary>
        /// 获取商品信息，添加评价使用
        /// </summary>
        /// <param name="product_id"></param>
        /// <returns></returns>
        public async Task<ProductInfo> GetProductInfo(long product_id)
        {
            var stCtx = NetClient.Create<WebResponseResult<ProductInfo>>(HttpMethod.Get, ApiList.GetProductInfo,
               data: new { product_id = product_id });

            await stCtx.SendAsync();
            if (!stCtx.IsValid())
            {
                throw new Exception("获取商品信息请求失败！");
            }
            if (stCtx.Result.success && stCtx.Result.Data.Length == 1)
            {
                return stCtx.Result.Data[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 批量添加评价
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public async Task<bool> AddProductCommnet(string json)
        {
            var stCtx = NetClient.Create<WebResponseResult>(HttpMethod.Post, ApiList.AddProductCommnet,
               data: new { data = json });
            //
            await stCtx.SendAsync();

            if (!stCtx.IsValid())
            {
                throw new Exception("ProductService.AddProductCommnet未能提交请求");
            }

            if (!stCtx.Result.success)
            {
                throw new Exception("提交失败，原因:" + stCtx.Result.msg);

            }
            return stCtx.Result.success;
        }
        #endregion

        #region 上传商品
        /// <summary>
        /// 上传商品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<WebResponseResult<string>> UploadProduct(ProductResult product)
        {
            var stCtx = ServiceContext.Session.NetClient
               .Create<WebResponseResult<string>>(HttpMethod.Post, ApiList.AddProduct4, data: product.ToString());
            //
            await stCtx.SendAsync();
            if (!stCtx.IsValid())
            {
                throw new Exception("商品上传提交失败！");
            }

            //入库记录
            if (stCtx.Result.success)
            {
                product.product_id = Convert.ToInt32(stCtx.Result.msg);
            }
            try
            {
                DbHelperOleDb.ExecuteSql(string.Format(_sqlFormatInsertProduct, product.ProductName.Replace("'", "\""), product.Source, product.SourceUrl, product.ShopName.Replace("'", "\""),
                 product.DetailHtml.Replace("'", "\""), product.ProductPrice, product.product_property, product.Location, product.SalesCount == null ? "0" : product.SalesCount, product.RateTotals == null ? "0" : product.RateTotals, product.product_id,
                 product.product_imgs, product.product_details.Replace("'", "\""), product.product_brand.Replace("'", "\""), ServiceContext.Session.Token.userid));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("商品信息入库失败，但是已经上传成功，商品ID是：{0}{1}[异常]{2}",
                    stCtx.Result.msg, Environment.NewLine, ex.Message));
            }

            return stCtx.Result;
        }
        #endregion

        
    }
}

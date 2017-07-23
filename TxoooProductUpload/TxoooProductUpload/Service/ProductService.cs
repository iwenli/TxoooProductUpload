using FSLib.Network.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Common;
using TxoooProductUpload.Service.Entities;
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
                new Exception("ProductService.UploadProduct未能提交请求");
            }

            //入库记录
            if (stCtx.Result.success)
            {
                product.product_id = Convert.ToInt32(stCtx.Result.msg);
            }
            try
            {
                DbHelperOleDb.ExecuteSql(string.Format(_sqlFormatInsertProduct, product.ProductName, product.Source, product.SourceUrl, product.ShopName,
                 product.DetailHtml.Replace("'", "\'"), product.ProductPrice, product.product_property, product.Location, product.SalesCount == null ? "0" : product.SalesCount, product.RateTotals == null ? "0" : product.RateTotals, product.product_id,
                 product.product_imgs, product.product_details, product.product_brand, ServiceContext.Session.Token.userid));
            }
            catch (Exception ex)
            {
                new Exception("ProductService.UploadProduct.DbHelperOleDb异常" + ex.Message);
            }
           
            return stCtx.Result;
        }
    }
}

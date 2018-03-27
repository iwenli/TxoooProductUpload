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
using TxoooProductUpload.Entities.Product;
using TxoooProductUpload.Entities.Request;
using TxoooProductUpload.Entities.Resporse.Txooo;
using TxoooProductUpload.Service.Entities;
using TxoooProductUpload.Service.Entities.Commnet;
using TxoooProductUpload.Service.Entities.Web;

namespace TxoooProductUpload.Service
{
    /// <summary>
    /// 商品相关数据服务
    /// </summary>
    public class ProductService : ServiceBase
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
                throw new Exception("{0}-商品服务器无法连接".FormatWith(AppConfig.PlatFormName));
            }
            if (!stCtx.Result.success)
            {
                throw new Exception(stCtx.Result.msg);
            }

            product.product_id = Convert.ToInt32(stCtx.Result.msg);
            //try
            //{
            //    DbHelperOleDb.ExecuteSql(string.Format(_sqlFormatInsertProduct, product.ProductName.Replace("'", "\""), product.Source, product.SourceUrl, product.ShopName.Replace("'", "\""),
            //     product.DetailHtml.Replace("'", "\""), product.ProductPrice, product.product_property, product.Location, product.SalesCount == null ? "0" : product.SalesCount, product.RateTotals == null ? "0" : product.RateTotals, product.product_id,
            //     product.product_imgs, product.product_details.Replace("'", "\""), product.product_brand.Replace("'", "\""), ServiceContext.Session.Token.userid));
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(string.Format("商品信息入库失败，但是已经上传成功，商品ID是：{0}{1}[异常]{2}",
            //        stCtx.Result.msg, Environment.NewLine, ex.Message));
            //}

            return stCtx.Result;
        }

        /// <summary>
        /// 上传商品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<WebResponseResult<string>> UploadProduct(ProductRequest product)
        {
            var stCtx = NetClient.Create<WebResponseResult<string>>(HttpMethod.Post, ApiList.AddProduct4, data: product.ToString());
            await stCtx.SendAsync();
            if (!stCtx.IsValid())
            {
                throw new Exception("{0}-商品服务器无法连接".FormatWith(AppConfig.PlatFormName));
            }
            if (!stCtx.Result.success)
            {
                throw new Exception(stCtx.Result.msg);
            }
            product.Id = Convert.ToInt32(stCtx.Result.msg);
            return stCtx.Result;
        }
        #endregion

        #region 商品来源相关
        /// <summary>
        /// 存储商品来源
        /// </summary>
        /// <param name="json">商品来源json集合</param>
        /// <returns></returns>
        public async Task<bool> InsertProductsSourceAsync(string json)
        {
            var stCtx = NetClient.Create<WebResponseResult<string>>(HttpMethod.Post, ApiList.InsertProductsSource,
               data: new { data = json });
            await stCtx.SendAsync();
            if (!stCtx.IsValid())
            {
                throw new Exception("创业赚钱-商品服务器无法连接");
            }
            if (!stCtx.Result.success)
            {
                throw new Exception("提交失败，原因:" + stCtx.Result.msg);
            }
            return stCtx.Result.success;
        }
        /// <summary>
        /// 增量获取商品来源
        /// </summary>
        /// <param name="maxId"></param>
        /// <returns></returns>
        public List<ProductSourceTxoooInfo> GetProductsSourceList(long maxId)
        {
            var stCtx = NetClient.Create<WebResponseResult<ProductSourceTxoooInfo>>(HttpMethod.Post, ApiList.GetProductsSourceList,
               data: new { id = maxId });

            stCtx.Send();
            if (!stCtx.IsValid())
            {
                throw new Exception("创业赚钱-商品服务器无法连接");
            }
            if (!stCtx.Result.success)
            {
                throw new Exception(stCtx.Result.msg);
            }
            if (stCtx.Result.Data.Length > 0)
            {
                return stCtx.Result.Data.ToList();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 增量获取商品来源
        /// </summary>
        /// <param name="maxId"></param>
        /// <returns></returns>
        public async Task<List<ProductSourceTxoooInfo>> GetProductsSourceListAsync(long maxId)
        {
            var stCtx = NetClient.Create<WebResponseResult<ProductSourceTxoooInfo>>(HttpMethod.Post, ApiList.GetProductsSourceList,
               data: new { id = maxId });

            await stCtx.SendAsync();
            if (!stCtx.IsValid())
            {
                throw new Exception("创业赚钱-商品服务器无法连接");
            }
            if (!stCtx.Result.success)
            {
                throw new Exception(stCtx.Result.msg);
            }
            if (stCtx.Result.Data.Length > 0)
            {
                return stCtx.Result.Data.ToList();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 通过txooo商品id获取抓取记录
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public ProductSourceTxoooInfo GetProductsSourceByTxoooId(long pid)
        {
            var stCtx = NetClient.Create<WebResponseResult<ProductSourceTxoooInfo>>(HttpMethod.Post, ApiList.GetProductsSource,
               data: new { pid = pid });

            stCtx.Send();
            if (!stCtx.IsValid())
            {
                throw new Exception("创业赚钱-商品服务器无法连接");
            }
            if (!stCtx.Result.success)
            {
                throw new Exception(stCtx.Result.msg);
            }
            if (stCtx.Result.Data.Length == 1)
            {
                return stCtx.Result.Data[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 通过来源id和来源类型获取抓取记录
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        public ProductSourceTxoooInfo GetProductsSourceBySourceId(long sourceId, int sourceType)
        {
            var stCtx = NetClient.Create<WebResponseResult<ProductSourceTxoooInfo>>(HttpMethod.Post, ApiList.GetProductsSource,
               data: new { sourceId = sourceId, sourcrType = sourceType });

            stCtx.Send();
            if (!stCtx.IsValid())
            {
                throw new Exception("创业赚钱-商品服务器无法连接");
            }
            if (!stCtx.Result.success)
            {
                throw new Exception(stCtx.Result.msg);
            }
            if (stCtx.Result.Data.Length == 1)
            {
                return stCtx.Result.Data[0];
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 商品编辑相关
        /// <summary>
        /// 获取商品各个状态数量
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductStateInfo>> GetProductStateCountAsync()
        {
            var stCtx = NetClient.Create<WebResponseResult<ProductStateInfo>>(HttpMethod.Get, ApiList.GetProductStateCount);
            await stCtx.SendAsync();
            if (!stCtx.IsValid())
            {
                throw new Exception("{0}-商品服务器无法连接".FormatWith(AppConfig.PlatFormName) + stCtx.Exception.Message);
            }
            if (!stCtx.Result.success)
            {
                throw new Exception("提交失败，原因:" + stCtx.Result.msg);
            }
            return stCtx.Result.Data.ToList();
        }

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="pIndex">页码</param>
        /// <param name="pSize">页尺寸</param>
        /// <param name="state">状态,默认全部</param>
        /// <returns></returns>
        public async Task<List<ManageProductInfo>> GetProductListForCrawl(int pIndex = 0, int pSize = 100, int state = -2)
        {
            var url = ApiList.GetProductListForCrawl + "&pageIndex={0}&pageSize={1}".FormatWith(pIndex, pSize);
            if (state != -2)
            {
                url = url + "&r_state=" + state;
            }
            var stCtx = NetClient.Create<WebResponseResult<MangeProductResult>>(HttpMethod.Get, url);

            await stCtx.SendAsync();
            if (!stCtx.IsValid())
            {
                throw new Exception("{0}-商品服务器无法连接".FormatWith(AppConfig.PlatFormName) + stCtx.Exception.Message);
            }
            if (!stCtx.Result.success)
            {
                throw new Exception(stCtx.Result.msg);
            }
            return stCtx.Result.Data[0].list.ToList();
        }


        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="productId">商品id</param>
        /// <returns></returns>
        public bool DelProduct(long productId)
        {
            var url = ApiList.DelProduct + "&product_id=" + productId;
            var stCtx = NetClient.Create<WebResponseResult>(HttpMethod.Get, url);

            stCtx.Send();
            if (!stCtx.IsValid())
            {
                throw new Exception("{0}-商品服务器无法连接".FormatWith(AppConfig.PlatFormName) + stCtx.Exception.Message);
            }
            if (!stCtx.Result.success)
            {
                throw new Exception(stCtx.Result.msg);
            }
            return stCtx.Result.success;
        }

        /// <summary>
        /// 商品上下架
        /// </summary>
        /// <param name="productIds">商品id集合</param>
        /// <param name="isShow">true表示上架</param>
        /// <returns></returns>
        public bool UpProducts(List<long> productIds, bool isShow)
        {
            var stCtx = NetClient.Create<WebResponseResult>(HttpMethod.Post, ApiList.UpProducts,
                data: new { product_ids = string.Join(",", productIds), is_show = Convert.ToInt32(isShow) });

            stCtx.Send();
            if (!stCtx.IsValid())
            {
                throw new Exception("{0}-商品服务器无法连接".FormatWith(AppConfig.PlatFormName) + stCtx.Exception.Message);
            }
            if (!stCtx.Result.success)
            {
                throw new Exception(stCtx.Result.msg);
            }
            return stCtx.Result.success;
        }
        #endregion
    }
}

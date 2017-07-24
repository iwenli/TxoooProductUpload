using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.Entities
{
    using Common;
    using Service.Entities.Web;

    /// <summary>
    /// 商品信息
    /// </summary>
    class ProductResult
    {
        /// <summary>
        /// 获得当前的服务上下文
        /// </summary>
        public ServiceContext ServiceContext { get; set; }

        public ProductResult(ServiceContext content) : this()
        {
            ServiceContext = content;
        }

        public ProductResult()
        {
            DetailImg = new List<string>();
            ThumImg = new List<string>();
            product_id = 0;
            submit_product = 1;
            product_details_type = 0;
        }
        #region api相关

        /// <summary>
        /// 商品id
        /// </summary>
        public int product_id { set; get; }

        /// <summary>
        /// 商品新旧，新品1，二手2
        /// </summary>
        public int new_old { set; get; }

        /// <summary>
        /// 商品主图,逗号分隔
        /// </summary>
        public string product_imgs { set; get; }


        /// <summary>
        ///  商品名称
        /// </summary>
        public string product_name { set; get; }

        /// <summary>
        /// 商品品牌
        /// </summary>
        public string product_brand { set; get; }

        /// <summary>
        /// 发货地代码（直辖市id：2,3,10,23）
        /// </summary>
        public long region_code { set; get; }

        /// <summary>
        /// 发货地名称
        /// </summary>
        public string region_name { set; get; }

        /// <summary>
        /// 是否虚拟商品1是，0否
        /// </summary>
        public int is_virtual { set; get; }

        /// <summary>
        /// 是否包邮（True包邮，Flase不包邮）
        /// </summary>
        public bool product_ispostage { set; get; }

        /// <summary>
        /// 邮费详情 {"postage":"10","append":"5","limit":"7"}（postage运费，append每增加一件加，limit宝贝数量达到）
        /// </summary>
        public string product_postage { set; get; }


        /// <summary>
        /// 支持七天无理由1支持，0不支持
        /// </summary>
        public int refund { set; get; }

        /// <summary>
        /// 商品类别id
        /// </summary>
        public long product_type { set; get; }

        /// <summary>
        /// 商品详情
        /// </summary>
        public string product_details { set; get; }


        /// <summary>
        /// 提交或保存商品（1提交，0保存）
        /// </summary>
        public int submit_product { set; get; }
        /// <summary>
        /// 详情类型（0手机，1pc）
        /// </summary>
        public int product_details_type { set; get; }

        /// <summary>
        /// 商品分类类型 （1产品，2服务）
        /// </summary>
        public int product_type_service { set; get; }

        /// <summary>
        /// 商品sku json
        /// </summary>
        public string product_property { set; get; }
        /// <summary>
        /// 推广语集合json
        /// </summary>
        public string share { set; get; }
        #endregion

        #region 设置的参数
        /// <summary>
        /// 邮费金额
        /// </summary>
        public int Postage { set; get; }
        /// <summary>
        /// 每增加一件增加的邮费
        /// </summary>
        public int Append { set; get; }
        /// <summary>
        /// 满足包邮的件数
        /// </summary>
        public int Limit { set; get; }
        #endregion

        #region 来源相关
        /// <summary>
        ///  商品名称
        /// </summary>
        public string ProductName { set; get; }
        /// <summary>
        /// 来源
        /// </summary>
        public string Source { set; get; }
        /// <summary>
        /// 来源URL
        /// </summary>
        public string SourceUrl { set; get; }

        /// <summary>
        /// 来源店铺名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 来源商品主图（原URL）
        /// </summary>
        public List<string> ThumImg { get; set; }

        /// <summary>
        ///  来源商品详细介绍图片（原URL）
        /// </summary>
        public List<string> DetailImg { get; set; }

        /// <summary>
        /// 商品来源售卖价格
        /// </summary>
        public string ProductPrice { get; set; }
        /// <summary>
        /// 商品来源SKU
        /// </summary>
        public List<SkuTmallInfo> SKUTmall { get; set; }
        /// <summary>
        /// 商品来源SKU
        /// </summary>
        public List<Sku1688Info> SKU1688 { get; set; }
        /// <summary>
        /// 商品来源SKU
        /// </summary>
        public SkuJdInfo SKUJD { get; set; }
        /// <summary>
        /// 发货地
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 销量
        /// </summary>
        public string SalesCount { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public string RateTotals { get; set; }
        /// <summary>
        /// 商品来源详情源码
        /// </summary>
        public string DetailHtml { get; set; }
        

        #endregion


        /// <summary>
        /// 生成商品上传信息
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Parameters parameters = new Parameters();
            parameters.Add("product_id", product_id);
            parameters.Add("new_old", new_old);
            parameters.Add("product_details_type", product_details_type);
            parameters.Add("product_name", ProductName);
            parameters.Add("product_type", product_type);
            parameters.Add("product_type_service", product_type_service);
            parameters.Add("region_code", region_code);
            parameters.Add("region_name", region_name);
            parameters.Add("submit_product", submit_product);
            parameters.Add("is_virtual", is_virtual);
            parameters.Add("product_ispostage", product_ispostage.ToString().ToLower());
            parameters.Add("refund", refund);
            parameters.Add("product_imgs", product_imgs);
            parameters.Add("product_details", product_details);
            parameters.Add("product_brand", product_brand);//品牌

            if (!product_ispostage)   //如果不包邮设置邮费
            {
                parameters.Add("product_postage", "{" + string.Format("\"postage\":\"{0}\",\"append\":\"{1}\",\"limit\":\"{2}\"", Postage, Append, Limit) + "}");
            }
            #region 推广语
            if (!share.IsNullOrEmpty())
            {
                var shareList = share.Split('|');
                for (int i = 0; i < shareList.Length; i++)
                {
                    parameters.Add("share_id_" + i, 0);
                    parameters.Add("share_content_" + i, product_details);
                }
            }
            #endregion
            return parameters.BuildQueryString(false) + product_property;
        }

        /// <summary>
        /// 识别发货地
        /// </summary>
        /// <returns></returns>
        public bool DiscernLcation()
        {
            var result = true;
            if (Location.IsNullOrEmpty()) {
                return false;
            }
            var area = ServiceContext.CacheContext.Cache.AreaList.Where(
                m => m.region_name.Contains(Location.Substring(Location.Length - 2))).FirstOrDefault();
            if (area != null)
            {
                region_name = area.region_name;
                region_code = area.region_code;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}

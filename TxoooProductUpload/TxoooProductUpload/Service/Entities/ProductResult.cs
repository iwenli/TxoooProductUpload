using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.Entities
{
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


        ///// <summary>
        ///// 规格id（新增规格默认值0）
        ///// </summary>
        //public int map_id_0 { set; get; }

        ///// <summary>
        ///// 规格名称（数字从0开始顺序排列，如：json_info_0，json_info_1）
        ///// </summary>
        //public int json_info_0 { set; get; }

        ///// <summary>
        ///// 市场价
        ///// </summary>
        //public int market_price_0 { set; get; }

        ///// <summary>
        ///// 会员价
        ///// </summary>
        //public int price_0 { set; get; }

        ///// <summary>
        ///// 库存
        ///// </summary>
        //public int remain_inventory_0 { set; get; }

        ///// <summary>
        /////  图片
        ///// </summary>
        //public int property_map_img_0 { set; get; }

        ///// <summary>
        ///// 是否默认
        ///// </summary>
        //public int is_default_0 { set; get; }

        ///// <summary>
        ///// 结算比例
        ///// </summary>
        //public int radio_num_0 { set; get; }

        ///// <summary>
        /////  推广语id
        ///// </summary>
        //public int share_id_0 { set; get; }

        ///// <summary>
        ///// 推广语（数字从0开始顺序排列，如：share_content_0，share_content_1）
        ///// </summary>
        //public string share_content_0 { set; get; }
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
        public List<Sku1688Info> SKU { get; set; }
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

        #endregion

        /// <summary>
        /// 生成商品上传信息
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder paramSb = new StringBuilder("{");
            paramSb.AppendFormat("\"product_id\" : {0},", product_id);
            paramSb.AppendFormat("\"new_old\" : {0},", new_old);
            paramSb.AppendFormat("\"product_details_type\" : {0},", product_details_type);
            paramSb.AppendFormat("\"product_name\" : \"{0}\",", ProductName);
            paramSb.AppendFormat("\"product_type\" : {0},", product_type);
            paramSb.AppendFormat("\"product_type_service\" : {0},", product_type_service);
            paramSb.AppendFormat("\"region_code\" : {0},", region_code);
            paramSb.AppendFormat("\"region_name\" : \"{0}\",", region_name);
            paramSb.AppendFormat("\"submit_product\" : {0},", submit_product);
            paramSb.AppendFormat("\"is_virtual\" : {0},", is_virtual);
            paramSb.AppendFormat("\"product_ispostage\" : {0},", product_ispostage);
            paramSb.AppendFormat("\"refund\" : {0},", refund);
            paramSb.AppendFormat("\"product_imgs\" : \"{0}\", ", product_imgs);
            paramSb.AppendFormat("\"product_details\" : \"{0}\",", product_details);
            if (!product_brand.IsNullOrEmpty())
            { //品牌
                paramSb.AppendFormat("\"product_brand\" : \"{0}\",", product_brand);
            }
            if (!product_ispostage)   //如果不包邮设置邮费
            {
                paramSb.Append("\"product_postage\" : {");
                paramSb.AppendFormat("\"postage\":{0},\"append\":{1},\"limit\":{2}", Postage, Append, Limit);
                paramSb.Append("}");
            }
            paramSb.Append("}");

            return paramSb.ToString();
            //    "{
            //    "is_default_0" = True; 
            //    "json_info_0" = "\U5e38\U89c4"; 
            //    "price_0" = 100; 
            //    "product_details" = "<p></p><img src=\"https://img.txooo.com/2017/06/19/a4f258eb654da2f08df81eadf902578c.jpg\"/><p></p><img src=\"https://img.txooo.com/2017/04/10/ab5cfed05a4b4002e5a792a91fcb479f.jpg\"/><p></p><img src=\"https://img.txooo.com/2017/06/20/a466f3629713e6db28de65488898f65f.jpg\"/><p></p><img src=\"https://img.txooo.com/2017/06/20/702a3caf04e8ce5e52b37bc1152d8ed3.jpg\"/>";
            //    "product_imgs" = "https://img.txooo.com/2017/06/19/c48e78c819d71acf6d8fafeb75008325.jpg,https://img.txooo.com/2017/06/19/e7cfb47ad20b5ea1aa3a3f85f41d08cd.jpg,https://img.txooo.com/2017/06/19/d00ec1764153c8cb514d00b91e66cb58.jpg,https://img.txooo.com/2017/06/19/4810b68a1c880c753d12e6964bd3bdaf.jpg";
            //    "property_map_img_0" = "https://img.txooo.com/2017/06/19/aca8612f1889e34ddc0c757bdf8f9bae.jpg";
            //    "radio_num_0" = 10;
            //    "remain_inventory_0" = 80;
            //    "share_content_0" = "\U63a8\U5e7f";
            //    "share_id_0" = 22769;
            //}"

        }
    }


}

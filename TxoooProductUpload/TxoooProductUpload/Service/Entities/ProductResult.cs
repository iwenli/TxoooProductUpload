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
        public int region_code { set; get; }

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
        public int product_type { set; get; }

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
        /// 规格id（新增规格默认值0）
        /// </summary>
        public int map_id_0 { set; get; }

        /// <summary>
        /// 规格名称（数字从0开始顺序排列，如：json_info_0，json_info_1）
        /// </summary>
        public int json_info_0 { set; get; }

        /// <summary>
        /// 市场价
        /// </summary>
        public int market_price_0 { set; get; }

        /// <summary>
        /// 会员价
        /// </summary>
        public int price_0 { set; get; }

        /// <summary>
        /// 库存
        /// </summary>
        public int remain_inventory_0 { set; get; }

        /// <summary>
        ///  图片
        /// </summary>
        public int property_map_img_0 { set; get; }

        /// <summary>
        /// 是否默认
        /// </summary>
        public int is_default_0 { set; get; }

        /// <summary>
        /// 结算比例
        /// </summary>
        public int radio_num_0 { set; get; }

        /// <summary>
        ///  推广语id
        /// </summary>
        public int share_id_0 { set; get; }

        /// <summary>
        /// 推广语（数字从0开始顺序排列，如：share_content_0，share_content_1）
        /// </summary>
        public string share_content_0 { set; get; }
        #endregion

        #region 来源相关
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
        public string ThumImg { get; set; }

        /// <summary>
        ///  来源商品详细介绍图片（原URL）
        /// </summary>
        public string DetailImg { get; set; }

        /// <summary>
        /// 商品来源价格
        /// </summary>
        public string ProductPrice { get; set; }
        #endregion
    }


}

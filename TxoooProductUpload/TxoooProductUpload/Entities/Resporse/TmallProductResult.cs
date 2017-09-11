using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Entities.Resporse
{
    /// <summary>
    ///  天猫商品JSON-待测试类目
    /// </summary>
    public class TmallProductResult
    {
        /// <summary>
        /// 商户信息
        /// </summary>
        public Seller seller { set; get; }
        /// <summary>
        /// 商品信息
        /// </summary>
        public Item item { set; get; }
        /// <summary>
        /// 发货信息
        /// </summary>
        public Delivery delivery { set; get; }
        /// <summary>
        /// SKU信息 基本信息
        /// </summary>
        public SkuBase skuBase { set; get; }
        /// <summary>
        /// SKU信息 价格和数量
        /// </summary>
        public SkuCore skuCore { set; get; }

        /// <summary>
        /// 详情
        /// </summary>
        public DetailDesc detailDesc { set; get; }

    }
    /// <summary>
    /// 商户信息
    /// </summary>
    public class Seller
    {
        public long userId { set; get; }
        public long shopId { set; get; }
        public string shopName { set; get; }
        public string allItemCount { set; get; }

        /// <summary>
        /// 天猫PC详情Url
        /// </summary>
        public string tmallDescUrl { set; get; }

    }

    /// <summary>
    /// 商品相关
    /// </summary>
    public class Item
    {
        /*
         * 商品名称：
         * 商品主图：
         * 商品详情：
         * 商品SKU:(颜色  尺码  价格)
         * 
         * 品牌：
         * 推广语：
         * 
         * 发货地：
         * 邮费：
         * 
         * 店铺信息：
         * 
         * 
         * 
         */
        /// <summary>
        /// 商品id
        /// </summary>
        public long itemId { set; get; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { set; get; }
        /// <summary>
        /// 子标题 - 对应txooo的推广语
        /// </summary>
        public string subtitle { set; get; }
        /// <summary>
        /// 主图集合
        /// </summary>
        public string[] images { set; get; }
        /// <summary>
        /// 收藏数
        /// </summary>
        public int favcount { set; get; }

        /// <summary>
        /// 评价数量
        /// </summary>
        public int commentCount { set; get; }

        /// <summary>
        /// 销量
        /// </summary>
        public int sellCount { set; get; }
    }

    /// <summary>
    /// 发货相关
    /// </summary>
    public class Delivery
    {
        public long areaId { set; get; }
        /// <summary>
        /// 收货地
        /// </summary>
        public string completedTo { set; get; }
        /// <summary>
        /// 发货地
        /// </summary>
        public string from { set; get; }
        /// <summary>
        /// 邮费  快递：0.00
        /// </summary>
        public string postage { set; get; }
        /// <summary>
        /// 收货地 最底层
        /// </summary>
        public string to { set; get; }
    }

    #region SKUBase
    public class SkuBase
    {
        public bool enable { set; get; }
        public List<Sku> skus { set; get; }
        public List<Prop> props { set; get; }
    }
    public class Prop
    {
        public long pid { set; get; }
        public string name { set; get; }
        public PropValue[] values { set; get; }
    }
    public class PropValue
    {
        public long vid { set; get; }
        public string name { set; get; }
        public string image { set; get; }
    }

    public class Sku
    {
        public long skuId { set; get; }
        public string propPath { set; get; }
    }
    #endregion

    #region SkuCore
    public class SkuCore
    {
        public Dictionary<long, Sku2Info> sku2info { set; get; }
    }

    public class Sku2Info
    {
        /// <summary>
        /// app价格以及语句
        /// </summary>
        public string app { set; get; }
        /// <summary>
        /// 数量
        /// </summary>
        public int quantity { set; get; }
        /// <summary>
        /// 价格
        /// </summary>
        public Price price { set; get; }
    }

    public class Price
    {
        public int priceMoney { set; get; }
        public string priceText { set; get; }
    }
    #endregion

    public class DetailDesc
    {
        public List<NewWapDescJson> newWapDescJson { set; get; }
        public string newWapDescDynUrl { set; get; }
    }

    public class NewWapDescJson
    {
        public bool enable { set; get; }
        public string moduleName { set; get; }
        public List<DescImage> data { set; get; }
    }
    public class DescImage
    {
        public string img { set; get; }
        public int height { set; get; }
        public int width { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.Crawl.ProductResult
{
    /// <summary>
    /// 天猫商品解析类
    /// </summary>
    public class TmallProductResult
    {
        public Seller seller { set; get; }
        public Item item { set; get; }
        public Delivery delivery { set; get; }
        public SkuBase skuBase { set; get; }

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
        /// 子标题 推广语
        /// </summary>
        public string subtitle { set; get; }
        /// <summary>
        /// 主图集合
        /// </summary>
        public List<string> images { set; get; }
        /// <summary>
        /// 收藏量
        /// </summary>
        public long favcount { set; get; }
    }

    /// <summary>
    /// 发货相关
    /// </summary>
    public class Delivery
    {
        public long areaId { set; get; }
        public string completedTo { set; get; }
        public string from { set; get; }
        public string postage { set; get; }
        public string to { set; get; }
    }

    #region SKUBase
    public class SkuBase
    {
        public bool enable { set; get; }
        public Sku[] skus { set; get; }
        public Prop[] props { set; get; }
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

}

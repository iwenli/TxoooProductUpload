using System.Collections.Generic;

namespace TxoooProductUpload.Entities.Resporse
{
    /// <summary>
    /// 天猫PC页面页面JSON解析类
    /// </summary>
    public class TmallPcProductResult
    {
        /// <summary>
        /// 描述api
        /// </summary>
        public TmllPcProductResultAPI api { set; get; }
        /// <summary>
        /// SKU图片
        /// </summary>
        public Dictionary<string, string[]> propertyPics { set; get; }
        /// <summary>
        /// SKU详细
        /// </summary>
        public TmllPcProductResultValItemInfo valItemInfo { set; get; }
        /// <summary>
        /// 商品信息
        /// </summary>
        public TmllPcProductResultItemDo itemDO { set; get; }
    }

    /// <summary>
    /// 商品信息
    /// </summary>
    public class TmllPcProductResultItemDo {
        public string brand { set; get; }
        public bool hasSku { set; get; }
        public long itemId { set; get; }
        public long userId { set; get; }
        public string sellerNickName { set; get; }
        public string title { set; get; }
    }

    /// <summary>
    /// 描述api
    /// </summary>
    public class TmllPcProductResultAPI
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string descUrl { set; get; }
        /// <summary>
        /// https描述
        /// </summary>
        public string httpsDescUrl { set; get; }
    }

    /// <summary>
    /// SKU解析
    /// </summary>
    public class TmllPcProductResultValItemInfo
    {
        public List<TmllPcProductResultSkuListItem> skuList { set; get; }

        public Dictionary<string, TmllPcProductResultSkuMapItem> skuMap { set; get; }
    }


    /// <summary>
    /// SKU List 项
    /// </summary>
    public class TmllPcProductResultSkuListItem
    {
        /// <summary>
        /// SKu名称
        /// </summary>
        public string names { set; get; }
        /// <summary>
        /// SKU path Values
        /// </summary>
        public string pvs { set; get; }
        /// <summary>
        /// SKU唯一标识
        /// </summary>
        public long skuId { set; get; }
    }
    /// <summary>
    /// SKU Map 项
    /// </summary>
    public class TmllPcProductResultSkuMapItem
    {
        /// <summary>
        /// 价格
        /// </summary>
        public double price { set; get; }
        /// <summary>
        /// SKU 唯一标识
        /// </summary>
        public long skuId { set; get; }
        /// <summary>
        /// 库存
        /// </summary>
        public int stock { set; get; }

    }
}

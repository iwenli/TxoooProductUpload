using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.Entities
{
    /// <summary>
    /// 天猫商品JSON-待测试类目
    /// </summary>
    class TmallProductResult
    {
        //_DATA_Mdskip =  ([\s\S]+}}}})
        //_DATA_Detail = ([\s\S]+]});

        public Seller seller { set; get; }
        public Item item { set; get; }
        public Delivery delivery { set; get; }

        public SkuBase skuBase { set; get; }
        
    }
    /// <summary>
    /// 商户信息
    /// </summary>
    class Seller
    {
        public long userId { set; get; }
        public long shopId { set; get; }
        public string shopName { set; get; }
        public string allItemCount { set; get; }
    }

    /// <summary>
    /// 商品相关
    /// </summary>
    class Item
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
        public long itemId { set; get; }
        public string title { set; get; }
        public string subtitle { set; get; }

        public string[] images { set; get; }

        public long favcount { set; get; }
    }

    /// <summary>
    /// 发货相关
    /// </summary>
    class Delivery
    {
        public long areaId { set; get; }
        public string completedTo { set; get; }
        public string from { set; get; }
        public string postage { set; get; }
        public string to { set; get; }
    }

    #region SKUBase
    class SkuBase
    {
        public bool enable { set; get; }
        public Sku[] skus { set; get; }
        public Prop[] props { set; get; }
    }
    class Prop
    {
        public long pid { set; get; }
        public string name { set; get; }
        public PropValue[] values { set; get; }
    }
    class PropValue
    {
        public long vid { set; get; }
        public string name { set; get; }
        public string image { set; get; }
    }

    class Sku
    {
        public long skuId { set; get; }
        public string propPath { set; get; }
    } 
    #endregion

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Entities.Resporse
{
    /// <summary>
    /// 淘宝商品详情解析类
    /// </summary>
    public class TaoBaoProductDetailResult
    {
        public ResporseResultCode code { set; get; }
        public TaoBaoProductDetailResultData data { set; get; }
    }

    /// <summary>
    /// 淘宝商品详情原价sku解析类
    /// </summary>
    public class TaoBaoProductSoureSkuResult {
        public Dictionary<string, PromoDataItem> skuMap { set; get; }
    }

    public class TaoBaoProductDetailResultData
    {
        public SoldQuantity soldQuantity { set; get; }
        public DeliveryFee deliveryFee { set; get; }

        public Promotion promotion { set; get; }
    }

    public class SoldQuantity
    {
        /// <summary>
        /// 确认收货数量
        /// </summary>
        public int confirmGoodsCount { set; get; }
        /// <summary>
        /// 总销量
        /// </summary>
        public int soldTotalCount { set; get; }
    }
    public class DeliveryFee
    {
        public bool success { set; get; }
        public DeliveryFeeData data { set; get; }
    }

    public class DeliveryFeeData
    {
        /// <summary>
        /// 收货地
        /// </summary>
        public string areaName { set; get; }
        /// <summary>
        /// 发货地
        /// </summary>
        public string sendCity { set; get; }

        public ServiceInfo serviceInfo { set; get; }
    }

    public class ServiceInfo
    {
        public List<ServiceInfoData> list { set; get; }
    }

    public class ServiceInfoData
    {
        public string id { set; get; }
        public string info { set; get; }
        public string markInfo { set; get; }

        public bool isDefault { set; get; }
    }

    public class Promotion
    {
        public Dictionary<string, List<PromoDataItem>> promoData { set; get; }
    }
    public class PromoDataItem
    {
        public string price { set; get; }
        public string type { set; get; }
    }
}

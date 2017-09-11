using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.Crawl.ProductResult
{
    /// <summary>
    /// 淘宝商品解析类
    /// </summary>
    public class TaoBaoProductResult
    {
        public string shopName { set; get; }
        public string sellerNick { set; get; }

        public string sellerId { set; get; }

        public string descUrl { set; get; }

        public TaoBaoItemData idata { set; get; }

        public DeliveryFee deliveryFee { set; get; }

        public Promotion pomotion { set; get; }

    }

    public class TaoBaoItemData
    {
        public TaobaoItem item { set; get; }
    }
    public class TaobaoItem
    {
        public string title { set; get; }
        /// <summary>
        /// 主图
        /// </summary>
        public List<string> auctionImages { set; get; }
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
        public double price { set; get; }
        public string type { set; get; }
    }
}

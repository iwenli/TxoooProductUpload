using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Entities.Resporse
{
    /// <summary>
    /// 淘宝商品解析类
    /// </summary>
    public class TaoBaoProductResult
    {
        public string shopName { set; get; }
        public string sellerNick { set; get; }

        public long sellerId { set; get; }

        public string descUrl { set; get; }

        public TaoBaoItemData idata { set; get; }

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

}

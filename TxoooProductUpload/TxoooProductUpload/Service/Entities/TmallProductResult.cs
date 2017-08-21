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
    }

    class Seller {
        public string shopName { set; get; }
        public string allItemCount { set; get; }
    }
    class Item {
        public long itemId { set; get; }
        public string title { set; get; }
        public string subtitle { set; get; }

        public string[] images {set;get;}

        public long favcount { set; get; }
    }

    class delivery {
        public long areaId { set; get; }
        public string completedTo { set; get; }
        public string from { set; get; }
        public string postage { set; get; }
        public string to { set; get; }
    }
}

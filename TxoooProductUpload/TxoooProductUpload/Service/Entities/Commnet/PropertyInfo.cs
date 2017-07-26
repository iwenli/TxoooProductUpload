using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.Entities.Commnet
{
    /// <summary>
    /// 商品属性
    /// </summary>
    class PropertyInfo
    {

        public string map_id { set; get; }
        public string product_id { set; get; }
        public string json_info { set; get; }
        public string remain_inventory { set; get; }
        public string total_inventory { set; get; }
        public string price { set; get; }
        public string market_price { set; get; }
        public string is_default { set; get; }
        public string img { set; get; }
        public string rebate_brokerage { set; get; }
        public string rebate_bonus { set; get; }
        public string add_time { set; get; }
        public string is_del { set; get; }
        public string rebate_point { set; get; }
        public string radio_num { set; get; }

        public override string ToString() {
            return json_info;
        }
    }
}

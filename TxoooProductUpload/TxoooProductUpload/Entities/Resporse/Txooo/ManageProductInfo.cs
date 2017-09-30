using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Entities.Resporse.Txooo
{
    /// <summary>
    /// Txooo商品信息
    /// </summary>
    public class ManageProductInfo
    {
        public long product_id { get; set; }
        public string product_name { get; set; }
        public string product_imgs { get; set; }
        public bool product_ispostage { get; set; }
        public int is_recommend { get; set; }
        public long mch_id { get; set; }
        public int product_type { get; set; }
        public int is_virtual { get; set; }
        public int parent_product_id { get; set; }
        public int product_details_type { get; set; }
        public string remark { get; set; }
        public int pro_state { get; set; }
        public string state_name { get; set; }
        public int is_check { get; set; }
        public int new_old { get; set; }
        public int only_show { get; set; }
        public int product_type_service { get; set; }
        public string product_type_name { get; set; }
        public double price { get; set; }
        public int min_inventory { get; set; }
        public int month_shop_count { get; set; }
    }
}

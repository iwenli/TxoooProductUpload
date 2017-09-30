using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Entities.Resporse.Txooo
{
    /// <summary>
    /// 商品状态
    /// </summary>
    public class ProductStateInfo
    {
        /// <summary>
        /// 该状态商品数
        /// </summary>
        public int pro_count { set; get; }
        /// <summary>
        /// 状态编号
        /// </summary>
        public int alias_name { set; get; }
        /// <summary>
        /// 状态名称
        /// </summary>
        public string class_name { set; get; }
    }
}

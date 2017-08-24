using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.Entities
{
    /// <summary>
    /// 地域信息
    /// </summary>
    public class AreaInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public int region_id { set; get; }
        /// <summary>
        /// Code
        /// </summary>
        public int region_code { set; get; }
        /// <summary>
        /// 父Id
        /// </summary>
        public int parent_id { set; get; }
        /// <summary>
        /// 地名
        /// </summary>
        public string region_name { set; get; }

        public override string ToString()
        {
            return region_name + " | " + region_code;
        }
    }
}

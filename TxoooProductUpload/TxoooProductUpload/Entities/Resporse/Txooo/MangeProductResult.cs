using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Entities.Resporse.Txooo
{
    /// <summary>
    /// 商品管理请求结果
    /// </summary>
    public class MangeProductResult
    {
        public int count { set; get; }
        public List<ManageProductInfo> list { set; get; }
    }
}

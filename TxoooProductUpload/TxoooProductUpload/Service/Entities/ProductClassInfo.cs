using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.Entities
{
    /// <summary>
    /// 商品分类
    /// </summary>
    public class ProductClassInfo
    {
        public long ClassId { get; set; }
        public string ClassName { get; set; }
        public long ParentId { get; set; }
        public DateTime AddTime { get; set; }
        public bool IsShow { get; set; }
        public int Order { get; set; }
        public string ImgUrl { get; set; }

        public List<double> RadioNums { get; set; }
        public override string ToString()
        {
            return string.Format("{0}[{1}]", ClassName, ClassId);
        }
    }
}

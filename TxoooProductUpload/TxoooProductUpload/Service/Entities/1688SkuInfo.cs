using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.Entities
{
    /// <summary>
    /// 1688SKU解析
    /// </summary>
    class Sku1688Info
    {
        /// <summary>
        /// 单位
        /// </summary>
        public string unit { set; get; }
        /// <summary>
        /// 类别,颜色|尺码
        /// </summary>
        public Sku1688Item[] value { set; get; }
        /// <summary>
        /// 类别,颜色|尺码
        /// </summary>
        public string prop { set; get; }
    }

    class Sku1688Item
    {
        /// <summary>
        /// 属性图像URL
        /// </summary>
        public string imageUrl { set; get; }
        /// <summary>
        /// 属性值
        /// </summary>
        public string name { set; get; }
    }
}

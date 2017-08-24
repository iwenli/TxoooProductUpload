using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.Entities.Commnet
{
    /// <summary>
    /// 添加评价商品信息集合
    /// </summary>
    public class ProductInfo
    {
        /// <summary>
        /// 商品基本信息
        /// </summary>
        public List<Product> product { set; get; }

        /// <summary>
        /// 商品属性
        /// </summary>
        public List<PropertyInfo> property { set; get; }
    }

    public class Product
    {
        /// <summary>
        /// 商品id
        /// </summary>
        public long product_id { set; get; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string product_name { set; get; }
        /// <summary>
        /// 是否在售
        /// </summary>
        public bool is_show { set; get; }
    }
}

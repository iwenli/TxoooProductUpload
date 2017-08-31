using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Entities.Product
{
    /// <summary>
    /// 商品来源 初始信息
    /// </summary>
    public class ProductSourceInfo
    {
        /// <summary>
        /// 初始化一个 ProductSourceInfo 对象
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public ProductSourceInfo(string id, SourceType type, string shopName) : this(id, type)
        {
            ShopName = shopName;
        }
        /// <summary>
        /// 初始化一个 ProductSourceInfo 对象
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public ProductSourceInfo(string id, SourceType type)
        {
            Id = id;
            SourceType = type;
        }


        /// <summary>
        /// 商品id
        /// </summary>
        public string Id { set; get; }
        /// <summary>
        ///  商品名称
        /// </summary>
        public string ProductName { set; get; }
        /// <summary>
        /// 来源类型
        /// </summary>
        public SourceType SourceType { set; get; }

        /// <summary>
        /// 来源店铺名称,如果有的话
        /// </summary>
        public string ShopName { get; set; }



        /// <summary>
        /// 来源类型名称
        /// </summary>
        public string SourceName
        {
            get
            {
                return ProductSource.GetFormatUrl(SourceType).FormatWith(Id);
            }
        }

        /// <summary>
        /// URL
        /// </summary>
        public string Url
        {
            get
            {
                return ProductSource.GetFormatUrl(SourceType).FormatWith(Id);
            }
        }
        /// <summary>
        /// H5 Url
        /// </summary>
        public string H5Url
        {
            get
            {
                return ProductSource.GetFormatH5Url(SourceType).FormatWith(Id);
            }
        }
    }
}

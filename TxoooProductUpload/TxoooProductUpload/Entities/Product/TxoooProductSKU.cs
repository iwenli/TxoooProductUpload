using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Entities.Product
{
    /// <summary>
    /// Txooo格式的SKu
    /// </summary>
    public class TxoooProductSKU
    {
        public long _mapId = 0;
        /// <summary>
        /// 淘宝SKU mapId
        /// </summary>
        public long MapId { set { _mapId = value; } get { return _mapId; } }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { set; get; }

        string _image = string.Empty;
        /// <summary>
        /// 图片
        /// </summary>
        public string Image
        {
            set
            {
                _image = value;
            }
            get
            {
                return _image;
            }
        }
        /// <summary>
        /// 价格
        /// </summary>
        public double Price { set; get; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { set; get; }

        string _txoooImage = string.Empty;
        /// <summary>
        /// Txooo服务器图片地址
        /// </summary>
        public string TxoooImage
        {
            set
            {
                _txoooImage = value;
            }
            get
            {
                return _txoooImage;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Entities.Product
{
    public class ProductSourceTxoooInfo
    {
        /// <summary>
        /// 唯一标识|id
        /// </summary>
        [Column(Name = "id")]
        public long Id { get; set; }
        /// <summary>
        /// 本品台商品id
        /// </summary>
        [Column(Name = "txooo_id")]
        public long TxoooId { get; set; }
        /// <summary>
        /// 来源id
        /// </summary>
        [Column(Name = "source_id")]
        public string SourceId { get; set; }
        /// <summary>
        /// 商品来源，1天猫  2淘宝  3阿里巴巴  4京东
        /// </summary>
        [Column(Name = "source_type")]
        public int SourceType { get; set; }
        /// <summary>
        /// 抓取商品的用户id
        /// </summary>
        [Column(Name = "user_id")]
        public long UserId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column(Name = "remarks")]
        public string Remarks { get; set; }
    }
}

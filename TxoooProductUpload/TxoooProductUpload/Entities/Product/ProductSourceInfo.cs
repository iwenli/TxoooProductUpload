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
        #region 构造函数
        /// <summary>
        /// 初始化一个 ProductSourceInfo 对象
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public ProductSourceInfo(long id, SourceType type, string shopName) : this(id, type)
        {
            ShopName = shopName;
        }

        /// <summary>
        /// 初始化一个 ProductSourceInfo 对象
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public ProductSourceInfo(long id, SourceType type) : this(id)
        {
            SourceType = type;
        }
        /// <summary>
        /// 初始化一个 ProductSourceInfo 对象
        /// </summary>
        /// <param name="id"></param>
        public ProductSourceInfo(long id)
        {
            Id = id;
        }
        #endregion

        #region  淘系独有
        /// <summary>
        /// 淘系用户昵称
        /// </summary>
        public string UserNick { set; get; }
        /// <summary>
        /// 淘系用户id
        /// </summary>
        public long UserId { set; get; }
        /// <summary>
        /// 淘系店铺URL 根据UserId生成
        /// </summary>
        public string StoreUrl
        {
            get
            {
                return "https://store.taobao.com/shop/view_shop.htm?user_number_id=" + UserId.ToString();
            }
        }
        #endregion

        #region 公共
        /// <summary>
        /// 默认显示的第一张主图
        /// </summary>
        public string FirstImg { set; get; }

        public bool _isFreePostage = true;
        /// <summary>
        /// 是否免邮
        /// </summary>
        public bool IsFreePostage
        {
            set
            {
                _isFreePostage = value;
            }
            get { return _isFreePostage; }
        }

        public double _postage = 0.00;
        /// <summary>
        /// 邮费
        /// </summary>
        public double Postage
        {
            set
            {
                _postage = value;
            }
            get { return _postage; }
        }

        /// <summary>
        /// 显示的价格
        /// </summary>
        public double ShowPrice { set; get; }

        /// <summary>
        /// 付款人数
        /// </summary>
        public int DealCnt { set; get; }

        /// <summary>
        /// 发货地
        /// </summary>
        public string Location { set; get; }

        /// <summary>
        /// 商品id
        /// </summary>
        public long Id { set; get; }
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
                return ProductSource.GetSourceName(SourceType);
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
        #endregion
    }
}

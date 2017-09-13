using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Entities.Product
{
    /// <summary>
    /// 商品信息
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
            ThumImgList = new List<string>();
            DetailImgList = new List<string>();
            SkuList = new List<ProductSKU>();
            TxoooThumImgList = new List<string>();
            TxoooDetailImgList = new List<string>();
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

        #region 公共属性
        string _firstImg = string.Empty;
        /// <summary>
        /// 默认显示的第一张主图
        /// </summary>
        public string FirstImg
        {
            set
            {
                _firstImg = value;
            }
            get
            {
                if (_firstImg.IsNullOrEmpty() && ThumImgList.Count > 0)
                {
                    _firstImg = ThumImgList[0];
                }
                return _firstImg;
            }
        }

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
        /// 收藏量
        /// </summary>
        public int FavCnt { set; get; }

        /// <summary>
        /// 销量
        /// </summary>
        public int SellCnt { set; get; }

        /// <summary>
        /// 评价数量
        /// </summary>
        public int CommnetCnt { set; get; }

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

        bool _isProcess = false;
        /// <summary>
        /// 是否处理过详细信息
        /// </summary>
        public bool IsProcess
        {
            set { _isProcess = value; }
            get
            {
                return _isProcess;
            }
        }
        #endregion

        #region Txooo商品属性
        bool _isNew = true;
        /// <summary>
        /// 是否新品
        /// </summary>
        public bool IsNew { get { return _isNew; } set { _isNew = value; } }

        bool _isVirtual = false;
        /// <summary>
        /// 是否虚拟商品
        /// </summary>
        public bool IsVirtual { get { return _isVirtual; } set { _isVirtual = value; } }

        bool _isRefund = true;
        /// <summary>
        /// 是否支持7天无理由
        /// </summary>
        public bool IsRefund { get { return _isRefund; } set { _isRefund = value; } }

        /// <summary>
        /// 商品分类id
        /// </summary>
        public long ClassId { set; get; }

        /// <summary>
        /// 发货地代码
        /// </summary>
        public long RegionCode { set; get; }

        /// <summary>
        /// 发货地名称
        /// </summary>
        public string RegionName { set; get; }

        long _classType = 1;
        /// <summary>
        /// 商品分类类型 （1产品，2服务）
        /// </summary>
        public long ClassType { set; get; }

        /// <summary>
        /// 结算比例
        /// </summary>
        public double SettlementRatio { set; get; }

        /// <summary>
        /// 溢价比例 比如抓取的价格100，溢价比例为0.3  则上传之后的价格为130
        /// </summary>
        public double PremiumRatio { set; get; }

        /// <summary>
        /// 商品主图
        /// </summary>
        public List<string> TxoooThumImgList { private set; get; }
        /// <summary>
        /// 商品详情图
        /// </summary>
        public List<string> TxoooDetailImgList { private set; get; }
        #endregion

        /// <summary>
        /// 商品品牌
        /// </summary>
        public string Brand { set; get; }
        /// <summary>
        /// 子标题  推广语
        /// </summary>
        public string SubTitle { set; get; }



        /// <summary>
        /// 商品主图
        /// </summary>
        public List<string> ThumImgList { private set; get; }
        /// <summary>
        /// 商品详情图
        /// </summary>
        public List<string> DetailImgList { private set; get; }
        /// <summary>
        /// Txooo格式的SKu集合
        /// </summary>
        public List<ProductSKU> SkuList { private set; get; }


        #region 公共方法
        /// <summary>
        /// 添加SKU
        /// </summary>
        /// <param name="sku"></param>
        public void AddSku(ProductSKU sku)
        {
            if (!sku.Image.IsNullOrEmpty() && !sku.Image.StartsWith("http"))
            {
                sku.Image = "http:" + sku.Image;
            }
            SkuList.Add(sku);
        }
        /// <summary>
        /// 检查主图地址并添加到主图列表，如果存在则不添加
        /// </summary>
        /// <param name="imgUrl">图片地址</param>
        public void AddThumImgWithCheck(string imgUrl)
        {
            if (!imgUrl.IsNullOrEmpty())
            {
                if (!imgUrl.StartsWith("http"))
                {
                    imgUrl = "http:" + imgUrl;
                }
                if (!ThumImgList.Contains(imgUrl))
                {
                    ThumImgList.Add(imgUrl);
                }
            }
        }

        /// <summary>
        /// 检查详情图片地址并添加到详情图片列表
        /// </summary>
        /// <param name="imgUrl">图片地址</param>
        public void AddDetailImgWithCheck(string imgUrl)
        {
            if (!imgUrl.IsNullOrEmpty())
            {
                if (!imgUrl.StartsWith("http"))
                {
                    imgUrl = "http:" + imgUrl;
                }
                if (!DetailImgList.Contains(imgUrl))
                {
                    DetailImgList.Add(imgUrl);
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// Txooo格式的SKu
    /// </summary>
    public class ProductSKU
    {
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

        /// <summary>
        /// Txooo服务器图片地址
        /// </summary>
        public string TxoooImage
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

    }
}

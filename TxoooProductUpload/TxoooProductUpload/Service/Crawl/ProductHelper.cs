using FSLib.Network.Http;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Entities.Product;
using TxoooProductUpload.Network;

namespace TxoooProductUpload.Service.Crawl
{
    /// <summary>
    /// 商品抓取公共入口
    /// </summary>
    public class ProductHelper
    {
        NetClient _netClient;
        IHelper _tmallHelper;
        IHelper _taobaoHelper;


        #region 属性
        /// <summary>
        /// 网络请求对象
        /// </summary>
        public NetClient NetClient
        {
            set
            {
                _netClient = value;
            }
            get { return _netClient; }

        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化一个 ProductHelper 实例
        /// </summary>
        public ProductHelper()
        {
            _netClient = new NetClient();
            _tmallHelper = new TmallHepler();
            _taobaoHelper = new TaobaoHelper();
        }

        /// <summary>
        /// 初始化一个 ProductHelper 实例
        /// </summary>
        /// <param name="netClient"></param>
        public ProductHelper(NetClient netClient) : this()
        {
            _netClient = netClient;
        }
        #endregion

        /// <summary>
        /// 从详情抓取商品信息
        /// </summary>
        /// <param name="product">商品信息</param>
        /// <returns>是否处理成功</returns>
        public void ProcessItem(ref ProductSourceInfo product)
        {
            switch (product.SourceType)
            {
                case SourceType.Txooo:
                    break;
                case SourceType.Tmall:
                    _tmallHelper.ProcessItem(_netClient, ref product);
                    break;
                case SourceType.Taobao:
                    _taobaoHelper.ProcessItem(_netClient, ref product);
                    break;
                case SourceType.Alibaba:
                    break;
                case SourceType.Jingdong:
                    break;
                default:
                    break;
            }
            product.IsProcess = true;
        }

        /// <summary>
        /// 从搜索结果页面提取商品基本信息集合
        /// </summary>
        /// <param name="document">当前搜素结果dom对象</param>
        /// <param name="type">当前搜素来源类型</param>
        /// <returns></returns>
        public List<ProductSourceInfo> GetProductListFormSearch(HtmlDocument document, SourceType type)
        {
            switch (type)
            {
                case SourceType.Txooo:
                    break;
                case SourceType.Tmall:
                    return _tmallHelper.GetProductListFormSearch(document);
                case SourceType.Taobao:
                    return _taobaoHelper.GetProductListFormSearch(document);
                case SourceType.Alibaba:
                    break;
                case SourceType.Jingdong:
                    break;
            }
            return new List<ProductSourceInfo>();
        }
    }
}

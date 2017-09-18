using FSLib.Network.Http;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Entities;
using TxoooProductUpload.Entities.Product;
using TxoooProductUpload.Network;

namespace TxoooProductUpload.Service.Crawl
{
    /// <summary>
    /// 商品抓取公共入口
    /// </summary>
    public class ProductHelper
    {
        ImageService _imageService;
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
        /// <param name="netClient"></param>
        private ProductHelper()
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
        /// <summary>
        /// 初始化一个 ProductHelper 实例
        /// </summary>
        /// <param name="netClient"></param>
        public ProductHelper(ImageService imageService) : this()
        {
            _imageService = imageService;
        }
        #endregion

        /// <summary>
        /// 从详情抓取商品信息
        /// </summary>
        /// <param name="product">商品信息</param>
        /// <returns>是否处理成功</returns>
        public void ProcessItem(ProductSourceInfo product)
        {
            try
            {
                switch (product.SourceType)
                {
                    case SourceType.Txooo:
                        break;
                    case SourceType.Tmall:
                        _tmallHelper.ProcessItem(_netClient, _imageService, product);
                        break;
                    case SourceType.Taobao:
                        _taobaoHelper.ProcessItem(_netClient, _imageService, product);
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
            catch (Exception ex)
            {
                Iwenli.LogHelper.LogError(this,
                        "[详情]{0}商品{1}异常：{2}".FormatWith(product.SourceName, product.Id, ex.Message));
            } 
       } 

        /// <summary>
        /// 从页面提取商品信息
        /// </summary>
        /// <param name="document">当前页面dom对象</param>
        /// <param name="type">当前页面类型</param>
        /// <returns></returns>
        public List<ProductSourceInfo> GetProductsRromDocument(HtmlDocument document, CrawlType type)
        {
            try
            {
                switch (type)
                {
                    case CrawlType.TaoBaoSearch:
                        return _taobaoHelper.GetProductListFormSearch(document);
                    case CrawlType.TaoBaoItem:
                        return _taobaoHelper.GetProductbyHtml(document);
                    case CrawlType.TmallItem:
                        return _tmallHelper.GetProductbyHtml(document);
                }
            }
            catch (Exception ex)
            {

                Iwenli.LogHelper.LogError(this,
                        "从{0}页面提取商品信息异常,页面来源：{1}".FormatWith(type, document.ToString()), ex);
            }
           
            return new List<ProductSourceInfo>();
        }
    }
}

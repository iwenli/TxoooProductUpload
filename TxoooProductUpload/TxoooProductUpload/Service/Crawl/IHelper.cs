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
    /// 商品抓取接口
    /// </summary>
    public interface IHelper
    {
        /// <summary>
        /// 从详情抓取商品信息
        /// </summary>
        /// <param name="client">HTTP客户端</param>
        /// <param name="product">基本商品信息，必须包含Id,以及Type</param>
        /// <returns></returns>
        void ProcessItem(NetClient client, ref ProductSourceInfo product);


        /// <summary>
        /// 从搜索结果页面提取商品基本信息集合
        /// </summary>
        /// <param name="document">当前搜素结果dom对象</param>
        /// <returns></returns>
        List<ProductSourceInfo> GetProductListFormSearch(HtmlAgilityPack.HtmlDocument document);
    }
}

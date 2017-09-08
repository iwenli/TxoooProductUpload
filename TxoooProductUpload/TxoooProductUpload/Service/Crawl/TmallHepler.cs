using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using TxoooProductUpload.Entities.Product;
using TxoooProductUpload.Network;
using Iwenli;
using FSLib.Network.Http;

namespace TxoooProductUpload.Service.Crawl
{
    /// <summary>
    /// 天猫相关处理
    /// </summary>
    public class TmallHepler : IHelper
    {
        /// <summary>
        /// 从天猫搜索结果页面提取商品基本信息集合
        /// </summary>
        /// <param name="document">当前天猫搜素文档对象</param>
        public List<ProductSourceInfo> GetProductListFormSearch(HtmlDocument document)
        {
            List<ProductSourceInfo> list = new List<ProductSourceInfo>();
            if (document == null) return list;
            try
            {

            }
            catch (Exception ex)
            {
                throw new WlException("解析天猫搜索结果异常", ex);
            }
            return list;
        }

        /// <summary>
        /// 从天猫详情抓取商品信息
        /// </summary>
        /// <param name="client">HTTP客户端</param>
        /// <param name="product">基本商品信息，必须包含Id,以及Type</param>
        /// <returns></returns>
        public bool ProcessItem(NetClient client, ref ProductSourceInfo product)
        {
            bool ret = false;
            var ctx = client.Create<string>(HttpMethod.Get, product.H5Url, allowAutoRedirect: true);
            ctx.Send();
            if (!ctx.IsValid())
            {
                throw new WlException(string.Format("未能提交请求,连接：{0}", product.H5Url));
            }

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(ctx.Result);

            ////主图
            //var thumImgs = document.GetElementbyId("J_mod0").SelectNodes("//img");
            //foreach (var node in thumImgs)
            //{
            //    product.AddThumImgWithCheck(node.Attributes["src"].Value);
            //}

            var jsNodes = document.DocumentNode.SelectNodes(".//script");
            //_DATA_Mdskip =  ([\s\S]+}}}})
            //_DATA_Detail = ([\s\S]+]});
            string dataMdskip, dataDetail;
            foreach (var item in jsNodes)
            {
                if (item.InnerHtml.IndexOf("_DATA_Mdskip") > -1)
                {
                    dataMdskip = item.InnerHtml.Replace(";|<script>|</script>", "");
                    dataMdskip = dataMdskip.Substring(dataMdskip.IndexOf("{"));
                }
                if (item.InnerHtml.IndexOf("_DATA_Detail") > -1)
                {
                    dataDetail = item.InnerHtml.Replace(";|<script>|</script>", "");
                    dataDetail = dataDetail.Substring(dataDetail.IndexOf("{"));
                }
            }
            return ret;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using TxoooProductUpload.Entities.Product;
using TxoooProductUpload.Network;

namespace TxoooProductUpload.Service.Crawl
{
    /// <summary>
    /// 淘宝相关处理
    /// </summary>
    public class TaobaoHelper : IHelper
    {
        /// <summary>
        /// 从淘宝详情抓取商品信息
        /// </summary>
        /// <param name="client">HTTP客户端</param>
        /// <param name="product">基本商品信息，必须包含Id,以及Type</param>
        /// <returns></returns>
        public bool ProcessItem(NetClient client, ref ProductSourceInfo product)
        {
            //appkey = 12574478   b.appKey || ("waptest" === c.subDomain ? "4272" : "12574478"),

            //e = b.appKey || ("waptest" === c.subDomain ? "4272" : "12574478"),
            //f = new Date().getTime(),
            //g = h(c.token + "&" + f + "&" + e + "&" + b.data),
            //i = { appKey: e, t: f, sign: g },
            //j = { data: b.data, ua: b.ua };

            //token:3ab549c1d86cc3db964de9ad51f4e17b_1505041028251
            //date:1505038515801
            //appkey:12574478
            //data:{"exParams":"{\"id\":\"543348160168\"}","itemNumId":"543348160168"}
            // %7B%22exParams%22%3A%22%7B%5C%22id%5C%22%3A%5C%22543348160168%5C%22%7D%22%2C%22itemNumId%22%3A%22543348160168%22%7D

            //sign:3caf44a2112dead22ef70ce5e4a0ce5b

            // 6aa0f4e2d14709e4b46fd92527da3b2b
            //  3ab549c1d86cc3db964de9ad51f4e17b_1505041028251&1505038515801&12574478&%7B%22exParams%22%3A%22%7B%5C%22id%5C%22%3A%5C%22543348160168%5C%22%7D%22%2C%22itemNumId%22%3A%22543348160168%22%7D

            /*
             * 
             return lib.mtop.request({
                        'api': config.data.getdetail.name,
                        'v': config.data.getdetail.version,
                        'data': paramsData,
                        'ttid': ttid,
                        'isSec': \"0\",
                        'ecode': \"0\",
                        'AntiFlood': true,
                        'AntiCreep': true,
                        'H5Request': true
                    });
             */

            //详情  基本信息   优惠信息
            /*
            http://acs.m.taobao.com/h5/mtop.wdetail.getitemdescx/4.1/?appKey=12574478&t=1505034450694&sign=2e61e44fe50e85948a8323123cf789fd&api=mtop.wdetail.getItemDescx&v=4.1&isSec=0&ecode=0&H5Request=true&type=jsonp&dataType=jsonp&callback=mtopjsonp1&data={"item_num_id":"543348160168","type":"0"}
            http://acs.m.taobao.com/h5/mtop.wdetail.getitemdescx/4.1/?appKey=12574478&t=1505035469266&sign=89feeb0218a25afd55550a8bdc1a86eb&api=mtop.wdetail.getItemDescx&v=4.1&isSec=0&ecode=0&H5Request=true&type=jsonp&dataType=jsonp&callback=mtopjsonp2&data={"item_num_id":"543348160168","type":"0"}
            http://acs.m.taobao.com/h5/mtop.taobao.detail.getdetail/6.0/?appKey=12574478&t=1505034450159&sign=1ad2052376dfd6f84e04808fc177bbf6&api=mtop.taobao.detail.getdetail&v=6.0&ttid=2016@taobao_h5_2.0.0&isSec=0&ecode=0&AntiFlood=true&AntiCreep=true&H5Request=true&type=jsonp&dataType=jsonp&callback=mtopjsonp1&data={"exParams":"{\"id\":\"543348160168\"}","itemNumId":"543348160168"}
            http://acs.m.taobao.com/h5/mtop.taobao.baichuan.smb.detail.get/1.0/?appKey=12574478&t=1505035469578&sign=517860a0126c2e3f80090f61309245e9&api=mtop.taobao.baichuan.smb.detail.get&v=1.0&type=originaljson&dataType=json&timeout=20000&ua=098#E1hv5QvUvbpvUvCkvvvvvjiPP25vsjt8RFcU0j1VPmPWsj18PFFvsjDnRsL9tjnjiQhvCvvv9UUtvpvhvvvvvbyCvm9vvvvvphvvvvvv92Bvpv9mvvmvnhCvmvUvvUv6phvUv9vv92Bvpv9mkphvC99vvOC0BuyCvv9vvUvS8shbw9yCvhQWDG6vC0P6lWF9eCO0747B9Wma+oHoDO2h1C6tExjxAfev+ul1Bzc6D70O5C61yNoxfX9fjobh1nF95ClABJ2p+nezrmphQRAn3feAvphvC9vhvvCvpvGCvvpYjRIE&data={"itemId":"543348160168"}

             */
            bool ret = false;

            return ret;
        }

        /// <summary>
        /// 从淘宝搜索结果页面提取商品基本信息集合
        /// </summary>
        /// <param name="document">当前淘宝搜素文档对象</param>
        public List<ProductSourceInfo> GetProductListFormSearch(HtmlDocument document)
        {
            List<ProductSourceInfo> list = new List<ProductSourceInfo>();
            if (document == null) return list;
            try
            {
                var productNodeList = document.GetElementbyId("mainsrp-itemlist").SelectNodes("//div[starts-with(@class,'item J_MouserOnverReq')]");
                HtmlNode temp = null;
                foreach (HtmlNode categoryNode in productNodeList)
                {
                    temp = HtmlNode.CreateNode(categoryNode.OuterHtml);
                    var picElement = temp.SelectSingleNode("//a[starts-with(@class,'pic-link')]");
                    var idStr = picElement.Attributes["trace-nid"].Value;
                    if (!string.IsNullOrEmpty(idStr))
                    {
                        var id = Convert.ToInt64(idStr);
                        if (list.Exists(m => m.Id == id)) { continue; }

                        ProductSourceInfo product = new ProductSourceInfo(id);
                        product.SourceType = temp.SelectSingleNode("//span[@class='icon-service-tianmao']") == null ?
                         SourceType.Taobao : SourceType.Tamll;

                        product.ShowPrice = Convert.ToDouble(picElement.Attributes["trace-price"].Value ?? "0");
                        product.FirstImg = picElement.SelectSingleNode("//img").Attributes["data-src"].Value;

                        product.IsFreePostage = temp.SelectSingleNode("//div[@class='ship icon-service-free']") != null;
                        product.ProductName = temp.SelectSingleNode("//a[@class='J_ClickStat']").InnerText.Trim();

                        product.DealCnt = Convert.ToInt32(temp.SelectSingleNode("//div[@class='deal-cnt']").InnerText.Trim().Replace("人付款", ""));
                        product.UserNick = temp.SelectSingleNode("//a[@class='shopname J_MouseEneterLeave J_ShopInfo']").InnerText;
                        product.UserId = Convert.ToInt64(temp.SelectSingleNode("//a[@class='shopname J_MouseEneterLeave J_ShopInfo']").Attributes["data-userid"].Value);
                        product.Location = temp.SelectSingleNode("//div[@class='location']").InnerText.Trim();

                        list.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new WlException("解析淘宝搜索结果异常", ex);
            }
            return list;
        }
    }
}

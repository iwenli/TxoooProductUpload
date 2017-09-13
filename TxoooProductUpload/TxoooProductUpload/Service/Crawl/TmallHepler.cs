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
using Newtonsoft.Json;
using TxoooProductUpload.Entities.Resporse;
using System.Text.RegularExpressions;

namespace TxoooProductUpload.Service.Crawl
{
    /// <summary>
    /// 天猫相关处理
    /// </summary>
    public class TmallHepler : IHelper
    {
        Regex _brandRegex = new Regex(@"{""品牌"":""([\s\S]*?)""}");
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
                throw new Exception("解析天猫搜索结果异常", ex);
            }
            return list;
        }

        /// <summary>
        /// 从天猫无线详情抓取商品信息
        /// </summary>
        /// <param name="client">HTTP客户端</param>
        /// <param name="product">基本商品信息，必须包含Id,以及Type</param>
        /// <returns></returns>
        public void ProcessItem(NetClient client, ref ProductSourceInfo product)
        {
            var ctx = client.Create<string>(HttpMethod.Get, product.H5Url, allowAutoRedirect: true);
            ctx.Send();
            if (!ctx.IsValid())
            {
                throw new Exception(string.Format("未能提交请求,连接：{0}", product.H5Url));
            }

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(ctx.Result);

            ////主图
            //var thumImgs = document.GetElementbyId("J_mod0").SelectNodes("//img");
            //foreach (var node in thumImgs)
            //{
            //    product.AddThumImgWithCheck(node.Attributes["src"].Value);
            //}

            #region 解析HTML 获取内容
            var jsNodes = document.DocumentNode.SelectNodes(".//script");
            //_DATA_Mdskip =  ([\s\S]+}}}})
            //_DATA_Detail = ([\s\S]+]});
            string dataMdskip = string.Empty
                , dataDetail = string.Empty;
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
                    dataDetail = dataDetail.Substring(dataDetail.IndexOf("{")).Replace(";", "");
                }
            }
            if (dataDetail.IsNullOrEmpty() || dataMdskip.IsNullOrEmpty())
            {
                throw new Exception("天猫抓取异常，_DATA_Mdskip或者_DATA_Detail为空");
            }
            #endregion

            //品牌
            if (_brandRegex.IsMatch(dataDetail))
            {
                product.Brand = _brandRegex.Match(dataDetail).Groups[1].Value.Trim();
            }
            var detailModel = JsonConvert.DeserializeObject<TmallProductResult>(dataDetail);
            var mdSkipModel = JsonConvert.DeserializeObject<TmallProductResult>(dataMdskip);

            #region 基本信息
            product.UserNick = product.ShopName = detailModel.seller.shopName;
            product.UserId = detailModel.seller.userId;

            product.ProductName = detailModel.item.title;
            product.SubTitle = detailModel.item.subtitle;
            foreach (var url in detailModel.item.images)
            {
                product.AddThumImgWithCheck(url);
            }
            product.FavCnt = detailModel.item.favcount;
            product.CommnetCnt = mdSkipModel.item.commentCount;
            product.SellCnt = mdSkipModel.item.sellCount;
            product.Location = product.Location ?? mdSkipModel.delivery.from;
            #endregion

            #region 邮费 以及 包邮处理
            if (mdSkipModel.delivery.postage.IndexOf("快递") > -1)
            {
                product.Postage = Convert.ToDouble(mdSkipModel.delivery.postage.Split(':')[1] ?? "0");
                if (product.Postage > 0)
                {
                    product.IsFreePostage = false;
                }
            }
            #endregion

            #region 处理详情
            if (detailModel.detailDesc.newWapDescJson != null)
            {
                var detailJson = detailModel.detailDesc.newWapDescJson.FirstOrDefault(m => m.moduleName == "商品图片");
                if (detailJson == null || detailJson.data.Count == 0)
                {
                    throw new Exception("天猫抓取异常，商品详情获取失败");
                }
                foreach (var item in detailJson.data)
                {
                    product.AddDetailImgWithCheck(item.img);
                }
            }
            else
            {
                var descUrl = detailModel.jumpUrl.apis.httpsDescUrl;
                if (!descUrl.StartsWith("http")) {
                    descUrl = "http:" + descUrl;
                }
                var descCtx = new NetClient().Create<string>(HttpMethod.Get, descUrl, refer: product.Url);
                descCtx.Send();
                if (!descCtx.IsValid())
                {
                    throw new Exception(string.Format("未能提交请求,连接：{0}", descUrl));
                }
                HtmlDocument descDoc = new HtmlDocument();
                descDoc.LoadHtml(descCtx.Result.Replace("var desc=|'|;", ""));
                var descimgNodes = descDoc.DocumentNode.SelectNodes("//img");
                if (descimgNodes != null)
                {
                    foreach (HtmlNode node in descimgNodes)
                    {
                        if (node.Attributes["src"] != null)
                        {
                            product.AddDetailImgWithCheck(node.Attributes["src"].Value);
                        }
                    }
                }
               
            } 
            #endregion

            //处理SKU
            switch (detailModel.skuBase.props.Count)
            {
                case 1:
                    #region 1级属性
                    foreach (var prop1 in detailModel.skuBase.props[0].values)
                    {
                        var skuPath = "{0}:{1}".FormatWith(detailModel.skuBase.props[0].pid, prop1.vid);

                        var skuBase = detailModel.skuBase.skus.FirstOrDefault(m => m.propPath == skuPath);
                        var skuId = skuBase.skuId;

                        ProductSKU sku = new ProductSKU();
                        sku.Name = prop1.name;
                        sku.Image = prop1.image ?? "";

                        var skuInfo = mdSkipModel.skuCore.sku2info.FirstOrDefault(m => m.Key == skuId);
                        sku.Quantity = skuInfo.Value.quantity;
                        sku.Price = skuInfo.Value.price.priceMoney / 100.00;
                        product.AddSku(sku);
                    }
                    #endregion
                    break;
                case 2:
                    #region 2级属性
                    foreach (var prop1 in detailModel.skuBase.props[0].values)
                    {
                        var skuPath1 = "{0}:{1}".FormatWith(detailModel.skuBase.props[0].pid, prop1.vid);

                        foreach (var prop2 in detailModel.skuBase.props[1].values)
                        {
                            var skuPath2 = "{0}:{1}".FormatWith(detailModel.skuBase.props[1].pid, prop2.vid);

                            var skuPath = "{0};{1}".FormatWith(skuPath1, skuPath2);
                            var skuBase = detailModel.skuBase.skus.FirstOrDefault(m => m.propPath == skuPath);
                            if (skuBase == null)
                            {
                                skuPath = "{0}{1}".FormatWith(skuPath1, skuPath2);
                                skuBase = detailModel.skuBase.skus.FirstOrDefault(m => m.propPath == skuPath);
                            }
                            var skuId = skuBase.skuId;

                            ProductSKU sku = new ProductSKU();
                            sku.Name = "{0}-{1}".FormatWith(prop1.name, prop2.name);
                            sku.Image = prop1.image ?? prop2.image ?? "";

                            var skuInfo = mdSkipModel.skuCore.sku2info.FirstOrDefault(m => m.Key == skuId);
                            sku.Quantity = skuInfo.Value.quantity;
                            sku.Price = skuInfo.Value.price.priceMoney / 100.00;
                            product.AddSku(sku);
                        }
                    }
                    #endregion
                    break;
                case 3:
                    //3级属性
                    throw new Exception("暂不支持天猫3级sku 请联系开发人员！");
                case 4:
                    #region 4级属性
                    foreach (var prop1 in detailModel.skuBase.props[0].values)
                    {
                        var skuPath1 = "{0}:{1}".FormatWith(detailModel.skuBase.props[0].pid, prop1.vid);

                        foreach (var prop2 in detailModel.skuBase.props[1].values)
                        {
                            var skuPath2 = "{0}:{1}".FormatWith(detailModel.skuBase.props[1].pid, prop2.vid);

                            foreach (var prop3 in detailModel.skuBase.props[2].values)
                            {
                                var skuPath3 = "{0}:{1}".FormatWith(detailModel.skuBase.props[2].pid, prop3.vid);

                                foreach (var prop4 in detailModel.skuBase.props[3].values)
                                {
                                    var skuPath4 = "{0}:{1}".FormatWith(detailModel.skuBase.props[3].pid, prop4.vid);

                                    var skuPath = "{0};{1};{2};{3}".FormatWith(skuPath1, skuPath2, skuPath3, skuPath4);
                                    var skuBase = detailModel.skuBase.skus.FirstOrDefault(m => m.propPath == skuPath);
                                    if (skuBase == null)
                                    {
                                        skuPath = "{0}{1}{2}{3}".FormatWith(skuPath1, skuPath2, skuPath3, skuPath4);
                                        skuBase = detailModel.skuBase.skus.FirstOrDefault(m => m.propPath == skuPath);
                                    }
                                    var skuId = skuBase.skuId;

                                    ProductSKU sku = new ProductSKU();
                                    sku.Name = "{0}-{1}-{2}-{3}".FormatWith(prop1.name, prop2.name, prop3.name, prop4.name);
                                    sku.Image = prop1.image ?? prop2.image ?? prop3.image ?? prop2.image ?? "";

                                    var skuInfo = mdSkipModel.skuCore.sku2info.FirstOrDefault(m => m.Key == skuId);
                                    sku.Quantity = skuInfo.Value.quantity;
                                    sku.Price = skuInfo.Value.price.priceMoney / 100.00;
                                    product.AddSku(sku);
                                }
                            }
                        }
                    }
                    #endregion
                    break;
                default:
                    throw new Exception("暂不支持天猫4级以上sku 请联系开发人员！");
            }
        }
    }
}

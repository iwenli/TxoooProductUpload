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
        /// <param name="imageService"></param>
        /// <param name="product">基本商品信息，必须包含Id,以及Type</param>
        /// <returns></returns>
        public void ProcessItem(NetClient client, ImageService imageService, ProductSourceInfo product)
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
                if (!descUrl.StartsWith("http"))
                {
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

            //处理SKU  哪个层级的SKU携带图片就放到最外层去循环
            switch (detailModel.skuBase.props.Count)
            {
                case 1:
                    #region 1级属性
                    foreach (var prop1 in detailModel.skuBase.props[0].values)
                    {
                        var skuPath = "{0}:{1}".FormatWith(detailModel.skuBase.props[0].pid, prop1.vid);
                        var skuBase = detailModel.skuBase.skus.FirstOrDefault(m => m.propPath == skuPath);
                        var skuId = skuBase.skuId;

                        TxoooProductSKU sku = new TxoooProductSKU();
                        sku.Name = prop1.name;
                        sku.Image = prop1.image ?? "";
                        #region SKU图片直接上传到Txooo中
                        if (!sku.Image.IsNullOrEmpty())
                        {
                            if (!sku.Image.StartsWith("http"))
                            {
                                sku.Image = "http:" + sku.Image;
                            }
                            try
                            {
                                sku.TxoooImage = imageService.UploadImg(sku.Image);
                            }
                            catch (Exception ex)
                            {
                                Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                                    .FormatWith(product.SourceName, product.Id, sku.Image, ex.Message));
                            }
                        }
                        #endregion

                        var skuInfo = mdSkipModel.skuCore.sku2info.FirstOrDefault(m => m.Key == skuId);
                        sku.Quantity = skuInfo.Value.quantity;
                        sku.Price = skuInfo.Value.price.priceMoney / 100.00;
                        product.AddSku(sku);
                    }
                    #endregion
                    break;
                case 2:
                    #region 2级属性
                    foreach (var prop1 in detailModel.skuBase.props[1].values)
                    {
                        var skuPath1 = "{0}:{1}".FormatWith(detailModel.skuBase.props[1].pid, prop1.vid);
                        var image = prop1.image;
                        var txoooImage = string.Empty;
                        #region SKU图片直接上传到Txooo中
                        if (!image.IsNullOrEmpty())
                        {
                            if (!image.StartsWith("http"))
                            {
                                image = "http:" + image;
                            }
                            try
                            {
                                txoooImage = imageService.UploadImg(image);
                            }
                            catch (Exception ex)
                            {
                                Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                                    .FormatWith(product.SourceName, product.Id, image, ex.Message));
                            }
                        }
                        #endregion

                        foreach (var prop0 in detailModel.skuBase.props[0].values)
                        {
                            var skuPath0 = "{0}:{1}".FormatWith(detailModel.skuBase.props[0].pid, prop0.vid);

                            var skuPath = "{0};{1}".FormatWith(skuPath0, skuPath1);
                            var skuBase = detailModel.skuBase.skus.FirstOrDefault(m => m.propPath == skuPath);
                            if (skuBase == null)
                            {
                                skuPath = "{0}{1}".FormatWith(skuPath0, skuPath1);
                                skuBase = detailModel.skuBase.skus.FirstOrDefault(m => m.propPath == skuPath);
                            }
                            var skuId = skuBase.skuId;

                            if (image.IsNullOrEmpty() && !prop0.image.IsNullOrEmpty())
                            {
                                image = prop0.image;
                                #region SKU图片直接上传到Txooo中
                                if (!image.IsNullOrEmpty())
                                {
                                    if (!image.StartsWith("http"))
                                    {
                                        image = "http:" + image;
                                    }
                                    try
                                    {
                                        txoooImage = imageService.UploadImg(image);
                                    }
                                    catch (Exception ex)
                                    {
                                        Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                                            .FormatWith(product.SourceName, product.Id, image, ex.Message));
                                    }
                                }
                                #endregion
                            }

                            TxoooProductSKU sku = new TxoooProductSKU();
                            sku.Name = "{0}-{1}".FormatWith(prop0.name, prop1.name);
                            sku.Image = image;
                            sku.TxoooImage = txoooImage;

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
                    foreach (var prop0 in detailModel.skuBase.props[0].values)
                    {
                        var skuPath0 = "{0}:{1}".FormatWith(detailModel.skuBase.props[0].pid, prop0.vid);
                        var image = prop0.image;
                        var txoooImage = string.Empty;
                        #region SKU图片直接上传到Txooo中
                        if (!image.IsNullOrEmpty())
                        {
                            if (!image.StartsWith("http"))
                            {
                                image = "http:" + image;
                            }
                            try
                            {
                                txoooImage = imageService.UploadImg(image);
                            }
                            catch (Exception ex)
                            {
                                Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                                    .FormatWith(product.SourceName, product.Id, image, ex.Message));
                            }
                        }
                        #endregion

                        foreach (var prop1 in detailModel.skuBase.props[1].values)
                        {
                            var skuPath1 = "{0}:{1}".FormatWith(detailModel.skuBase.props[1].pid, prop1.vid);
                            if (image.IsNullOrEmpty() && !prop1.image.IsNullOrEmpty())
                            {
                                image = prop1.image;
                                #region SKU图片直接上传到Txooo中
                                if (!image.IsNullOrEmpty())
                                {
                                    if (!image.StartsWith("http"))
                                    {
                                        image = "http:" + image;
                                    }
                                    try
                                    {
                                        txoooImage = imageService.UploadImg(image);
                                    }
                                    catch (Exception ex)
                                    {
                                        Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                                            .FormatWith(product.SourceName, product.Id, image, ex.Message));
                                    }
                                }
                                #endregion
                            }

                            foreach (var prop2 in detailModel.skuBase.props[2].values)
                            {
                                var skuPath2 = "{0}:{1}".FormatWith(detailModel.skuBase.props[2].pid, prop2.vid);
                                if (image.IsNullOrEmpty() && !prop2.image.IsNullOrEmpty())
                                {
                                    image = prop2.image;
                                    #region SKU图片直接上传到Txooo中
                                    if (!image.IsNullOrEmpty())
                                    {
                                        if (!image.StartsWith("http"))
                                        {
                                            image = "http:" + image;
                                        }
                                        try
                                        {
                                            txoooImage = imageService.UploadImg(image);
                                        }
                                        catch (Exception ex)
                                        {
                                            Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                                                .FormatWith(product.SourceName, product.Id, image, ex.Message));
                                        }
                                    }
                                    #endregion
                                }
                                foreach (var prop3 in detailModel.skuBase.props[3].values)
                                {
                                    var skuPath3 = "{0}:{1}".FormatWith(detailModel.skuBase.props[3].pid, prop3.vid);

                                    var skuPath = "{0};{1};{2};{3}".FormatWith(skuPath0, skuPath1, skuPath2, skuPath3);
                                    var skuBase = detailModel.skuBase.skus.FirstOrDefault(m => m.propPath == skuPath);
                                    if (skuBase == null)
                                    {
                                        skuPath = "{0}{1}{2}{3}".FormatWith(skuPath0, skuPath1, skuPath2, skuPath3);
                                        skuBase = detailModel.skuBase.skus.FirstOrDefault(m => m.propPath == skuPath);
                                    }
                                    var skuId = skuBase.skuId;
                                    if (image.IsNullOrEmpty() && !prop3.image.IsNullOrEmpty())
                                    {
                                        image = prop3.image;
                                        #region SKU图片直接上传到Txooo中
                                        if (!image.IsNullOrEmpty())
                                        {
                                            if (!image.StartsWith("http"))
                                            {
                                                image = "http:" + image;
                                            }
                                            try
                                            {
                                                txoooImage = imageService.UploadImg(image);
                                            }
                                            catch (Exception ex)
                                            {
                                                Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                                                    .FormatWith(product.SourceName, product.Id, image, ex.Message));
                                            }
                                        }
                                        #endregion
                                    }

                                    TxoooProductSKU sku = new TxoooProductSKU();
                                    sku.Name = "{0}-{1}-{2}-{3}".FormatWith(prop0.name, prop1.name, prop2.name, prop3.name);
                                    sku.Image = image;
                                    sku.TxoooImage = txoooImage;
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

        /// <summary>
        /// 从天猫商品展示中获取商品信息
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public List<ProductSourceInfo> GetProductbyHtml(HtmlDocument document)
        {
            var list = new List<ProductSourceInfo>();
            var product = new ProductSourceInfo();
            product.IsProcess = true;
            product.SourceType = SourceType.Tmall;

            product.Id = Convert.ToInt64(document.GetElementbyId("side-shop-info").SelectSingleNode(".//div/h3/div/span").Attributes["data-item"].Value);
            product.ShopName = product.UserNick = document.GetElementbyId("side-shop-info").SelectSingleNode(".//div/h3/div/a").InnerText.Trim();
            product.ShowPrice = Convert.ToDouble(document.GetElementbyId("J_PromoPrice").SelectSingleNode(".//dd/div/span").InnerText.Trim());
            product.Location = document.GetElementbyId("J_deliveryAdd").InnerText.Trim();
            product.ProductName = document.GetElementbyId("J_DetailMeta").SelectSingleNode(".//div[1]/div[1]/div/div[1]/h1").InnerText.Trim();
            product.SubTitle = document.GetElementbyId("J_DetailMeta").SelectSingleNode(".//div[1]/div[1]/div/div[1]/p").InnerText.Trim();
            var postage = document.GetElementbyId("J_PostageToggleCont");
            if (postage != null)
            {
                if (postage.InnerText.Trim().IndexOf("包邮") == -1 && postage.InnerText.Trim().Split(':').Length == 2)
                {
                    product.Postage = Convert.ToDouble(postage.InnerText.Trim().Split(':')[1] ?? "0");
                    if (product.Postage > 0)
                    {
                        product.IsFreePostage = false;
                    }
                }
            }
            product.FavCnt = Convert.ToInt16(new Regex("（|）|人气", RegexOptions.IgnoreCase).Replace(document.GetElementbyId("J_CollectCount").InnerText, ""));
            product.SellCnt = Convert.ToInt32(document.GetElementbyId("J_DetailMeta").SelectSingleNode(".//div[1]/div[1]/div/ul/li[1]/div/span[2]").InnerText.Trim());
            product.CommnetCnt = Convert.ToInt32(document.GetElementbyId("J_ItemRates").SelectSingleNode(".//div/span[2]").InnerText.Trim());
            product.Brand = document.GetElementbyId("J_BrandAttr").SelectSingleNode(".//div/a").InnerText.Trim();

            list.Add(product);
            return list;
        }
    }
}

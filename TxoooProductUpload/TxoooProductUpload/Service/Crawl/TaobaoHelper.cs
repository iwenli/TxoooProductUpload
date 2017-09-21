using FSLib.Network.Http;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TxoooProductUpload.Entities.Product;
using TxoooProductUpload.Entities.Resporse;
using TxoooProductUpload.Network;
using System.Linq;

namespace TxoooProductUpload.Service.Crawl
{
    /// <summary>
    /// 淘宝相关处理
    /// </summary>
    public class TaobaoHelper : IHelper
    {
        Regex _skuMapRegex = new Regex(@"valItemInfo      : ([\s\S]*?),propertyMemoMap");
        Regex _brandRegex = new Regex(@"品牌:&nbsp;([\s\S]*?)</li>");
        Regex _skuImageRegex = new Regex(@"background:url\(([\s\S]+?)_30x30.jpg\) center no-repeat;");
        int _defaultQuantity = 100;  //默认每个SKU的数量

        /// <summary>
        /// 从淘宝PC详情抓取商品信息
        /// </summary>
        /// <param name="client">HTTP客户端</param>
        /// <param name="product">基本商品信息，必须包含Id,以及Type</param>
        /// <returns></returns>
        public void ProcessItem(NetClient client, ProductSourceInfo product)
        {
            var ctx = client.Create<string>(HttpMethod.Get, product.Url, allowAutoRedirect: true);
            ctx.Send();
            if (!ctx.IsValid())
            {
                throw new Exception(string.Format("未能提交请求,连接：{0}", product.H5Url));
            }

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(ctx.Result);

            #region 解析HTML 获取内容
            var jsNodes = document.DocumentNode.SelectNodes(".//script");
            string json = string.Empty, sourceSkuJson = string.Empty;
            foreach (var item in jsNodes)
            {
                if (item.InnerHtml.IndexOf("var g_config = {") > -1)
                {
                    json = item.InnerHtml.Substring(0, item.InnerHtml.IndexOf(";")).Replace(" ", "")
                        .Replace("+newDate", "0").Replace("!true", "false")
                        .Replace("location.protocol==='http:'?", "\"")
                        .Replace(",\ncounterApi", "\",\ncounterApi").Replace("\nvarg_config=", "");
                }
                if (item.InnerHtml.IndexOf("Hub = {};") > -1)
                {
                    sourceSkuJson = _skuMapRegex.Match(item.InnerHtml).Groups[1].Value;
                }
                if (!json.IsNullOrEmpty() && !sourceSkuJson.IsNullOrEmpty())
                {
                    break;
                }
            }
            if (json.IsNullOrEmpty())
            {
                throw new Exception("淘宝抓取异常，g_config为空");
            }
            #endregion

            var thumModel = JsonConvert.DeserializeObject<TaoBaoProductResult>(json);


            var detailJsonUrl = @"https://detailskip.taobao.com/service/getData/1/p1/item/detail/sib.htm?itemId={0}&sellerId={1}&modules=delivery,soldQuantity,xmpPromotion&callback="
                                .FormatWith(product.Id, thumModel.sellerId);
            var ctxJson = client.Create<string>(HttpMethod.Get, detailJsonUrl, refer: product.Url, allowAutoRedirect: true);
            ctxJson.Send();
            if (!ctxJson.IsValid())
            {
                throw new Exception(string.Format("未能提交请求,连接：{0}", detailJsonUrl));
            }

            TaoBaoProductDetailResult detailModel = null;
            try
            {
                detailModel = JsonConvert.DeserializeObject<TaoBaoProductDetailResult>(ctxJson.Result);
                if (detailModel.code.code != 0)
                {
                    throw new Exception("淘宝抓取异常，{0}请求失败！".FormatWith(detailJsonUrl));
                }
            }
            catch (Exception ex)
            {
                Iwenli.LogHelper.LogFatal(this, "当前请求{0}已被淘宝屏蔽，请使用收费接口！".FormatWith(detailJsonUrl));
                //throw new Exception("当前请求{0}已被淘宝屏蔽，请使用收费接口！".FormatWith(detailJsonUrl), ex);
            }


            //显示的价格
            if (product.ShowPrice == 0)
            {
                product.ShowPrice = Convert.ToDouble(document.GetElementbyId("J_StrPrice").InnerText.Replace("&yen;", "").Split('-')[0]);
            }
            //品牌
            if (_brandRegex.IsMatch(ctx.Result))
            {
                product.Brand = _brandRegex.Match(ctx.Result).Groups[1].Value.Trim();
            }

            #region 基本信息 没有拿到子标题 收藏数 评价数
            product.UserNick = thumModel.sellerNick;
            product.ShopName = thumModel.shopName;
            product.UserId = thumModel.sellerId;

            product.ProductName = thumModel.idata.item.title;
            //product.SubTitle = detailModel.item.subtitle;  淘宝没有子标题
            foreach (var url in thumModel.idata.item.auctionImages)
            {
                product.AddThumImgWithCheck(url);
            }
            //product.FavCnt = detailModel.item.favcount;  //收藏没有拿到
            //product.CommnetCnt = mdSkipModel.item.commentCount;  //评价数量没有拿到
            if (detailModel != null)
            {
                product.SellCnt = detailModel.data.soldQuantity.soldTotalCount;
                product.Location = product.Location ?? detailModel.data.deliveryFee.data.sendCity;
            }

            #endregion

            #region 邮费 以及 包邮处理
            if (product.Postage == 0 && detailModel != null && detailModel.data.deliveryFee.data.serviceInfo != null
                && detailModel.data.deliveryFee.data.serviceInfo.list != null)
            {
                var postageInfo = detailModel.data.deliveryFee.data.serviceInfo.list.FirstOrDefault(m => m.isDefault == true);
                if (postageInfo != null && postageInfo.info != "快递 免运费")
                {
                    product.Postage = Convert.ToDouble(postageInfo.info.Replace("快递 <span class=\"wl-yen\">&yen;</span>", "") ?? "0");
                    if (product.Postage > 0)
                    {
                        product.IsFreePostage = false;
                    }
                }
            }
            #endregion

            #region 详情
            var descUrl = (Regex.Split(thumModel.descUrl, "':'")[1] ?? "").Replace("'", "");
            if (!descUrl.IsNullOrEmpty() && !descUrl.StartsWith("http"))
            {
                descUrl = "http:" + descUrl;
            }
            var descCtx = new NetClient().Create<string>(HttpMethod.Get, descUrl, refer: product.H5Url);
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
            #endregion

            #region SKU
            var propNodes = document.DocumentNode.SelectNodes("//dl[starts-with(@class,'J_Prop')]"); //获取属性标签
            if (propNodes != null)
            {
                if (sourceSkuJson.IsNullOrEmpty())
                {
                    sourceSkuJson = "{}";
                }
                else
                {
                    sourceSkuJson = sourceSkuJson + "}";
                }
                var sourceSkuModel = JsonConvert.DeserializeObject<TaoBaoProductSoureSkuResult>(sourceSkuJson);
                switch (propNodes.Count)
                {
                    case 1:
                        #region 1级SKU
                        foreach (var prop0 in propNodes[0].SelectNodes(".//li"))
                        {
                            //var prop0Name = prop0.ParentNode.Attributes["data-property"].Value;
                            var prop0Id = prop0.Attributes["data-value"].Value;
                            var prop0Value = prop0.SelectSingleNode(".//span").InnerText;
                            var image = string.Empty;
                            //var txoooImage = string.Empty;
                            var styleHtml = prop0.SelectSingleNode(".//a").Attributes["style"];
                            if (styleHtml != null && _skuImageRegex.IsMatch(styleHtml.Value))
                            {
                                image = _skuImageRegex.Match(styleHtml.Value).Groups[1].Value;
                            }
                            //#region SKU图片直接上传到Txooo中
                            //if (!image.IsNullOrEmpty())
                            //{
                            //    if (!image.StartsWith("http"))
                            //    {
                            //        image = "http:" + image;
                            //    }
                            //    try
                            //    {
                            //        txoooImage = imageService.UploadImg(image);
                            //    }
                            //    catch (Exception ex)
                            //    {
                            //        Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                            //            .FormatWith(product.SourceName, product.Id, image, ex.Message));
                            //    }
                            //}
                            //#endregion

                            var skuPath = ";{0};".FormatWith(prop0Id);

                            TxoooProductSKU sku = new TxoooProductSKU();
                            sku.Name = "{0}".FormatWith(prop0Value);
                            sku.Image = image ?? "";
                            //sku.TxoooImage = txoooImage;
                            if (!sku.Image.IsNullOrEmpty())
                            {
                                //sku.TxoooImage =
                            }

                            var skuSourceInfo = sourceSkuModel.skuMap.FirstOrDefault(m => m.Key == skuPath);
                            if (detailModel != null)
                            {
                                var skuInfo = detailModel.data.promotion.promoData.FirstOrDefault(m => m.Key == skuPath);
                                if (!skuInfo.Key.IsNullOrEmpty())
                                {
                                    //如果打折  显示打折价格
                                    sku.Price = Convert.ToDouble(skuInfo.Value.First().price ?? "0");
                                }
                            }
                            else if (!skuSourceInfo.Key.IsNullOrEmpty())
                            {
                                //如果不打折  显示原价
                                sku.Price = Convert.ToDouble(skuSourceInfo.Value.price ?? "0");
                            }
                            else
                            {
                                sku.Price = product.ShowPrice;// throw new Exception("抓取淘宝SKU价格异常！");
                            }
                            sku.Quantity = _defaultQuantity;
                            product.AddSku(sku);
                        }
                        #endregion
                        break;
                    case 2:
                        #region 2级SKU
                        foreach (var prop1 in propNodes[1].SelectNodes(".//li"))
                        {
                            //var prop1Name = prop1.ParentNode.Attributes["data-property"].Value;
                            var prop1Id = prop1.Attributes["data-value"].Value;
                            var prop1Value = prop1.SelectSingleNode(".//span").InnerText;
                            var image1 = string.Empty;
                            //var txoooImage = string.Empty;
                            var styleHtml = prop1.SelectSingleNode(".//a").Attributes["style"];
                            if (styleHtml != null && _skuImageRegex.IsMatch(styleHtml.Value))
                            {
                                image1 = _skuImageRegex.Match(styleHtml.Value).Groups[1].Value;
                            }
                            //#region SKU图片直接上传到Txooo中
                            //if (!image.IsNullOrEmpty())
                            //{
                            //    if (!image.StartsWith("http"))
                            //    {
                            //        image = "http:" + image;
                            //    }
                            //    try
                            //    {
                            //        txoooImage = imageService.UploadImg(image);
                            //    }
                            //    catch (Exception ex)
                            //    {
                            //        Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                            //            .FormatWith(product.SourceName, product.Id, image, ex.Message));
                            //    }
                            //}
                            //#endregion
                            foreach (var prop0 in propNodes[0].SelectNodes(".//li"))
                            {
                                //var prop0Name = prop0.ParentNode.Attributes["data-property"].Value;
                                var prop0Id = prop0.Attributes["data-value"].Value;
                                var prop0Value = prop0.SelectSingleNode(".//span").InnerText;
                                var image0 = string.Empty;
                                styleHtml = prop0.SelectSingleNode(".//a").Attributes["style"];
                                if (styleHtml != null && _skuImageRegex.IsMatch(styleHtml.Value))
                                {
                                    image0 = _skuImageRegex.Match(styleHtml.Value).Groups[1].Value;
                                    //#region SKU图片直接上传到Txooo中
                                    //if (!image.IsNullOrEmpty())
                                    //{
                                    //    if (!image.StartsWith("http"))
                                    //    {
                                    //        image = "http:" + image;
                                    //    }
                                    //    try
                                    //    {
                                    //        txoooImage = imageService.UploadImg(image);
                                    //    }
                                    //    catch (Exception ex)
                                    //    {
                                    //        Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                                    //            .FormatWith(product.SourceName, product.Id, image, ex.Message));
                                    //    }
                                    //}
                                    //#endregion
                                }

                                var skuPath = ";{0};{1};".FormatWith(prop0Id, prop1Id);

                                TxoooProductSKU sku = new TxoooProductSKU();
                                sku.Name = "{0}-{1}".FormatWith(prop0Value, prop1Value);
                                sku.Image = image0 ?? image1 ?? "";
                                //sku.TxoooImage = txoooImage;

                                var skuSourceInfo = sourceSkuModel.skuMap.FirstOrDefault(m => m.Key == skuPath);
                                if (detailModel != null)
                                {
                                    var skuInfo = detailModel.data.promotion.promoData.FirstOrDefault(m => m.Key == skuPath);
                                    if (!skuInfo.Key.IsNullOrEmpty())
                                    {
                                        //如果打折  显示打折价格
                                        sku.Price = Convert.ToDouble(skuInfo.Value.First().price ?? "0");
                                    }
                                }
                                else if (!skuSourceInfo.Key.IsNullOrEmpty())
                                {
                                    //如果不打折  显示原价
                                    sku.Price = Convert.ToDouble(skuSourceInfo.Value.price ?? "0");
                                }
                                else
                                {
                                    sku.Price = product.ShowPrice;// throw new Exception("抓取淘宝SKU价格异常！");
                                }
                                sku.Quantity = _defaultQuantity;
                                product.AddSku(sku);
                            }
                        }
                        #endregion
                        break;
                    case 3:
                        #region 3级SKU
                        foreach (var prop2 in propNodes[2].SelectNodes(".//li"))
                        {
                            var prop2Id = prop2.Attributes["data-value"].Value;
                            var prop2Value = prop2.SelectSingleNode(".//span").InnerText;
                            var image2 = string.Empty;
                            //var txoooImage = string.Empty;
                            var styleHtml = prop2.SelectSingleNode(".//a").Attributes["style"];
                            if (styleHtml != null && _skuImageRegex.IsMatch(styleHtml.Value))
                            {
                                image2 = _skuImageRegex.Match(styleHtml.Value).Groups[1].Value;
                            }
                            //#region SKU图片直接上传到Txooo中
                            //if (!image.IsNullOrEmpty())
                            //{
                            //    if (!image.StartsWith("http"))
                            //    {
                            //        image = "http:" + image;
                            //    }
                            //    try
                            //    {
                            //        txoooImage = imageService.UploadImg(image);
                            //    }
                            //    catch (Exception ex)
                            //    {
                            //        Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                            //            .FormatWith(product.SourceName, product.Id, image, ex.Message));
                            //    }
                            //}
                            //#endregion
                            foreach (var prop1 in propNodes[1].SelectNodes(".//li"))
                            {
                                var prop1Id = prop1.Attributes["data-value"].Value;
                                var prop1Value = prop1.SelectSingleNode(".//span").InnerText;
                                var image1 = string.Empty;

                                styleHtml = prop1.SelectSingleNode(".//a").Attributes["style"];
                                if (styleHtml != null && _skuImageRegex.IsMatch(styleHtml.Value))
                                {
                                    image1 = _skuImageRegex.Match(styleHtml.Value).Groups[1].Value;
                                    //#region SKU图片直接上传到Txooo中
                                    //if (!image.IsNullOrEmpty())
                                    //{
                                    //    if (!image.StartsWith("http"))
                                    //    {
                                    //        image = "http:" + image;
                                    //    }
                                    //    try
                                    //    {
                                    //        txoooImage = imageService.UploadImg(image);
                                    //    }
                                    //    catch (Exception ex)
                                    //    {
                                    //        Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                                    //            .FormatWith(product.SourceName, product.Id, image, ex.Message));
                                    //    }
                                    //}
                                    //#endregion
                                }

                                foreach (var prop0 in propNodes[0].SelectNodes(".//li"))
                                {
                                    var prop0Id = prop0.Attributes["data-value"].Value;
                                    var prop0Value = prop0.SelectSingleNode(".//span").InnerText;
                                    var image0 = string.Empty;
                                    styleHtml = prop0.SelectSingleNode(".//a").Attributes["style"];
                                    if (image0.IsNullOrEmpty() && styleHtml != null && _skuImageRegex.IsMatch(styleHtml.Value))
                                    {
                                        image0 = _skuImageRegex.Match(styleHtml.Value).Groups[1].Value;
                                        //#region SKU图片直接上传到Txooo中
                                        //if (!image.IsNullOrEmpty())
                                        //{
                                        //    if (!image.StartsWith("http"))
                                        //    {
                                        //        image = "http:" + image;
                                        //    }
                                        //    try
                                        //    {
                                        //        txoooImage = imageService.UploadImg(image);
                                        //    }
                                        //    catch (Exception ex)
                                        //    {
                                        //        Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                                        //            .FormatWith(product.SourceName, product.Id, image, ex.Message));
                                        //    }
                                        //}
                                        //#endregion
                                    }

                                    var skuPath = ";{0};{1};{2};".FormatWith(prop0Id, prop1Id, prop2Id);

                                    TxoooProductSKU sku = new TxoooProductSKU();
                                    sku.Name = "{0}-{1}-{2}".FormatWith(prop0Value, prop1Value, prop2Value);
                                    sku.Image = image0 ?? image1 ?? image2 ?? "";
                                    //sku.TxoooImage = txoooImage;

                                    var skuSourceInfo = sourceSkuModel.skuMap.FirstOrDefault(m => m.Key == skuPath);
                                    if (detailModel != null)
                                    {
                                        var skuInfo = detailModel.data.promotion.promoData.FirstOrDefault(m => m.Key == skuPath);
                                        if (!skuInfo.Key.IsNullOrEmpty())
                                        {
                                            //如果打折  显示打折价格
                                            sku.Price = Convert.ToDouble(skuInfo.Value.First().price ?? "0");
                                        }
                                    }
                                    else if (!skuSourceInfo.Key.IsNullOrEmpty())
                                    {
                                        //如果不打折  显示原价
                                        sku.Price = Convert.ToDouble(skuSourceInfo.Value.price ?? "0");
                                    }
                                    else
                                    {
                                        sku.Price = product.ShowPrice;// throw new Exception("抓取淘宝SKU价格异常！");
                                    }
                                    sku.Quantity = _defaultQuantity;
                                    product.AddSku(sku);
                                }
                            }
                        }
                        #endregion
                        break;
                    case 4:
                        #region 4级SKU
                        foreach (var prop3 in propNodes[3].SelectNodes(".//li"))
                        {
                            var prop3Id = prop3.Attributes["data-value"].Value;
                            var prop3Value = prop3.SelectSingleNode(".//span").InnerText;
                            var image3 = string.Empty;
                            //var txoooImage = string.Empty;
                            var styleHtml = prop3.SelectSingleNode(".//a").Attributes["style"];
                            if (styleHtml != null && _skuImageRegex.IsMatch(styleHtml.Value))
                            {
                                image3 = _skuImageRegex.Match(styleHtml.Value).Groups[1].Value;
                            }

                            foreach (var prop2 in propNodes[2].SelectNodes(".//li"))
                            {
                                var prop2Id = prop2.Attributes["data-value"].Value;
                                var prop2Value = prop2.SelectSingleNode(".//span").InnerText;
                                var image2 = string.Empty;
                                styleHtml = prop2.SelectSingleNode(".//a").Attributes["style"];
                                if (styleHtml != null && _skuImageRegex.IsMatch(styleHtml.Value))
                                {
                                    image2 = _skuImageRegex.Match(styleHtml.Value).Groups[1].Value;
                                    //#region SKU图片直接上传到Txooo中
                                    //if (!image.IsNullOrEmpty())
                                    //{
                                    //    if (!image.StartsWith("http"))
                                    //    {
                                    //        image = "http:" + image;
                                    //    }
                                    //    try
                                    //    {
                                    //        txoooImage = imageService.UploadImg(image);
                                    //    }
                                    //    catch (Exception ex)
                                    //    {
                                    //        Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                                    //            .FormatWith(product.SourceName, product.Id, image, ex.Message));
                                    //    }
                                    //}
                                    //#endregion
                                }

                                foreach (var prop1 in propNodes[1].SelectNodes(".//li"))
                                {
                                    var prop1Id = prop1.Attributes["data-value"].Value;
                                    var prop1Value = prop1.SelectSingleNode(".//span").InnerText;
                                    var image1 = string.Empty;
                                    styleHtml = prop1.SelectSingleNode(".//a").Attributes["style"];
                                    if (styleHtml != null && _skuImageRegex.IsMatch(styleHtml.Value))
                                    {
                                        image1 = _skuImageRegex.Match(styleHtml.Value).Groups[1].Value;
                                        //#region SKU图片直接上传到Txooo中
                                        //if (!image.IsNullOrEmpty())
                                        //{
                                        //    if (!image.StartsWith("http"))
                                        //    {
                                        //        image = "http:" + image;
                                        //    }
                                        //    try
                                        //    {
                                        //        txoooImage = imageService.UploadImg(image);
                                        //    }
                                        //    catch (Exception ex)
                                        //    {
                                        //        Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                                        //            .FormatWith(product.SourceName, product.Id, image, ex.Message));
                                        //    }
                                        //}
                                        //#endregion
                                    }

                                    foreach (var prop0 in propNodes[0].SelectNodes(".//li"))
                                    {
                                        var prop0Id = prop0.Attributes["data-value"].Value;
                                        var prop0Value = prop0.SelectSingleNode(".//span").InnerText;
                                        var image0 = string.Empty;
                                        styleHtml = prop0.SelectSingleNode(".//a").Attributes["style"];
                                        if (styleHtml != null && _skuImageRegex.IsMatch(styleHtml.Value))
                                        {
                                            image0 = _skuImageRegex.Match(styleHtml.Value).Groups[1].Value;
                                            //#region SKU图片直接上传到Txooo中
                                            //if (!image.IsNullOrEmpty())
                                            //{
                                            //    if (!image.StartsWith("http"))
                                            //    {
                                            //        image = "http:" + image;
                                            //    }
                                            //    try
                                            //    {
                                            //        txoooImage = imageService.UploadImg(image);
                                            //    }
                                            //    catch (Exception ex)
                                            //    {
                                            //        Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                                            //            .FormatWith(product.SourceName, product.Id, image, ex.Message));
                                            //    }
                                            //}
                                            //#endregion
                                        }

                                        var skuPath = ";{0};{1};{2};{3};".FormatWith(prop0Id, prop1Id, prop2Id, prop3Id);

                                        TxoooProductSKU sku = new TxoooProductSKU();
                                        sku.Name = "{0}-{1}-{2}-{3}".FormatWith(prop0Value, prop1Value, prop2Value, prop3Value);
                                        sku.Image = image0 ?? image1 ?? image2 ?? image3 ?? "";
                                        //sku.TxoooImage = txoooImage;

                                        var skuSourceInfo = sourceSkuModel.skuMap.FirstOrDefault(m => m.Key == skuPath);
                                        if (detailModel != null)
                                        {
                                            var skuInfo = detailModel.data.promotion.promoData.FirstOrDefault(m => m.Key == skuPath);
                                            if (!skuInfo.Key.IsNullOrEmpty())
                                            {
                                                //如果打折  显示打折价格
                                                sku.Price = Convert.ToDouble(skuInfo.Value.First().price ?? "0");
                                            }
                                        }
                                        else if (!skuSourceInfo.Key.IsNullOrEmpty())
                                        {
                                            //如果不打折  显示原价
                                            sku.Price = Convert.ToDouble(skuSourceInfo.Value.price ?? "0");
                                        }
                                        else
                                        {
                                            sku.Price = product.ShowPrice;// throw new Exception("抓取淘宝SKU价格异常！");
                                        }
                                        sku.Quantity = _defaultQuantity;
                                        product.AddSku(sku);
                                    }
                                }
                            }
                        }
                        #endregion
                        break;
                    default:
                        throw new Exception("暂不支持淘宝4级以上sku 请联系开发人员！");
                }
            } 
            #endregion

            //评价数量接口 https://rate.taobao.com/detailCount.do?itemId=542469108642&&callback=

            #region 接口测试代码  勿动
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
            #endregion
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
                if (productNodeList != null)
                {
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
                            product.SourceType = temp.SelectSingleNode("//span[@class='icon-service-tianmao']") == null
                                && temp.SelectSingleNode("//span[@class='icon-service-tianmaoguoji']") == null ?
                             SourceType.Taobao : SourceType.Tmall;

                            product.ShowPrice = Convert.ToDouble(picElement.Attributes["trace-price"].Value ?? "0");
                            product.FirstImg = picElement.SelectSingleNode("//img").Attributes["data-src"].Value;

                            product.IsFreePostage = temp.SelectSingleNode("//div[@class='ship icon-service-free']") != null;
                            product.ProductName = temp.SelectSingleNode("//a[@class='J_ClickStat']").InnerText.Trim();

                            var dealCnt = temp.SelectSingleNode("//div[@class='deal-cnt']");
                            if (dealCnt != null)
                            {
                                product.DealCnt = Convert.ToInt32(dealCnt.InnerText.Trim().Replace("人付款", ""));
                            }
                            product.UserNick = temp.SelectSingleNode("//a[@class='shopname J_MouseEneterLeave J_ShopInfo']").InnerText;
                            product.UserId = Convert.ToInt64(temp.SelectSingleNode("//a[@class='shopname J_MouseEneterLeave J_ShopInfo']").Attributes["data-userid"].Value);
                            product.Location = temp.SelectSingleNode("//div[@class='location']").InnerText.Trim();

                            list.Add(product);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("解析淘宝搜索结果异常", ex);
            }
            return list;
        }

        /// <summary>
        /// 从淘宝商品展示中获取商品信息
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public List<ProductSourceInfo> GetProductbyHtml(HtmlDocument document)
        {
            var list = new List<ProductSourceInfo>();
            var product = new ProductSourceInfo();
            product.IsProcess = true;
            product.SourceType = SourceType.Taobao;

            return list;
        }
    }
}

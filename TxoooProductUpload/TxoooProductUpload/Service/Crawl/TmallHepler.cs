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
        Regex _userIdRegex = new Regex(@"userid=(\d+);");
        Regex _jsonRegex = new Regex(@"TShop.Setup\(([\s\S]+?)\);");
        Regex _skuImageRegex = new Regex(@"background:url\(([\s\S]+?)\)");
        Regex _filterSkuNameReg = new Regex(@"[\n\t|已选中]*");
        int _defaultQuantity = 100;  //默认每个SKU的数量

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
        public void ProcessItem(NetClient client, ProductSourceInfo product)
        {
            var ctx = client.Create<string>(HttpMethod.Get, product.H5Url, allowAutoRedirect: true);
            ctx.Send();
            if (!ctx.IsValid())
            {
                throw new Exception(string.Format("未能提交请求,连接：{0}", product.H5Url));
            }

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(ctx.Result);

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
            if (mdSkipModel.delivery.postage.IndexOf("包邮") == -1)
            {
                if (mdSkipModel.delivery.postage.IndexOf("快递") > -1)
                {
                    product.Postage = Convert.ToDouble(mdSkipModel.delivery.postage.Split(':')[1] ?? "0");
                    if (product.Postage > 0)
                    {
                        product.IsFreePostage = false;
                    }
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
                        //#region SKU图片直接上传到Txooo中
                        //if (!sku.Image.IsNullOrEmpty())
                        //{
                        //    if (!sku.Image.StartsWith("http"))
                        //    {
                        //        sku.Image = "http:" + sku.Image;
                        //    }
                        //    try
                        //    {
                        //        sku.TxoooImage = imageService.UploadImg(sku.Image);
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                        //            .FormatWith(product.SourceName, product.Id, sku.Image, ex.Message));
                        //    }
                        //}
                        //#endregion

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
                        //var image1 = prop1.image;
                        // var txoooImage = string.Empty;
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

                            //var image0 = string.Empty;
                            //if (!prop0.image.IsNullOrEmpty())
                            //{
                            //    image0 = prop0.image;
                            //    //#region SKU图片直接上传到Txooo中
                            //    //if (!image.IsNullOrEmpty())
                            //    //{
                            //    //    if (!image.StartsWith("http"))
                            //    //    {
                            //    //        image = "http:" + image;
                            //    //    }
                            //    //    try
                            //    //    {
                            //    //        txoooImage = imageService.UploadImg(image);
                            //    //    }
                            //    //    catch (Exception ex)
                            //    //    {
                            //    //        Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                            //    //            .FormatWith(product.SourceName, product.Id, image, ex.Message));
                            //    //    }
                            //    //}
                            //    //#endregion
                            //}

                            TxoooProductSKU sku = new TxoooProductSKU();
                            sku.Name = "{0}-{1}".FormatWith(prop0.name, prop1.name);
                            sku.Image = prop0.image ?? prop1.image ?? "";
                            //sku.TxoooImage = txoooImage;

                            var skuInfo = mdSkipModel.skuCore.sku2info.FirstOrDefault(m => m.Key == skuId);
                            sku.Quantity = skuInfo.Value.quantity;
                            sku.Price = skuInfo.Value.price.priceMoney / 100.00;
                            product.AddSku(sku);
                        }
                    }
                    #endregion
                    break;
                case 3:
                    #region 3级属性
                    foreach (var prop0 in detailModel.skuBase.props[0].values)
                    {
                        var skuPath0 = "{0}:{1}".FormatWith(detailModel.skuBase.props[0].pid, prop0.vid);
                        foreach (var prop1 in detailModel.skuBase.props[1].values)
                        {
                            var skuPath1 = "{0}:{1}".FormatWith(detailModel.skuBase.props[1].pid, prop1.vid);
                            foreach (var prop2 in detailModel.skuBase.props[2].values)
                            {
                                var skuPath2 = "{0}:{1}".FormatWith(detailModel.skuBase.props[2].pid, prop2.vid);
                                var skuPath = "{0};{1};{2}".FormatWith(skuPath0, skuPath1, skuPath2);
                                var skuBase = detailModel.skuBase.skus.FirstOrDefault(m => m.propPath == skuPath);
                                if (skuBase == null)
                                {
                                    skuPath = "{0}{1}{2}".FormatWith(skuPath0, skuPath1, skuPath2);
                                    skuBase = detailModel.skuBase.skus.FirstOrDefault(m => m.propPath == skuPath);
                                }
                                var skuId = skuBase.skuId;
                                TxoooProductSKU sku = new TxoooProductSKU();
                                sku.Name = "{0}-{1}-{2}".FormatWith(prop0.name, prop1.name, prop2.name);
                                sku.Image = prop0.image ?? prop1.image ?? prop2.image ?? "";
                                var skuInfo = mdSkipModel.skuCore.sku2info.FirstOrDefault(m => m.Key == skuId);
                                sku.Quantity = skuInfo.Value.quantity;
                                sku.Price = skuInfo.Value.price.priceMoney / 100.00;
                                product.AddSku(sku);
                            }
                        }
                    }
                    #endregion
                    break;
                case 4:
                    #region 4级属性
                    foreach (var prop0 in detailModel.skuBase.props[0].values)
                    {
                        var skuPath0 = "{0}:{1}".FormatWith(detailModel.skuBase.props[0].pid, prop0.vid);
                        //var image0 = prop0.image;
                        //var txoooImage = string.Empty;
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

                        foreach (var prop1 in detailModel.skuBase.props[1].values)
                        {
                            var skuPath1 = "{0}:{1}".FormatWith(detailModel.skuBase.props[1].pid, prop1.vid);
                            //var image1 = string.Empty;
                            //if (!prop1.image.IsNullOrEmpty())
                            //{
                            //    image1 = prop1.image;
                            //    //#region SKU图片直接上传到Txooo中
                            //    //if (!image.IsNullOrEmpty())
                            //    //{
                            //    //    if (!image.StartsWith("http"))
                            //    //    {
                            //    //        image = "http:" + image;
                            //    //    }
                            //    //    try
                            //    //    {
                            //    //        txoooImage = imageService.UploadImg(image);
                            //    //    }
                            //    //    catch (Exception ex)
                            //    //    {
                            //    //        Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                            //    //            .FormatWith(product.SourceName, product.Id, image, ex.Message));
                            //    //    }
                            //    //}
                            //    //#endregion
                            //}

                            foreach (var prop2 in detailModel.skuBase.props[2].values)
                            {
                                var skuPath2 = "{0}:{1}".FormatWith(detailModel.skuBase.props[2].pid, prop2.vid);
                                //var image2 = string.Empty;
                                //if (!prop2.image.IsNullOrEmpty())
                                //{
                                //    image2 = prop2.image;
                                //    //#region SKU图片直接上传到Txooo中
                                //    //if (!image.IsNullOrEmpty())
                                //    //{
                                //    //    if (!image.StartsWith("http"))
                                //    //    {
                                //    //        image = "http:" + image;
                                //    //    }
                                //    //    try
                                //    //    {
                                //    //        txoooImage = imageService.UploadImg(image);
                                //    //    }
                                //    //    catch (Exception ex)
                                //    //    {
                                //    //        Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                                //    //            .FormatWith(product.SourceName, product.Id, image, ex.Message));
                                //    //    }
                                //    //}
                                //    //#endregion
                                //}
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
                                    if (skuBase == null)
                                    {
                                        continue;
                                    }
                                    var skuId = skuBase.skuId;
                                    //var image3 = string.Empty;
                                    //if (!prop3.image.IsNullOrEmpty())
                                    //{
                                    //    image3 = prop3.image;
                                    //    //#region SKU图片直接上传到Txooo中
                                    //    //if (!image.IsNullOrEmpty())
                                    //    //{
                                    //    //    if (!image.StartsWith("http"))
                                    //    //    {
                                    //    //        image = "http:" + image;
                                    //    //    }
                                    //    //    try
                                    //    //    {
                                    //    //        txoooImage = imageService.UploadImg(image);
                                    //    //    }
                                    //    //    catch (Exception ex)
                                    //    //    {
                                    //    //        Iwenli.LogHelper.LogFatal(this, "{0}商品{1}上传SKU图片{2}异常{3}"
                                    //    //            .FormatWith(product.SourceName, product.Id, image, ex.Message));
                                    //    //    }
                                    //    //}
                                    //    //#endregion
                                    //}

                                    TxoooProductSKU sku = new TxoooProductSKU();
                                    sku.Name = "{0}-{1}-{2}-{3}".FormatWith(prop0.name, prop1.name, prop2.name, prop3.name);
                                    sku.Image = prop0.image ?? prop1.image ?? prop2.image ?? prop3.image ?? "";
                                    //sku.TxoooImage = txoooImage;
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
                case 0: break;
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
            var json = _jsonRegex.Match(document.DocumentNode.InnerHtml).Groups[1].Value;
            var productInfo = JsonConvert.DeserializeObject<TmallPcProductResult>(json);

            #region USER ID
            //if (_userIdRegex.IsMatch(document.DocumentNode.InnerHtml))
            //{
            //    product.UserId = Convert.ToInt64(_userIdRegex.Match(document.DocumentNode.InnerHtml).Groups[1].Value);
            //}
            product.UserId = productInfo.itemDO.userId;
            #endregion
            #region 商品id
            product.Id = productInfo.itemDO.itemId;
            //if (document.GetElementbyId("side-shop-info") != null)
            //{
            //    product.Id = Convert.ToInt64(document.GetElementbyId("side-shop-info").SelectSingleNode(".//div/h3/div/span").Attributes["data-item"].Value);
            //}
            //else
            //{
            //    product.Id = Convert.ToInt64(document.GetElementbyId("LineZing").SelectSingleNode(".//div/h3/div/span").Attributes["data-item"].Value);
            //} 
            #endregion
            #region 显示的价格
            var priceText = document.GetElementbyId("J_PromoPrice").SelectSingleNode(".//dd/div/span").InnerText.Trim();
            if (priceText.IndexOf("-") > -1)
            {
                priceText = priceText.Split('-')[0];
            }
            product.ShowPrice = Convert.ToDouble(priceText);
            #endregion
            #region 邮费以及包邮
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
            #endregion

            product.ShopName = product.UserNick = document.GetElementbyId("side-shop-info").SelectSingleNode(".//div/h3/div/a").InnerText.Trim();
            product.Location = document.GetElementbyId("J_deliveryAdd").InnerText.Trim();
            product.ProductName = document.GetElementbyId("J_DetailMeta").SelectSingleNode(".//div[1]/div[1]/div/div[1]/h1").InnerText.Trim();
            product.SubTitle = document.GetElementbyId("J_DetailMeta").SelectSingleNode(".//div[1]/div[1]/div/div[1]/p").InnerText.Trim();
            product.FavCnt = Convert.ToInt32(new Regex("（|）|人气", RegexOptions.IgnoreCase).Replace(document.GetElementbyId("J_CollectCount").InnerText, ""));
            product.SellCnt = Convert.ToInt32(document.GetElementbyId("J_DetailMeta").SelectSingleNode(".//div[1]/div[1]/div/ul/li[1]/div/span[2]").InnerText.Trim());
            product.CommnetCnt = Convert.ToInt32(document.GetElementbyId("J_ItemRates").SelectSingleNode(".//div/span[2]").InnerText.Trim());
            product.Brand = document.GetElementbyId("J_BrandAttr").SelectSingleNode(".//div/a").InnerText.Trim();

            #region 主图
            var thumImgs = productInfo.propertyPics.FirstOrDefault(m => m.Key == "default");
            if (thumImgs.Key != null && thumImgs.Value.Length > 0)
            {
                foreach (var img in thumImgs.Value)
                {
                    product.AddThumImgWithCheck(img);
                }
            }
            else
            {
                var thumImgNodes = document.GetElementbyId("J_UlThumb").SelectNodes(".//img");
                if (thumImgNodes != null)
                {
                    foreach (var node in thumImgNodes)
                    {
                        product.AddThumImgWithCheck(node.Attributes["src"].Value.Replace("_60x60q90.jpg", ""));
                    }
                }
            }
            #endregion

            #region 描述
            var detailImgNodes = document.GetElementbyId("description").SelectNodes(".//img");
            if (detailImgNodes != null)
            {
                foreach (var node in detailImgNodes)
                {
                    var imgurl = node.Attributes["src"].Value;
                    if (imgurl == "//img-tmdetail.alicdn.com/tps/i3/T1BYd_XwFcXXb9RTPq-90-90.png")
                    {
                        imgurl = node.Attributes["data-ks-lazyload"].Value;
                    }
                    product.AddDetailImgWithCheck(imgurl);
                }
            }
            #endregion

            #region SKU
            //https://mdskip.taobao.com/core/initItemDetail.htm?isApparel=true&sellerPreview=false&cachedTimestamp=1505936920757&service3C=false&addressLevel=2&isForbidBuyItem=false&isPurchaseMallPage=false&isUseInventoryCenter=false&queryMemberRight=true&tryBeforeBuy=false&cartEnable=true&isAreaSell=false&isRegionLevel=false&itemId=550554404001&isSecKill=false&offlineShop=false&showShopProm=false&tmallBuySupport=true&household=false&callback=setMdskip&timestamp=1505984125364&isg=AiUlGS1eBppwT2ASDT-IzAvytfpfbNkO&isg2=AurqQc9aR2buM8q8doAGPrq_O1BM82-FdJI6fHSjhz3Ip4phXOu-xTDXQeRB
            try
            {
                var propNodes = document.GetElementbyId("J_DetailMeta").SelectNodes("//ul[starts-with(@class,'tm-clear J_TSaleProp')]");
                if (propNodes != null)
                {
                    switch (propNodes.Count)
                    {
                        case 1:
                            #region 1级SKU
                            {
                                //var propName0 = propNodes[0].Attributes["data-property"].Value;
                                foreach (var prop0 in propNodes[0].SelectNodes(".//li"))
                                {
                                    var name0 = prop0.InnerText.Trim();
                                    var path0 = prop0.Attributes["data-value"].Value;
                                    string image0 = null;
                                    if (_skuImageRegex.IsMatch(prop0.OuterHtml))
                                    {
                                        image0 = _skuImageRegex.Match(prop0.OuterHtml).Groups[1].Value.Replace("_40x40q90.jpg", "");
                                    }

                                    var path = ";{0};".FormatWith(path0);
                                    var name = "{0}".FormatWith(name0);
                                    TxoooProductSKU sku = new TxoooProductSKU();
                                    sku.Name = FilterSkuName(name);
                                    sku.Image = image0 ?? "";
                                    var skuInfo = productInfo.valItemInfo.skuMap.FirstOrDefault(m => m.Key == path);
                                    if (skuInfo.Key != null)
                                    {
                                        sku.Price = skuInfo.Value.price;
                                        sku.Quantity = skuInfo.Value.stock;
                                    }
                                    else
                                    {
                                        sku.Price = product.ShowPrice;
                                        sku.Quantity = _defaultQuantity;
                                    }
                                    product.AddSku(sku);
                                }
                            }
                            #endregion
                            break;
                        case 2:
                            #region 2级SKU
                            {
                                //var propName0 = propNodes[0].Attributes["data-property"].Value;
                                foreach (var prop0 in propNodes[0].SelectNodes(".//li"))
                                {
                                    var name0 = prop0.InnerText.Trim();
                                    var path0 = prop0.Attributes["data-value"].Value;
                                    string image0 = null;
                                    if (_skuImageRegex.IsMatch(prop0.OuterHtml))
                                    {
                                        image0 = _skuImageRegex.Match(prop0.OuterHtml).Groups[1].Value.Replace("_40x40q90.jpg", "");
                                    }
                                    foreach (var prop1 in propNodes[1].SelectNodes(".//li"))
                                    {
                                        var name1 = prop1.InnerText.Trim();
                                        var path1 = prop1.Attributes["data-value"].Value;
                                        string image1 = null;
                                        if (_skuImageRegex.IsMatch(prop1.OuterHtml))
                                        {
                                            image1 = _skuImageRegex.Match(prop1.OuterHtml).Groups[1].Value.Replace("_40x40q90.jpg", "");
                                        }

                                        var path = ";{0};{1};".FormatWith(path0, path1);
                                        var name = "{0}-{1}".FormatWith(name0, name1);
                                        TxoooProductSKU sku = new TxoooProductSKU();
                                        sku.Name = FilterSkuName(name);
                                        sku.Image = image0 ?? image1 ?? "";
                                        var skuInfo = productInfo.valItemInfo.skuMap.FirstOrDefault(m => m.Key == path);
                                        if (skuInfo.Key != null)
                                        {
                                            sku.Price = skuInfo.Value.price;
                                            sku.Quantity = skuInfo.Value.stock;
                                        }
                                        else
                                        {
                                            sku.Price = product.ShowPrice;
                                            sku.Quantity = _defaultQuantity;
                                        }
                                        product.AddSku(sku);
                                    }
                                }
                            }
                            #endregion
                            break;
                        case 3:
                            #region 3级SKU
                            {
                                //var propName0 = propNodes[0].Attributes["data-property"].Value;
                                foreach (var prop0 in propNodes[0].SelectNodes(".//li"))
                                {
                                    var name0 = prop0.InnerText.Trim();
                                    var path0 = prop0.Attributes["data-value"].Value;
                                    string image0 = null;
                                    if (_skuImageRegex.IsMatch(prop0.OuterHtml))
                                    {
                                        image0 = _skuImageRegex.Match(prop0.OuterHtml).Groups[1].Value.Replace("_40x40q90.jpg", "");
                                    }
                                    foreach (var prop1 in propNodes[1].SelectNodes(".//li"))
                                    {
                                        var name1 = prop1.InnerText.Trim();
                                        var path1 = prop1.Attributes["data-value"].Value;
                                        string image1 = null;
                                        if (_skuImageRegex.IsMatch(prop1.OuterHtml))
                                        {
                                            image1 = _skuImageRegex.Match(prop1.OuterHtml).Groups[1].Value.Replace("_40x40q90.jpg", "");
                                        }
                                        foreach (var prop2 in propNodes[2].SelectNodes(".//li"))
                                        {
                                            var name2 = prop2.InnerText.Trim();
                                            var path2 = prop2.Attributes["data-value"].Value;
                                            string image2 = null;
                                            if (_skuImageRegex.IsMatch(prop2.OuterHtml))
                                            {
                                                image2 = _skuImageRegex.Match(prop2.OuterHtml).Groups[1].Value.Replace("_40x40q90.jpg", "");
                                            }

                                            var path = ";{0};{1};{2};".FormatWith(path0, path1, path2);
                                            var name = "{0}-{1}-{2}".FormatWith(name0, name1, name2);
                                            TxoooProductSKU sku = new TxoooProductSKU();
                                            sku.Name = FilterSkuName(name);
                                            sku.Image = image0 ?? image1 ?? image2 ?? "";
                                            var skuInfo = productInfo.valItemInfo.skuMap.FirstOrDefault(m => m.Key == path);
                                            if (skuInfo.Key != null)
                                            {
                                                sku.Price = skuInfo.Value.price;
                                                sku.Quantity = skuInfo.Value.stock;
                                            }
                                            else
                                            {
                                                sku.Price = product.ShowPrice;
                                                sku.Quantity = _defaultQuantity;
                                            }
                                            product.AddSku(sku);
                                        }
                                    }
                                }
                            }
                            #endregion
                            break;
                        case 4:
                            #region 4级SKU
                            {
                                //var propName0 = propNodes[0].Attributes["data-property"].Value;
                                foreach (var prop0 in propNodes[0].SelectNodes(".//li"))
                                {
                                    var name0 = prop0.InnerText.Trim();
                                    var path0 = prop0.Attributes["data-value"].Value;
                                    string image0 = null;
                                    if (_skuImageRegex.IsMatch(prop0.OuterHtml))
                                    {
                                        image0 = _skuImageRegex.Match(prop0.OuterHtml).Groups[1].Value.Replace("_40x40q90.jpg", "");
                                    }
                                    foreach (var prop1 in propNodes[1].SelectNodes(".//li"))
                                    {
                                        var name1 = prop1.InnerText.Trim();
                                        var path1 = prop1.Attributes["data-value"].Value;
                                        string image1 = null;
                                        if (_skuImageRegex.IsMatch(prop1.OuterHtml))
                                        {
                                            image1 = _skuImageRegex.Match(prop1.OuterHtml).Groups[1].Value.Replace("_40x40q90.jpg", "");
                                        }
                                        foreach (var prop2 in propNodes[2].SelectNodes(".//li"))
                                        {
                                            var name2 = prop2.InnerText.Trim();
                                            var path2 = prop2.Attributes["data-value"].Value;
                                            string image2 = null;
                                            if (_skuImageRegex.IsMatch(prop2.OuterHtml))
                                            {
                                                image2 = _skuImageRegex.Match(prop2.OuterHtml).Groups[1].Value.Replace("_40x40q90.jpg", "");
                                            }
                                            foreach (var prop3 in propNodes[3].SelectNodes(".//li"))
                                            {
                                                var name3 = prop3.InnerText.Trim();
                                                var path3 = prop3.Attributes["data-value"].Value;
                                                string image3 = null;
                                                if (_skuImageRegex.IsMatch(prop3.OuterHtml))
                                                {
                                                    image3 = _skuImageRegex.Match(prop3.OuterHtml).Groups[1].Value.Replace("_40x40q90.jpg", "");
                                                }

                                                var path = ";{0};{1};{2};{3};".FormatWith(path0, path1, path2, path3);
                                                var name = "{0}-{1}-{2}-{3}".FormatWith(name0, name1, name2, name3);
                                                TxoooProductSKU sku = new TxoooProductSKU();
                                                sku.Name = FilterSkuName(name);
                                                sku.Image = image0 ?? image1 ?? image2 ?? image3 ?? "";
                                                var skuInfo = productInfo.valItemInfo.skuMap.FirstOrDefault(m => m.Key == path);
                                                if (skuInfo.Key != null)
                                                {
                                                    sku.Price = skuInfo.Value.price;
                                                    sku.Quantity = skuInfo.Value.stock;
                                                }
                                                else
                                                {
                                                    sku.Price = product.ShowPrice;
                                                    sku.Quantity = _defaultQuantity;
                                                }
                                                product.AddSku(sku);
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion
                            break;
                        case 0: break;
                        default:
                            throw new Exception("暂不支持天猫4级以上sku 请联系开发人员！");
                    }
                }

            }
            catch (Exception ex)
            {
                Iwenli.LogHelper.LogError(this, "解析{0}商品{1}SKU异常,生成自定义属性".FormatWith(product.SourceName, product.Id), ex);
            }
            #endregion
            list.Add(product);
            return list;
        }

        /// <summary>
        /// 过滤SKU名字中的非法字符
        /// </summary>
        /// <param name="propName"></param>
        /// <returns></returns>
        private string FilterSkuName(string propName)
        {
            return _filterSkuNameReg.Replace(propName, "");
        }
    }
}

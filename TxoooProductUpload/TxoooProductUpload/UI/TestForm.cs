using FSLib.Network.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using TxoooProductUpload.Network;
using TxoooProductUpload.Service.Entities;

namespace TxoooProductUpload.UI
{
    partial class TestForm : FormBase
    {
        NetClient NetClient;
        public TestForm()
        {
            InitializeComponent();
            _context = new Service.ServiceContext();
            NetClient = _context.Session.NetClient;

            button1.Click += async (s, e) =>
            {
                var result = await GetInfoByTmallUrl(textBox1.Text);
            };

        }

        #region 根据天猫商品地址获取商品信息+taoModel GetInfoByTmallUrl(string TmallUrl)
        /// <summary>
        /// 根据天猫商品地址获取商品信息
        /// </summary>
        ///<param name="url">天猫地址</param>
        /// <returns>商品实体信息</returns>
        private async Task<ProductResult> GetInfoByTmallUrl(string url)
        {
            ProductResult productModel = new ProductResult(_context);
            var getDoc = NetClient.Create<HtmlAgilityPack.HtmlDocument>(HttpMethod.Get, url, allowAutoRedirect: true);
            await getDoc.SendAsync();

            string str = "";
            var getTmallHtml = NetClient.Create<string>(HttpMethod.Get, url, allowAutoRedirect: true);
            await getTmallHtml.SendAsync();
            if (!getTmallHtml.IsValid())
            {
                new Exception("未能提交请求");
            }
            str = getTmallHtml.Result;
            //https://detail.m.tmall.com/item.htm?id=536929636061&skuId=3205551032757
            // FSLib.Network.Adapter.HtmlAgilityPack.ResponseHtmlDocumentResult
            var html = getTmallHtml.Result;
            Regex myRegex = new Regex("(?<=>商品图片</h3>)[\\s\\S]+?(?<=</div>\\s*</div>\\s*</div>)");//详情
            Regex imgaeRegex = new Regex("(?<=src=\").+?(?=_640x640q50.jpg)|(?<=src=\").+?(?=_640x640Q50s50.jpg)|(?<=src=\").+?(?=\")");//商品主图
            Regex detailimgRegex = new Regex("(?<=data-ks-lazyload=\").+?(?=\")");//商品详细图片
            Regex priceRegex = new Regex("(?<=\"priceText\":\")\\d+?(?=\")|(?<=\"price\":\")\\d+\\.\\d{1,2}");    //售价
            Regex shopNameRegex = new Regex("(?<=\"shop-t\">).+?(?=</div>)");//店铺名称
            Regex titleRegex = new Regex("(?<=<title>).+?(?= - 天猫Tmall.com)");  //标题
            Regex SKURegex = new Regex("(?<=skuName\":).+?(?<=}]}])");  //SKU
            Regex LocationRegex = new Regex("(?<=\"location\":\").+?(?=\",)|(?<=\"from\":\").+?(?=\",)");  //发货地
            Regex SalesCountRegex = new Regex("(?<=\"sellCount\":).+?(?=,)");  //销量
            Regex RateTotalsRegex = new Regex("(?<=\"commentCount\":).+?(?=,)");  //评价

            try
            {
                //主图
                MatchCollection matchs = imgaeRegex.Matches(new Regex("(?=s-showcase)[\\s\\S]+?(?<=</div>\\s*</div>)|(?=scroller preview-scroller)[\\s\\S]+?(?<=</div>\\s*</div>)").Match(str).Value, 0);
                foreach (Match mat in matchs)
                {
                    string tempmat = mat.Value;
                    if (!tempmat.StartsWith("http"))
                    {
                        tempmat = "http:" + tempmat;
                    }
                    if (!productModel.ThumImg.Contains(tempmat))
                    {
                        productModel.ThumImg.Add(tempmat);
                    }
                }

                //天猫加载商品详情的方式比较复杂
                //详情图片
                productModel.DetailHtml = myRegex.Match(str).Value;
                MatchCollection matches1 = null;

                //https://detail.tmall.com/item.htm?id=552998726618
                if (productModel.DetailHtml.IsNullOrEmpty())
                {
                    string detailUrl = new Regex("(?<=\"descUrl\":\").+?(?=\",)").Match(str).Value;
                    if (!detailUrl.StartsWith("http"))
                    {
                        detailUrl = "http:" + detailUrl;
                    }
                    var detail = NetClient.Create<string>(HttpMethod.Get, detailUrl, allowAutoRedirect: false).Send().Result;
                    matches1 = new Regex("(?<=src=\").+?(?=\")").Matches(detail, 0);
                }
                else
                {
                    matches1 = detailimgRegex.Matches(productModel.DetailHtml, 0);
                }
                foreach (Match mat in matches1)
                {
                    string tempmat = mat.Value;
                    if (!tempmat.StartsWith("http"))
                    {
                        tempmat = "http:" + tempmat;
                    }
                    if (tempmat.IndexOf("assets.alicdn.com/kissy/1.0.0/build/imglazyload/spaceball.gif") == -1
                        && !productModel.DetailImg.Contains(tempmat))
                    {
                        productModel.DetailImg.Add(tempmat);
                    }
                }

                productModel.SKUTmall = JsonConvert.DeserializeObject<List<SkuTmallInfo>>(SKURegex.Match(str.ToString()).Value);//SKU
                                                                                                                                //处理SKU图片
                if (productModel.SKUTmall != null)
                {
                    var skuColor = productModel.SKUTmall.FirstOrDefault(m => m.text.Contains("颜色"));
                    var colorImg = new Regex("(?<=skuPics\":{).*?(?=})").Match(str).Value;
                    if (skuColor != null)
                    {
                        string[] colorImgList;
                        if (colorImg.IsNullOrEmpty())
                        {
                            colorImgList = new string[] { };
                        }
                        else
                        {
                            colorImgList = colorImg.Split(',');
                        }
                        //如果没有SKU图片  从主图拿
                        for (int i = 0; i < skuColor.values.Length; i++)
                        {
                            var img = string.Empty;
                            if (colorImgList.Length < skuColor.values.Length)
                            {
                                img = productModel.ThumImg.FirstOrDefault();
                            }
                            else
                            {
                                img = colorImgList.FirstOrDefault(m => m.Contains(skuColor.values[i].id)).Split(':')[2].Replace("\"", "");
                            }
                            if (!img.StartsWith("http"))
                            {
                                img = "http:" + img;
                            }
                            skuColor.values[i].image = img;
                        }
                    }
                }
                productModel.ProductName = titleRegex.Match(str.ToString()).Value;
                productModel.ShopName = HttpUtility.UrlDecode(shopNameRegex.Match(str.ToString()).Value);
                productModel.ProductPrice = priceRegex.Match(str.ToString()).Value;
                productModel.Location = LocationRegex.Match(str.ToString()).Value;
                productModel.SalesCount = SalesCountRegex.Match(str.ToString()).Value;
                //productModel.RateTotals = RateTotalsRegex.Match(str.ToString()).Value;

                productModel.Source = "天猫";
                productModel.SourceUrl = url;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return productModel;
        }
        #endregion
    }
}

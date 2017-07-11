using FSLib.Network.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using TxoooProductUpload.Common;
using TxoooProductUpload.Network;
using TxoooProductUpload.Service.Entities;

namespace TxoooProductUpload.Service
{
    class UrlConvertProductService : ServiceBase
    {
        public UrlConvertProductService(ServiceContext context) : base(context)
        {
        }

        /// <summary>
        /// 处理URL商品
        /// </summary>
        /// <param name="productUrl">京东、淘宝、天猫、阿里巴巴商品详情页url</param>
        /// <returns></returns>
        public async Task<ProductResult> ProcessProduct(string productUrl)
        {
            Regex taobaoReg = new Regex("item.taobao.com");//淘宝url
            Regex tianmaoReg = new Regex("detail.tmall.com");//天猫
            Regex aliReg = new Regex("detail.1688.com");//阿里巴巴
            Regex jdReg = new Regex("item.jd.com");//京东

            Regex mAliReg = new Regex("m.1688.com");//阿里巴巴手机

            if (taobaoReg.Match(productUrl).Success)
            {
                return GetInfoByTaobaoUrl(productUrl);
            }
            else if (tianmaoReg.Match(productUrl).Success)
            {
                return GetInfoByTmallUrl(productUrl);
            }
            else if (aliReg.Match(productUrl).Success)
            {
                return  await GetInfoByAli(productUrl.Replace("detail.1688.com", "m.1688.com"));
            }
            else if (mAliReg.Match(productUrl).Success)
            {
                return await GetInfoByAli(productUrl);
            }
            else if (jdReg.Match(productUrl).Success)
            {
                return GetInfoByJd(productUrl);
            }
            return null;
        }

        #region 根据Url获取相应字符串+string GetStrByUrl(string url)
        /// <summary>
        /// 根据Url获取相应字符串
        /// </summary>
        /// <param name="url">网址</param>
        /// <returns>网页html代码</returns>
        private string GetStrByUrl(string url, string encodeing)
        {
            string str = "";
            Encoding ecd = string.IsNullOrEmpty(encodeing) ? Encoding.Default : Encoding.GetEncoding(encodeing);
            try
            {
                WebRequest request = HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encodeing));
                str = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                response.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
            }
            return str;
        }
        #endregion

        #region 浏览器根据url打开页面获取页面内容+StringBuilder GetStrByBorwserUrl(string url)
        /// <summary>
        /// 根据浏览器控件打开页面获取页面内容
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private StringBuilder GetStrByBorwserUrl(string url)
        {
            StringBuilder sbHml = new StringBuilder();
            WebBrowser browser = new WebBrowser();
            browser.Navigate(url);
            var result = WaitWebPageLoad(browser);
            while (!result)
            {
                result = WaitWebPageLoad(browser);
            }
            Encoding encoding = Encoding.GetEncoding(browser.Document.Encoding);
            StreamReader stream = new StreamReader(browser.DocumentStream, encoding);
            sbHml.Append(stream.ReadToEnd());
            return sbHml;
        }

        /// <summary>
        /// 延迟系统时间，但系统又能同时能执行其它任务；
        /// </summary>
        /// <param name="Millisecond"></param>
        private static void Delay(int Millisecond) //延迟系统时间，但系统又能同时能执行其它任务；
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(Millisecond) > DateTime.Now)
            {
                Application.DoEvents();//转让控制权            
            }
            return;
        }

        /// <summary>
        /// 判断页面是否加载完毕
        /// </summary>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        private bool WaitWebPageLoad(WebBrowser webBrowser)
        {
            int i = 0;
            string sUrl;
            while (true)
            {
                Delay(50);//系统延迟50毫秒，够少了吧！
                if (webBrowser.ReadyState == WebBrowserReadyState.Complete) //先判断是否发生完成事件。
                {
                    if (!webBrowser.IsBusy) //再判断是浏览器是否繁忙                  
                    {
                        i = i + 1;
                        if (i == 2)
                        {
                            sUrl = webBrowser.Url.ToString();
                            if (sUrl.Contains("res")) //这是判断没有网络的情况下                           
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        continue;
                    }
                    i = 0;
                }
            }
        }
        #endregion

        #region 根据天猫商品地址获取商品信息+taoModel GetInfoByTmallUrl(string TmallUrl)
        /// <summary>
        /// 根据天猫商品地址获取商品信息
        /// </summary>
        ///<param name="TmallUrl">天猫地址</param>
        /// <returns>商品实体信息</returns>
        private ProductResult GetInfoByTmallUrl(string TmallUrl)
        {
            ProductResult taoModel = new ProductResult();
            string Imgstr, str = "";
            str = GetStrByUrl(TmallUrl, "gb2312");
            Regex myRegex = new Regex("(?<=descUrl\":\").+(?=\",\"fetchDcUrl\")");//指定其正则验证式
            Regex imgaeRegex = new Regex("http://img.+60x60q90.jpg|https://img.+60x60q90.jpg|//img.+60x60q90.jpg");//商品图片
            Regex detailimgRegex = new Regex("https://img\\S+jpg|http://img\\S+jpg");//商品详细图片
            Regex ZkPriceRegex = new Regex("(?<=\"comboPrice\":\").+(?=\",\"defaultPromType\")");//折扣后价格
            Regex PriceRegex = new Regex("(?<=\"reservePrice\":\").+(?=\",\"rootCatId\")");//默认价格
            Regex shopNameRegex = new Regex("(?<=\"sellerNickName\":\").+(?=\",\"spuId\")");//店铺名称
            Regex titleRegex = new Regex("(?<=\"title\":\").+(?=\",\"userId\":\")");
            Regex PriceNowRegex = new Regex("");
            string detailImg = myRegex.Match(str).Value;//从指定内容中匹配字符串
            MatchCollection matchs = imgaeRegex.Matches(str, 0);
            string imgUrl = "";
            foreach (Match mat in matchs)
            {
                string tempmat = mat.Value;
                //tempmat = "http:" + tempmat;
                if (!tempmat.StartsWith("http"))
                {
                    tempmat = "http:" + tempmat;
                }
                tempmat = tempmat.Replace("_60x60q90.jpg", "");
                imgUrl += tempmat + "|";
            }
            string price = PriceRegex.Match(str).Value;
            string shopname = shopNameRegex.Match(str).Value.UnicodeToString();
            string title = titleRegex.Match(str).Value;
            //imgUrl = "商品图片："+imgUrl.Substring(0,imgUrl.Length-12);
            Imgstr = GetStrByUrl("http:" + detailImg, "gb2312").Substring(10);
            MatchCollection matches1 = detailimgRegex.Matches(Imgstr, 0);
            string DetailimgUrl = "";
            foreach (Match mat in matches1)
            {
                DetailimgUrl += mat.Value + "|";
            }
            taoModel.product_name = title;
            taoModel.ShopName = shopname;
            taoModel.ProductPrice = price;
            taoModel.ThumImg = imgUrl;
            taoModel.DetailImg = DetailimgUrl;
            taoModel.Source = "天猫";
            taoModel.SourceUrl = TmallUrl;
            return taoModel;
        }
        #endregion

        #region 根据淘宝商品地址获取商品信息+string GetInfoByTaobaoUrl(string TaobaoUrl)
        /// <summary>
        /// 根据淘宝商品地址获取商品信息
        /// </summary>
        /// <param name="TaobaoUrl">淘宝商品地址</param>
        /// <returns>淘宝商品信息</returns>
        private ProductResult GetInfoByTaobaoUrl(string TaobaoUrl)
        {
            ProductResult taoModel = new ProductResult();
            string Imgstr, str = "";
            str = GetStrByUrl(TaobaoUrl, "gb2312");
            Regex myRegex = new Regex("(?<=location\\.protocol===\'http:\' \\? \').+(?=' :)");//指定其正则验证式
            Regex detailimgRegex = new Regex("https://img\\S+jpg|http://img\\S+jpg");//商品详细图片
            Regex imgaeRegex = new Regex("(?<=auctionImages    : \\[).+(?=])");//商品图片
            Regex PriceRegex = new Regex("(?<=price:).+(?=,)");//默认价格
            Regex shopNameRegex = new Regex("(?<=shopName         : ').+(?=',)");//店铺名称
            Regex titleRegex = new Regex("(?<=title.).+(?=-淘宝网)");//商品名称
            string detailImg = myRegex.Match(str).Value.Replace("\"", "").Replace("'", "").Replace(":", "").Trim();//从指定内容中匹配字符串
            string imgUrl = imgaeRegex.Match(str).Value;
            MatchCollection matchs = imgaeRegex.Matches(str, 0);
            imgUrl = imgUrl.Replace("\"", "").Replace(",", "|").Replace("//", "http://").Trim();
            string price = PriceRegex.Match(str).Value;
            string shopname = shopNameRegex.Match(str).Value.UnicodeToString();
            string title = titleRegex.Match(str).Value;
            //imgUrl = "商品图片："+imgUrl.Substring(0,imgUrl.Length-12);
            Imgstr = GetStrByUrl("http:" + detailImg, "gb2312");
            MatchCollection matches1 = detailimgRegex.Matches(Imgstr, 0);
            string DetailimgUrl = "";
            foreach (Match mat in matches1)
            {
                DetailimgUrl += mat.Value + "|";
            }
            taoModel.product_name = title;
            taoModel.ShopName = shopname;
            taoModel.ProductPrice = price;
            taoModel.ThumImg = imgUrl;
            taoModel.DetailImg = DetailimgUrl;
            taoModel.Source = "淘宝";
            taoModel.SourceUrl = TaobaoUrl;
            return taoModel;
        }
        #endregion

        #region 根据阿里巴巴商品地址获取商品信息+TaoModel GetInfoByAli(string AliUrl)
        /// <summary>
        /// 根据阿里巴巴商品地址获取商品信息
        /// </summary>
        /// <param name="AliUrl"></param>
        /// <returns></returns>
        public async Task<ProductResult>  GetInfoByAli(string AliUrl)
        {
            ProductResult taoModel = new ProductResult();
            StringBuilder str = new StringBuilder();
            string Imgstr = "";

            #region 发送请求 获取页面HTML
            var getAliHtml = NetClient.Create<string>(HttpMethod.Get, AliUrl);
            await getAliHtml.SendAsync();
            if (!getAliHtml.IsValid())
            {
                new Exception("未能提交请求");
            }
            str.Append(getAliHtml.Result); // GetStrByBorwserUrl(AliUrl); 
            #endregion
            #region 解析页面HTML
            Regex myRegex = new Regex("(?<=\"detailUrl\":\").+(?=\",\"discount\")");//详情
            Regex imgaeRegex = new Regex("(?<=\"originalImageURI\":\").+?(?=\"})");//商品主图
            //Regex imgaeRegex = new Regex("https://\\S+?.alicdn.com/.+?.310.jpg|http://\\S?+.alicdn.com/.+?.310.jpg|//\\S+?.alicdn.com/.+?.310.jpg");//商品主图
            Regex detailimgRegex = new Regex("https://\\S+.alicdn.com\\S+jpg|http://\\S+.alicdn.com\\S+jpg|//\\S+.alicdn.com\\S+jpg");//商品详细图片
            //Regex ZkPriceRegex = new Regex("(?<=\"discountPriceRanges\":[{\"price\":\").+(?=\",\"convertPrice\")");//折扣后价格
            Regex PriceRegex = new Regex("(?<=\"discountPriceRanges\":\\[{\"price\":\").+?(?=\",\"convertPrice\")");//默认价格
            Regex shopNameRegex = new Regex("(?<=\"companyName\":\").+(?=\",\"coupons\")");//店铺名称
            Regex titleRegex = new Regex("(?<=class=\"d-title\">).+(?=</h1>)");
            string detailImg = myRegex.Match(str.ToString()).Value;//从指定内容中匹配字符串
            MatchCollection matchs = imgaeRegex.Matches(str.ToString(), 0);
            string imgUrl = "";
            foreach (Match mat in matchs)
            {
                string tempmat = mat.Value;
                //tempmat = "http:" + tempmat;
                if (!tempmat.StartsWith("http"))
                {
                    tempmat = "http:" + tempmat;
                }
                tempmat = tempmat.Replace(".310x310", "");
                if (!imgUrl.Contains(tempmat))
                {
                    imgUrl += tempmat + "|";
                }
            }
            string price = PriceRegex.Match(str.ToString()).Value;
            string shopname = HttpUtility.UrlDecode(shopNameRegex.Match(str.ToString()).Value);
            string title = titleRegex.Match(str.ToString()).Value;
            //imgUrl = "商品图片："+imgUrl.Substring(0,imgUrl.Length-12);
            Imgstr = NetClient.Create<string>(HttpMethod.Get, detailImg).Send().Result;   //GetStrByBorwserUrl(detailImg).ToString();
            MatchCollection matches1 = detailimgRegex.Matches(Imgstr, 0);
            string DetailimgUrl = "";
            foreach (Match mat in matches1)
            {
                string tempmat = mat.Value;
                if (!tempmat.StartsWith("http"))
                {
                    tempmat = "http:" + tempmat;
                }
                if (!DetailimgUrl.Contains(tempmat))
                {
                    DetailimgUrl += tempmat + "|";
                }
            }
            taoModel.product_name = title;
            taoModel.ShopName = shopname;
            taoModel.ProductPrice = price;
            taoModel.ThumImg = imgUrl;
            taoModel.DetailImg = DetailimgUrl;
            taoModel.Source = "阿里巴巴";
            taoModel.SourceUrl = AliUrl; 
            #endregion
            return taoModel;
        }
        #endregion

        #region  根据京东商品地址获取商品信息+TaoModel GetInfoByJd(string JdUrl)
        /// <summary>
        /// 根据京东商品地址获取商品信息
        /// </summary>
        /// <param name="JdUrl"></param>
        /// <returns></returns>
        public ProductResult GetInfoByJd(string JdUrl)
        {
            ProductResult taoModel = new ProductResult();
            string Imgstr, str = "";
            str = GetStrByUrl(JdUrl, "gb2312");
            Regex titleRegex = new Regex("(?<=title.).+(?=-京东)");//商品名称
            Regex imgRegex = new Regex("(?<=data-url=')\\S+.jpg|(?<=data-url=')\\S+.png");//获取商品图片
            Regex detailImgRegex = new Regex("(?<=desc: ')\\S+(?=',)");//商品详细图片地址
            Regex dImgRegex = new Regex("//\\S+.jpg|//\\S+.png");//所有详细图片

            string imgUrl = "";
            MatchCollection mact = imgRegex.Matches(str);
            foreach (Match mt in mact)
            {
                imgUrl += string.Concat("http://img13.360buyimg.com/n0/", mt.Value, "|");
            }
            string title = titleRegex.Match(str).Value;

            string detailImg = detailImgRegex.Match(str).Value;

            Imgstr = GetStrByUrl("http:" + detailImg, "gb2312");
            MatchCollection matches1 = dImgRegex.Matches(Imgstr, 0);
            string DetailimgUrl = "";
            foreach (Match mat in matches1)
            {
                DetailimgUrl += string.Concat("http:", mat.Value, "|");
            }
            taoModel.product_name = title;
            taoModel.ProductPrice = "";
            taoModel.ShopName = "";
            taoModel.ThumImg = imgUrl;
            taoModel.DetailImg = DetailimgUrl;
            taoModel.Source = "京东";
            taoModel.SourceUrl = JdUrl;
            return taoModel;
        }
        #endregion

    }
}

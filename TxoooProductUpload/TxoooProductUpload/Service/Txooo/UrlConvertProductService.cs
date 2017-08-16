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
            Regex tmallReg = new Regex("detail.tmall.com");//天猫
            Regex aliReg = new Regex("detail.1688.com");//阿里巴巴
            Regex jdReg = new Regex("item.jd.com");//京东

            Regex mAliReg = new Regex("m.1688.com");//阿里巴巴手机
            Regex mJdReg = new Regex("item.m.jd.com");//京东手机
            Regex mTmallReg = new Regex("detail.m.tmall.com");//天猫手机
            Regex mTaobaoReg = new Regex("h5.m.taobao.com/awp/core/detail.htm");// 淘宝无线
            if (taobaoReg.Match(productUrl).Success)
            {
                var id = new Regex("id=(\\d+)&").Match(productUrl).Groups[1].Value;
                return await GetInfoByTaobaoUrl("https://h5.m.taobao.com/awp/core/detail.htm?id=" + id);
            }
            else if (mTaobaoReg.Match(productUrl).Success)
            {
                return await GetInfoByTaobaoUrl(productUrl);
            }
            else if (tmallReg.Match(productUrl).Success)
            {
                return await GetInfoByTmallUrl(productUrl.Replace("detail.tmall.com", "detail.m.tmall.com"));
            }
            else if (mTmallReg.Match(productUrl).Success)
            {
                return await GetInfoByTmallUrl(productUrl);
            }
            else if (aliReg.Match(productUrl).Success)
            {
                return await GetInfoByAli(productUrl.Replace("detail.1688.com", "m.1688.com"));
            }
            else if (mAliReg.Match(productUrl).Success)
            {
                return await GetInfoByAli(productUrl);
            }
            else if (jdReg.Match(productUrl).Success)
            {
                return await GetInfoByJd(productUrl.Replace("item.jd.com", "item.m.jd.com/product"));
            }
            else if (mJdReg.Match(productUrl).Success)
            {
                return await GetInfoByJd(productUrl);
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
        ///<param name="url">天猫地址</param>
        /// <returns>商品实体信息</returns>
        private async Task<ProductResult> GetInfoByTmallUrl(string url)
        {
            ProductResult productModel = new ProductResult(ServiceContext);
            string str = "";
            var getTmallHtml = NetClient.Create<string>(HttpMethod.Get, url);
            getTmallHtml.Request.AllowAutoRedirect = true;
            await getTmallHtml.SendAsync();
            if (!getTmallHtml.IsValid())
            {
                new Exception("未能提交请求");
            }
            str = getTmallHtml.Result;  //GetStrByUrl(url, "gb2312");//
            Regex myRegex = new Regex("(?<=>商品图片</h3>)[\\s\\S]+?(?<=</div>\\s*</div>\\s*</div>)");//详情
            Regex imgaeRegex = new Regex("(?<=src=\").+?(?=_640x640q50.jpg)");//商品主图
            Regex detailimgRegex = new Regex("(?<=data-ks-lazyload=\").+?(?=\")");//商品详细图片
            Regex priceRegex = new Regex("(?<=\"price\":\")\\d+\\.\\d{1,2}");    //售价
            Regex shopNameRegex = new Regex("(?<=\"shop-t\">).+?(?=</div>)");//店铺名称
            Regex titleRegex = new Regex("(?<=<title>).+?(?= - 天猫Tmall.com)");  //标题
            Regex SKURegex = new Regex("(?<=skuName\":).+?(?<=}]}])");  //SKU
            Regex LocationRegex = new Regex("(?<=\"deliveryAddress\":\").+?(?=\",)");  //发货地
            Regex SalesCountRegex = new Regex("(?<=\"sellCount\":).+?(?=,)");  //销量
            Regex RateTotalsRegex = new Regex("(?<=\"rateCounts\":).+?(?=,)");  //评价

            //主图
            MatchCollection matchs = imgaeRegex.Matches(new Regex("(?=s-showcase)[\\s\\S]+?(?<=</div>\\s*</div>)").Match(str).Value, 0);
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
                var detail = NetClient.Create<string>(HttpMethod.Get, detailUrl).Send().Result;
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
            productModel.RateTotals = RateTotalsRegex.Match(str.ToString()).Value;

            productModel.Source = "天猫";
            productModel.SourceUrl = url;
            return productModel;
        }
        #endregion

        #region 根据淘宝商品地址获取商品信息+string GetInfoByTaobaoUrl(string TaobaoUrl)
        /// <summary>
        /// 根据淘宝商品地址获取商品信息
        /// </summary>
        /// <param name="url">淘宝商品地址</param>
        /// <returns>淘宝商品信息</returns>
        private async Task<ProductResult> GetInfoByTaobaoUrl(string url)
        {
            ProductResult productModel = new ProductResult(ServiceContext);
            string str = "";
            var getTmallHtml = NetClient.Create<string>(HttpMethod.Get, url);
            getTmallHtml.Request.AllowAutoRedirect = true;
            await getTmallHtml.SendAsync();
            if (!getTmallHtml.IsValid())
            {
                new Exception("未能提交请求");
            }
            str = getTmallHtml.Result;  //GetStrByUrl(url, "gb2312");//
            Regex myRegex = new Regex("(?<=>商品图片</h3>)[\\s\\S]+?(?<=</div>\\s*</div>\\s*</div>)");//详情
            Regex imgaeRegex = new Regex("(?<=src=\").+?(?=_640x640q50.jpg)");//商品主图
            Regex detailimgRegex = new Regex("(?<=data-ks-lazyload=\").+?(?=\")");//商品详细图片
            Regex priceRegex = new Regex("(?<=\"price\":\")\\d+\\.\\d{1,2}");    //售价
            Regex shopNameRegex = new Regex("(?<=\"shop-t\">).+?(?=</div>)");//店铺名称
            Regex titleRegex = new Regex("(?<=\"title\":\").+?(?=\",)");  //标题
            Regex SKURegex = new Regex("(?<=skuName\":).+(?<=}]}])");  //SKU
            Regex LocationRegex = new Regex("(?<=\"deliveryAddress\":\").+?(?=\",)");  //发货地
            Regex SalesCountRegex = new Regex("(?<=\"sellCount\":).+?(?=,)");  //销量
            Regex RateTotalsRegex = new Regex("(?<=\"rateCounts\":).+?(?=,)");  //评价

            //基本信息
            //http://unszacs.m.taobao.com/h5/mtop.taobao.detail.getdetail/6.0/?api=mtop.taobao.detail.getdetail&type=jsonp&dataType=jsonp&callback=mtopjsonp1&data={"exParams":"{\"spm\":\"a230r.1.14.116.ebb2eb2xXnVyH\",\"id\":\"550019724604\",\"ns\":\"1\",\"abbucket\":\"3\"}","itemNumId":"550019724604"}
            //http://unszacs.m.taobao.com/h5/mtop.taobao.detail.getdetail/6.0/?appKey=12574478&t=1500831036955&sign=4fcd89c8c775d3775777c102b95f32d3&api=mtop.taobao.detail.getdetail&v=6.0&ttid=2016%40taobao_h5_2.0.0&isSec=0&ecode=0&AntiFlood=true&AntiCreep=true&H5Request=true&type=jsonp&dataType=jsonp&callback=mtopjsonp1&data=%7B%22exParams%22%3A%22%7B%5C%22spm%5C%22%3A%5C%22a230r.1.14.116.ebb2eb2xXnVyH%5C%22%2C%5C%22id%5C%22%3A%5C%22550019724604%5C%22%2C%5C%22ns%5C%22%3A%5C%221%5C%22%2C%5C%22abbucket%5C%22%3A%5C%223%5C%22%7D%22%2C%22itemNumId%22%3A%22550019724604%22%7D
            //详情
            //http://acs.m.taobao.com/h5/mtop.wdetail.getitemdescx/4.1/?appKey=12574478&t=1500831037700&sign=406d6b4389a051641ef2813dc96c4837&api=mtop.wdetail.getItemDescx&v=4.1&isSec=0&ecode=0&H5Request=true&type=jsonp&dataType=jsonp&callback=mtopjsonp1&data=%7B%22item_num_id%22%3A%22550019724604%22%2C%22type%22%3A%220%22%7D


            //http://acs.m.taobao.com/h5/mtop.wdetail.getitemdescx/4.1/?appKey=12574478&t=1500832287064&sign=9d5876b51efe0c0544fb80a768d6b611&api=mtop.wdetail.getItemDescx&v=4.1&isSec=0&ecode=0&H5Request=true&type=jsonp&dataType=jsonp&callback=mtopjsonp1&data=%7B%22item_num_id%22%3A%22550019724604%22%2C%22type%22%3A%220%22%7D
            //http://acs.m.taobao.com/h5/mtop.wdetail.getitemdescx/4.1/?appKey=12574478&t=1500832478815&sign=1ad1c7e3d10a35911609dd9c1ccd0087&api=mtop.wdetail.getItemDescx&v=4.1&isSec=0&ecode=0&H5Request=true&type=jsonp&dataType=jsonp&callback=mtopjsonp1&data=%7B%22item_num_id%22%3A%22550019724604%22%2C%22type%22%3A%220%22%7D
            //21281452        c211167c6bd43f3a2971fc66836a4ed3

            string detailImg = myRegex.Match(str).Value;//从指定内容中匹配字符串
            MatchCollection matchs = imgaeRegex.Matches(new Regex("(?=s-showcase)[\\s\\S]+?(?<=</div>\\s*</div>)").Match(str).Value, 0);
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
            //详情图片
            productModel.DetailHtml = myRegex.Match(str).Value;
            MatchCollection matches1 = detailimgRegex.Matches(productModel.DetailHtml, 0);
            foreach (Match mat in matches1)
            {
                string tempmat = mat.Value;
                if (!tempmat.StartsWith("http"))
                {
                    tempmat = "http:" + tempmat;
                }
                if (!productModel.DetailImg.Contains(tempmat))
                {
                    productModel.DetailImg.Add(tempmat);
                }
            }

            productModel.SKUTmall = JsonConvert.DeserializeObject<List<SkuTmallInfo>>(SKURegex.Match(str.ToString()).Value);//SKU
            //处理SKU图片
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

            productModel.ProductName = titleRegex.Match(str.ToString()).Value;
            productModel.ShopName = HttpUtility.UrlDecode(shopNameRegex.Match(str.ToString()).Value);
            productModel.ProductPrice = priceRegex.Match(str.ToString()).Value;
            productModel.Location = LocationRegex.Match(str.ToString()).Value;
            productModel.SalesCount = SalesCountRegex.Match(str.ToString()).Value;
            productModel.RateTotals = RateTotalsRegex.Match(str.ToString()).Value;

            productModel.Source = "淘宝";
            productModel.SourceUrl = url;
            return productModel;
        }
        #endregion

        #region 根据阿里巴巴商品地址获取商品信息+TaoModel GetInfoByAli(string AliUrl)
        /// <summary>
        /// 根据阿里巴巴商品地址获取商品信息
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<ProductResult> GetInfoByAli(string url)
        {
            ProductResult productModel = new ProductResult(ServiceContext);
            StringBuilder str = new StringBuilder();

            #region 发送请求 获取页面HTML
            var getAliHtml = NetClient.Create<string>(HttpMethod.Get, url);
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
            //Regex PriceRegex = new Regex("(?<=\"discountPriceRanges\":\\[{\"price\":\").+?(?=\",\"convertPrice\")");//原价
            Regex priceRegex = new Regex("(?<=\"price\":\").+?(?=\",)");//售价
            Regex shopNameRegex = new Regex("(?<=\"companyName\":\").+?(?=\",)");//店铺名称
            Regex titleRegex = new Regex("(?<=\"subject\":\").+?(?=\",)");  //标题
            Regex SKURegex = new Regex("(?<=\"skuProps\":).+(?=,\"subject\")");  //SKU
            Regex LocationRegex = new Regex("(?<=\"location\":\").+?(?=\",)");  //发货地
            Regex SalesCountRegex = new Regex("(?<=\"saledCount\":\").+?(?=\",)");  //销量
            Regex RateTotalsRegex = new Regex("(?<=\"rateTotals\":\").+?(?=\",)");  //评价
            //主图
            MatchCollection matchs = imgaeRegex.Matches(str.ToString(), 0);
            foreach (Match mat in matchs)
            {
                string tempmat = mat.Value;
                if (!tempmat.StartsWith("http"))
                {
                    tempmat = "http:" + tempmat;
                }
                tempmat = tempmat.Replace(".310x310", "");
                if (!productModel.ThumImg.Contains(tempmat))
                {
                    productModel.ThumImg.Add(tempmat);
                }
            }
            //详情图片
            productModel.DetailHtml = NetClient.Create<string>(HttpMethod.Get, myRegex.Match(str.ToString()).Value).SendAsync().Result;   //GetStrByBorwserUrl(detailImg).ToString();
            MatchCollection matches1 = detailimgRegex.Matches(productModel.DetailHtml, 0);
            foreach (Match mat in matches1)
            {
                string tempmat = mat.Value;
                if (!tempmat.StartsWith("http"))
                {
                    tempmat = "http:" + tempmat;
                }
                if (!productModel.DetailImg.Contains(tempmat))
                {
                    productModel.DetailImg.Add(tempmat);
                }
            }

            productModel.SKU1688 = JsonConvert.DeserializeObject<List<Sku1688Info>>(SKURegex.Match(str.ToString()).Value);//SKU
            productModel.ProductName = titleRegex.Match(str.ToString()).Value;
            productModel.ShopName = HttpUtility.UrlDecode(shopNameRegex.Match(str.ToString()).Value);
            productModel.ProductPrice = priceRegex.Match(str.ToString()).Value;
            productModel.Location = LocationRegex.Match(str.ToString()).Value;
            productModel.SalesCount = SalesCountRegex.Match(str.ToString()).Value;
            productModel.RateTotals = RateTotalsRegex.Match(str.ToString()).Value;
            productModel.Source = "阿里巴巴";
            productModel.SourceUrl = url;
            #endregion
            return productModel;
        }
        #endregion

        #region  根据京东商品地址获取商品信息+TaoModel GetInfoByJd(string JdUrl)
        /// <summary>
        /// 根据京东商品地址获取商品信息
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<ProductResult> GetInfoByJd(string url)
        {
            ProductResult productModel = new ProductResult(ServiceContext);
            string str = "";
            var getJdHtml = NetClient.Create<string>(HttpMethod.Get, url);
            await getJdHtml.SendAsync();
            if (!getJdHtml.IsValid())
            {
                new Exception("未能提交请求");
            }
            str = getJdHtml.Result;

            Regex titleRegex = new Regex("(?<=name=\"goodName\" value=\").+(?=\")");//商品名称
            Regex imgRegex = new Regex("(?<=src=\")\\S+?.jpg(?=!q70.jpg)");//获取商品图片
            Regex detailImgRegex = new Regex("(?<=desc: ')\\S+(?=',)");//商品详细图片地址
            Regex dImgRegex = new Regex("(?<=src=\")\\S+(?:png|jpg|bmp|gif)");//所有详细图片
            Regex PriceRegex = new Regex("(?<=name=\"jdPrice\" value=\").+(?=\")");//售价
            Regex shopNameRegex = new Regex("(?<=\"name\":\").+?(?=\",)");
            Regex sKURegex = new Regex("(?<=\"skuColorSizeJson\":\").+(?=\",\"specSet)");
            Regex salesCountRegex = new Regex("(?<=\"allCnt\":\").+?(?=\",)");
            Regex locationRegex = new Regex("(?<=class=\"service-item-text\">由[\\s\\S]+从).+?(?=发货并提供售后服务</span>)");

            //https://item.m.jd.com/newComments/newCommentsDetail.json   //评价 POST
            //https://item.m.jd.com/ware/getDetailCommentList.json?wareId=2962435  //评价
            //https://item.m.jd.com/ware/detail.json?wareId=2962435  详情
            //https://item.m.jd.com/ware/getSpecInfo.json?sid=a478e51bbe06746e0484fbf4baf137c8&wareId=11241122359&yanbaoIds= SKU
            //主图
            MatchCollection mact = imgRegex.Matches(str);
            foreach (Match mt in mact)
            {
                string tempmat = mt.Value;
                if (!tempmat.StartsWith("http"))
                {
                    tempmat = "http:" + tempmat;
                }
                if (!productModel.ThumImg.Contains(tempmat))
                {
                    productModel.ThumImg.Add(tempmat);
                }
            }

            //productid
            var productId = new Regex("(?<=product/)[0-9]+(?=.html)").Match(url).Value;
            var detailInfo = NetClient.Create<string>(HttpMethod.Get, "https://item.m.jd.com/ware/detail.json?wareId=" + productId).Send().Result;
            var rateInfo = NetClient.Create<string>(HttpMethod.Get, "https://item.m.jd.com/ware/getDetailCommentList.json?wareId=" + productId).Send().Result;

            productModel.DetailHtml = Regex.Unescape(new Regex("(?<=\"wdis\":\").+?(?=\",)").Match(detailInfo).Value);
            MatchCollection matches1 = dImgRegex.Matches(productModel.DetailHtml, 0);
            foreach (Match mat in matches1)
            {
                string tempmat = mat.Value;
                if (!tempmat.StartsWith("http"))
                {
                    tempmat = "http:" + tempmat;
                }
                if (!productModel.DetailImg.Contains(tempmat))
                {
                    productModel.DetailImg.Add(tempmat);
                }
            }

            productModel.SKUJD = JsonConvert.DeserializeObject<SkuJdInfo>(Regex.Unescape(sKURegex.Match(detailInfo.ToString()).Value));   //SKU
            foreach (var item in productModel.SKUJD.colorSize)
            {
                var skuImgDetail = NetClient.Create<string>(HttpMethod.Get, "https://item.m.jd.com/ware/getSpecInfo.json?wareId=" + productId).Send().Result;
                item.image = new Regex("(?<=\"wareMainImageUrl\":\").+?(?=\",)").Match(Regex.Unescape(skuImgDetail)).Value.Replace("!q70.jpg", "");
            }
            productModel.Location = locationRegex.Match(str.ToString()).Value;
            if (productModel.Location.Length > 3)
            {
                productModel.Location = productModel.Location.Substring(productModel.Location.Length - 3, 2);
            }

            productModel.ShopName = HttpUtility.UrlDecode(shopNameRegex.Match(detailInfo).Value);
            productModel.ShopName = productModel.ShopName.IsNullOrEmpty() ? "自营" : productModel.ShopName;
            productModel.ProductPrice = PriceRegex.Match(str).Value;
            productModel.SalesCount = salesCountRegex.Match(rateInfo.ToString()).Value;
            productModel.RateTotals = productModel.SalesCount;
            productModel.ProductName = titleRegex.Match(str).Value;
            productModel.Source = "京东";
            productModel.SourceUrl = url;
            return productModel;
        }
        #endregion

    }
}

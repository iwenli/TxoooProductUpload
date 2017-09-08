using FSLib.Network.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.Service.Entities;

namespace TxoooProductUpload.UI
{
    using Entities.Product;
    using HtmlAgilityPack;
    using Newtonsoft.Json.Linq;
    using Service.Crawl;
    using TxoooProductUpload.Common;

    public partial class TestForm : FormBase
    {
        public TestForm()
        {
            InitializeComponent();
            _context = new Service.ServiceContext();
            var _productHelper = new ProductHelper();

            button1.Click += async (s, e) =>
            {
                ProductSourceInfo product = new ProductSourceInfo(536929636061, SourceType.Tamll);
                _productHelper.ProcessItem(ref product);
                await Task.Delay(10);


                //var url = "https://detail.m.tmall.com/item.htm?id=536929636061";
                //if (textBox1.Text.Length > 0)
                //{
                //    url = textBox1.Text;
                //}

                //try
                //{
                //    var ctr = _context.Session.NetClient.Create<string>(HttpMethod.Get, url, allowAutoRedirect: true);
                //    await ctr.SendAsync();
                //    if (!ctr.IsValid())
                //    {
                //        throw new Exception(string.Format("未能提交请求,连接：{0}", url));
                //    }
                //    var result = ctr.Result;

                //    HtmlDocument document = new HtmlDocument();
                //    document.LoadHtml(result);
                //    var jsNodes = document.DocumentNode.SelectNodes(".//script");
                //    //_DATA_Mdskip =  ([\s\S]+}}}})
                //    //_DATA_Detail = ([\s\S]+]});
                //    foreach (var item in jsNodes)
                //    {
                //        if (item.InnerHtml.IndexOf("_DATA_Mdskip") > -1)
                //        {
                //            var mdskip = item.InnerHtml.Replace(";|<script>|</script>", "");
                //            mdskip = mdskip.Substring(mdskip.IndexOf("{"));
                //            //AppendLogWarning(txtLog, );
                //            var obj1 = DynamicJson.Parse(mdskip);
                //            foreach (KeyValuePair<string, dynamic> o in obj1)
                //            {
                //                //string key = o.Key;
                //                //JArray value = (JArray)o.Value;
                //                AppendLogWarning(txtLog, "{0}={1}", o.Key, o.Value.ToString());
                //            }

                //            //JObject obj = JObject.Parse(mdskip);
                //            //foreach (KeyValuePair<string, JToken> o in obj)
                //            //{
                //            //    //string key = o.Key;
                //            //    //JArray value = (JArray)o.Value;
                //            //    AppendLogWarning(txtLog, "{0}={1}", o.Key, o.Value.ToString());
                //            //}
                //        }
                //        //if (item.InnerHtml.IndexOf("_DATA_Detail") > -1)
                //        //{
                //        //    var detail = item.InnerHtml.Replace(";|<script>|</script>", "");
                //        //    AppendLog(txtLog, detail.Substring(detail.IndexOf("{")));
                //        //}
                //    }

                //}
                //catch (Exception ex)
                //{
                //    AppendLogError(txtLog, ex.Message);
                //}
            };

        }
    }
}

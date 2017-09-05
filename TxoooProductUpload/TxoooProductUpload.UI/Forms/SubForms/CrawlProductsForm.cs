using System;
using System.Windows.Forms;
using TxoooProductUpload.UI.CefGlue.Browser;
using TxoooProductUpload.UI.Common.Extended.Winform;
using HtmlAgilityPack;
using TxoooProductUpload.Entities.Product;
using CCWin.SkinControl;
using System.Linq;
using System.Collections.Generic;

namespace TxoooProductUpload.UI.Forms.SubForms
{

    /// <summary>
    /// 抓取商品
    /// </summary>
    public partial class CrawlProductsForm : Form
    {

        List<ProductSourceInfo> _productList = new List<ProductSourceInfo>();

        ///// <summary>
        ///// 当前页面的html
        ///// </summary>
        //public string Html { set; get; }


        public CrawlProductsForm()
        {
            InitializeComponent();

            Load += CrawlProductsForm_Load;
        }

        private void CrawlProductsForm_Load(object sender, EventArgs e)
        {
            InitMenuEvent();

            DataGridViewCheckBoxColumn colCB = new DataGridViewCheckBoxColumn();
            DataGridViewCheckBoxHeaderCell cbHeader = new DataGridViewCheckBoxHeaderCell();
            colCB.HeaderCell = cbHeader;
            sdgvProduct.Columns.Add(colCB);
            cbHeader.OnCheckBoxClicked += CbHeader_OnCheckBoxClicked;
            bs.DataSource = _productList;
        }

        private void CbHeader_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {

        }


        #region 控制菜单相关事件
        void InitMenuEvent()
        {
            tsBtnGO.Click += TsBtnGO_Click;
            tsBtnLeft.Click += TsBtnLeft_Click;
            tsBtnRight.Click += TsBtnRight_Click;
            tsBtnTest.Click += TsBtnTest_Click;
            tsBtnRefresh.Click += TsBtnRefresh_Click;
            tsTxtUrl.KeyUp += TsTxtUrl_KeyUp;
            webBrowser.AddressChanged += WebBrowser_AddressChanged;
            //webBrowser.LoadEnd += WebBrowser_LoadEnd;
        }

        //void WebBrowser_LoadEnd(object sender, Xilium.CefGlue.WindowsForms.LoadEndEventArgs e)
        //{
        //    HtmlChange(text =>
        //    {
        //        BeginInvoke(new Action(() =>
        //        {
        //            Html = text;
        //        }));
        //    });
        //}

        void HtmlChange(Action<string> callBack)
        {
            if (webBrowser.Browser.GetMainFrame().IsMain)
            {
                var visitor = new SourceVisitor(callBack);
                webBrowser.Browser.GetMainFrame().GetSource(visitor);
            }
        }

        void TsBtnTest_Click(object sender, EventArgs e)
        {
            HtmlChange(Html =>
            {
                BeginInvoke(new Action(() =>
                {
                    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                    document.LoadHtml(Html);
                    var productNodeList = document.GetElementbyId("mainsrp-itemlist").SelectNodes("//div[starts-with(@class,'item J_MouserOnverReq')]");
                    HtmlNode temp = null;
                    foreach (HtmlNode categoryNode in productNodeList)
                    {
                        temp = HtmlNode.CreateNode(categoryNode.OuterHtml);
                        var picElement = temp.SelectSingleNode("//a[starts-with(@class,'pic-link')]");
                        var idStr = picElement.Attributes["trace-nid"].Value;
                        if (!idStr.IsNullOrEmpty())
                        {
                            var id = Convert.ToInt64(idStr);
                            if (_productList.Exists(m => m.Id == id)) { continue; }

                            ProductSourceInfo product = new ProductSourceInfo(id);
                            product.SourceType = temp.SelectSingleNode("//span[@class='icon-service-tianmao']") == null ?
                                SourceType.Taobao : SourceType.Tamll;

                            product.ShowPrice = Convert.ToDouble(picElement.Attributes["trace-price"].Value ?? "0");
                            product.FirstImg = picElement.SelectSingleNode("//img").Attributes["data-src"].Value;

                            product.IsFreePostage = temp.SelectSingleNode("//span[@class='baoyou-intitle icon-service-free']") != null;
                            product.ProductName = temp.SelectSingleNode("//a[@class='J_ClickStat']").InnerText.Trim();

                            product.DealCnt = Convert.ToInt32(temp.SelectSingleNode("//div[@class='deal-cnt']").InnerText.Trim().Replace("人付款", ""));
                            product.UserNick = temp.SelectSingleNode("//a[@class='shopname J_MouseEneterLeave J_ShopInfo']").InnerText;
                            product.UserId = Convert.ToInt64(temp.SelectSingleNode("//a[@class='shopname J_MouseEneterLeave J_ShopInfo']").Attributes["data-userid"].Value);
                            product.Location = temp.SelectSingleNode("//div[@class='location']").InnerText.Trim();

                            bs.Add(product);
                        }
                    }
                }));
            });
        }

        void TsBtnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser.Browser.Reload();
        }

        private void TsBtnRight_Click(object sender, EventArgs e)
        {
            webBrowser.Browser.GoForward();
        }

        void TsBtnLeft_Click(object sender, EventArgs e)
        {
            webBrowser.Browser.GoBack();
        }

        void TsTxtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                OpenNewUrl(tsTxtUrl.Text.Trim());
            }
        }

        void WebBrowser_AddressChanged(object sender, Xilium.CefGlue.WindowsForms.AddressChangedEventArgs e)
        {
            tsTxtUrl.Text = webBrowser.Browser.GetMainFrame().Url;
            tsBtnLeft.Enabled = webBrowser.Browser.CanGoBack;
            tsBtnRight.Enabled = webBrowser.Browser.CanGoForward;
        }

        void TsBtnGO_Click(object sender, EventArgs e)
        {
            OpenNewUrl(tsTxtUrl.Text.Trim());
        }

        /// <summary>
        /// 在webBrowser中打开新url
        /// </summary>
        /// <param name="url"></param>
        void OpenNewUrl(string url)
        {
            webBrowser.Browser.GetMainFrame().LoadUrl(tsTxtUrl.Text);
        }
        #endregion
    }
}

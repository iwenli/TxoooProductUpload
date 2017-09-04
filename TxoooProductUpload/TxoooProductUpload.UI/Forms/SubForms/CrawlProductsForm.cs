using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.UI.CefGlue.Browser;
using TxoooProductUpload.UI.Common.Extended.Winform;
using Xilium.CefGlue;

namespace TxoooProductUpload.UI.Forms.SubForms
{

    /// <summary>
    /// 抓取商品
    /// </summary>
    public partial class CrawlProductsForm : Form
    {
        /// <summary>
        /// 当前页面的html
        /// </summary>
        public string Html { set; get; }


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
            webBrowser.LoadEnd += WebBrowser_LoadEnd;
        }

        void WebBrowser_LoadEnd(object sender, Xilium.CefGlue.WindowsForms.LoadEndEventArgs e)
        {
            if (webBrowser.Browser.GetMainFrame().IsMain)
            {
                var visitor = new SourceVisitor(text =>
                {
                    BeginInvoke(new Action(() =>
                    {
                        Html = text;
                    }));
                });
                webBrowser.Browser.GetMainFrame().GetSource(visitor);
            }
        }

        void TsBtnTest_Click(object sender, EventArgs e)
        {
            //CefStringVisitor vister = new CefStringVisitor();
            //webBrowser.Browser.GetMainFrame().GetSource(CefGlue.)
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

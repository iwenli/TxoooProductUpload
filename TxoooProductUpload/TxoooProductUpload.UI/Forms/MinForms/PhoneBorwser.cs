using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.UI.CefGlue;
using TxoooProductUpload.Common;

namespace TxoooProductUpload.UI
{
    /// <summary>
    /// 手机模拟浏览器
    /// </summary>
    public partial class PhoneBorwser : SkinMain
    {
        string _url = "https://0.u.7518.cn";

        string _loadUrl = string.Empty;

        /// <summary>
        /// 通过参数URL实例化一个 PhoneBorwser 对象
        /// </summary>
        /// <param name="url"></param>
        public PhoneBorwser(string url) : this()
        {
            _loadUrl = url;
        }
        /// <summary>
        /// 实例化一个 PhoneBorwser 对象
        /// </summary>
        public PhoneBorwser()
        {
            InitializeComponent();
            Load += ProdutBorwser_Load;
        }

        void ProdutBorwser_Load(object sender, EventArgs e)
        {
            webBrowser.StartUrl = _url;
            webBrowser.BringToFront();

            cmsGo.Click += CmsGo_Click;
            cmsIn.Click += CmsIn_Click;
            cmsClose.Click += Close_Click;
            panClose.Click += Close_Click;

            //打开页面
            webBrowser.TitleChanged += (s, e1) =>
            {
                BeginInvoke(new Action(() =>
                {
                    if (_loadUrl != string.Empty)
                    {
                        _url = _loadUrl;
                        Go();
                        _loadUrl = string.Empty;
                    }
                }));
            };
        }

        public void Open(string url)
        {
            _url = url;
            Go();
            WindowState = FormWindowState.Normal;
        }

        void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        void CmsIn_Click(object sender, EventArgs e)
        {
            string cbText = Clipboard.GetText();
            if (cbText.IsUrl())
            {
                _url = cbText;
                Go();
            }
        }

        void CmsGo_Click(object sender, EventArgs e)
        {
            var hidePop = "document.getElementsByClassName('app-download-popup')[0].style.display = 'none';";
            webBrowser.Browser.GetMainFrame().ExecuteJavaScript(hidePop, _url, 1);
        }

        /// <summary>
        /// 显示
        /// </summary>
        void Go()
        {
            if (_url.IsUrl())
            {
                webBrowser.Browser.GetMainFrame().LoadUrl(_url);
            }
            webBrowser.BringToFront();
        }
    }
}

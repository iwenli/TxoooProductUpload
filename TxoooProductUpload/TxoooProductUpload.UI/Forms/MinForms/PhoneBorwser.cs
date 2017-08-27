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
        /// <summary>
        /// 设置或获取当前浏览地址
        /// </summary>
        public string Url { set { _url = value; } get { return _url; } }
        /// <summary>
        /// 通过参数URL实例化一个 PhoneBorwser 对象
        /// </summary>
        /// <param name="url"></param>
        public PhoneBorwser(string  url):this()
        {
            _url = url;
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
            cefWebBrowser1.StartUrl = _url;
            cefWebBrowser1.BringToFront();

            cmsGo.Click += CmsGo_Click;
            cmsIn.Click += CmsIn_Click;
            cmsClose.Click += CmsClose_Click;

            //cefWebBrowser1.TitleChanged += (s, e1) =>
            //{
            //    BeginInvoke(new Action(() =>
            //    {
            //        var title = cefWebBrowser1.Title;
            //        if (title != null)
            //        {
            //            Text = title;
            //        }
            //    }));
            //};
        }

        public void Open(string url)
        {
            _url = url;
            Go();
        }

        void CmsClose_Click(object sender, EventArgs e)
        {
            Close();
            //Hide();
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
            cefWebBrowser1.Browser.GetMainFrame().ExecuteJavaScript(hidePop, _url, 1);
        }

        /// <summary>
        /// 显示
        /// </summary>
        void Go()
        {
            if (_url.IsUrl())
            {
                cefWebBrowser1.Browser.GetMainFrame().LoadUrl(_url);
            }
            cefWebBrowser1.BringToFront();
        }
    }
}

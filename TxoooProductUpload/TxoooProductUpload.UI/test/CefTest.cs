using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using Xilium.CefGlue;
using System.Text.RegularExpressions;
using TxoooProductUpload.UI.CefGlue;
using Xilium.CefGlue.WindowsForms;

namespace TxoooProductUpload.UI
{
    public partial class CefTest : Form
    {
        //CefWebBrowser _cefWebBrowser;
        //CefBrowser _cefBrowser;
        //CefFrame _cefFrame;
        public CefTest()
        {
            InitializeComponent();
            Load += BaseForm_Load;
            btnGo.Click += (s, e) => {
                Go(textBox1.Text);
            };
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            String path = "file:///" + Application.StartupPath + "/CefGlue/V8/ExampleObject.html";
            path = Regex.Replace(path, @"\\", "/");
            path = Regex.Replace(path, @"#", "%23");
            cefWebBrowser1.StartUrl = path;
            cefWebBrowser1.BringToFront();
            //OpenNewUrl(path);

            //String path = "file:///" + Application.StartupPath + "/CefGlue/V8/ExampleObject.html";
            //path = Regex.Replace(path, @"\\", "/");
            //path = Regex.Replace(path, @"#", "%23");
            //cefWebBrowser1.StartUrl = path;
        }

        //void OpenNewUrl(string url)
        //{
        //    textBox1.Text = url;
        //    _cefWebBrowser = new CefWebBrowser() { StartUrl = url };
        //    _cefWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
        //    this.Controls.Add(_cefWebBrowser);
        //    _cefWebBrowser.BringToFront();
        //}

        /// <summary>
        /// 显示
        /// </summary>
        void Go(string _url)
        {
            cefWebBrowser1.Browser.GetMainFrame().LoadUrl(_url);
            cefWebBrowser1.BringToFront();
        }

    }
}


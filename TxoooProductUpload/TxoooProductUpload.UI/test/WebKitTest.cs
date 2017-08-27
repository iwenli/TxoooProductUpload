using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TxoooProductUpload.UI
{
    public partial class WebKitTest : Form
    {
        public WebKitTest()
        {
            Environment.SetEnvironmentVariable("WEBKIT_IGNORE_SSL_ERRORS", "1");
            InitializeComponent();
            webKitBrowser1.IsScriptingEnabled = true;
            button1.Click += (s, e) => {
                webKitBrowser1.Navigate(textBox1.Text);
            };
        }
    }
}

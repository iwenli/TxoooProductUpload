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
            comboBox1.SelectedIndex = 0;

            button1.Click += async (s, e) =>
            {
                var sourceType = comboBox1.Text == "天猫" ? SourceType.Tmall : SourceType.Taobao;
                var id = textBox1.Text.Trim();
                if (!id.IsNullOrEmpty())
                {
                    button1.Enabled = false;
                    try
                    {
                        ProductSourceInfo product = new ProductSourceInfo(Convert.ToInt64(id), sourceType);
                        _productHelper.ProcessItem(product);
                        await Task.Delay(10);
                    }
                    catch (Exception ex)
                    {
                        AppendLog(txtLog, ex.Message);
                    }
                }
                button1.Enabled = true;
            };

        }
    }
}

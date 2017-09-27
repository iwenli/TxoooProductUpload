using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.Entities.Product;
using TxoooProductUpload.Service.Crawl;
using TxoooProductUpload.UI.Common;
using TxoooProductUpload.UI.Forms;
using TxoooProductUpload.UI.Forms.SubForms;

namespace TxoooProductUpload.UI.Test
{
    public partial class TestForm : BaseForm
    {
        public TestForm()
        {
            InitializeComponent();
            this.LogControl = txtLog;

            var _productHelper = new ProductHelper();
            comboBox1.SelectedIndex = 0;

            button1.Click += async (s, e) =>
            {
                var sourceType = comboBox1.Text == "天猫" ? SourceType.Tmall : SourceType.Taobao;
                //541939796071
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
                        AppendLog(ex.Message);
                    }
                }
                button1.Enabled = true;
            };

            for (int i = 0; i < 100; i++)
            {
                AppendLog(Utils.RandomInt(AppSetting.RandomMinValue,AppSetting.RandomMaxValue).ToString()); 
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Task.Run(() =>
        //   {
        //       ShowLoadForm();
        //   });
        //}

        //async void ShowLoadForm()
        //{
        //    if (InvokeRequired)
        //    {
        //        Invoke(new Action(() =>
        //        {
        //            ShowLoadForm();
        //        }));
        //        return;
        //    }
        //    var loadForm = new ProductUploadLoading("正在上传商品...",-1);
        //    loadForm.ShowDialog(this);
        //}
    }
}

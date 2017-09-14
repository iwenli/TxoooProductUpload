using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.UI.Forms;
using TxoooProductUpload.UI.Forms.SubForms;

namespace TxoooProductUpload.UI.Test
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
           {
               ShowLoadForm();
           });
        }

        async void ShowLoadForm()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    ShowLoadForm();
                }));
                return;
            }
            var loadForm = new ProductUploadLoading("正在上传商品...",-1);
            loadForm.ShowDialog(this);
        }
    }
}

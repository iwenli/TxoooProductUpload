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
    partial class TestForm : FormBase
    {
        public TestForm()
        {
            InitializeComponent();
            _context = new Service.ServiceContext();

            //button1.Click += async (s, e) =>
            //{
            //    var result = await _context.ProductService.GetAllProductsByUrl(textBox1.Text);
            //};

        }
    }
}

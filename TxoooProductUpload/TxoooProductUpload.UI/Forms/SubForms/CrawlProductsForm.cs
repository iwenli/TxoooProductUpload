using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.UI.Common.Extended.Winform;

namespace TxoooProductUpload.UI.Forms.SubForms
{
    /// <summary>
    /// 抓取商品
    /// </summary>
    public partial class CrawlProductsForm : Form
    {
        public CrawlProductsForm()
        {
            InitializeComponent();

            DataGridViewCheckBoxColumn colCB = new DataGridViewCheckBoxColumn();
            DataGridViewCheckBoxHeaderCell cbHeader = new DataGridViewCheckBoxHeaderCell();
            colCB.HeaderCell = cbHeader;
            sdgvProduct.Columns.Add(colCB);
            cbHeader.OnCheckBoxClicked += CbHeader_OnCheckBoxClicked;
        }

        private void CbHeader_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {
            
        }
    }
}

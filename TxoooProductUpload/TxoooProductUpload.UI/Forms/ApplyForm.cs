using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.Common;

namespace TxoooProductUpload.UI.Forms
{
    public partial class ApplyForm : BaseForm
    {
        public ApplyForm()
        {
            InitializeComponent();
            Load += ApplyForm_Load;
        }

        private void ApplyForm_Load(object sender, EventArgs e)
        {
            mchTypeBindingSource.DataSource = MchCache.MchTypeList;
        }
    }
}

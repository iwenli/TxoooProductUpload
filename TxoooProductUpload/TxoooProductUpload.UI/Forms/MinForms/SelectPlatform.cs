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
using TxoooProductUpload.UI.Common;

namespace TxoooProductUpload.UI.Forms.MinForms
{
    public partial class SelectPlatform : BaseForm
    {
        public SelectPlatform()
        {
            InitializeComponent();
            Load += SelectPlatform_Load;
            btnOK.Click += BtnOK_Click;
        }

        void BtnOK_Click(object sender, EventArgs e)
        {
            ApiList.Domain = cmbPlatform.SelectedValue.ToString();
            AppConfig.PlatFormName = cmbPlatform.Text;
            Close();
        }

        void SelectPlatform_Load(object sender, EventArgs e)
        {
            BindingSource _bs = new BindingSource();
            _bs.DataSource = AppSetting.Hosts;
            cmbPlatform.DataSource = _bs;
            cmbPlatform.ValueMember = "Value";
            cmbPlatform.DisplayMember = "Key";
        }
    }
}

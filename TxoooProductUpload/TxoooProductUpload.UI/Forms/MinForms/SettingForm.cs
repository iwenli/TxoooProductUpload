using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.UI.Common;

namespace TxoooProductUpload.UI.Forms.MinForms
{
    public partial class SettingForm : BaseForm
    {
        public SettingForm()
        {
            InitializeComponent();
            Load += SettingForm_Load;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            txtMaxThreadCount.Text = AppSetting.MaxThreadCount.ToString();
            txtRandomMaxValue.Text = AppSetting.RandomMaxValue.ToString();
            txtRandomMinValue.Text = AppSetting.RandomMinValue.ToString();

            txtMaxThreadCount.Leave += Text_Leave;
            txtRandomMaxValue.Leave += Text_Leave;
            txtRandomMinValue.Leave += Text_Leave;
        }

        private void TxtMaxThreadCount_Leave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void Text_Leave(object sender, EventArgs e)
        {
            CCWin.SkinControl.SkinTextBox textBox = sender as CCWin.SkinControl.SkinTextBox;
            int textValue = 0;
            if (textBox.Text.IsNullOrEmpty())
            {
                SM("该值不能为空！");
                return;
            }
            try
            {
                textValue = Convert.ToInt32(textBox.Text);
            }
            catch (Exception ex)
            {
                SM("输入值异常！");
                return;
            }
            switch (textBox.Name)
            {
                case "txtMaxThreadCount":
                    AppSetting.MaxThreadCount = textValue;
                    break;
                case "txtRandomMaxValue":
                    AppSetting.RandomMaxValue = textValue;
                    break;
                case "txtRandomMinValue":
                    AppSetting.RandomMinValue = textValue;
                    break;
            }
        }
    }
}

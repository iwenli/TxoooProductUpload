using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TxoooProductUpload.UI.Forms
{
    public partial class SetSearchKeyForm : BaseForm
    {
        /// <summary>
        /// 修改标题时 发生
        /// </summary>
        public event EventHandler<string> OnSetSearchKey;

        /// <summary>
        /// 引发 <see cref="OnChangeTitle" /> 事件
        /// </summary>
        protected virtual void SetSearchKey(string key)
        {
            OnSetSearchKey?.Invoke(this, key);

        }
        public SetSearchKeyForm()
        {
            InitializeComponent();
            Load += ChangeTitleForm_Load;

        }

        private void ChangeTitleForm_Load(object sender, EventArgs e)
        {
            btnSet.Click += Btn_Click;
            btnCancel.Click += Btn_Click;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            switch ((sender as SkinButton).Name)
            {
                case "btnSet":
                    if (!string.IsNullOrEmpty(txtOriginalWord.Text))
                    {
                        DialogResult = DialogResult.Yes;
                        SetSearchKey(txtOriginalWord.Text);
                    }
                    break;
                case "btnCancel":
                    break;
            }
            this.Close();
        }
    }
}

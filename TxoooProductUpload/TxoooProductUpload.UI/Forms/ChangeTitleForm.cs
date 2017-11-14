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
    public partial class ChangeTitleForm : BaseForm
    {
        /// <summary>
        /// 修改标题时 发生
        /// </summary>
        public event EventHandler<ChangeTitleEventArgs> OnChangeTitle;

        /// <summary>
        /// 引发 <see cref="OnChangeTitle" /> 事件
        /// </summary>
        protected virtual void ChangeTitle(ChangeTitleEventArgs args)
        {
            OnChangeTitle?.Invoke(this, args);

        }
        public ChangeTitleForm()
        {
            InitializeComponent();
            Load += ChangeTitleForm_Load;

        }

        private void ChangeTitleForm_Load(object sender, EventArgs e)
        {
            btnReplace.Click += Btn_Click;
            btnCancel.Click += Btn_Click;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            switch ((sender as SkinButton).Name)
            {
                case "btnReplace":
                    if (!string.IsNullOrEmpty(txtOriginalWord.Text))
                    {
                        DialogResult = DialogResult.Yes;
                        ChangeTitle(new ChangeTitleEventArgs(txtNewWord.Text,txtOriginalWord.Text));
                    }
                    break;
                case "btnCancel":
                    break;
            }
            this.Close();
        }
    }

    /// <summary>
    /// 标题修改事件数据
    /// </summary>
    public class ChangeTitleEventArgs : EventArgs
    {
        /// <summary>
        /// 替换后关键词
        /// </summary>
        public string NewWord { set; get; }

        /// <summary>
        /// 待替换关键词
        /// </summary>
        public string OriginalWord { set; get; }



        /// <summary>
        /// 初始化一个 ChangeTitleEventArgs 实例
        /// </summary>
        public ChangeTitleEventArgs(string newWord, string originalWord)
        {
            NewWord = newWord;
            OriginalWord = originalWord;
        }
    }
}

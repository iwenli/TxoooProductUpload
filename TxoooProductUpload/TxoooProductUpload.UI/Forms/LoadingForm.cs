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
    public partial class LoadingForm : BaseForm
    {
        /// <summary>
        /// 任务总数
        /// </summary>
        public int MaxTaskCount { set; get; }
        /// <summary>
        /// 当前任务进度
        /// </summary>
        public int TaskIndex { set; get; }

        public LoadingForm(string title) : this()
        {
            Text = title;
        }
        public LoadingForm()
        {
            InitializeComponent();
            LogControl = logTxt;
            UploadProgressSatate();
        }

        /// <summary>
        /// 更新任务进度
        /// </summary>
        public void UploadProgressSatate()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    UploadProgressSatate();
                }));
                return;
            }
            LoadMessage.Text = string.Format("当前任务进度：{0}/{1}", TaskIndex, MaxTaskCount);
        }
    }
}

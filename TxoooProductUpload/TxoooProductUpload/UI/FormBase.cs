using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TxoooProductUpload.UI
{
    using Service;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    /// <summary>
    /// 抽象窗口基类
    /// </summary>
    class FormBase : Form
    {
        /// <summary>
        /// 获得当前的上下文
        /// </summary>
        public ServiceContext _context;

        public FormBase(ServiceContext serviceContext)
        {
            _context = serviceContext;
        }

        /// <summary>
        /// 无效构造函数
        /// </summary>
        private FormBase()
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormBase
            // 
            this.ClientSize = new System.Drawing.Size(574, 360);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "创业赚钱";
            this.ResumeLayout(false);

        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void AppendLog(RichTextBox txtLog, string message, params object[] args)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    AppendLog(txtLog,message, args);
                }));
                return;
            }
            string timeL = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtLog.AppendText(timeL + " => ");
            //txtLog.AppendText(Environment.NewLine);  //换行显示

            if (args == null || args.Length == 0)
            {
                txtLog.AppendText(message);
            }
            else
            {
                txtLog.AppendText(string.Format(message, args));
            }
            txtLog.AppendText(Environment.NewLine);
            txtLog.ScrollToCaret();
        }

        #region 内部函数
        /// <summary>
        /// 显示提示
        /// </summary>
        /// <param name="msg">提示内容</param>
        protected void SM(string msg)
        {
            MessageBox.Show(msg, "创业赚钱商家工具");
        }
        /// <summary>
        /// 显示错误内容
        /// </summary>
        /// <param name="msg">错误内容</param>
        protected void EM(string msg)
        {
            MessageBox.Show(msg, "创业赚钱商家工具", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } 
        #endregion
    }
}

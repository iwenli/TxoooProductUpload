using System;
using System.Drawing;

namespace TxoooProductUpload.UI
{
    using Service;
    using System.Windows.Forms;
    using TxoooProductUpload.Common;

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
        /// 构造函数
        /// </summary>
        public FormBase()
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

        #region 内部函数
        /// <summary>
        /// 追加警告
        /// </summary>
        /// <param name="txtLog"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        protected void AppendLogWarning(RichTextBox txtLog, string message, params object[] args)
        {
            AppendLog(txtLog, Color.Violet, message, args);
        }
        /// <summary>
        /// 追加错误信息
        /// </summary>
        /// <param name="txtLog"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        protected void AppendLogError(RichTextBox txtLog, string message, params object[] args)
        {
            AppendLog(txtLog, Color.Red, message, args);
        }
        /// <summary>
        /// 添加日志 定义颜色
        /// </summary>
        /// <param name="txtLog"></param>
        /// <param name="fontColor"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void AppendLog(RichTextBox txtLog, Color fontColor, string message, params object[] args)
        {
            Color beforColor = txtLog.SelectionColor;
            txtLog.SelectionColor = fontColor;
            AppendLog(txtLog, message, args);
            txtLog.SelectionColor = beforColor;
        }
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        protected void AppendLog(RichTextBox txtLog, string message, params object[] args)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    AppendLog(txtLog, message, args);
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

        /// <summary>
        /// 显示提示
        /// </summary>
        /// <param name="msg">提示内容</param>
        protected void SM(string msg)
        {
            MessageBox.Show(msg, ConstParams.APP_NAME);
        }
        /// <summary>
        /// 显示错误内容
        /// </summary>
        /// <param name="msg">错误内容</param>
        protected void EM(string msg)
        {
            MessageBox.Show(msg, ConstParams.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// 显示信息提示
        /// </summary>
        /// <param name="msg">错误内容</param>
        protected void IS(string msg)
        {
            MessageBox.Show(msg, ConstParams.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 显示提示，带ye和no提示的
        /// </summary>
        /// <param name="msg">错误内容</param>
        protected DialogResult SMYN(string msg)
        {
            return MessageBox.Show(msg, ConstParams.APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

        #endregion
    }
}

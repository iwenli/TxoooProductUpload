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
    using CCWin;
    using Common;
    using Handler;
    using Iwenli;
    using Service;
    using TxoooProductUpload.UI.Common.Const;

    public partial class BaseForm : CCSkinMain
    {
        /// <summary>
        /// 消息委托句柄
        /// </summary>
        public SendMessageHandler SendMessageHandler { set; get; }
        /// <summary>
        /// 日志控件
        /// </summary>
        public Control LogControl { set; get; }

        public BaseForm()
        {
            InitializeComponent();
           // this.XTheme = new Skin_Mac() { };
        }

        public void Event_OnSendMessage(object sender, Handler.SendMessageEventArgs e)
        {
            switch (e.Type)
            {
                case MessageType.INFO:
                    AppendLog(e.Message);
                    break;
                case MessageType.WARN:
                    AppendLogWarning(e.Message);
                    break;
                case MessageType.ERROR:
                    AppendLogError(e.Message);
                    break;
                case MessageType.FATAL:
                    AppendLog(Color.DimGray, e.Message);
                    break;
                default:
                    break;
            }
        }

        #region 内部函数
        /// <summary>
        /// 追加警告信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        protected void AppendLogWarning(string message, params object[] args)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    AppendLog(Color.Violet, message, args);
                }));
                return;
            }
            AppendLog(Color.Violet, message, args);
        }
        /// <summary>
        /// 追加错误信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        protected void AppendLogError(string message, params object[] args)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    AppendLog(Color.Red, message, args);
                }));
                return;
            }
            AppendLog(Color.Red, message, args);
        }
        /// <summary>
        /// 添加日志 定义颜色
        /// </summary>
        /// <param name="fontColor"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        protected void AppendLog(Color fontColor, string message, params object[] args)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    AppendLog(fontColor, message, args);
                }));
                return;
            }
            (LogControl as RichTextBox).SelectionColor = fontColor;
            AppendLog(message, args);
        }
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        protected void AppendLog(string message, params object[] args)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    AppendLog(message, args);
                }));
                return;
            }
            string timeL = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            (LogControl as RichTextBox).AppendText(timeL + " => ");
            if (args == null || args.Length == 0)
            {
                (LogControl as RichTextBox).AppendText(message);
            }
            else
            {
                (LogControl as RichTextBox).AppendText(string.Format(message, args));
            }
             (LogControl as RichTextBox).AppendText(Environment.NewLine);
            (LogControl as RichTextBox).ScrollToCaret();
        }

        /// <summary>
        /// 显示提示
        /// </summary>
        /// <param name="msg">提示内容</param>
        protected void SM(string msg)
        {
            MessageBoxEx.Show(msg, AppInfo.AssemblyTitle);
        }
        /// <summary>
        /// 显示错误内容
        /// </summary>
        /// <param name="msg">错误内容</param>
        protected void SRM(string msg)
        {
            MessageBoxEx.Show(msg, AppInfo.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// 显示信息提示
        /// </summary>
        /// <param name="msg">错误内容</param>
        protected void SIM(string msg)
        {
            MessageBoxEx.Show(msg, AppInfo.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 显示提示，带ye和no提示的
        /// </summary>
        /// <param name="msg">错误内容</param>
        protected DialogResult SMYN(string msg)
        {
            return MessageBoxEx.Show(msg, AppInfo.AssemblyTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

        #endregion 
    }
}

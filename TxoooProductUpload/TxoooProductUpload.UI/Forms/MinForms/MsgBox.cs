using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using CCWin.SkinControl;
using TxoooProductUpload.UI.Handler;
using TxoooProductUpload.UI.Common.Const;

namespace TxoooProductUpload.UI
{
    /// <summary>
    /// 消息提示窗体
    /// </summary>
    public partial class MsgBox : CCSkinMain
    {

        /// <summary>
        /// 实例化一个 MsgBox 对象
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="title">标题</param>
        /// <param name="type">消息类型</param>
        public MsgBox(string message, string title = "", MessageType type = MessageType.INFO)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(title)) {
                title = AppInfo.AssemblyTitle;
            }
            Text = title;
            lblMsg.Text = message;
            switch (type)
            {
                case MessageType.INFO:
                    iconBox.BackgroundImage = Properties.Resources._3;
                    break;
                case MessageType.WARN:
                    iconBox.BackgroundImage = Properties.Resources._12;
                    break;
                case MessageType.ERROR:
                    iconBox.BackgroundImage = Properties.Resources._16;
                    break;
                case MessageType.FATAL:
                    iconBox.BackgroundImage = Properties.Resources._5;
                    break;
            }
            
        }

        //倒计时三秒关闭弹出窗
        private void timerHide_Tick(object sender, EventArgs e)
        {
            //如果鼠标在窗体上
            if (!this.Bounds.Contains(Cursor.Position))
            {
                this.Close();
            }
        }
    }
}

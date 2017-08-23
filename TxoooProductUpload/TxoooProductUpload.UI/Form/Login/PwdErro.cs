using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TxoooProductUpload.UI
{
    public partial class PwdErro : UserControl
    {
        public PwdErro()
        {
            InitializeComponent();
            SetStyles();
        }

        private DialogResult diglog;
        /// <summary>
        /// 对话框的返回值
        /// </summary>
        public DialogResult Diglog
        {
            get { return diglog; }
            set { diglog = value; }
        }

        #region 减少闪烁方法
        private void SetStyles()
        {
            //设置自定义控件Style
            this.SetStyle(ControlStyles.ResizeRedraw, true);//调整大小时重绘
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);// 双缓冲
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);// 禁止擦除背景.
            this.SetStyle(ControlStyles.UserPaint, true);//自行绘制
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.FromArgb(200, 255, 255, 255);
            UpdateStyles();
        }
        #endregion

        void findPwd_Click(object sender, EventArgs e)
        {
            App.Context.UserService.FindPassWordSync();
        }

        private void btnQx_Click(object sender, EventArgs e)
        {
            this.Diglog = DialogResult.Cancel;
            this.Visible = false;
        }
    }
}

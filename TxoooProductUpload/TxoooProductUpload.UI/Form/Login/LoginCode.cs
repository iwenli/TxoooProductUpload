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
    public partial class LoginCode : UserControl
    {
        public LoginCode() {
            InitializeComponent();
        }

        private DialogResult diglog;
        /// <summary>
        /// 对话框的返回值
        /// </summary>
        public DialogResult Diglog {
            get { return diglog; }
            set { diglog = value; }
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e) {
            if (txtCode.SkinTxt.Text.ToLower() == CodeImg.CodeStr.ToLower()) {
                Diglog = DialogResult.OK;
                this.Visible = false;
            } else {
                Diglog = DialogResult.No;
                //刷新验证码
                CodeImg.NewCode();
                lblErroCode.Visible = true;
                this.txtCode.SkinTxt.Clear();
                this.txtCode.SkinTxt.Focus();
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQx_Click(object sender, EventArgs e) {
            Diglog = DialogResult.Cancel;
            this.Visible = false;
        }

        /// <summary>
        /// 查看登录地
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCkLoginD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("http://ip.qq.com/cgi-bin/myip");
        }

        /// <summary>
        /// 设置登录保护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetLoginBh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("http://aq.qq.com/cn2/safe_service/my_login_prot?source_id=2192");
        }

        /// <summary>
        /// 存储窗体容器的Enter响应按钮
        /// </summary>
        IButtonControl btn;

        /// <summary>
        /// 显示时清空文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginCode_VisibleChanged(object sender, EventArgs e) {
            if (this.Visible) {
                lblErroCode.Visible = false;
                txtCode.SkinTxt.Clear();
                if (main != null) {
                    btn = main.AcceptButton;
                    main.AcceptButton = btnOk;
                }
            } else {
                if (main != null) {
                    main.AcceptButton = btn;
                }
            }
        }

        /// <summary>
        /// 控件所在窗体
        /// </summary>
        Form main;
        protected override void OnCreateControl() {
            base.OnCreateControl();
            main = this.FindForm();
        }

        /// <summary>
        /// 刷新验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblNewCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            //刷新验证码
            CodeImg.NewCode();
        }
    }
}

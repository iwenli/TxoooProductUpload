using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TxoooProductUpload.UI.Main
{
    using TxoooProductUpload.Common;
    using TxoooProductUpload.Service;
    partial class Login : FormBase
    {

        public Login(ServiceContext context) : base(context)
        {
            _context = context;
            InitializeComponent();
            this.Text = "登录 " + ConstParams.APP_NAME;
            Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        void Init()
        {
            this.txtUserName.SetHintText("请输入注册手机号");
            this.cbIsRemember.Checked = AppConfig.IsRemember;

            if (AppConfig.IsRemember && _context.CacheContext.Data.LoginInfo != null)
            {
                this.txtUserName.Text = _context.CacheContext.Data.LoginInfo.UserName;
                this.txtPassword.Text = _context.CacheContext.Data.LoginInfo.Password;
            }
            cbIsTest.CheckedChanged += (s, e) =>
            {
                ApiList.IsTest = (s as CheckBox).Checked;
            };
            cbIsRemember.CheckedChanged += (s, e) =>
            {
                AppConfig.IsRemember = (s as CheckBox).Checked;
            };
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            var username = txtUserName.Text;
            var password = txtPassword.Text;
            if (username.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                IS("输入用户名和密码哦！");
                return;
            }

            this.btnOk.Enabled = this.cbIsTest.Enabled = this.cbIsRemember.Enabled = false;
            this.btnOk.Text = "正在登陆.";
            var result = await _context.Session.LoginAsync(username, password);
            if (result == null)
            {
                this.DialogResult = DialogResult.OK;
                Close();
                return;
            }
            this.btnOk.Text = "登录(&O)";
            EM("登录失败：" + result.Message);
            this.btnOk.Enabled = this.cbIsTest.Enabled = this.cbIsRemember.Enabled = true;
        }
    }
}

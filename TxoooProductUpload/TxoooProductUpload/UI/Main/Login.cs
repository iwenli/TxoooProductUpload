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
    partial class Login : Form
    {
        ServiceContext _context;

        public Login(ServiceContext context)
        {
            _context = context;
            InitializeComponent();
            this.txtUserName.SetHintText("请输入注册手机号");

            txtUserName.Text = "18310807769";
            txtPassword.Text = "000";

            cbIsTest.CheckedChanged += (s, e) =>
            {
                ApiList.IsTest = (s as CheckBox).Checked;
            };
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            this.btnOk.Enabled = this.cbIsTest.Enabled = false;
            var username = txtUserName.Text;
            var password = txtPassword.Text;

            if (username.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                MessageBox.Show("输入用户名和密码哦！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.btnOk.Text = "正在登陆.";
            var result = await _context.Session.LoginAsync(username, password);
            if (result == null)
            {
                this.DialogResult = DialogResult.OK;
                Close();
                return;
            }
            this.btnOk.Text = "登录(&O)";
            MessageBox.Show("登录失败：" + result.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.btnOk.Enabled = this.cbIsTest.Enabled = true;
        }
    }
}

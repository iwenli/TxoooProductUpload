using CCWin;
using CCWin.SkinClass;
using CCWin.SkinControl;
using Iwenli;
using Iwenli.Text;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TxoooProductUpload.Common;
using TxoooProductUpload.Service.Entities;
using TxoooProductUpload.UI.Properties;
using TxoooProductUpload.UI.Service.Entities;

namespace TxoooProductUpload.UI
{
    public partial class LoginForm : CCSkinMain
    {
        public LoginForm()
        {
            InitializeComponent();
            MessageBox.Show(App.Context.UserService.GetCachePath("user"));
        }
        #region 变量
        /// <summary>
        /// 主窗体
        /// </summary>
        MainForm _main;
        /// <summary>
        /// 请求登陆的账号信息
        /// </summary>
        LoginInfo _loginUser;
        /// <summary>
        /// 用户列表
        /// </summary>
        LoginListInfo _loginUsers;
        /// <summary>
        /// 登陆缓存名称
        /// </summary>
        string _loginCacheName = "user.db";
        #endregion

        #region 窗口加载时
        /// <summary>
        /// 窗口加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            init_Notify();

            //根据时间换背景
            int H = DateTime.Now.Hour;
            this.BackgroundImage =
                H > 5 & H <= 11 ? Resources.morning :     //早上
                H > 11 & H <= 16 ? Resources.noon :       //中午
                H > 16 & H <= 19 ? Resources.afternoon :      //下午
                Resources.night;        //晚上
            //还原提示框位置
            pwdErro.Left = 0;
            loginCode.Left = 0;
            //多线程加载Id下拉框
            System.Threading.ThreadPool.QueueUserWorkItem((s) => SetUsers());

        }
        #endregion

        #region 下拉框事件
        //账号下拉框按钮事件
        private void btnId_MouseDown(object sender, MouseEventArgs e)
        {
            MenuId.Show(txtId, 0, txtId.Height);
            btnId.StopState = StopStates.Pressed;
            btnId.Enabled = false;
            txtId.StopState = StopStates.Hover;
        }

        //悬浮时
        private void Control_MouseEnter(object sender, EventArgs e)
        {
            txtId.MouseState = ControlState.Hover;
        }

        //离开时
        private void Control_MouseLeave(object sender, EventArgs e)
        {
            txtId.MouseState = ControlState.Normal;
        }

        //状态菜单中的Item选择事件
        void item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            _loginUser = _loginUsers.List.FirstOrDefault(m => m.UserName.AESDecrypt() == item.Tag.ToString());

            txtId.SkinTxt.Text = item.Tag.ToString();
            pnlImgTx.BackgroundImage = item.Image;
            if (_loginUser.RememberPwd)
            {
                txtPwd.SkinTxt.Text = _loginUser.Password.AESDecrypt();
            }
            chkRemember.Checked = _loginUser.RememberPwd;
            txtPwd.Focus();
        }

        #region 加载用户下拉框
        /// <summary>
        /// 读取历史登陆用户
        /// </summary>
        private void SetUsers()
        {
            try
            {
                _loginUsers = (LoginListInfo)Serialize.BinaryDeserialize(_loginCacheName);
            }
            catch (Exception ex)
            {
                this.LogError(ex.Message, ex);
            }
            finally
            {
                if (_loginUsers == null)
                {
                    _loginUsers = new LoginListInfo();
                }
                else
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        _loginUser = _loginUsers.LastLoginInfo;
                        txtId.SkinTxt.Text = _loginUser.UserName.AESDecrypt();
                        if (_loginUser.RememberPwd)
                        {
                            txtPwd.SkinTxt.Text = _loginUser.Password.AESDecrypt();
                        }
                        chkRemember.Checked = _loginUser.RememberPwd;
                        txtPwd.SkinTxt.Focus();

                    }));

                    foreach (var item in _loginUsers.List)
                    {
                        ToolStripMenuItem tsMenuItem = new ToolStripMenuItem();
                        tsMenuItem.AutoSize = false;
                        tsMenuItem.Size = new System.Drawing.Size(193, 45);
                        var userName = item.UserName.AESDecrypt();
                        tsMenuItem.Tag = userName;
                        tsMenuItem.Text = userName + "\n" + item.MchInfo.NickName;
                        //获取头像
                        Image img = App.Context.BaseContent.ImageService.GetImageByUrl(item.MchInfo.HeaPic);
                        tsMenuItem.Image = img;
                        tsMenuItem.Click += new EventHandler(item_Click);
                        MenuId.Height += 45;
                        MenuId.Items.Add(tsMenuItem);
                    }
                }
            }
        }
        #endregion

        //账号下拉菜单关闭时
        private void MenuId_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            btnId.Enabled = true;
            txtId.StopState = btnId.StopState = StopStates.NoStop;
            btnId.ControlState = txtId.MouseState = ControlState.Normal;
        }

        //账号框悬浮离开时
        private void txtId_MouseLeave(object sender, EventArgs e)
        {
            if (MenuId.Visible)
            {
                txtId.MouseState = ControlState.Hover;
            }
        }
        private void txtId_Leave(object sender, EventArgs e)
        {
            if (MenuId.Visible)
            {
                txtId.MouseState = ControlState.Hover;
            }
        }
        #endregion

        #region 小键盘按钮事件
        /// <summary>
        /// 打开密码小键盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJpPwd_Click(object sender, EventArgs e)
        {
            PassKey pass = new PassKey(this.Left + txtPwd.Left - 25, this.Top + txtPwd.Bottom + 1, txtPwd.SkinTxt);
            pass.Show(this);
        }

        /// <summary>
        /// 小键盘按钮悬浮时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJpPwd_MouseEnter(object sender, EventArgs e)
        {
            txtPwd.MouseState = ControlState.Hover;

        }

        /// <summary>
        /// 小键盘按钮离开时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJpPwd_MouseLeave(object sender, EventArgs e)
        {
            txtPwd.MouseState = ControlState.Normal;
        }
        #endregion

        #region 记住密码和测试环境
        //自动登录
        void chkZdLogin_CheckedChanged(object sender, EventArgs e)
        {
            chkRemember.Checked = chkIsTest.Checked ? true : chkRemember.Checked;
        }

        //记住密码
        void chkMima_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkRemember.Checked && chkIsTest.Checked)
            {
                chkIsTest.Checked = false;
            }
        }
        #endregion

        #region 注册 和 找回密码
        void RegAndFindPwd_Click(object sender, EventArgs e)
        {
            try
            {
                var button = sender as SkinButton;
                switch (button.Tag.ToString())
                {
                    case "reg":
                        App.Context.UserService.RegisterSync();
                        break;
                    case "findpwd":
                        App.Context.UserService.FindPassWordSync();
                        break;
                }
            }
            catch (Exception ex)
            {
                this.LogError(ex.Message, ex);
            }

        }
        #endregion

        #region 托盘菜单事件
        /// <summary>
        /// 初始化托盘信息
        /// </summary>
        private void init_Notify()
        {
            this.notify.Text = ConstParams.APP_NAME + "(未登陆)";
            this.notify.BalloonTipIcon = ToolTipIcon.Info;
            this.notify.BalloonTipTitle = ConstParams.APP_NAME;
            this.notify.BalloonTipText = "系统正在运行，双击显示窗口！\n右击弹出快捷菜单...\n当前版本" + ConstParams.Version.ToString();
            //绑定窗体失去焦点时时间  气泡提示
            Deactivate += LoginForm_DeacTivate;
        }
        /// <summary>
        /// 重写当窗体失去焦点时事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_DeacTivate(object sender, EventArgs e)
        {
            notify.ShowBalloonTip(1000);
        }
        /// <summary>
        /// 托盘图标双击显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsShow_Click(object sender, EventArgs e)
        {
            if (_main != null)
            {
                _main.ShowInTaskbar = true;
                _main.Show();
                _main.Activate();
                _main.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.Show();
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsExit_Click(object sender, EventArgs e)
        {
            if (_main != null)
            {
                _main.Dispose();
                _main.Close();
            }
            else
            {
                this.Dispose();
                this.Close();
            }
            Application.Exit();//退出整个应用程序。（无法退出单独开启的线程）
            Application.ExitThread();//释放所有线程　
        }
        #endregion

        #region 登录检查事件
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDl_Click(object sender, EventArgs e)
        {
            //pwdErro.Visible = true;
            //loginCode.Visible = true;
            #region 验证账号信息
            MsgBox msgBox;
            _loginUser = new LoginInfo(txtId.Text, txtPwd.Text, chkRemember.Checked);
            if (_loginUser.UserName.IsNullOrEmpty())
            {
                msgBox = new MsgBox("登陆手机号不能为空");
                msgBox.ShowDialog();
                return;
            }
            if (_loginUser.Password.IsNullOrEmpty())
            {
                msgBox = new MsgBox("密码不能为空");
                msgBox.ShowDialog();
                return;
            }
            try
            {
                _loginUser = await App.Context.BaseContent.Session.LoginAsync(_loginUser);
            }
            catch (Exception ex)
            {
                msgBox = new MsgBox(ex.Message, "登录失败");
                msgBox.ShowDialog();
                return;
            }
            #endregion

            #region 保存账号信息

            int index = _loginUsers.IsExists(_loginUser.UserName.AESEncrypt());
            if (index > -1)  //已经存在
            {
                _loginUsers.List.RemoveAt(index);  //删除
            }
            _loginUser.UserName = _loginUser.UserName.AESEncrypt();
            _loginUser.Password = _loginUser.Password.AESEncrypt();
            _loginUsers.List.Add(_loginUser);//重新存储

            Serialize.BinarySerialize(_loginCacheName, _loginUsers);
            #endregion
        }
        #endregion

        #region 验证码通过后就可以登录-登录跳转事件在这里
        /// <summary>
        /// 验证码通过后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginCode_VisibleChanged(object sender, EventArgs e)
        {
            if (!loginCode.Visible && loginCode.Diglog == DialogResult.OK)
            {
                this.Hide();
                //构建登录用户信息
                ChatListSubItem item = new ChatListSubItem();
                item.NicName = "’失忆";
                item.ID = uint.Parse(txtId.Text);
                item.HeadImage = pnlImgTx.BackgroundImage;
                item.QQShow = HttpHelper.GetUrlImg(string.Format("http://acfs.tencent.com/{0}/.jpg", txtId.Text));
                item.PersonalMsg = "我的个性签名我的个性签名我的个性签名我的个性签名我的个性签名";
                //main = new FrmMain(item, btnState);
                //main.Show();
            }
        }
        #endregion

        #region 窗口显示时
        private void FrmLogin_VisibleChanged(object sender, EventArgs e)
        {
            //Environment.OSVersion.Version.Major小于6则是win7 Vista以下系统
            this.Special = Environment.OSVersion.Version.Major >= 6;
        }
        #endregion

        #region ID框改变时自动检索头像
        //QQ改变时
        private void txtId_SkinTxt_TextChanged(object sender, EventArgs e)
        {
            Image img = Properties.Resources._4;
            foreach (ToolStripMenuItem item in MenuId.Items)
            {
                if (item.Tag.ToString().Equals(txtId.SkinTxt.Text))
                {
                    img = item.Image;
                    break;
                }
            }
            pnlImgTx.BackgroundImage = img;
        }
        #endregion
    }
}

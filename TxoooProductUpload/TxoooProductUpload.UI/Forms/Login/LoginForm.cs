using CCWin;
using CCWin.SkinClass;
using Iwenli;
using Iwenli.Text;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.Service.Entities;
using TxoooProductUpload.UI.Properties;
using TxoooProductUpload.UI.Service.Entities;
using TxoooProductUpload.UI.Common.Const;
using TxoooProductUpload.Common;
using CCWin.SkinControl;
using TxoooProductUpload.UI.Forms.MinForms;

namespace TxoooProductUpload.UI
{
    public partial class LoginForm : CCSkinMain
    {
        public LoginForm()
        {
            InitializeComponent();
            new SelectPlatform().ShowDialog(this);  //先选择平台
            //捕捉登录状态变化事件，在登录状态发生变化的时候重设登录状态
            App.Context.BaseContent.Session.IsLoginedChanged += async (s, e) => await LoginedChanged();
            FormClosing += (s, e) =>
            {
                Exit();
            };
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
        /// <summary>
        /// 上一次登陆时间
        /// </summary>
        DateTime _lastLoginTime = DateTime.Now;
        /// <summary>
        /// 当前登录的ip信息
        /// </summary>
        IpInfo _loginIp;
        #endregion

        #region 窗口加载时
        /// <summary>
        /// 窗口加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            init_Notify();
            //根据时间换背景
            int H = DateTime.Now.Hour;
            BackgroundImage =
                H > 5 & H <= 11 ? Resources.morning :     //早上
                H > 11 & H <= 15 ? Resources.noon :       //中午
                H > 15 & H <= 18 ? Resources.afternoon :  //下午
                Resources.night;        //晚上
            //还原提示框位置
            pwdErro.Left = 0;
            loginCode.Left = 0;
            //多线程加载Id下拉框
            System.Threading.ThreadPool.QueueUserWorkItem((s) => SetUsers());
            //获取ip
            Task.Run(async () =>
            {
                _loginIp = await App.Context.BaseContent.CommonService.GetIp();
            });
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
            ChangeLoginInfo();
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
                Invoke(new MethodInvoker(delegate
                {
                    if (_loginUsers == null)
                    {
                        _loginUsers = new LoginListInfo();
                        WindowState = FormWindowState.Normal;
                    }
                    else
                    {
                        //账号密码头像变更
                        _loginUser = _loginUsers.LastLoginInfo;
                        ChangeLoginInfo();
                        WindowState = FormWindowState.Normal;

                        //下拉框
                        foreach (var item in _loginUsers.List)
                        {
                            ToolStripMenuItem tsMenuItem = new ToolStripMenuItem();
                            tsMenuItem.AutoSize = false;
                            tsMenuItem.Size = new System.Drawing.Size(193, 45);
                            var userName = item.UserName.AESDecrypt();
                            tsMenuItem.Tag = userName;
                            tsMenuItem.Text = userName + Environment.NewLine + item.MchInfo.NickName;
                            //获取头像
                            Image img = App.Context.UserService.GetHeadPic(userName);
                            tsMenuItem.Image = img;
                            tsMenuItem.Click += new EventHandler(item_Click);
                            MenuId.Height += 45;
                            MenuId.Items.Add(tsMenuItem);
                        }
                    }
                }));
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

        #region 测试环境
        //测试环境
        private void chkIsTest_CheckedChanged(object sender, EventArgs e)
        {
            ApiList.IsTest = (sender as CheckBox).Checked;
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
                        App.Context.UserService.RegisterAsync();
                        break;
                    case "findpwd":
                        App.Context.UserService.FindPassWordAsync();
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
            notify.BalloonTipIcon = ToolTipIcon.Info;
            notify.BalloonTipTitle = AppInfo.AssemblyTitle;
            notify.Text = string.Format("{0}{1}状态:未登陆{1}版本:{2}", AppInfo.AssemblyTitle,
                   Environment.NewLine, AppInfo.AssemblyVersion.ToString());
            notify.Icon = Resources._icon;
            notify.BalloonTipText = "系统正在运行，双击显示窗口！" + Environment.NewLine
                + "右击弹出快捷菜单..." + Environment.NewLine
                + "当前版本" + AppInfo.AssemblyVersion.ToString();

            //notify.ShowBalloonTip(1000);

            //绑定窗体失去焦点时时间  气泡提示
            //Deactivate += LoginForm_DeacTivate;
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
                _main.Show();

                //_main.ShowInTaskbar = true;
                //_main.WindowState = FormWindowState.Normal;
                ///_main.Activate();
            }
            else
            {
                this.Show();
            }
        }
        //注销
        void tsLogout_Click(object sender, EventArgs e)
        {
            App.Context.BaseContent.Session.Logout();
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsExit_Click(object sender, EventArgs e)
        {
            Exit();
        }
        void Exit()
        {
            try
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
            }
            catch (Exception ex)
            {
                CefGlue.WlCefGlueLoader.ShutDownCEF();
                Application.Exit();//退出整个应用程序。（无法退出单独开启的线程）
                Application.ExitThread();//释放所有线程
            }

        }
        #endregion

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //pwdErro.Visible = true;
            //loginCode.Visible = true;
            #region 验证必输项
            _loginUser = new LoginInfo(txtId.Text, txtPwd.Text, chkRemember.Checked);
            if (string.IsNullOrEmpty(_loginUser.UserName))
            {
                MessageBoxEx.Show("登陆手机号不能为空", AppInfo.AssemblyTitle);
                return;
            }
            if (string.IsNullOrEmpty(_loginUser.Password))
            {
                MessageBoxEx.Show("密码不能为空", AppInfo.AssemblyTitle);
                //msgBox = new MsgBox("密码不能为空");
                //msgBox.ShowDialog();
                return;
            }
            #endregion

            btnLogin.Enabled = false;//加载资源过程中登陆按钮不可使用
            prbLoading.Visible = true;
            Thread thread = new Thread(new ThreadStart(Login));
            thread.Start();
        }

        async void Login()
        {
            try
            {
                _loginUser = await App.Context.BaseContent.Session.LoginAsync(_loginUser);
                ShowPro(50);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Invoke(new Action(() =>
                {
                    btnLogin.Enabled = true;
                    prbLoading.Value = 0;
                    prbLoading.Visible = false;
                }));
                return;
            }
            #region 保存账号信息
            int index = _loginUsers.IsExists(_loginUser.UserName.AESEncrypt());
            if (index > -1)  //已经存在
            {
                _lastLoginTime = _loginUsers.List[index].LastLoginTime;
                _loginUsers.List.RemoveAt(index);  //删除
            }
            Thread.Sleep(300);
            //保存头像
            await App.Context.UserService.SaveHeadPicAsync(_loginUser);
            ShowPro(75);
            //保存登录信息
            _loginUser.UserName = _loginUser.UserName.AESEncrypt();
            _loginUser.Password = _loginUser.Password.AESEncrypt();
            _loginUsers.List.Insert(0, _loginUser);//重新存储
            Serialize.BinarySerialize(_loginCacheName, _loginUsers);
            ShowPro(80);
            #endregion
            for (int i = 80; i <= 100; i++)
            {
                ShowPro(i);
                i++; //模拟发送多少
                Thread.Sleep(100);
            }
            Thread.CurrentThread.Abort();

        }

        private delegate void ProgressBarShow(int i);
        private void ShowPro(int value)
        {
            if (InvokeRequired)
            {
                Invoke(new ProgressBarShow(ShowPro), value);
            }
            else
            {
                prbLoading.Value = value;
                if (prbLoading.Value == 100)
                {
                    //弹窗显示信息
                    _loginUser.LastLoginTime = _lastLoginTime;
                    new InformationFrm(_loginUser, _loginIp).Show();
                    //显示主窗体
                    _main = new MainForm(_loginUser);
                    _main.Show();
                    _main.ExitSystem += (s, e) => { Exit(); };  //主窗体退出事件
                    //登陆窗体隐藏
                    Hide();
                    prbLoading.Value = 0;
                    prbLoading.Visible = false;
                    btnLogin.Enabled = btnLogin.Enabled = true;
                }
            }

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
                item.HeadImage = pnlHeadPic.BackgroundImage;
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
            this.Special = Environment.OSVersion.Version.Major >= 6;
        }
        #endregion

        #region 变更用户信息 
        /// <summary>
        /// 更改界面用户输入信息
        /// </summary>
        void ChangeLoginInfo()
        {
            txtId.SkinTxt.Text = _loginUser.UserName.AESDecrypt();
            pnlHeadPic.BackgroundImage = App.Context.UserService.GetHeadPic(txtId.SkinTxt.Text);
            if (_loginUser.RememberPwd)
            {
                txtPwd.SkinTxt.Text = _loginUser.Password.AESDecrypt();
            }
            chkRemember.Checked = _loginUser.RememberPwd;
        }
        #endregion

        /// <summary>
        /// 登录状态变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async Task LoginedChanged()
        {

            if (InvokeRequired)
            {
                Invoke(new Action(async () => { await LoginedChanged(); }));
                return;
            }
            tsLogout.Enabled = App.Context.BaseContent.Session.IsLogined;
            if (App.Context.BaseContent.Session.IsLogined)
            {
                var notifyText = string.Format("{0}{1}状态:已登陆({2}){3}店铺:{4}{5}版本:{6}{7}环境:{8}",
                         AppInfo.AssemblyTitle, Environment.NewLine, _loginUser.UserName,
                         Environment.NewLine, _loginUser.MchInfo.ComName, Environment.NewLine,
                         AppInfo.AssemblyVersion.ToString(), Environment.NewLine,
                         ApiList.IsTest ? "测试环境" : "正式环境");
                notify.Text = notifyText.Length >= 64 ? (notifyText.Substring(0, 60) + "...") : notifyText;
                notify.Icon = Resources.__icon;
                await App.Context.UserService.LoginLog(_loginUser);
                await Task.Run(async () =>
                {
                    try
                    {
                        await App.Context.BaseContent.CacheContext.Update();
                    }
                    catch (Exception ex)
                    {
                        MessageBoxEx.Show("更新缓存失败，请手动更新！");
                        this.LogFatal(ex.Message, ex);
                    }
                });
            }
            else
            {
                notify.Text = string.Format("{0}{1}状态:未登陆{1}版本:{2}", AppInfo.AssemblyTitle,
                   Environment.NewLine, AppInfo.AssemblyVersion.ToString());
                notify.Icon = Resources._icon;
                _main.Close();
                _main = null;
                Show();
            }
        }

    }
}

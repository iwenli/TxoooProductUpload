using CCWin;
using CCWin.SkinClass;
using CCWin.SkinControl;
using Microsoft.Win32;
using TxoooProductUpload.UI.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using Iwenli;

namespace TxoooProductUpload.UI
{
    public partial class LoginForm : CCSkinMain
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        #region 变量
        /// <summary>
        /// 主窗体
        /// </summary>
        MainForm main;
        #endregion

        #region 窗口加载时
        /// <summary>
        /// 窗口加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
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
            System.Threading.ThreadPool.QueueUserWorkItem((s) => SetId());
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
            txtId.SkinTxt.Text = item.Tag.ToString();
            pnlImgTx.BackgroundImage = item.Image;
            txtPwd.Focus();
        }

        #region 加载Id下拉框
        //加载Id下拉框
        private void SetId()
        {
            //获取所有本地登陆过的QQ
            DirectoryInfo theFolder = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/Tencent Files");
            //如果存在，说明数据缓冲在默认文档
            if (!theFolder.Exists)
            {
                //默认文档不存在QQ号历史数据的话，读取注册表获取缓存路径
                RegistryKey rsg = Registry.CurrentUser.OpenSubKey("Software\\Tencent\\bugReport\\QQ", true);
                string QQGet = rsg.GetValue("InstallDir").ToString();
                if (QQGet != null)
                {
                    theFolder = new DirectoryInfo(QQGet);
                }
            }
            //获取下列所有文件夹
            DirectoryInfo[] dirInfo = theFolder.GetDirectories();
            //数组转List
            ArrayList a = new ArrayList(dirInfo);
            //删除文件名非QQ数组
            RemoveNoQQ(ref a);
            if (a.Count > 0)
            {
                //根据访问时间排序
                SortTime(ref a);
                //只加入六个最近访问QQ
                WebClient web = new WebClient();
                for (int i = 0; i < a.Count; i++)
                {
                    if (i < 5)
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem();
                        item.AutoSize = false;
                        item.Size = new System.Drawing.Size(193, 45);
                        string QQ = ((DirectoryInfo)a[i]).Name;
                        item.Tag = QQ;
                        //获取Q名
                        web.Encoding = Encoding.GetEncoding("utf-8");//设置编码
                        //获取QQ名称
                        string qqName = web.DownloadString(string.Format("http://r.qzone.qq.com/cgi-bin/user/cgi_personal_card?uin={0}", QQ)).Replace("&quot;", "\"");
                        Regex regex = new Regex("\"nickname\":\"(.+?)\"");
                        MatchCollection match = regex.Matches(qqName);
                        if (match.Count > 0)
                        {
                            item.Text = match[0].Success ? match[0].Groups[1].Value + "\n" + QQ : QQ;
                            //获取QQ头像
                            Image img = Image.FromStream(web.OpenRead(string.Format("http://q.qlogo.cn/headimg_dl?bs=qq&dst_uin={0}&spec=100", QQ)));
                            item.Image = img;
                            item.Click += new EventHandler(item_Click);
                            this.Invoke(new MethodInvoker(delegate
                            {
                                if (i == 0)
                                {
                                    txtId.SkinTxt.Text = QQ;
                                    pnlImgTx.BackgroundImage = img;
                                    txtPwd.SkinTxt.Focus();
                                }
                                MenuId.Height += 45;
                                MenuId.Items.Add(item);
                            }));
                        }
                    }
                }
            }
            else
            {
                //没找到QQ列表时加载随机Id下拉框
                SetIdLx();
            }
        }

        //没找到QQ列表时加载随机Id下拉框
        Random rnd = new Random();
        private void SetIdLx()
        {
            for (int i = 0; i < 6; i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.AutoSize = false;
                item.Size = new System.Drawing.Size(193, 45);
                item.Tag = rnd.Next(1000, 10000).ToString();
                item.Text = "威廉乔克斯_汀\n" + rnd.Next(1000, 10000).ToString();
                item.Image = Properties.Resources._4;
                item.Click += new EventHandler(item_Click);
                this.Invoke(new MethodInvoker(delegate
                {
                    MenuId.Height += 45;
                    MenuId.Items.Add(item);
                }));
            }
        }

        /// <summary>
        /// 删除文件名非QQ数组
        /// </summary>
        /// <param name="a"></param>
        private void RemoveNoQQ(ref ArrayList a)
        {
            foreach (DirectoryInfo item in a.ToArray())
            {
                int i;
                if (!int.TryParse(item.Name, out i))
                {
                    a.Remove(item);
                }
            }
        }

        /// <summary>
        /// 冒泡排序算法
        /// </summary>
        /// <param name="arrSort"></param>
        public void SortTime(ref ArrayList arrSort)
        {
            DirectoryInfo temp;
            for (int i = 0; i < arrSort.Count; i++)
            {
                for (int j = i + 1; j < arrSort.Count; j++)
                {
                    if (((DirectoryInfo)arrSort[j]).LastWriteTime > ((DirectoryInfo)arrSort[i]).LastWriteTime)
                    {
                        temp = (DirectoryInfo)arrSort[j];
                        arrSort[j] = arrSort[i];
                        arrSort[i] = temp;
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

        #region 自动登录与记住密码
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
        /// 托盘图标双击显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolQQShow_Click(object sender, EventArgs e)
        {
            if (main != null)
            {
                main.Show();
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
        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 登录检查事件
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDl_Click(object sender, EventArgs e)
        {
            if (txtId.SkinTxt.Text.Length == 0 || txtPwd.SkinTxt.Text.Length == 0)
            {
                pwdErro.Visible = true;
                return;
            }
            loginCode.Visible = true;
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

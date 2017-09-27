using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using TxoooProductUpload.UI.Common.Const;
using System.Diagnostics;
using TxoooProductUpload.UI.Common;
using TxoooProductUpload.Service.Entities;
using Iwenli.Text;
using System.Threading.Tasks;
using Iwenli;

namespace TxoooProductUpload.UI
{
    public partial class MainForm : BaseForm
    {
        /// <summary>
        /// 选中的MenuItem
        /// </summary>
        ToolStripMenuItem _selectItem;

        /// <summary>
        /// 退出系统
        /// </summary>
        public event EventHandler ExitSystem;
        /// <summary>
        /// 引发 <see cref="ExitSystem" /> 事件
        /// </summary>
        protected virtual void OnExitSystem()
        {
            var handler = ExitSystem;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public MainForm()
        {
            InitializeComponent();
            Text = AppInfo.AssemblyTitle + string.Format(" V{0}    PowerBy:{1}"
                , AppInfo.AssemblyVersion.Substring(0, AppInfo.AssemblyVersion.LastIndexOf('.'))
                , AppInfo.AUTHOR);
            stCompany.Text = "版权:" + AppInfo.AssemblyCompany;
            InitFormEvent();
        }
        public MainForm(LoginInfo login) : this()
        {
            stLoginInfo.Text = string.Format("当前已登录为{0}-{1} ({2})", login.MchInfo.ComName, login.MchInfo.NickName,
                login.UserName.AESDecrypt());
        }

        void InitFormEvent()
        {
            FormClosing += MainForm_FormClosing;
            webBrowser.LoadEnd += WebBrowser_LoadEnd;
        }

        /// <summary>
        /// 加载完显示页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void WebBrowser_LoadEnd(object sender, Xilium.CefGlue.WindowsForms.LoadEndEventArgs e)
        {
            palShow.Visible = false;
        }

        /// <summary>
        /// 关闭最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ///WindowState = FormWindowState.Minimized;
            Hide();
            //ShowInTaskbar = false;
            e.Cancel = true;
        }


        #region 窗口加载时
        /// <summary>
        /// 窗口加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //存储选中MenuItem
            _selectItem = SkinTool1;
            InitTagPage();
            InitSkinItems();
        }

        /// <summary>
        /// 初始化TabPage内容
        /// </summary>
        void InitTagPage()
        {
            foreach (TabPage page in tabShow.TabPages)
            {
                if (page.Tag != null)
                {
                    Assembly asb = Assembly.GetExecutingAssembly();//得到当前的程序集
                    object c = asb.CreateInstance("TxoooProductUpload.UI.Forms.SubForms." + page.Tag.ToString(), true);
                    if (c != null)
                    {
                        Form f = (Form)c;
                        f.Dock = DockStyle.Fill;
                        f.TopLevel = false;
                        f.FormBorderStyle = FormBorderStyle.None;
                        f.Show();
                        page.Controls.Add(f);
                    }
                }
            }
        }
        /// <summary>
        /// 初始化皮肤选项
        /// </summary>
        void InitSkinItems()
        {
            if (!Directory.Exists(AppInfo.SkinFormPath)) return;
            var paths = Directory.GetFiles(AppInfo.SkinFormPath);
            foreach (var filePath in paths)
            {
                string extension = Path.GetExtension(filePath);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                var toolItem = new ToolStripMenuItem();
                toolItem.Name = "SkinTool" + (SkinMenu.Items.Count + 1).ToString();
                toolItem.Size = new System.Drawing.Size(124, 22);
                toolItem.Tag = fileNameWithoutExtension + extension;
                toolItem.Text = fileNameWithoutExtension;
                toolItem.Click += new System.EventHandler(SkinTool_Click);
                SkinMenu.Items.AddRange(new ToolStripItem[] { toolItem });
            }
        }
        #endregion

        #region 画窗体边框
        /// <summary>
        /// 画窗体边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.FromArgb(33, 40, 46), 2);
            g.DrawRectangle(p, tabShow.Left, tabShow.Top, tabShow.Width, tabShow.Height);
        }
        #endregion

        #region 换肤菜单
        private void SkinTool_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            //选中当前Item
            item.Checked = true;
            //取消选中上一个Item，并存储当前Item
            _selectItem.Checked = false;
            _selectItem = item;
            //如果是0，则是默认皮肤
            if (item.Tag.ToString().Equals("0"))
            {
                Back = null;
                BackColor = Color.FromArgb(50, 155, 255);
            }
            else
            {
                var skinFilePath = Path.Combine(AppInfo.SkinFormPath, item.Tag.ToString());
                if (File.Exists(skinFilePath))
                {
                    //其他皮肤，从文件夹中获取
                    Back = Image.FromFile(skinFilePath);
                }
            }
        }
        #endregion

        #region 自定义系统按钮事件
        //自定义系统按钮事件
        private void FrmMain_SysBottomClick(object sender, CCWin.SkinControl.SysButtonEventArgs e)
        {
            //获得弹出坐标
            Point l = PointToScreen(e.SysButton.Location);
            l.Y += e.SysButton.Size.Height + 1;
            //如果是皮肤菜单
            if (e.SysButton.Name == "ToolSkin")
            {
                SkinMenu.Show(l);
            }
            else if (e.SysButton.Name == "ToolSet")
            {
                //如果是设置菜单
                SkinToolMenu.Show(l);
            }
        }
        #endregion

        #region Tab切换时事件，用于子窗体更改了提示Lbl后的还原
        private void tabShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            // lblTs.Text = lblTs.Tag.ToString();
        }
        #endregion

        #region ToolMenuEvent
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void stmExit_Click(object sender, EventArgs e)
        {
            OnExitSystem();
        }
        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void stmLogout_Click(object sender, EventArgs e)
        {
            App.Context.BaseContent.Session.Logout();
        }
        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void stmAbout_Click(object sender, EventArgs e)
        {
            new TxoooProductUpload.UI.Forms.MinForms.AboutForm().ShowDialog(this);
        }
        /// <summary>
        /// 联系作者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void stmAuthor_Click(object sender, EventArgs e)
        {
            Utils.OpenUrl(AppConfigInfo.ContactAuthorUrl);
        }
        /// <summary>
        /// 系统设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void stmSet_Click(object sender, EventArgs e)
        {
            new TxoooProductUpload.UI.Forms.MinForms.SettingForm().ShowDialog(this);
        }
        /// <summary>
        /// 置顶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void stmTop_Click(object sender, EventArgs e)
        {
            if (stmTop.CheckState == CheckState.Checked)
            {
                stmTop.CheckState = CheckState.Unchecked;
                TopMost = false;
            }
            else
            {
                stmTop.CheckState = CheckState.Checked;
                TopMost = true;
            }
        }
        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void stmUpdate_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                try
                {
                    if (await App.Context.BaseContent.CacheContext.UpdateAlways())
                    {
                        MessageBoxEx.Show("缓存更新完成！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show("更新缓存失败，请手动更新！");
                    this.LogFatal(ex.Message, ex);
                }

            });
        }
        #endregion
    }
}

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

namespace TxoooProductUpload.UI
{
    public partial class FrmMain : CCSkinMain
    {
        public FrmMain() {
            InitializeComponent();
        }
        #region 控制web控件滚动条
        /// <summary>
        /// 控制web控件滚动条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webShow_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            webShow.Document.Window.ScrollTo(0, 310);
            webShow.Show();
        }
        #endregion

        #region 窗口加载时
        /// <summary>
        /// 窗口加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e) {
            //存储选中MenuItem
            SelectItem = SkinTool1;
            #region 初始化TabPage内容
            foreach (TabPage page in tabShow.TabPages) {
                if (page.Tag != null) {
                    Assembly asb = Assembly.GetExecutingAssembly();//得到当前的程序集
                    object c = asb.CreateInstance("TxoooProductUpload.UI." + page.Tag.ToString(), true);
                    if (c != null) {
                        Form f = (Form)c;
                        f.Dock = DockStyle.Fill;
                        f.TopLevel = false;
                        f.FormBorderStyle = FormBorderStyle.None;
                        f.Show();
                        page.Controls.Add(f);
                    }
                }
            }
            #endregion
        }
        #endregion

        #region 画窗体边框
        /// <summary>
        /// 画窗体边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.FromArgb(33, 40, 46), 2);
            g.DrawRectangle(p, tabShow.Left, tabShow.Top, tabShow.Width, tabShow.Height);
        }
        #endregion

        #region 换肤菜单
        /// <summary>
        /// 选中的MenuItem
        /// </summary>
        ToolStripMenuItem SelectItem;
        private void SkinTool_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            //选中当前Item
            item.Checked = true;
            //取消选中上一个Item，并存储当前Item
            SelectItem.Checked = false;
            SelectItem = item;
            //如果是0，则是默认皮肤
            if (item.Tag.ToString().Equals("0")) {
                this.Back = null;
                this.BackColor = Color.FromArgb(50, 155, 255);
                this.Opacity = this.SkinOpacity = 0.9;
            } else {
                //其他皮肤，从文件夹中获取
                this.Opacity = this.SkinOpacity = 1;
                //this.Back = ImageObject.GetResBitmap(string.Format("TxoooProductUpload.UI.Skin.{0}.jpg", item.Tag));
            }
        }
        #endregion

        #region 自定义系统按钮事件
        //自定义系统按钮事件
        private void FrmMain_SysBottomClick(object sender, CCWin.SkinControl.SysButtonEventArgs e) {
            //获得弹出坐标
            Point l = PointToScreen(e.SysButton.Location);
            l.Y += e.SysButton.Size.Height + 1;
            //如果是皮肤菜单
            if (e.SysButton.Name == "ToolSkin") {
                SkinMenu.Show(l);
            } else if (e.SysButton.Name == "ToolSet") {
                //如果是设置菜单
                SkinToolMenu.Show(l);
            }
        }
        #endregion

        #region Tab切换时事件，用于子窗体更改了提示Lbl后的还原
        private void tabShow_SelectedIndexChanged(object sender, EventArgs e) {
            lblTs.Text = lblTs.Tag.ToString();
        } 
        #endregion
    }
}

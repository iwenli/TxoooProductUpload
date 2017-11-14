/********************************************************************
 * *
 * * 使本项目源码或本项目生成的DLL前请仔细阅读以下协议内容，如果你同意以下协议才能使用本项目所有的功能，
 * * 否则如果你违反了以下协议，有可能陷入法律纠纷和赔偿，作者保留追究法律责任的权利。
 * *
 * * 1、你可以在开发的软件产品中使用和修改本项目的源码和DLL，但是请保留所有相关的版权信息。
 * * 2、不能将本项目源码与作者的其他项目整合作为一个单独的软件售卖给他人使用。
 * * 3、不能传播本项目的源码和DLL，包括上传到网上、拷贝给他人等方式。
 * * 4、以上协议暂时定制，由于还不完善，作者保留以后修改协议的权利。
 * *
 * * Copyright (C) 2013-? cskin Corporation All rights reserved.
 * * 网站：CSkin界面库 http://www.cskin.net 论坛 http://bbs.cskin.net
 * * 作者： 乔克斯 QQ：345015918 .Net项目技术组群：306485590
 * * 请保留以上版权信息，否则作者将保留追究法律责任。
 * *
 * * 创建时间：2014-08-26
 * * 说明：FrmMain.Designer.cs
 * *
********************************************************************/

namespace TxoooProductUpload.UI
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            CCWin.CmSysButton cmSysButton3 = new CCWin.CmSysButton();
            CCWin.CmSysButton cmSysButton4 = new CCWin.CmSysButton();
            this.tabShow = new CCWin.SkinControl.SkinTabControl();
            this.tabPage1 = new CCWin.SkinControl.SkinTabPage();
            this.palShow = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.webBrowser = new Xilium.CefGlue.WindowsForms.CefWebBrowser();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.tabPage2 = new CCWin.SkinControl.SkinTabPage();
            this.tabPage3 = new CCWin.SkinControl.SkinTabPage();
            this.tabPage4 = new CCWin.SkinControl.SkinTabPage();
            this.tabPage5 = new CCWin.SkinControl.SkinTabPage();
            this.tabPage6 = new CCWin.SkinControl.SkinTabPage();
            this.tabPage7 = new CCWin.SkinControl.SkinTabPage();
            this.tabPage8 = new CCWin.SkinControl.SkinTabPage();
            this.SkinMenu = new CCWin.SkinControl.SkinContextMenuStrip();
            this.SkinTool1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool1 = new System.Windows.Forms.ToolStripButton();
            this.tool2 = new System.Windows.Forms.ToolStripButton();
            this.tool3 = new System.Windows.Forms.ToolStripButton();
            this.tool4 = new System.Windows.Forms.ToolStripButton();
            this.tool5 = new System.Windows.Forms.ToolStripButton();
            this.tool6 = new System.Windows.Forms.ToolStripButton();
            this.tool7 = new System.Windows.Forms.ToolStripButton();
            this.tool8 = new System.Windows.Forms.ToolStripButton();
            this.ToolShow = new CCWin.SkinControl.SkinToolStrip();
            this.SkinToolMenu = new CCWin.SkinControl.SkinContextMenuStrip();
            this.stmTop = new System.Windows.Forms.ToolStripMenuItem();
            this.stmUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.stmSet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.stmAuthor = new System.Windows.Forms.ToolStripMenuItem();
            this.stmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.stmLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.stmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timColor = new System.Windows.Forms.Timer(this.components);
            this.ss = new System.Windows.Forms.StatusStrip();
            this.stStates = new System.Windows.Forms.ToolStripStatusLabel();
            this.stLoginInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.stCompany = new System.Windows.Forms.ToolStripStatusLabel();
            this.stmApply = new System.Windows.Forms.ToolStripMenuItem();
            this.tabShow.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.palShow.SuspendLayout();
            this.SkinMenu.SuspendLayout();
            this.ToolShow.SuspendLayout();
            this.SkinToolMenu.SuspendLayout();
            this.ss.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabShow
            // 
            this.tabShow.AnimatorType = CCWin.SkinControl.AnimationType.HorizSlide;
            this.tabShow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabShow.CloseRect = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.tabShow.Controls.Add(this.tabPage1);
            this.tabShow.Controls.Add(this.tabPage2);
            this.tabShow.Controls.Add(this.tabPage3);
            this.tabShow.Controls.Add(this.tabPage4);
            this.tabShow.Controls.Add(this.tabPage5);
            this.tabShow.Controls.Add(this.tabPage6);
            this.tabShow.Controls.Add(this.tabPage7);
            this.tabShow.Controls.Add(this.tabPage8);
            this.tabShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabShow.DrawType = CCWin.SkinControl.DrawStyle.Draw;
            this.tabShow.HeadBack = null;
            this.tabShow.ImgTxtOffset = new System.Drawing.Point(0, 0);
            this.tabShow.Interval = 5;
            this.tabShow.ItemSize = new System.Drawing.Size(68, 30);
            this.tabShow.Location = new System.Drawing.Point(4, 98);
            this.tabShow.Margin = new System.Windows.Forms.Padding(0);
            this.tabShow.Name = "tabShow";
            this.tabShow.PageArrowDown = ((System.Drawing.Image)(resources.GetObject("tabShow.PageArrowDown")));
            this.tabShow.PageArrowHover = ((System.Drawing.Image)(resources.GetObject("tabShow.PageArrowHover")));
            this.tabShow.PageCloseHover = ((System.Drawing.Image)(resources.GetObject("tabShow.PageCloseHover")));
            this.tabShow.PageCloseNormal = ((System.Drawing.Image)(resources.GetObject("tabShow.PageCloseNormal")));
            this.tabShow.PageDown = ((System.Drawing.Image)(resources.GetObject("tabShow.PageDown")));
            this.tabShow.PageHover = ((System.Drawing.Image)(resources.GetObject("tabShow.PageHover")));
            this.tabShow.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Left;
            this.tabShow.PageNorml = null;
            this.tabShow.SelectedIndex = 1;
            this.tabShow.ShowToolTips = true;
            this.tabShow.Size = new System.Drawing.Size(992, 573);
            this.tabShow.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabShow.TabIndex = 0;
            this.tabShow.SelectedIndexChanged += new System.EventHandler(this.tabShow_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.palShow);
            this.tabPage1.Controls.Add(this.webBrowser);
            this.tabPage1.Controls.Add(this.skinPanel1);
            this.tabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage1.Location = new System.Drawing.Point(0, 30);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(992, 543);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.TabItemImage = null;
            this.tabPage1.Text = "主页";
            // 
            // palShow
            // 
            this.palShow.Controls.Add(this.progressBar1);
            this.palShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palShow.Location = new System.Drawing.Point(0, 30);
            this.palShow.Name = "palShow";
            this.palShow.Size = new System.Drawing.Size(992, 513);
            this.palShow.TabIndex = 8;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(96, 200);
            this.progressBar1.MarqueeAnimationSpeed = 20;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(803, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            // 
            // webBrowser
            // 
            this.webBrowser.BrowserSettings = null;
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 30);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(992, 513);
            this.webBrowser.StartUrl = "http://www.7518.cn";
            this.webBrowser.TabIndex = 7;
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinPanel1.BackgroundImage = global::TxoooProductUpload.UI.Properties.Resources.BaiduShurufa_2014_8_2_16_32_58;
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(0, 0);
            this.skinPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(992, 30);
            this.skinPanel1.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage2.Location = new System.Drawing.Point(0, 30);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(992, 543);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.TabItemImage = null;
            this.tabPage2.Tag = "CrawlProductsForm";
            this.tabPage2.Text = "抓取商品";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage3.Location = new System.Drawing.Point(0, 30);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(992, 543);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.TabItemImage = null;
            this.tabPage3.Tag = "";
            this.tabPage3.Text = "整店复制";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage4.Location = new System.Drawing.Point(0, 30);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(992, 543);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.TabItemImage = null;
            this.tabPage4.Tag = "FrmSpy";
            this.tabPage4.Text = "图片管理";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.White;
            this.tabPage5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage5.Location = new System.Drawing.Point(0, 30);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(992, 543);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.TabItemImage = null;
            this.tabPage5.Tag = "FrmWebSpy";
            this.tabPage5.Text = "评价管理";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.White;
            this.tabPage6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage6.Location = new System.Drawing.Point(0, 30);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(992, 543);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.TabItemImage = null;
            this.tabPage6.Tag = "ProductManageForm";
            this.tabPage6.Text = "商品管理";
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.White;
            this.tabPage7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage7.Location = new System.Drawing.Point(0, 30);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(992, 543);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.TabItemImage = null;
            this.tabPage7.Tag = "FrmPrcImg";
            this.tabPage7.Text = "订单管理";
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.White;
            this.tabPage8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage8.Location = new System.Drawing.Point(0, 30);
            this.tabPage8.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(992, 543);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.TabItemImage = null;
            this.tabPage8.Tag = "FrmExeManager";
            this.tabPage8.Text = "店铺设置";
            // 
            // SkinMenu
            // 
            this.SkinMenu.Arrow = System.Drawing.Color.Black;
            this.SkinMenu.Back = System.Drawing.Color.White;
            this.SkinMenu.BackRadius = 4;
            this.SkinMenu.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.SkinMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.SkinMenu.Fore = System.Drawing.Color.Black;
            this.SkinMenu.HoverFore = System.Drawing.Color.White;
            this.SkinMenu.ItemAnamorphosis = false;
            this.SkinMenu.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.SkinMenu.ItemBorderShow = false;
            this.SkinMenu.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.SkinMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.SkinMenu.ItemRadius = 4;
            this.SkinMenu.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.SkinMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SkinTool1});
            this.SkinMenu.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.SkinMenu.Name = "skinContextMenuStrip1";
            this.SkinMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.SkinMenu.Size = new System.Drawing.Size(125, 26);
            this.SkinMenu.SkinAllColor = true;
            this.SkinMenu.TitleAnamorphosis = false;
            this.SkinMenu.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.SkinMenu.TitleRadius = 4;
            this.SkinMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // SkinTool1
            // 
            this.SkinTool1.Checked = true;
            this.SkinTool1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SkinTool1.Name = "SkinTool1";
            this.SkinTool1.Size = new System.Drawing.Size(124, 22);
            this.SkinTool1.Tag = "0";
            this.SkinTool1.Text = "默认皮肤";
            this.SkinTool1.Click += new System.EventHandler(this.SkinTool_Click);
            // 
            // tool1
            // 
            this.tool1.AutoSize = false;
            this.tool1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1.Margin = new System.Windows.Forms.Padding(0);
            this.tool1.Name = "tool1";
            this.tool1.Size = new System.Drawing.Size(60, 60);
            this.tool1.Tag = "0";
            this.tool1.Text = "主页";
            // 
            // tool2
            // 
            this.tool2.AutoSize = false;
            this.tool2.Checked = true;
            this.tool2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tool2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool2.Margin = new System.Windows.Forms.Padding(0);
            this.tool2.Name = "tool2";
            this.tool2.Size = new System.Drawing.Size(60, 60);
            this.tool2.Tag = "1";
            this.tool2.Text = "抓取商品";
            // 
            // tool3
            // 
            this.tool3.AutoSize = false;
            this.tool3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool3.Margin = new System.Windows.Forms.Padding(0);
            this.tool3.Name = "tool3";
            this.tool3.Size = new System.Drawing.Size(60, 60);
            this.tool3.Tag = "2";
            this.tool3.Text = "整店复制";
            // 
            // tool4
            // 
            this.tool4.AutoSize = false;
            this.tool4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool4.Margin = new System.Windows.Forms.Padding(0);
            this.tool4.Name = "tool4";
            this.tool4.Size = new System.Drawing.Size(60, 60);
            this.tool4.Tag = "3";
            this.tool4.Text = "图片管理";
            // 
            // tool5
            // 
            this.tool5.AutoSize = false;
            this.tool5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool5.Margin = new System.Windows.Forms.Padding(0);
            this.tool5.Name = "tool5";
            this.tool5.Size = new System.Drawing.Size(60, 60);
            this.tool5.Tag = "4";
            this.tool5.Text = "评价管理";
            // 
            // tool6
            // 
            this.tool6.AutoSize = false;
            this.tool6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool6.Margin = new System.Windows.Forms.Padding(0);
            this.tool6.Name = "tool6";
            this.tool6.Size = new System.Drawing.Size(60, 60);
            this.tool6.Tag = "5";
            this.tool6.Text = "商品管理";
            // 
            // tool7
            // 
            this.tool7.AutoSize = false;
            this.tool7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool7.Margin = new System.Windows.Forms.Padding(0);
            this.tool7.Name = "tool7";
            this.tool7.Size = new System.Drawing.Size(60, 60);
            this.tool7.Tag = "6";
            this.tool7.Text = "订单管理";
            // 
            // tool8
            // 
            this.tool8.AutoSize = false;
            this.tool8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool8.Margin = new System.Windows.Forms.Padding(0);
            this.tool8.Name = "tool8";
            this.tool8.Size = new System.Drawing.Size(60, 60);
            this.tool8.Tag = "7";
            this.tool8.Text = "店铺设置";
            // 
            // ToolShow
            // 
            this.ToolShow.Arrow = System.Drawing.Color.Black;
            this.ToolShow.AutoSize = false;
            this.ToolShow.Back = System.Drawing.Color.White;
            this.ToolShow.BackColor = System.Drawing.Color.Transparent;
            this.ToolShow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ToolShow.BackgroundImage")));
            this.ToolShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ToolShow.BackRadius = 4;
            this.ToolShow.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.ToolShow.Base = System.Drawing.Color.Transparent;
            this.ToolShow.BaseFore = System.Drawing.Color.Black;
            this.ToolShow.BaseForeAnamorphosis = false;
            this.ToolShow.BaseForeAnamorphosisBorder = 4;
            this.ToolShow.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.ToolShow.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.ToolShow.BaseHoverFore = System.Drawing.Color.White;
            this.ToolShow.BaseItemAnamorphosis = true;
            this.ToolShow.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.ToolShow.BaseItemBorderShow = true;
            this.ToolShow.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("ToolShow.BaseItemDown")));
            this.ToolShow.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.ToolShow.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("ToolShow.BaseItemMouse")));
            this.ToolShow.BaseItemNorml = null;
            this.ToolShow.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.ToolShow.BaseItemRadius = 4;
            this.ToolShow.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.ToolShow.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.ToolShow.BindTabControl = this.tabShow;
            this.ToolShow.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.ToolShow.Fore = System.Drawing.Color.Black;
            this.ToolShow.GripMargin = new System.Windows.Forms.Padding(0);
            this.ToolShow.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolShow.HoverFore = System.Drawing.Color.White;
            this.ToolShow.ItemAnamorphosis = true;
            this.ToolShow.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.ToolShow.ItemBorderShow = true;
            this.ToolShow.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.ToolShow.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.ToolShow.ItemRadius = 4;
            this.ToolShow.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.ToolShow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool1,
            this.tool2,
            this.tool3,
            this.tool4,
            this.tool5,
            this.tool6,
            this.tool7,
            this.tool8});
            this.ToolShow.Location = new System.Drawing.Point(4, 32);
            this.ToolShow.Name = "ToolShow";
            this.ToolShow.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.ToolShow.Size = new System.Drawing.Size(992, 66);
            this.ToolShow.SkinAllColor = true;
            this.ToolShow.TabIndex = 1;
            this.ToolShow.Text = "skinToolStrip1";
            this.ToolShow.TitleAnamorphosis = true;
            this.ToolShow.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.ToolShow.TitleRadius = 4;
            this.ToolShow.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            // 
            // SkinToolMenu
            // 
            this.SkinToolMenu.Arrow = System.Drawing.Color.Black;
            this.SkinToolMenu.Back = System.Drawing.Color.White;
            this.SkinToolMenu.BackRadius = 4;
            this.SkinToolMenu.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.SkinToolMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.SkinToolMenu.Fore = System.Drawing.Color.Black;
            this.SkinToolMenu.HoverFore = System.Drawing.Color.White;
            this.SkinToolMenu.ItemAnamorphosis = false;
            this.SkinToolMenu.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.SkinToolMenu.ItemBorderShow = false;
            this.SkinToolMenu.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.SkinToolMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.SkinToolMenu.ItemRadius = 4;
            this.SkinToolMenu.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.SkinToolMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stmTop,
            this.stmApply,
            this.stmUpdate,
            this.stmSet,
            this.toolStripMenuItem6,
            this.stmAuthor,
            this.stmAbout,
            this.toolStripMenuItem7,
            this.stmLogout,
            this.stmExit});
            this.SkinToolMenu.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.SkinToolMenu.Name = "SkinToolMenu";
            this.SkinToolMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.SkinToolMenu.Size = new System.Drawing.Size(153, 214);
            this.SkinToolMenu.SkinAllColor = true;
            this.SkinToolMenu.TitleAnamorphosis = false;
            this.SkinToolMenu.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.SkinToolMenu.TitleRadius = 4;
            this.SkinToolMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // stmTop
            // 
            this.stmTop.Name = "stmTop";
            this.stmTop.Size = new System.Drawing.Size(152, 22);
            this.stmTop.Text = "窗口置顶(&T)";
            this.stmTop.Click += new System.EventHandler(this.stmTop_Click);
            // 
            // stmUpdate
            // 
            this.stmUpdate.Name = "stmUpdate";
            this.stmUpdate.Size = new System.Drawing.Size(152, 22);
            this.stmUpdate.Text = "更新缓存(&U)";
            this.stmUpdate.Click += new System.EventHandler(this.stmUpdate_Click);
            // 
            // stmSet
            // 
            this.stmSet.Image = global::TxoooProductUpload.UI.Properties.Resources.set_icon;
            this.stmSet.Name = "stmSet";
            this.stmSet.Size = new System.Drawing.Size(152, 22);
            this.stmSet.Text = "软件设置(&S)";
            this.stmSet.Click += new System.EventHandler(this.stmSet_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(149, 6);
            // 
            // stmAuthor
            // 
            this.stmAuthor.Image = global::TxoooProductUpload.UI.Properties.Resources.counseling_style_51;
            this.stmAuthor.Name = "stmAuthor";
            this.stmAuthor.Size = new System.Drawing.Size(152, 22);
            this.stmAuthor.Text = "联系作者(&P)";
            this.stmAuthor.Click += new System.EventHandler(this.stmAuthor_Click);
            // 
            // stmAbout
            // 
            this.stmAbout.Image = global::TxoooProductUpload.UI.Properties.Resources.info_16;
            this.stmAbout.Name = "stmAbout";
            this.stmAbout.Size = new System.Drawing.Size(152, 22);
            this.stmAbout.Text = "关于系统(&A)";
            this.stmAbout.Click += new System.EventHandler(this.stmAbout_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(149, 6);
            // 
            // stmLogout
            // 
            this.stmLogout.Image = global::TxoooProductUpload.UI.Properties.Resources.left_16;
            this.stmLogout.Name = "stmLogout";
            this.stmLogout.Size = new System.Drawing.Size(152, 22);
            this.stmLogout.Text = "注销(&L)";
            this.stmLogout.Click += new System.EventHandler(this.stmLogout_Click);
            // 
            // stmExit
            // 
            this.stmExit.Image = global::TxoooProductUpload.UI.Properties.Resources.block_16;
            this.stmExit.Name = "stmExit";
            this.stmExit.Size = new System.Drawing.Size(152, 22);
            this.stmExit.Text = "退出(&E)";
            this.stmExit.Click += new System.EventHandler(this.stmExit_Click);
            // 
            // ss
            // 
            this.ss.BackColor = System.Drawing.Color.Transparent;
            this.ss.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ss.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stStates,
            this.stLoginInfo,
            this.stCompany});
            this.ss.Location = new System.Drawing.Point(4, 671);
            this.ss.Name = "ss";
            this.ss.Size = new System.Drawing.Size(992, 25);
            this.ss.TabIndex = 4;
            this.ss.Text = "statusStrip1";
            // 
            // stStates
            // 
            this.stStates.ForeColor = System.Drawing.Color.DimGray;
            this.stStates.Image = global::TxoooProductUpload.UI.Properties.Resources.show;
            this.stStates.Name = "stStates";
            this.stStates.Size = new System.Drawing.Size(56, 20);
            this.stStates.Text = "就绪.";
            // 
            // stLoginInfo
            // 
            this.stLoginInfo.Name = "stLoginInfo";
            this.stLoginInfo.Size = new System.Drawing.Size(769, 20);
            this.stLoginInfo.Spring = true;
            this.stLoginInfo.Text = "toolStripStatusLabel2";
            // 
            // stCompany
            // 
            this.stCompany.Name = "stCompany";
            this.stCompany.Size = new System.Drawing.Size(152, 20);
            this.stCompany.Text = "toolStripStatusLabel3";
            // 
            // stmApply
            // 
            this.stmApply.Name = "stmApply";
            this.stmApply.Size = new System.Drawing.Size(152, 22);
            this.stmApply.Text = "商家入驻(&R)";
            this.stmApply.Click += new System.EventHandler(this.stmApply_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.BorderPalace = ((System.Drawing.Image)(resources.GetObject("$this.BorderPalace")));
            this.CaptionFont = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CaptionHeight = 28;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.CloseBoxSize = new System.Drawing.Size(39, 20);
            this.CloseDownBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseDownBack")));
            this.CloseMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseMouseBack")));
            this.CloseNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseNormlBack")));
            this.ControlBoxOffset = new System.Drawing.Point(0, -1);
            this.Controls.Add(this.tabShow);
            this.Controls.Add(this.ToolShow);
            this.Controls.Add(this.ss);
            this.EffectBack = System.Drawing.Color.Transparent;
            this.EffectCaption = CCWin.TitleType.Title;
            this.EffectWidth = 5;
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ICoOffset = new System.Drawing.Point(5, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaxDownBack = ((System.Drawing.Image)(resources.GetObject("$this.MaxDownBack")));
            this.MaxMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.MaxMouseBack")));
            this.MaxNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.MaxNormlBack")));
            this.MaxSize = new System.Drawing.Size(28, 20);
            this.MiniDownBack = ((System.Drawing.Image)(resources.GetObject("$this.MiniDownBack")));
            this.MiniMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.MiniMouseBack")));
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.MiniNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.MiniNormlBack")));
            this.MiniSize = new System.Drawing.Size(28, 20);
            this.Name = "MainForm";
            this.RestoreDownBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreDownBack")));
            this.RestoreMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreMouseBack")));
            this.RestoreNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreNormlBack")));
            this.ShadowPalace = ((System.Drawing.Image)(resources.GetObject("$this.ShadowPalace")));
            this.ShowSystemMenu = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            cmSysButton3.Bounds = new System.Drawing.Rectangle(877, -1, 28, 20);
            cmSysButton3.BoxState = CCWin.ControlBoxState.Normal;
            cmSysButton3.Location = new System.Drawing.Point(877, -1);
            cmSysButton3.Name = "ToolSet";
            cmSysButton3.OwnerForm = this;
            cmSysButton3.SysButtonDown = ((System.Drawing.Image)(resources.GetObject("cmSysButton3.SysButtonDown")));
            cmSysButton3.SysButtonMouse = ((System.Drawing.Image)(resources.GetObject("cmSysButton3.SysButtonMouse")));
            cmSysButton3.SysButtonNorml = ((System.Drawing.Image)(resources.GetObject("cmSysButton3.SysButtonNorml")));
            cmSysButton3.ToolTip = "设置";
            cmSysButton4.Bounds = new System.Drawing.Rectangle(849, -1, 28, 20);
            cmSysButton4.BoxState = CCWin.ControlBoxState.Normal;
            cmSysButton4.Location = new System.Drawing.Point(849, -1);
            cmSysButton4.Name = "ToolSkin";
            cmSysButton4.OwnerForm = this;
            cmSysButton4.SysButtonDown = ((System.Drawing.Image)(resources.GetObject("cmSysButton4.SysButtonDown")));
            cmSysButton4.SysButtonMouse = ((System.Drawing.Image)(resources.GetObject("cmSysButton4.SysButtonMouse")));
            cmSysButton4.SysButtonNorml = ((System.Drawing.Image)(resources.GetObject("cmSysButton4.SysButtonNorml")));
            cmSysButton4.ToolTip = "皮肤";
            this.SysButtonItems.AddRange(new CCWin.CmSysButton[] {
            cmSysButton3,
            cmSysButton4});
            this.Text = "";
            this.TitleCenter = true;
            this.TitleColor = System.Drawing.Color.White;
            this.SysBottomClick += new CCWin.CCSkinMain.SysBottomEventHandler(this.FrmMain_SysBottomClick);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmMain_Paint);
            this.tabShow.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.palShow.ResumeLayout(false);
            this.SkinMenu.ResumeLayout(false);
            this.ToolShow.ResumeLayout(false);
            this.ToolShow.PerformLayout();
            this.SkinToolMenu.ResumeLayout(false);
            this.ss.ResumeLayout(false);
            this.ss.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CCWin.SkinControl.SkinContextMenuStrip SkinMenu;
        private System.Windows.Forms.ToolStripMenuItem SkinTool1;
        private CCWin.SkinControl.SkinTabControl tabShow;
        private CCWin.SkinControl.SkinTabPage tabPage2;
        private CCWin.SkinControl.SkinTabPage tabPage3;
        private CCWin.SkinControl.SkinTabPage tabPage4;
        private CCWin.SkinControl.SkinTabPage tabPage5;
        private CCWin.SkinControl.SkinTabPage tabPage6;
        private CCWin.SkinControl.SkinTabPage tabPage7;
        private CCWin.SkinControl.SkinTabPage tabPage8;
        private System.Windows.Forms.ToolStripButton tool1;
        private System.Windows.Forms.ToolStripButton tool2;
        private System.Windows.Forms.ToolStripButton tool3;
        private System.Windows.Forms.ToolStripButton tool4;
        private System.Windows.Forms.ToolStripButton tool5;
        private System.Windows.Forms.ToolStripButton tool6;
        private System.Windows.Forms.ToolStripButton tool7;
        private System.Windows.Forms.ToolStripButton tool8;
        private CCWin.SkinControl.SkinToolStrip ToolShow;
        private CCWin.SkinControl.SkinContextMenuStrip SkinToolMenu;
        private System.Windows.Forms.ToolStripMenuItem stmTop;
        private System.Windows.Forms.ToolStripMenuItem stmSet;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem stmAuthor;
        private System.Windows.Forms.ToolStripMenuItem stmAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem stmExit;
        private System.Windows.Forms.Timer timColor;
        private System.Windows.Forms.StatusStrip ss;
        private CCWin.SkinControl.SkinTabPage tabPage1;
        private CCWin.SkinControl.SkinPanel skinPanel1;
        private System.Windows.Forms.ToolStripStatusLabel stStates;
        private System.Windows.Forms.ToolStripStatusLabel stLoginInfo;
        private System.Windows.Forms.ToolStripStatusLabel stCompany;
        private System.Windows.Forms.ToolStripMenuItem stmLogout;
        private Xilium.CefGlue.WindowsForms.CefWebBrowser webBrowser;
        private System.Windows.Forms.Panel palShow;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripMenuItem stmUpdate;
        private System.Windows.Forms.ToolStripMenuItem stmApply;
    }
}


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
 * * 网站：CSkin界面库 http://www.cskin.net 
 * * 论坛：http://bbs.cskin.net
 * * 作者： 乔克斯 QQ：345015918 .Net项目技术组群：306485590
 * * 请保留以上版权信息，否则作者将保留追究法律责任。
 * *
 * * 创建时间：2015-01-28
 * * 说明：FrmLogin.Designer.cs
 * *
********************************************************************/

namespace TxoooProductUpload.UI
{
    partial class LoginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            CCWin.CmSysButton cmSysButton1 = new CCWin.CmSysButton();
            this.pnlTx = new CCWin.SkinControl.SkinPanel();
            this.pnlHeadPic = new CCWin.SkinControl.SkinPanel();
            this.btnDuoId = new CCWin.SkinControl.SkinButton();
            this.btnSw = new CCWin.SkinControl.SkinButton();
            this.btnLogin = new CCWin.SkinControl.SkinButton();
            this.chkRemember = new CCWin.SkinControl.SkinCheckBox();
            this.btnFindPwd = new CCWin.SkinControl.SkinButton();
            this.btnRegister = new CCWin.SkinControl.SkinButton();
            this.btnId = new CCWin.SkinControl.SkinButton();
            this.txtPwd = new CCWin.SkinControl.SkinTextBox();
            this.btnJpPwd = new CCWin.SkinControl.SkinButton();
            this.txtId = new CCWin.SkinControl.SkinTextBox();
            this.chkIsTest = new CCWin.SkinControl.SkinCheckBox();
            this.toolShow = new System.Windows.Forms.ToolTip(this.components);
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyMenu = new CCWin.SkinControl.SkinContextMenuStrip();
            this.tsShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuId = new CCWin.SkinControl.SkinContextMenuStrip();
            this.ItemImonline = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemQme = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemAway = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemBusy = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemMute = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemInVisble = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuState = new CCWin.SkinControl.SkinContextMenuStrip();
            this.prbLoading = new System.Windows.Forms.ProgressBar();
            this.pwdErro = new TxoooProductUpload.UI.PwdErro();
            this.loginCode = new TxoooProductUpload.UI.LoginCode();
            this.pnlTx.SuspendLayout();
            this.txtPwd.SuspendLayout();
            this.txtId.SuspendLayout();
            this.NotifyMenu.SuspendLayout();
            this.MenuState.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTx
            // 
            this.pnlTx.BackColor = System.Drawing.Color.Transparent;
            this.pnlTx.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTx.BackgroundImage")));
            this.pnlTx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlTx.Controls.Add(this.pnlHeadPic);
            this.pnlTx.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.pnlTx.DownBack = null;
            this.pnlTx.Location = new System.Drawing.Point(42, 195);
            this.pnlTx.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTx.MouseBack = null;
            this.pnlTx.Name = "pnlTx";
            this.pnlTx.NormlBack = null;
            this.pnlTx.Size = new System.Drawing.Size(82, 82);
            this.pnlTx.TabIndex = 13;
            // 
            // pnlHeadPic
            // 
            this.pnlHeadPic.BackColor = System.Drawing.Color.White;
            this.pnlHeadPic.BackgroundImage = global::TxoooProductUpload.UI.Properties.Resources.head_d;
            this.pnlHeadPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHeadPic.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.pnlHeadPic.DownBack = null;
            this.pnlHeadPic.Location = new System.Drawing.Point(1, 1);
            this.pnlHeadPic.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeadPic.MouseBack = null;
            this.pnlHeadPic.Name = "pnlHeadPic";
            this.pnlHeadPic.NormlBack = null;
            this.pnlHeadPic.Radius = 4;
            this.pnlHeadPic.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.pnlHeadPic.Size = new System.Drawing.Size(80, 80);
            this.pnlHeadPic.TabIndex = 12;
            // 
            // btnDuoId
            // 
            this.btnDuoId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDuoId.BackColor = System.Drawing.Color.Transparent;
            this.btnDuoId.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.btnDuoId.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnDuoId.DownBack = ((System.Drawing.Image)(resources.GetObject("btnDuoId.DownBack")));
            this.btnDuoId.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnDuoId.Location = new System.Drawing.Point(9, 301);
            this.btnDuoId.Margin = new System.Windows.Forms.Padding(0);
            this.btnDuoId.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnDuoId.MouseBack")));
            this.btnDuoId.Name = "btnDuoId";
            this.btnDuoId.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnDuoId.NormlBack")));
            this.btnDuoId.Size = new System.Drawing.Size(24, 24);
            this.btnDuoId.TabIndex = 14;
            this.toolShow.SetToolTip(this.btnDuoId, "多帐号登录");
            this.btnDuoId.UseVisualStyleBackColor = false;
            // 
            // btnSw
            // 
            this.btnSw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSw.BackColor = System.Drawing.Color.Transparent;
            this.btnSw.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.btnSw.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSw.DownBack = ((System.Drawing.Image)(resources.GetObject("btnSw.DownBack")));
            this.btnSw.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnSw.Location = new System.Drawing.Point(399, 301);
            this.btnSw.Margin = new System.Windows.Forms.Padding(0);
            this.btnSw.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnSw.MouseBack")));
            this.btnSw.Name = "btnSw";
            this.btnSw.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnSw.NormlBack")));
            this.btnSw.Size = new System.Drawing.Size(24, 24);
            this.btnSw.TabIndex = 15;
            this.toolShow.SetToolTip(this.btnSw, "二维码登录");
            this.btnSw.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogin.BackRectangle = new System.Drawing.Rectangle(50, 23, 50, 23);
            this.btnLogin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.btnLogin.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnLogin.DownBack = ((System.Drawing.Image)(resources.GetObject("btnLogin.DownBack")));
            this.btnLogin.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(133, 288);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogin.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnLogin.MouseBack")));
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnLogin.NormlBack")));
            this.btnLogin.Size = new System.Drawing.Size(194, 30);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登  录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.BackColor = System.Drawing.Color.Transparent;
            this.chkRemember.Checked = true;
            this.chkRemember.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemember.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.chkRemember.DefaultCheckButtonWidth = 17;
            this.chkRemember.DownBack = ((System.Drawing.Image)(resources.GetObject("chkRemember.DownBack")));
            this.chkRemember.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkRemember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(101)))), ((int)(((byte)(101)))));
            this.chkRemember.LightEffect = false;
            this.chkRemember.Location = new System.Drawing.Point(133, 260);
            this.chkRemember.MouseBack = ((System.Drawing.Image)(resources.GetObject("chkRemember.MouseBack")));
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.NormlBack = ((System.Drawing.Image)(resources.GetObject("chkRemember.NormlBack")));
            this.chkRemember.SelectedDownBack = ((System.Drawing.Image)(resources.GetObject("chkRemember.SelectedDownBack")));
            this.chkRemember.SelectedMouseBack = ((System.Drawing.Image)(resources.GetObject("chkRemember.SelectedMouseBack")));
            this.chkRemember.SelectedNormlBack = ((System.Drawing.Image)(resources.GetObject("chkRemember.SelectedNormlBack")));
            this.chkRemember.Size = new System.Drawing.Size(75, 21);
            this.chkRemember.TabIndex = 1;
            this.chkRemember.Text = "记住密码";
            this.chkRemember.UseVisualStyleBackColor = false;
            // 
            // btnFindPwd
            // 
            this.btnFindPwd.BackColor = System.Drawing.Color.Transparent;
            this.btnFindPwd.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.btnFindPwd.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnFindPwd.Create = true;
            this.btnFindPwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindPwd.DownBack = ((System.Drawing.Image)(resources.GetObject("btnFindPwd.DownBack")));
            this.btnFindPwd.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnFindPwd.Location = new System.Drawing.Point(337, 235);
            this.btnFindPwd.Margin = new System.Windows.Forms.Padding(0);
            this.btnFindPwd.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnFindPwd.MouseBack")));
            this.btnFindPwd.Name = "btnFindPwd";
            this.btnFindPwd.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnFindPwd.NormlBack")));
            this.btnFindPwd.Size = new System.Drawing.Size(48, 11);
            this.btnFindPwd.TabIndex = 38;
            this.btnFindPwd.Tag = "findpwd";
            this.btnFindPwd.UseVisualStyleBackColor = false;
            this.btnFindPwd.Click += new System.EventHandler(this.RegAndFindPwd_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnRegister.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.btnRegister.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnRegister.Create = true;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.DownBack = ((System.Drawing.Image)(resources.GetObject("btnRegister.DownBack")));
            this.btnRegister.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnRegister.Location = new System.Drawing.Point(337, 205);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(0);
            this.btnRegister.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnRegister.MouseBack")));
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnRegister.NormlBack")));
            this.btnRegister.Size = new System.Drawing.Size(48, 11);
            this.btnRegister.TabIndex = 37;
            this.btnRegister.Tag = "reg";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.RegAndFindPwd_Click);
            // 
            // btnId
            // 
            this.btnId.BackColor = System.Drawing.Color.White;
            this.btnId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnId.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.btnId.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnId.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnId.DownBack = ((System.Drawing.Image)(resources.GetObject("btnId.DownBack")));
            this.btnId.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnId.IsEnabledDraw = false;
            this.btnId.Location = new System.Drawing.Point(170, 3);
            this.btnId.Margin = new System.Windows.Forms.Padding(0);
            this.btnId.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnId.MouseBack")));
            this.btnId.Name = "btnId";
            this.btnId.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnId.NormlBack")));
            this.btnId.Size = new System.Drawing.Size(22, 24);
            this.btnId.TabIndex = 36;
            this.btnId.UseVisualStyleBackColor = false;
            this.btnId.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnId_MouseDown);
            this.btnId.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnId.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            // 
            // txtPwd
            // 
            this.txtPwd.BackColor = System.Drawing.Color.White;
            this.txtPwd.Controls.Add(this.btnJpPwd);
            this.txtPwd.DownBack = null;
            this.txtPwd.Icon = null;
            this.txtPwd.IconIsButton = true;
            this.txtPwd.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtPwd.IsPasswordChat = '●';
            this.txtPwd.IsSystemPasswordChar = false;
            this.txtPwd.Lines = new string[0];
            this.txtPwd.Location = new System.Drawing.Point(133, 226);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(0);
            this.txtPwd.MaxLength = 32767;
            this.txtPwd.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtPwd.MouseBack = ((System.Drawing.Bitmap)(resources.GetObject("txtPwd.MouseBack")));
            this.txtPwd.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtPwd.Multiline = true;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.NormlBack = ((System.Drawing.Bitmap)(resources.GetObject("txtPwd.NormlBack")));
            this.txtPwd.Padding = new System.Windows.Forms.Padding(5, 5, 28, 5);
            this.txtPwd.ReadOnly = false;
            this.txtPwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPwd.Size = new System.Drawing.Size(194, 30);
            // 
            // 
            // 
            this.txtPwd.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPwd.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPwd.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtPwd.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtPwd.SkinTxt.Multiline = true;
            this.txtPwd.SkinTxt.Name = "BaseText";
            this.txtPwd.SkinTxt.PasswordChar = '●';
            this.txtPwd.SkinTxt.Size = new System.Drawing.Size(161, 20);
            this.txtPwd.SkinTxt.TabIndex = 0;
            this.txtPwd.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtPwd.SkinTxt.WaterText = "密码";
            this.txtPwd.TabIndex = 1;
            this.txtPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPwd.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtPwd.WaterText = "密码";
            this.txtPwd.WordWrap = true;
            // 
            // btnJpPwd
            // 
            this.btnJpPwd.BackColor = System.Drawing.Color.White;
            this.btnJpPwd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnJpPwd.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.btnJpPwd.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnJpPwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJpPwd.DownBack = ((System.Drawing.Image)(resources.GetObject("btnJpPwd.DownBack")));
            this.btnJpPwd.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnJpPwd.Location = new System.Drawing.Point(172, 6);
            this.btnJpPwd.Margin = new System.Windows.Forms.Padding(0);
            this.btnJpPwd.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnJpPwd.MouseBack")));
            this.btnJpPwd.Name = "btnJpPwd";
            this.btnJpPwd.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnJpPwd.NormlBack")));
            this.btnJpPwd.Size = new System.Drawing.Size(15, 16);
            this.btnJpPwd.TabIndex = 41;
            this.toolShow.SetToolTip(this.btnJpPwd, "打开软键盘");
            this.btnJpPwd.UseVisualStyleBackColor = false;
            this.btnJpPwd.Click += new System.EventHandler(this.btnJpPwd_Click);
            this.btnJpPwd.MouseEnter += new System.EventHandler(this.btnJpPwd_MouseEnter);
            this.btnJpPwd.MouseLeave += new System.EventHandler(this.btnJpPwd_MouseLeave);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.White;
            this.txtId.Controls.Add(this.btnId);
            this.txtId.DownBack = null;
            this.txtId.Icon = null;
            this.txtId.IconIsButton = false;
            this.txtId.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtId.IsPasswordChat = '\0';
            this.txtId.IsSystemPasswordChar = false;
            this.txtId.Lines = new string[0];
            this.txtId.Location = new System.Drawing.Point(133, 196);
            this.txtId.Margin = new System.Windows.Forms.Padding(0);
            this.txtId.MaxLength = 32767;
            this.txtId.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtId.MouseBack = ((System.Drawing.Bitmap)(resources.GetObject("txtId.MouseBack")));
            this.txtId.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtId.Multiline = true;
            this.txtId.Name = "txtId";
            this.txtId.NormlBack = ((System.Drawing.Bitmap)(resources.GetObject("txtId.NormlBack")));
            this.txtId.Padding = new System.Windows.Forms.Padding(5, 5, 28, 5);
            this.txtId.ReadOnly = false;
            this.txtId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtId.Size = new System.Drawing.Size(194, 30);
            // 
            // 
            // 
            this.txtId.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtId.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtId.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtId.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtId.SkinTxt.Multiline = true;
            this.txtId.SkinTxt.Name = "BaseText";
            this.txtId.SkinTxt.Size = new System.Drawing.Size(161, 20);
            this.txtId.SkinTxt.TabIndex = 0;
            this.txtId.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtId.SkinTxt.WaterText = "创业赚钱注册手机号码";
            this.txtId.TabIndex = 0;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtId.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtId.WaterText = "创业赚钱注册手机号码";
            this.txtId.WordWrap = true;
            this.txtId.Leave += new System.EventHandler(this.txtId_Leave);
            this.txtId.MouseLeave += new System.EventHandler(this.txtId_MouseLeave);
            // 
            // chkIsTest
            // 
            this.chkIsTest.AutoSize = true;
            this.chkIsTest.BackColor = System.Drawing.Color.Transparent;
            this.chkIsTest.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.chkIsTest.DefaultCheckButtonWidth = 17;
            this.chkIsTest.DownBack = ((System.Drawing.Image)(resources.GetObject("chkIsTest.DownBack")));
            this.chkIsTest.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkIsTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(101)))), ((int)(((byte)(101)))));
            this.chkIsTest.LightEffect = false;
            this.chkIsTest.Location = new System.Drawing.Point(252, 260);
            this.chkIsTest.MouseBack = ((System.Drawing.Image)(resources.GetObject("chkIsTest.MouseBack")));
            this.chkIsTest.Name = "chkIsTest";
            this.chkIsTest.NormlBack = ((System.Drawing.Image)(resources.GetObject("chkIsTest.NormlBack")));
            this.chkIsTest.SelectedDownBack = ((System.Drawing.Image)(resources.GetObject("chkIsTest.SelectedDownBack")));
            this.chkIsTest.SelectedMouseBack = ((System.Drawing.Image)(resources.GetObject("chkIsTest.SelectedMouseBack")));
            this.chkIsTest.SelectedNormlBack = ((System.Drawing.Image)(resources.GetObject("chkIsTest.SelectedNormlBack")));
            this.chkIsTest.Size = new System.Drawing.Size(75, 21);
            this.chkIsTest.TabIndex = 2;
            this.chkIsTest.Text = "测试环境";
            this.chkIsTest.UseVisualStyleBackColor = false;
            this.chkIsTest.CheckedChanged += new System.EventHandler(this.chkIsTest_CheckedChanged);
            // 
            // notify
            // 
            this.notify.ContextMenuStrip = this.NotifyMenu;
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Visible = true;
            this.notify.DoubleClick += new System.EventHandler(this.tsShow_Click);
            // 
            // NotifyMenu
            // 
            this.NotifyMenu.Arrow = System.Drawing.Color.Black;
            this.NotifyMenu.Back = System.Drawing.Color.White;
            this.NotifyMenu.BackRadius = 2;
            this.NotifyMenu.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.NotifyMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.NotifyMenu.Fore = System.Drawing.Color.Black;
            this.NotifyMenu.HoverFore = System.Drawing.Color.White;
            this.NotifyMenu.ImageScalingSize = new System.Drawing.Size(11, 11);
            this.NotifyMenu.ItemAnamorphosis = false;
            this.NotifyMenu.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(136)))), ((int)(((byte)(200)))));
            this.NotifyMenu.ItemBorderShow = false;
            this.NotifyMenu.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(136)))), ((int)(((byte)(200)))));
            this.NotifyMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(136)))), ((int)(((byte)(200)))));
            this.NotifyMenu.ItemRadius = 4;
            this.NotifyMenu.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.NotifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsShow,
            this.tsSeparator,
            this.tsLogout,
            this.tsExit});
            this.NotifyMenu.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.NotifyMenu.Name = "MenuState";
            this.NotifyMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.NotifyMenu.Size = new System.Drawing.Size(153, 98);
            this.NotifyMenu.SkinAllColor = true;
            this.NotifyMenu.TitleAnamorphosis = false;
            this.NotifyMenu.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(233)))), ((int)(((byte)(236)))));
            this.NotifyMenu.TitleRadius = 4;
            this.NotifyMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            // 
            // tsShow
            // 
            this.tsShow.AutoSize = false;
            this.tsShow.Image = global::TxoooProductUpload.UI.Properties.Resources.show;
            this.tsShow.Name = "tsShow";
            this.tsShow.Size = new System.Drawing.Size(119, 22);
            this.tsShow.Text = "打开主面板(&S)";
            this.tsShow.Click += new System.EventHandler(this.tsShow_Click);
            // 
            // tsSeparator
            // 
            this.tsSeparator.Name = "tsSeparator";
            this.tsSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // tsLogout
            // 
            this.tsLogout.Enabled = false;
            this.tsLogout.Image = global::TxoooProductUpload.UI.Properties.Resources.left_16;
            this.tsLogout.Name = "tsLogout";
            this.tsLogout.Size = new System.Drawing.Size(152, 22);
            this.tsLogout.Text = "注销(&L)";
            this.tsLogout.Click += new System.EventHandler(this.tsLogout_Click);
            // 
            // tsExit
            // 
            this.tsExit.AutoSize = false;
            this.tsExit.Image = global::TxoooProductUpload.UI.Properties.Resources.block_16;
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(119, 22);
            this.tsExit.Text = "退出(&E)";
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // MenuId
            // 
            this.MenuId.Arrow = System.Drawing.Color.Black;
            this.MenuId.AutoSize = false;
            this.MenuId.Back = System.Drawing.Color.White;
            this.MenuId.BackColor = System.Drawing.Color.White;
            this.MenuId.BackRadius = 4;
            this.MenuId.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.MenuId.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(209)))));
            this.MenuId.Fore = System.Drawing.Color.Black;
            this.MenuId.HoverFore = System.Drawing.Color.White;
            this.MenuId.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.MenuId.ItemAnamorphosis = false;
            this.MenuId.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.MenuId.ItemBorderShow = false;
            this.MenuId.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.MenuId.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.MenuId.ItemRadius = 4;
            this.MenuId.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.MenuId.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.MenuId.Name = "MenuId";
            this.MenuId.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.MenuId.Size = new System.Drawing.Size(194, 4);
            this.MenuId.SkinAllColor = true;
            this.MenuId.TitleAnamorphosis = false;
            this.MenuId.TitleColor = System.Drawing.Color.White;
            this.MenuId.TitleRadius = 4;
            this.MenuId.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.MenuId.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.MenuId_Closing);
            // 
            // ItemImonline
            // 
            this.ItemImonline.Name = "ItemImonline";
            this.ItemImonline.Size = new System.Drawing.Size(68, 22);
            // 
            // ItemQme
            // 
            this.ItemQme.Name = "ItemQme";
            this.ItemQme.Size = new System.Drawing.Size(68, 22);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(102, 6);
            // 
            // ItemAway
            // 
            this.ItemAway.Name = "ItemAway";
            this.ItemAway.Size = new System.Drawing.Size(68, 22);
            // 
            // ItemBusy
            // 
            this.ItemBusy.Name = "ItemBusy";
            this.ItemBusy.Size = new System.Drawing.Size(68, 22);
            // 
            // ItemMute
            // 
            this.ItemMute.Name = "ItemMute";
            this.ItemMute.Size = new System.Drawing.Size(68, 22);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(102, 6);
            // 
            // ItemInVisble
            // 
            this.ItemInVisble.Name = "ItemInVisble";
            this.ItemInVisble.Size = new System.Drawing.Size(68, 22);
            // 
            // MenuState
            // 
            this.MenuState.Arrow = System.Drawing.Color.Black;
            this.MenuState.AutoSize = false;
            this.MenuState.Back = System.Drawing.Color.White;
            this.MenuState.BackRadius = 2;
            this.MenuState.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.MenuState.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.MenuState.Fore = System.Drawing.Color.Black;
            this.MenuState.HoverFore = System.Drawing.Color.White;
            this.MenuState.ImageScalingSize = new System.Drawing.Size(15, 15);
            this.MenuState.ItemAnamorphosis = false;
            this.MenuState.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.MenuState.ItemBorderShow = false;
            this.MenuState.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.MenuState.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.MenuState.ItemRadius = 4;
            this.MenuState.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.MenuState.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemImonline,
            this.ItemQme,
            this.toolStripMenuItem1,
            this.ItemAway,
            this.ItemBusy,
            this.ItemMute,
            this.toolStripMenuItem2,
            this.ItemInVisble});
            this.MenuState.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.MenuState.Name = "MenuState";
            this.MenuState.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.MenuState.Size = new System.Drawing.Size(106, 147);
            this.MenuState.SkinAllColor = true;
            this.MenuState.TitleAnamorphosis = false;
            this.MenuState.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.MenuState.TitleRadius = 2;
            this.MenuState.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            // 
            // prbLoading
            // 
            this.prbLoading.BackColor = System.Drawing.Color.DarkRed;
            this.prbLoading.ForeColor = System.Drawing.Color.Blue;
            this.prbLoading.Location = new System.Drawing.Point(0, 184);
            this.prbLoading.Name = "prbLoading";
            this.prbLoading.Size = new System.Drawing.Size(430, 3);
            this.prbLoading.TabIndex = 44;
            this.prbLoading.Visible = false;
            // 
            // pwdErro
            // 
            this.pwdErro.BackColor = System.Drawing.Color.Transparent;
            this.pwdErro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pwdErro.BackgroundImage")));
            this.pwdErro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pwdErro.Diglog = System.Windows.Forms.DialogResult.None;
            this.pwdErro.Location = new System.Drawing.Point(438, 25);
            this.pwdErro.Name = "pwdErro";
            this.pwdErro.Size = new System.Drawing.Size(430, 300);
            this.pwdErro.TabIndex = 42;
            this.pwdErro.Visible = false;
            // 
            // loginCode
            // 
            this.loginCode.BackColor = System.Drawing.Color.Transparent;
            this.loginCode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loginCode.BackgroundImage")));
            this.loginCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loginCode.Diglog = System.Windows.Forms.DialogResult.None;
            this.loginCode.Location = new System.Drawing.Point(443, 25);
            this.loginCode.Name = "loginCode";
            this.loginCode.Size = new System.Drawing.Size(430, 300);
            this.loginCode.TabIndex = 43;
            this.loginCode.Visible = false;
            this.loginCode.VisibleChanged += new System.EventHandler(this.loginCode_VisibleChanged);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Back = ((System.Drawing.Image)(resources.GetObject("$this.Back")));
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(249)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackShade = false;
            this.BackToColor = false;
            this.CanResize = false;
            this.CaptionHeight = 30;
            this.ClientSize = new System.Drawing.Size(430, 330);
            this.CloseBoxSize = new System.Drawing.Size(30, 30);
            this.CloseDownBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseDownBack")));
            this.CloseMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseMouseBack")));
            this.CloseNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseNormlBack")));
            this.ControlBoxOffset = new System.Drawing.Point(0, 0);
            this.Controls.Add(this.prbLoading);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.pwdErro);
            this.Controls.Add(this.loginCode);
            this.Controls.Add(this.chkIsTest);
            this.Controls.Add(this.chkRemember);
            this.Controls.Add(this.btnFindPwd);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnSw);
            this.Controls.Add(this.btnDuoId);
            this.Controls.Add(this.pnlTx);
            this.Controls.Add(this.txtPwd);
            this.DropBack = false;
            this.EffectCaption = CCWin.TitleType.None;
            this.MaxDownBack = ((System.Drawing.Image)(resources.GetObject("$this.MaxDownBack")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(430, 330);
            this.MaxMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.MaxMouseBack")));
            this.MaxNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.MaxNormlBack")));
            this.MaxSize = new System.Drawing.Size(30, 30);
            this.MiniDownBack = ((System.Drawing.Image)(resources.GetObject("$this.MiniDownBack")));
            this.MiniMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.MiniMouseBack")));
            this.MinimumSize = new System.Drawing.Size(430, 330);
            this.MiniNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.MiniNormlBack")));
            this.MiniSize = new System.Drawing.Size(30, 30);
            this.MobileApi = false;
            this.Name = "LoginForm";
            this.Radius = 2;
            this.RestoreDownBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreDownBack")));
            this.RestoreMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreMouseBack")));
            this.RestoreNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreNormlBack")));
            this.ShadowPalace = ((System.Drawing.Image)(resources.GetObject("$this.ShadowPalace")));
            this.ShadowWidth = 6;
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            cmSysButton1.Bounds = new System.Drawing.Rectangle(340, 0, 30, 30);
            cmSysButton1.BoxState = CCWin.ControlBoxState.Normal;
            cmSysButton1.Location = new System.Drawing.Point(340, 0);
            cmSysButton1.Name = "SysSet";
            cmSysButton1.OwnerForm = this;
            cmSysButton1.Size = new System.Drawing.Size(30, 30);
            cmSysButton1.SysButtonDown = ((System.Drawing.Image)(resources.GetObject("cmSysButton1.SysButtonDown")));
            cmSysButton1.SysButtonMouse = ((System.Drawing.Image)(resources.GetObject("cmSysButton1.SysButtonMouse")));
            cmSysButton1.SysButtonNorml = ((System.Drawing.Image)(resources.GetObject("cmSysButton1.SysButtonNorml")));
            cmSysButton1.ToolTip = "设置";
            this.SysButtonItems.AddRange(new CCWin.CmSysButton[] {
            cmSysButton1});
            this.Text = "";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.VisibleChanged += new System.EventHandler(this.FrmLogin_VisibleChanged);
            this.pnlTx.ResumeLayout(false);
            this.txtPwd.ResumeLayout(false);
            this.txtPwd.PerformLayout();
            this.txtId.ResumeLayout(false);
            this.txtId.PerformLayout();
            this.NotifyMenu.ResumeLayout(false);
            this.MenuState.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinPanel pnlTx;
        private CCWin.SkinControl.SkinPanel pnlHeadPic;
        private CCWin.SkinControl.SkinButton btnDuoId;
        private CCWin.SkinControl.SkinButton btnSw;
        private CCWin.SkinControl.SkinButton btnLogin;
        private CCWin.SkinControl.SkinCheckBox chkRemember;
        private CCWin.SkinControl.SkinButton btnFindPwd;
        private CCWin.SkinControl.SkinButton btnRegister;
        private CCWin.SkinControl.SkinButton btnId;
        private CCWin.SkinControl.SkinTextBox txtPwd;
        private CCWin.SkinControl.SkinTextBox txtId;
        private CCWin.SkinControl.SkinCheckBox chkIsTest;
        private CCWin.SkinControl.SkinButton btnJpPwd;
        private System.Windows.Forms.ToolTip toolShow;
        public System.Windows.Forms.NotifyIcon notify;
        private CCWin.SkinControl.SkinContextMenuStrip NotifyMenu;
        private System.Windows.Forms.ToolStripMenuItem tsShow;
        private System.Windows.Forms.ToolStripSeparator tsSeparator;
        private System.Windows.Forms.ToolStripMenuItem tsExit;
        private PwdErro pwdErro;
        private LoginCode loginCode;
        private CCWin.SkinControl.SkinContextMenuStrip MenuId;
        private System.Windows.Forms.ToolStripMenuItem ItemImonline;
        private System.Windows.Forms.ToolStripMenuItem ItemQme;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ItemAway;
        private System.Windows.Forms.ToolStripMenuItem ItemBusy;
        private System.Windows.Forms.ToolStripMenuItem ItemMute;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ItemInVisble;
        private CCWin.SkinControl.SkinContextMenuStrip MenuState;
        private System.Windows.Forms.ProgressBar prbLoading;
        private System.Windows.Forms.ToolStripMenuItem tsLogout;
    }
}


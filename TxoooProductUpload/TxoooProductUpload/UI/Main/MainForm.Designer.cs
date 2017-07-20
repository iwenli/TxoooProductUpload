using TxoooProductUpload.Common;

namespace TxoooProductUpload.UI.Main
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ts = new System.Windows.Forms.ToolStrip();
            this.tsImgManage = new System.Windows.Forms.ToolStripButton();
            this.tsExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLogout = new System.Windows.Forms.ToolStripButton();
            this.tsLogin = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsDataPack = new System.Windows.Forms.ToolStripButton();
            this.st = new System.Windows.Forms.StatusStrip();
            this.stStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.stProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.gbBase = new System.Windows.Forms.GroupBox();
            this.gbPostage = new System.Windows.Forms.GroupBox();
            this.tbLinit = new System.Windows.Forms.NumericUpDown();
            this.tbappend = new System.Windows.Forms.NumericUpDown();
            this.tbPostage = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPostage = new System.Windows.Forms.Label();
            this.gbIspostage = new System.Windows.Forms.GroupBox();
            this.rbPostageFalse = new System.Windows.Forms.RadioButton();
            this.rbPostageTrue = new System.Windows.Forms.RadioButton();
            this.gbVirtual = new System.Windows.Forms.GroupBox();
            this.rbVirtualFalse = new System.Windows.Forms.RadioButton();
            this.rbVirtualTrue = new System.Windows.Forms.RadioButton();
            this.gbShare = new System.Windows.Forms.GroupBox();
            this.tbShare = new System.Windows.Forms.TextBox();
            this.gbBrand = new System.Windows.Forms.GroupBox();
            this.tbBrand = new System.Windows.Forms.TextBox();
            this.gbRefund = new System.Windows.Forms.GroupBox();
            this.rbRefundFalse = new System.Windows.Forms.RadioButton();
            this.rbRefundTrue = new System.Windows.Forms.RadioButton();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.rbTypeOld = new System.Windows.Forms.RadioButton();
            this.rbTypeNew = new System.Windows.Forms.RadioButton();
            this.gbArea = new System.Windows.Forms.GroupBox();
            this.lbArea = new System.Windows.Forms.Label();
            this.cbArea3 = new System.Windows.Forms.ComboBox();
            this.cbArea2 = new System.Windows.Forms.ComboBox();
            this.cbArea1 = new System.Windows.Forms.ComboBox();
            this.gbClass = new System.Windows.Forms.GroupBox();
            this.tsClass4 = new System.Windows.Forms.Label();
            this.tsClass3 = new System.Windows.Forms.ComboBox();
            this.tsClass2 = new System.Windows.Forms.ComboBox();
            this.tsClass1 = new System.Windows.Forms.ComboBox();
            this.rchBoxLog = new System.Windows.Forms.RichTextBox();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.btnOneKeyOk = new System.Windows.Forms.Button();
            this.txtOneKeyUrl = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ts.SuspendLayout();
            this.st.SuspendLayout();
            this.gbSetting.SuspendLayout();
            this.gbBase.SuspendLayout();
            this.gbPostage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLinit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbappend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPostage)).BeginInit();
            this.gbIspostage.SuspendLayout();
            this.gbVirtual.SuspendLayout();
            this.gbShare.SuspendLayout();
            this.gbBrand.SuspendLayout();
            this.gbRefund.SuspendLayout();
            this.gbType.SuspendLayout();
            this.gbArea.SuspendLayout();
            this.gbClass.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // ts
            // 
            this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsImgManage,
            this.tsExit,
            this.toolStripSeparator1,
            this.tsLogout,
            this.tsLogin,
            this.toolStripSeparator3,
            this.tsDataPack});
            this.ts.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ts.Location = new System.Drawing.Point(0, 0);
            this.ts.Name = "ts";
            this.ts.Size = new System.Drawing.Size(1186, 31);
            this.ts.TabIndex = 0;
            this.ts.Text = "toolStrip1";
            // 
            // tsImgManage
            // 
            this.tsImgManage.Enabled = false;
            this.tsImgManage.Image = global::TxoooProductUpload.Properties.Resources.Postman;
            this.tsImgManage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsImgManage.Name = "tsImgManage";
            this.tsImgManage.Size = new System.Drawing.Size(104, 28);
            this.tsImgManage.Text = "图片管理(&M)";
            // 
            // tsExit
            // 
            this.tsExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsExit.Image = global::TxoooProductUpload.Properties.Resources.block_16;
            this.tsExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(76, 28);
            this.tsExit.Text = "退出(&X)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsLogout
            // 
            this.tsLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsLogout.Enabled = false;
            this.tsLogout.Image = global::TxoooProductUpload.Properties.Resources.left_16;
            this.tsLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLogout.Name = "tsLogout";
            this.tsLogout.Size = new System.Drawing.Size(74, 28);
            this.tsLogout.Text = "注销(&L)";
            // 
            // tsLogin
            // 
            this.tsLogin.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsLogin.Image = global::TxoooProductUpload.Properties.Resources.user_16;
            this.tsLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLogin.Name = "tsLogin";
            this.tsLogin.Size = new System.Drawing.Size(72, 28);
            this.tsLogin.Text = "登录(&I)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // tsDataPack
            // 
            this.tsDataPack.Enabled = false;
            this.tsDataPack.Image = global::TxoooProductUpload.Properties.Resources.processon;
            this.tsDataPack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDataPack.Name = "tsDataPack";
            this.tsDataPack.Size = new System.Drawing.Size(108, 28);
            this.tsDataPack.Text = "数据包导入(&I)";
            // 
            // st
            // 
            this.st.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.st.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stStatus,
            this.stProgress,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel1});
            this.st.Location = new System.Drawing.Point(0, 621);
            this.st.Name = "st";
            this.st.Size = new System.Drawing.Size(1186, 30);
            this.st.TabIndex = 2;
            this.st.Text = "statusStrip1";
            // 
            // stStatus
            // 
            this.stStatus.AutoSize = false;
            this.stStatus.Image = global::TxoooProductUpload.Properties.Resources.info_16;
            this.stStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stStatus.Name = "stStatus";
            this.stStatus.Size = new System.Drawing.Size(400, 25);
            this.stStatus.Text = "就绪";
            this.stStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stProgress
            // 
            this.stProgress.Name = "stProgress";
            this.stProgress.Size = new System.Drawing.Size(400, 24);
            this.stProgress.Visible = false;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Image = global::TxoooProductUpload.Properties.Resources.globe_16;
            this.toolStripStatusLabel3.IsLink = true;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(56, 25);
            this.toolStripStatusLabel3.Tag = "https://github.com/iwenli";
            this.toolStripStatusLabel3.Text = "开源";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Image = global::TxoooProductUpload.Properties.Resources.globe_16;
            this.toolStripStatusLabel4.IsLink = true;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(56, 25);
            this.toolStripStatusLabel4.Tag = "blog.iwenli.org";
            this.toolStripStatusLabel4.Text = "博客";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::TxoooProductUpload.Properties.Resources.globe_16;
            this.toolStripStatusLabel1.IsLink = true;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(56, 25);
            this.toolStripStatusLabel1.Tag = "iwenli.org";
            this.toolStripStatusLabel1.Text = "主页";
            // 
            // gbSetting
            // 
            this.gbSetting.Controls.Add(this.gbBase);
            this.gbSetting.Controls.Add(this.gbArea);
            this.gbSetting.Controls.Add(this.gbClass);
            this.gbSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSetting.Enabled = false;
            this.gbSetting.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSetting.Location = new System.Drawing.Point(0, 31);
            this.gbSetting.Margin = new System.Windows.Forms.Padding(2);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Padding = new System.Windows.Forms.Padding(2);
            this.gbSetting.Size = new System.Drawing.Size(1186, 164);
            this.gbSetting.TabIndex = 3;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "商品上传通用设置";
            // 
            // gbBase
            // 
            this.gbBase.Controls.Add(this.gbPostage);
            this.gbBase.Controls.Add(this.gbIspostage);
            this.gbBase.Controls.Add(this.gbVirtual);
            this.gbBase.Controls.Add(this.gbShare);
            this.gbBase.Controls.Add(this.gbBrand);
            this.gbBase.Controls.Add(this.gbRefund);
            this.gbBase.Controls.Add(this.gbType);
            this.gbBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbBase.Location = new System.Drawing.Point(432, 18);
            this.gbBase.Name = "gbBase";
            this.gbBase.Size = new System.Drawing.Size(752, 144);
            this.gbBase.TabIndex = 3;
            this.gbBase.TabStop = false;
            // 
            // gbPostage
            // 
            this.gbPostage.Controls.Add(this.tbLinit);
            this.gbPostage.Controls.Add(this.tbappend);
            this.gbPostage.Controls.Add(this.tbPostage);
            this.gbPostage.Controls.Add(this.label2);
            this.gbPostage.Controls.Add(this.label1);
            this.gbPostage.Controls.Add(this.lblPostage);
            this.gbPostage.Location = new System.Drawing.Point(374, 9);
            this.gbPostage.Name = "gbPostage";
            this.gbPostage.Size = new System.Drawing.Size(372, 62);
            this.gbPostage.TabIndex = 3;
            this.gbPostage.TabStop = false;
            this.gbPostage.Text = "包邮条件";
            this.toolTip.SetToolTip(this.gbPostage, "包邮条件设置\r\n邮费表示基础运费\r\n递增邮费表示没增加一件需要补加的邮费\r\n包邮条件表示满足几件即可免邮费");
            // 
            // tbLinit
            // 
            this.tbLinit.Font = new System.Drawing.Font("微软雅黑", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbLinit.Location = new System.Drawing.Point(294, 25);
            this.tbLinit.Name = "tbLinit";
            this.tbLinit.Size = new System.Drawing.Size(51, 19);
            this.tbLinit.TabIndex = 2;
            this.toolTip.SetToolTip(this.tbLinit, "单位：件");
            // 
            // tbappend
            // 
            this.tbappend.Font = new System.Drawing.Font("微软雅黑", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbappend.Location = new System.Drawing.Point(174, 25);
            this.tbappend.Name = "tbappend";
            this.tbappend.Size = new System.Drawing.Size(51, 19);
            this.tbappend.TabIndex = 2;
            this.toolTip.SetToolTip(this.tbappend, "单位：元");
            // 
            // tbPostage
            // 
            this.tbPostage.Font = new System.Drawing.Font("微软雅黑", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPostage.Location = new System.Drawing.Point(43, 25);
            this.tbPostage.Name = "tbPostage";
            this.tbPostage.Size = new System.Drawing.Size(51, 19);
            this.tbPostage.TabIndex = 2;
            this.toolTip.SetToolTip(this.tbPostage, "单位：元");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "包邮条件:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "递增邮费:";
            // 
            // lblPostage
            // 
            this.lblPostage.AutoSize = true;
            this.lblPostage.Location = new System.Drawing.Point(7, 26);
            this.lblPostage.Name = "lblPostage";
            this.lblPostage.Size = new System.Drawing.Size(35, 17);
            this.lblPostage.TabIndex = 0;
            this.lblPostage.Text = "邮费:";
            // 
            // gbIspostage
            // 
            this.gbIspostage.Controls.Add(this.rbPostageFalse);
            this.gbIspostage.Controls.Add(this.rbPostageTrue);
            this.gbIspostage.Location = new System.Drawing.Point(255, 9);
            this.gbIspostage.Name = "gbIspostage";
            this.gbIspostage.Size = new System.Drawing.Size(113, 62);
            this.gbIspostage.TabIndex = 3;
            this.gbIspostage.TabStop = false;
            this.gbIspostage.Text = "是否包邮";
            this.toolTip.SetToolTip(this.gbIspostage, "设置包邮，如果不包邮则需设置运费条件");
            // 
            // rbPostageFalse
            // 
            this.rbPostageFalse.AutoSize = true;
            this.rbPostageFalse.Checked = true;
            this.rbPostageFalse.Location = new System.Drawing.Point(63, 23);
            this.rbPostageFalse.Name = "rbPostageFalse";
            this.rbPostageFalse.Size = new System.Drawing.Size(38, 21);
            this.rbPostageFalse.TabIndex = 2;
            this.rbPostageFalse.TabStop = true;
            this.rbPostageFalse.Text = "否";
            this.rbPostageFalse.UseVisualStyleBackColor = true;
            // 
            // rbPostageTrue
            // 
            this.rbPostageTrue.AutoSize = true;
            this.rbPostageTrue.Location = new System.Drawing.Point(19, 23);
            this.rbPostageTrue.Name = "rbPostageTrue";
            this.rbPostageTrue.Size = new System.Drawing.Size(38, 21);
            this.rbPostageTrue.TabIndex = 3;
            this.rbPostageTrue.Tag = "1";
            this.rbPostageTrue.Text = "是";
            this.rbPostageTrue.UseVisualStyleBackColor = true;
            // 
            // gbVirtual
            // 
            this.gbVirtual.Controls.Add(this.rbVirtualFalse);
            this.gbVirtual.Controls.Add(this.rbVirtualTrue);
            this.gbVirtual.Location = new System.Drawing.Point(136, 9);
            this.gbVirtual.Name = "gbVirtual";
            this.gbVirtual.Size = new System.Drawing.Size(113, 62);
            this.gbVirtual.TabIndex = 3;
            this.gbVirtual.TabStop = false;
            this.gbVirtual.Text = "是否虚拟商品";
            // 
            // rbVirtualFalse
            // 
            this.rbVirtualFalse.AutoSize = true;
            this.rbVirtualFalse.Checked = true;
            this.rbVirtualFalse.Location = new System.Drawing.Point(63, 23);
            this.rbVirtualFalse.Name = "rbVirtualFalse";
            this.rbVirtualFalse.Size = new System.Drawing.Size(38, 21);
            this.rbVirtualFalse.TabIndex = 2;
            this.rbVirtualFalse.TabStop = true;
            this.rbVirtualFalse.Tag = "0";
            this.rbVirtualFalse.Text = "否";
            this.rbVirtualFalse.UseVisualStyleBackColor = true;
            // 
            // rbVirtualTrue
            // 
            this.rbVirtualTrue.AutoSize = true;
            this.rbVirtualTrue.Location = new System.Drawing.Point(19, 23);
            this.rbVirtualTrue.Name = "rbVirtualTrue";
            this.rbVirtualTrue.Size = new System.Drawing.Size(38, 21);
            this.rbVirtualTrue.TabIndex = 3;
            this.rbVirtualTrue.Tag = "1";
            this.rbVirtualTrue.Text = "是";
            this.rbVirtualTrue.UseVisualStyleBackColor = true;
            // 
            // gbShare
            // 
            this.gbShare.Controls.Add(this.tbShare);
            this.gbShare.Location = new System.Drawing.Point(374, 76);
            this.gbShare.Name = "gbShare";
            this.gbShare.Size = new System.Drawing.Size(372, 68);
            this.gbShare.TabIndex = 3;
            this.gbShare.TabStop = false;
            this.gbShare.Tag = "品牌";
            this.gbShare.Text = "推广语";
            this.toolTip.SetToolTip(this.gbShare, "设置商品推广语\r\n每条最多30个汉字\r\n多天推广语之间用|分割");
            // 
            // tbShare
            // 
            this.tbShare.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbShare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbShare.Location = new System.Drawing.Point(3, 19);
            this.tbShare.Multiline = true;
            this.tbShare.Name = "tbShare";
            this.tbShare.Size = new System.Drawing.Size(366, 46);
            this.tbShare.TabIndex = 0;
            this.toolTip.SetToolTip(this.tbShare, "设置商品推广语\r\n每条最多30个汉字\r\n多天推广语之间用|分割\r\n");
            // 
            // gbBrand
            // 
            this.gbBrand.Controls.Add(this.tbBrand);
            this.gbBrand.Location = new System.Drawing.Point(136, 77);
            this.gbBrand.Name = "gbBrand";
            this.gbBrand.Size = new System.Drawing.Size(232, 67);
            this.gbBrand.TabIndex = 3;
            this.gbBrand.TabStop = false;
            this.gbBrand.Tag = "品牌";
            this.gbBrand.Text = "品牌";
            this.toolTip.SetToolTip(this.gbBrand, "设置商品品牌");
            // 
            // tbBrand
            // 
            this.tbBrand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBrand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbBrand.Location = new System.Drawing.Point(3, 19);
            this.tbBrand.Multiline = true;
            this.tbBrand.Name = "tbBrand";
            this.tbBrand.Size = new System.Drawing.Size(226, 45);
            this.tbBrand.TabIndex = 0;
            this.toolTip.SetToolTip(this.tbBrand, "设置商品品牌");
            // 
            // gbRefund
            // 
            this.gbRefund.Controls.Add(this.rbRefundFalse);
            this.gbRefund.Controls.Add(this.rbRefundTrue);
            this.gbRefund.Location = new System.Drawing.Point(6, 77);
            this.gbRefund.Name = "gbRefund";
            this.gbRefund.Size = new System.Drawing.Size(124, 67);
            this.gbRefund.TabIndex = 3;
            this.gbRefund.TabStop = false;
            this.gbRefund.Tag = "";
            this.gbRefund.Text = "七天无理由退货";
            this.toolTip.SetToolTip(this.gbRefund, "默认支持七天无理由退货\r\n虚拟商品不支持");
            // 
            // rbRefundFalse
            // 
            this.rbRefundFalse.AutoSize = true;
            this.rbRefundFalse.Location = new System.Drawing.Point(58, 30);
            this.rbRefundFalse.Name = "rbRefundFalse";
            this.rbRefundFalse.Size = new System.Drawing.Size(62, 21);
            this.rbRefundFalse.TabIndex = 2;
            this.rbRefundFalse.Tag = "0";
            this.rbRefundFalse.Text = "不支持";
            this.rbRefundFalse.UseVisualStyleBackColor = true;
            // 
            // rbRefundTrue
            // 
            this.rbRefundTrue.AutoSize = true;
            this.rbRefundTrue.Checked = true;
            this.rbRefundTrue.Location = new System.Drawing.Point(5, 30);
            this.rbRefundTrue.Name = "rbRefundTrue";
            this.rbRefundTrue.Size = new System.Drawing.Size(50, 21);
            this.rbRefundTrue.TabIndex = 3;
            this.rbRefundTrue.TabStop = true;
            this.rbRefundTrue.Tag = "1";
            this.rbRefundTrue.Text = "支持";
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.rbTypeOld);
            this.gbType.Controls.Add(this.rbTypeNew);
            this.gbType.Location = new System.Drawing.Point(6, 9);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(124, 62);
            this.gbType.TabIndex = 3;
            this.gbType.TabStop = false;
            this.gbType.Tag = "发布类型";
            this.gbType.Text = "发布类型";
            this.toolTip.SetToolTip(this.gbType, "设置发布类型，默认为新品");
            // 
            // rbTypeOld
            // 
            this.rbTypeOld.AutoSize = true;
            this.rbTypeOld.Location = new System.Drawing.Point(66, 23);
            this.rbTypeOld.Name = "rbTypeOld";
            this.rbTypeOld.Size = new System.Drawing.Size(50, 21);
            this.rbTypeOld.TabIndex = 2;
            this.rbTypeOld.Tag = "0";
            this.rbTypeOld.Text = "二手";
            this.rbTypeOld.UseVisualStyleBackColor = true;
            // 
            // rbTypeNew
            // 
            this.rbTypeNew.AutoSize = true;
            this.rbTypeNew.Checked = true;
            this.rbTypeNew.Location = new System.Drawing.Point(12, 23);
            this.rbTypeNew.Name = "rbTypeNew";
            this.rbTypeNew.Size = new System.Drawing.Size(50, 21);
            this.rbTypeNew.TabIndex = 3;
            this.rbTypeNew.TabStop = true;
            this.rbTypeNew.Tag = "1";
            this.rbTypeNew.Text = "新品";
            this.rbTypeNew.UseVisualStyleBackColor = true;
            // 
            // gbArea
            // 
            this.gbArea.Controls.Add(this.lbArea);
            this.gbArea.Controls.Add(this.cbArea3);
            this.gbArea.Controls.Add(this.cbArea2);
            this.gbArea.Controls.Add(this.cbArea1);
            this.gbArea.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbArea.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbArea.Location = new System.Drawing.Point(217, 18);
            this.gbArea.Name = "gbArea";
            this.gbArea.Size = new System.Drawing.Size(215, 144);
            this.gbArea.TabIndex = 3;
            this.gbArea.TabStop = false;
            this.gbArea.Text = "发货地";
            this.toolTip.SetToolTip(this.gbArea, "设置商品发货地");
            // 
            // lbArea
            // 
            this.lbArea.AutoSize = true;
            this.lbArea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbArea.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbArea.Location = new System.Drawing.Point(3, 124);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(44, 17);
            this.lbArea.TabIndex = 1;
            this.lbArea.Text = "未选择";
            // 
            // cbArea3
            // 
            this.cbArea3.FormattingEnabled = true;
            this.cbArea3.Location = new System.Drawing.Point(6, 90);
            this.cbArea3.Name = "cbArea3";
            this.cbArea3.Size = new System.Drawing.Size(195, 25);
            this.cbArea3.TabIndex = 0;
            // 
            // cbArea2
            // 
            this.cbArea2.FormattingEnabled = true;
            this.cbArea2.Location = new System.Drawing.Point(6, 56);
            this.cbArea2.Name = "cbArea2";
            this.cbArea2.Size = new System.Drawing.Size(195, 25);
            this.cbArea2.TabIndex = 0;
            // 
            // cbArea1
            // 
            this.cbArea1.FormattingEnabled = true;
            this.cbArea1.Location = new System.Drawing.Point(6, 22);
            this.cbArea1.Name = "cbArea1";
            this.cbArea1.Size = new System.Drawing.Size(195, 25);
            this.cbArea1.TabIndex = 0;
            // 
            // gbClass
            // 
            this.gbClass.Controls.Add(this.tsClass4);
            this.gbClass.Controls.Add(this.tsClass3);
            this.gbClass.Controls.Add(this.tsClass2);
            this.gbClass.Controls.Add(this.tsClass1);
            this.gbClass.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbClass.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbClass.Location = new System.Drawing.Point(2, 18);
            this.gbClass.Name = "gbClass";
            this.gbClass.Size = new System.Drawing.Size(215, 144);
            this.gbClass.TabIndex = 3;
            this.gbClass.TabStop = false;
            this.gbClass.Text = "分类";
            this.toolTip.SetToolTip(this.gbClass, "设置商品分类");
            // 
            // tsClass4
            // 
            this.tsClass4.AutoSize = true;
            this.tsClass4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsClass4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tsClass4.Location = new System.Drawing.Point(3, 124);
            this.tsClass4.Name = "tsClass4";
            this.tsClass4.Size = new System.Drawing.Size(44, 17);
            this.tsClass4.TabIndex = 1;
            this.tsClass4.Text = "未选择";
            // 
            // tsClass3
            // 
            this.tsClass3.FormattingEnabled = true;
            this.tsClass3.Location = new System.Drawing.Point(6, 90);
            this.tsClass3.Name = "tsClass3";
            this.tsClass3.Size = new System.Drawing.Size(195, 25);
            this.tsClass3.TabIndex = 0;
            // 
            // tsClass2
            // 
            this.tsClass2.FormattingEnabled = true;
            this.tsClass2.Location = new System.Drawing.Point(6, 56);
            this.tsClass2.Name = "tsClass2";
            this.tsClass2.Size = new System.Drawing.Size(195, 25);
            this.tsClass2.TabIndex = 0;
            // 
            // tsClass1
            // 
            this.tsClass1.FormattingEnabled = true;
            this.tsClass1.Location = new System.Drawing.Point(6, 22);
            this.tsClass1.Name = "tsClass1";
            this.tsClass1.Size = new System.Drawing.Size(195, 25);
            this.tsClass1.TabIndex = 0;
            // 
            // rchBoxLog
            // 
            this.rchBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rchBoxLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rchBoxLog.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.rchBoxLog.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.rchBoxLog.Location = new System.Drawing.Point(0, 248);
            this.rchBoxLog.Margin = new System.Windows.Forms.Padding(2);
            this.rchBoxLog.Name = "rchBoxLog";
            this.rchBoxLog.Size = new System.Drawing.Size(1186, 373);
            this.rchBoxLog.TabIndex = 6;
            this.rchBoxLog.Text = "";
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.btnOneKeyOk);
            this.gbSearch.Controls.Add(this.txtOneKeyUrl);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.gbSearch.Location = new System.Drawing.Point(0, 195);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.gbSearch.Size = new System.Drawing.Size(1186, 60);
            this.gbSearch.TabIndex = 5;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "一键同步";
            // 
            // btnOneKeyOk
            // 
            this.btnOneKeyOk.AutoSize = true;
            this.btnOneKeyOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOneKeyOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOneKeyOk.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnOneKeyOk.Image = global::TxoooProductUpload.Properties.Resources.sync;
            this.btnOneKeyOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOneKeyOk.Location = new System.Drawing.Point(1080, 16);
            this.btnOneKeyOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnOneKeyOk.Name = "btnOneKeyOk";
            this.btnOneKeyOk.Size = new System.Drawing.Size(103, 41);
            this.btnOneKeyOk.TabIndex = 5;
            this.btnOneKeyOk.Text = "提交(&S)";
            this.btnOneKeyOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOneKeyOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOneKeyOk.UseVisualStyleBackColor = true;
            // 
            // txtOneKeyUrl
            // 
            this.txtOneKeyUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOneKeyUrl.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtOneKeyUrl.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOneKeyUrl.Location = new System.Drawing.Point(3, 16);
            this.txtOneKeyUrl.Margin = new System.Windows.Forms.Padding(2);
            this.txtOneKeyUrl.Name = "txtOneKeyUrl";
            this.txtOneKeyUrl.Size = new System.Drawing.Size(1073, 39);
            this.txtOneKeyUrl.TabIndex = 4;
            this.txtOneKeyUrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(603, 25);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 651);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.rchBoxLog);
            this.Controls.Add(this.gbSetting);
            this.Controls.Add(this.st);
            this.Controls.Add(this.ts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商家工具";
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            this.st.ResumeLayout(false);
            this.st.PerformLayout();
            this.gbSetting.ResumeLayout(false);
            this.gbBase.ResumeLayout(false);
            this.gbPostage.ResumeLayout(false);
            this.gbPostage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLinit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbappend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPostage)).EndInit();
            this.gbIspostage.ResumeLayout(false);
            this.gbIspostage.PerformLayout();
            this.gbVirtual.ResumeLayout(false);
            this.gbVirtual.PerformLayout();
            this.gbShare.ResumeLayout(false);
            this.gbShare.PerformLayout();
            this.gbBrand.ResumeLayout(false);
            this.gbBrand.PerformLayout();
            this.gbRefund.ResumeLayout(false);
            this.gbRefund.PerformLayout();
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
            this.gbArea.ResumeLayout(false);
            this.gbArea.PerformLayout();
            this.gbClass.ResumeLayout(false);
            this.gbClass.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ts;
        private System.Windows.Forms.ToolStripButton tsLogin;
        private System.Windows.Forms.ToolStripButton tsLogout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsExit;
        private System.Windows.Forms.StatusStrip st;
        private System.Windows.Forms.ToolStripStatusLabel stStatus;
        private System.Windows.Forms.ToolStripProgressBar stProgress;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton tsImgManage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsDataPack;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.RichTextBox rchBoxLog;
        private System.Windows.Forms.GroupBox gbClass;
        private System.Windows.Forms.ComboBox tsClass3;
        private System.Windows.Forms.ComboBox tsClass2;
        private System.Windows.Forms.ComboBox tsClass1;
        private System.Windows.Forms.Label tsClass4;
        private System.Windows.Forms.GroupBox gbArea;
        private System.Windows.Forms.Label lbArea;
        private System.Windows.Forms.ComboBox cbArea3;
        private System.Windows.Forms.ComboBox cbArea2;
        private System.Windows.Forms.ComboBox cbArea1;
        private System.Windows.Forms.GroupBox gbBase;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Button btnOneKeyOk;
        private System.Windows.Forms.TextBox txtOneKeyUrl;
        private System.Windows.Forms.GroupBox gbPostage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPostage;
        private System.Windows.Forms.GroupBox gbIspostage;
        private System.Windows.Forms.RadioButton rbPostageFalse;
        private System.Windows.Forms.RadioButton rbPostageTrue;
        private System.Windows.Forms.GroupBox gbVirtual;
        private System.Windows.Forms.RadioButton rbVirtualFalse;
        private System.Windows.Forms.RadioButton rbVirtualTrue;
        private System.Windows.Forms.GroupBox gbType;
        private System.Windows.Forms.RadioButton rbTypeOld;
        private System.Windows.Forms.RadioButton rbTypeNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbBrand;
        private System.Windows.Forms.TextBox tbBrand;
        private System.Windows.Forms.GroupBox gbShare;
        private System.Windows.Forms.TextBox tbShare;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox gbRefund;
        private System.Windows.Forms.RadioButton rbRefundFalse;
        private System.Windows.Forms.RadioButton rbRefundTrue;
        private System.Windows.Forms.NumericUpDown tbLinit;
        private System.Windows.Forms.NumericUpDown tbappend;
        private System.Windows.Forms.NumericUpDown tbPostage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}
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
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.rchBoxLog = new System.Windows.Forms.RichTextBox();
            this.gbClass = new System.Windows.Forms.GroupBox();
            this.tsClass1 = new System.Windows.Forms.ComboBox();
            this.tsClass2 = new System.Windows.Forms.ComboBox();
            this.tsClass3 = new System.Windows.Forms.ComboBox();
            this.tsClass4 = new System.Windows.Forms.Label();
            this.gbArea = new System.Windows.Forms.GroupBox();
            this.lbArea = new System.Windows.Forms.Label();
            this.cbArea3 = new System.Windows.Forms.ComboBox();
            this.cbArea2 = new System.Windows.Forms.ComboBox();
            this.cbArea1 = new System.Windows.Forms.ComboBox();
            this.gbBase = new System.Windows.Forms.GroupBox();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.btnOneKeyOk = new System.Windows.Forms.Button();
            this.txtOneKeyUrl = new System.Windows.Forms.TextBox();
            this.ts.SuspendLayout();
            this.st.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.gbSetting.SuspendLayout();
            this.gbClass.SuspendLayout();
            this.gbArea.SuspendLayout();
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
            this.ts.Size = new System.Drawing.Size(1225, 31);
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
            this.st.Size = new System.Drawing.Size(1225, 30);
            this.st.TabIndex = 2;
            this.st.Text = "statusStrip1";
            // 
            // stStatus
            // 
            this.stStatus.AutoSize = false;
            this.stStatus.Image = global::TxoooProductUpload.Properties.Resources.info_16;
            this.stStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stStatus.Name = "stStatus";
            this.stStatus.Size = new System.Drawing.Size(300, 25);
            this.stStatus.Text = "就绪";
            this.stStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stProgress
            // 
            this.stProgress.Name = "stProgress";
            this.stProgress.Size = new System.Drawing.Size(200, 24);
            this.stProgress.Visible = false;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(742, 25);
            this.toolStripStatusLabel2.Spring = true;
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
            this.gbSetting.Size = new System.Drawing.Size(1225, 152);
            this.gbSetting.TabIndex = 3;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "商品上传通用设置";
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
            this.rchBoxLog.Size = new System.Drawing.Size(1225, 373);
            this.rchBoxLog.TabIndex = 6;
            this.rchBoxLog.Text = "";
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
            this.gbClass.Size = new System.Drawing.Size(215, 132);
            this.gbClass.TabIndex = 3;
            this.gbClass.TabStop = false;
            this.gbClass.Text = "分类";
            // 
            // tsClass1
            // 
            this.tsClass1.FormattingEnabled = true;
            this.tsClass1.Location = new System.Drawing.Point(6, 22);
            this.tsClass1.Name = "tsClass1";
            this.tsClass1.Size = new System.Drawing.Size(195, 25);
            this.tsClass1.TabIndex = 0;
            // 
            // tsClass2
            // 
            this.tsClass2.FormattingEnabled = true;
            this.tsClass2.Location = new System.Drawing.Point(6, 53);
            this.tsClass2.Name = "tsClass2";
            this.tsClass2.Size = new System.Drawing.Size(195, 25);
            this.tsClass2.TabIndex = 0;
            // 
            // tsClass3
            // 
            this.tsClass3.FormattingEnabled = true;
            this.tsClass3.Location = new System.Drawing.Point(6, 84);
            this.tsClass3.Name = "tsClass3";
            this.tsClass3.Size = new System.Drawing.Size(195, 25);
            this.tsClass3.TabIndex = 0;
            // 
            // tsClass4
            // 
            this.tsClass4.AutoSize = true;
            this.tsClass4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsClass4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tsClass4.Location = new System.Drawing.Point(3, 112);
            this.tsClass4.Name = "tsClass4";
            this.tsClass4.Size = new System.Drawing.Size(44, 17);
            this.tsClass4.TabIndex = 1;
            this.tsClass4.Text = "未选择";
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
            this.gbArea.Size = new System.Drawing.Size(215, 132);
            this.gbArea.TabIndex = 3;
            this.gbArea.TabStop = false;
            this.gbArea.Text = "发货地";
            // 
            // lbArea
            // 
            this.lbArea.AutoSize = true;
            this.lbArea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbArea.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbArea.Location = new System.Drawing.Point(3, 112);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(44, 17);
            this.lbArea.TabIndex = 1;
            this.lbArea.Text = "未选择";
            // 
            // cbArea3
            // 
            this.cbArea3.FormattingEnabled = true;
            this.cbArea3.Location = new System.Drawing.Point(6, 84);
            this.cbArea3.Name = "cbArea3";
            this.cbArea3.Size = new System.Drawing.Size(195, 25);
            this.cbArea3.TabIndex = 0;
            // 
            // cbArea2
            // 
            this.cbArea2.FormattingEnabled = true;
            this.cbArea2.Location = new System.Drawing.Point(6, 53);
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
            // gbBase
            // 
            this.gbBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbBase.Location = new System.Drawing.Point(432, 18);
            this.gbBase.Name = "gbBase";
            this.gbBase.Size = new System.Drawing.Size(791, 132);
            this.gbBase.TabIndex = 3;
            this.gbBase.TabStop = false;
            this.gbBase.Text = "基本设置";
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.btnOneKeyOk);
            this.gbSearch.Controls.Add(this.txtOneKeyUrl);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.gbSearch.Location = new System.Drawing.Point(0, 183);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.gbSearch.Size = new System.Drawing.Size(1225, 60);
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
            this.btnOneKeyOk.Location = new System.Drawing.Point(1119, 16);
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
            this.txtOneKeyUrl.Size = new System.Drawing.Size(1112, 39);
            this.txtOneKeyUrl.TabIndex = 4;
            this.txtOneKeyUrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 651);
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
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.gbSetting.ResumeLayout(false);
            this.gbClass.ResumeLayout(false);
            this.gbClass.PerformLayout();
            this.gbArea.ResumeLayout(false);
            this.gbArea.PerformLayout();
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
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.BindingSource bs;
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
    }
}
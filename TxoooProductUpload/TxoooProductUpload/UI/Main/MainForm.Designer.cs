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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.st = new System.Windows.Forms.StatusStrip();
            this.stProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.stStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsImgManage = new System.Windows.Forms.ToolStripButton();
            this.tsExit = new System.Windows.Forms.ToolStripButton();
            this.tsLogout = new System.Windows.Forms.ToolStripButton();
            this.tsLogin = new System.Windows.Forms.ToolStripButton();
            this.tsDataPack = new System.Windows.Forms.ToolStripButton();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.btnOneKeyOk = new System.Windows.Forms.Button();
            this.txtOneKeyUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rchBoxLog = new System.Windows.Forms.RichTextBox();
            this.ts.SuspendLayout();
            this.st.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.gb1.SuspendLayout();
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
            this.ts.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ts.Size = new System.Drawing.Size(1261, 31);
            this.ts.TabIndex = 0;
            this.ts.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
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
            this.st.Location = new System.Drawing.Point(0, 946);
            this.st.Name = "st";
            this.st.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.st.Size = new System.Drawing.Size(1261, 30);
            this.st.TabIndex = 2;
            this.st.Text = "statusStrip1";
            // 
            // stProgress
            // 
            this.stProgress.Name = "stProgress";
            this.stProgress.Size = new System.Drawing.Size(300, 24);
            this.stProgress.Visible = false;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(426, 25);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
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
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Image = global::TxoooProductUpload.Properties.Resources.globe_16;
            this.toolStripStatusLabel3.IsLink = true;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(70, 25);
            this.toolStripStatusLabel3.Tag = "https://github.com/iwenli";
            this.toolStripStatusLabel3.Text = "开源";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Image = global::TxoooProductUpload.Properties.Resources.globe_16;
            this.toolStripStatusLabel4.IsLink = true;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(70, 25);
            this.toolStripStatusLabel4.Tag = "blog.iwenli.org";
            this.toolStripStatusLabel4.Text = "博客";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::TxoooProductUpload.Properties.Resources.globe_16;
            this.toolStripStatusLabel1.IsLink = true;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(70, 25);
            this.toolStripStatusLabel1.Tag = "iwenli.org";
            this.toolStripStatusLabel1.Text = "主页";
            // 
            // tsImgManage
            // 
            this.tsImgManage.Enabled = false;
            this.tsImgManage.Image = global::TxoooProductUpload.Properties.Resources.Postman;
            this.tsImgManage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsImgManage.Name = "tsImgManage";
            this.tsImgManage.Size = new System.Drawing.Size(140, 28);
            this.tsImgManage.Text = "图片管理(&M)";
            // 
            // tsExit
            // 
            this.tsExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsExit.Image = global::TxoooProductUpload.Properties.Resources.block_16;
            this.tsExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(98, 28);
            this.tsExit.Text = "退出(&X)";
            // 
            // tsLogout
            // 
            this.tsLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsLogout.Enabled = false;
            this.tsLogout.Image = global::TxoooProductUpload.Properties.Resources.left_16;
            this.tsLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLogout.Name = "tsLogout";
            this.tsLogout.Size = new System.Drawing.Size(95, 28);
            this.tsLogout.Text = "注销(&L)";
            // 
            // tsLogin
            // 
            this.tsLogin.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsLogin.Image = global::TxoooProductUpload.Properties.Resources.user_16;
            this.tsLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLogin.Name = "tsLogin";
            this.tsLogin.Size = new System.Drawing.Size(91, 28);
            this.tsLogin.Text = "登录(&I)";
            // 
            // tsDataPack
            // 
            this.tsDataPack.Enabled = false;
            this.tsDataPack.Image = global::TxoooProductUpload.Properties.Resources.processon;
            this.tsDataPack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDataPack.Name = "tsDataPack";
            this.tsDataPack.Size = new System.Drawing.Size(145, 28);
            this.tsDataPack.Text = "数据包导入(&I)";
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.btnOneKeyOk);
            this.gb1.Controls.Add(this.txtOneKeyUrl);
            this.gb1.Controls.Add(this.label1);
            this.gb1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb1.Location = new System.Drawing.Point(0, 31);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(1261, 80);
            this.gb1.TabIndex = 3;
            this.gb1.TabStop = false;
            // 
            // btnOneKeyOk
            // 
            this.btnOneKeyOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOneKeyOk.Enabled = false;
            this.btnOneKeyOk.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnOneKeyOk.Image = global::TxoooProductUpload.Properties.Resources.sync;
            this.btnOneKeyOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOneKeyOk.Location = new System.Drawing.Point(1092, 17);
            this.btnOneKeyOk.Name = "btnOneKeyOk";
            this.btnOneKeyOk.Size = new System.Drawing.Size(157, 56);
            this.btnOneKeyOk.TabIndex = 2;
            this.btnOneKeyOk.Text = "提交(&S)";
            this.btnOneKeyOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOneKeyOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOneKeyOk.UseVisualStyleBackColor = true;
            // 
            // txtOneKeyUrl
            // 
            this.txtOneKeyUrl.Enabled = false;
            this.txtOneKeyUrl.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtOneKeyUrl.Location = new System.Drawing.Point(74, 29);
            this.txtOneKeyUrl.Name = "txtOneKeyUrl";
            this.txtOneKeyUrl.Size = new System.Drawing.Size(994, 31);
            this.txtOneKeyUrl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "链接：";
            // 
            // rchBoxLog
            // 
            this.rchBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rchBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchBoxLog.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.rchBoxLog.Location = new System.Drawing.Point(0, 111);
            this.rchBoxLog.Name = "rchBoxLog";
            this.rchBoxLog.Size = new System.Drawing.Size(1261, 835);
            this.rchBoxLog.TabIndex = 4;
            this.rchBoxLog.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 976);
            this.Controls.Add(this.rchBoxLog);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.st);
            this.Controls.Add(this.ts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商家工具";
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            this.st.ResumeLayout(false);
            this.st.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
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
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Button btnOneKeyOk;
        private System.Windows.Forms.TextBox txtOneKeyUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rchBoxLog;
    }
}
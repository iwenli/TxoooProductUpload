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
            this.tsExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLogout = new System.Windows.Forms.ToolStripButton();
            this.tsLogin = new System.Windows.Forms.ToolStripButton();
            this.tsUploadImg = new System.Windows.Forms.ToolStripButton();
            this.st = new System.Windows.Forms.StatusStrip();
            this.stStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.stProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.ts1688 = new System.Windows.Forms.ToolStripButton();
            this.ts.SuspendLayout();
            this.st.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.SuspendLayout();
            // 
            // ts
            // 
            this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsExit,
            this.toolStripSeparator1,
            this.tsLogout,
            this.tsLogin,
            this.tsUploadImg,
            this.ts1688});
            this.ts.Location = new System.Drawing.Point(0, 0);
            this.ts.Name = "ts";
            this.ts.Size = new System.Drawing.Size(1161, 25);
            this.ts.TabIndex = 0;
            this.ts.Text = "toolStrip1";
            // 
            // tsExit
            // 
            this.tsExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsExit.Image = global::TxoooProductUpload.Properties.Resources.block_16;
            this.tsExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(68, 22);
            this.tsExit.Text = "退出(&X)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsLogout
            // 
            this.tsLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsLogout.Enabled = false;
            this.tsLogout.Image = global::TxoooProductUpload.Properties.Resources.left_16;
            this.tsLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLogout.Name = "tsLogout";
            this.tsLogout.Size = new System.Drawing.Size(66, 22);
            this.tsLogout.Text = "注销(&L)";
            // 
            // tsLogin
            // 
            this.tsLogin.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsLogin.Image = global::TxoooProductUpload.Properties.Resources.user_16;
            this.tsLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLogin.Name = "tsLogin";
            this.tsLogin.Size = new System.Drawing.Size(64, 22);
            this.tsLogin.Text = "登录(&I)";
            // 
            // tsUploadImg
            // 
            this.tsUploadImg.Image = global::TxoooProductUpload.Properties.Resources.left_16;
            this.tsUploadImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUploadImg.Name = "tsUploadImg";
            this.tsUploadImg.Size = new System.Drawing.Size(76, 22);
            this.tsUploadImg.Text = "上传图片";
            // 
            // st
            // 
            this.st.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stStatus,
            this.stProgress,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel1});
            this.st.Location = new System.Drawing.Point(0, 629);
            this.st.Name = "st";
            this.st.Size = new System.Drawing.Size(1161, 22);
            this.st.TabIndex = 2;
            this.st.Text = "statusStrip1";
            // 
            // stStatus
            // 
            this.stStatus.AutoSize = false;
            this.stStatus.Image = global::TxoooProductUpload.Properties.Resources.info_16;
            this.stStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stStatus.Name = "stStatus";
            this.stStatus.Size = new System.Drawing.Size(300, 17);
            this.stStatus.Text = "就绪";
            this.stStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stProgress
            // 
            this.stProgress.Name = "stProgress";
            this.stProgress.Size = new System.Drawing.Size(200, 16);
            this.stProgress.Visible = false;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(702, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Image = global::TxoooProductUpload.Properties.Resources.globe_16;
            this.toolStripStatusLabel3.IsLink = true;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel3.Tag = "https://github.com/iwenli";
            this.toolStripStatusLabel3.Text = "开源";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Image = global::TxoooProductUpload.Properties.Resources.globe_16;
            this.toolStripStatusLabel4.IsLink = true;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel4.Tag = "blog.iwenli.org";
            this.toolStripStatusLabel4.Text = "博客";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::TxoooProductUpload.Properties.Resources.globe_16;
            this.toolStripStatusLabel1.IsLink = true;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel1.Tag = "iwenli.org";
            this.toolStripStatusLabel1.Text = "主页";
            // 
            // ts1688
            // 
            this.ts1688.Image = global::TxoooProductUpload.Properties.Resources.left_16;
            this.ts1688.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts1688.Name = "ts1688";
            this.ts1688.Size = new System.Drawing.Size(80, 22);
            this.ts1688.Text = "1688爬取";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 651);
            this.Controls.Add(this.st);
            this.Controls.Add(this.ts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商家工具";
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            this.st.ResumeLayout(false);
            this.st.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
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
        private System.Windows.Forms.ToolStripButton tsUploadImg;
        private System.Windows.Forms.ToolStripButton ts1688;
    }
}
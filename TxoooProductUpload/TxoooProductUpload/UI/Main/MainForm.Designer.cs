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
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsClass1 = new System.Windows.Forms.ToolStripComboBox();
            this.tsClass2 = new System.Windows.Forms.ToolStripComboBox();
            this.tsClass3 = new System.Windows.Forms.ToolStripComboBox();
            this.tsClass4 = new System.Windows.Forms.ToolStripLabel();
            this.st = new System.Windows.Forms.StatusStrip();
            this.stStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.stProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.tsDataPack,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.tsClass1,
            this.tsClass2,
            this.tsClass3,
            this.tsClass4});
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 28);
            this.toolStripLabel1.Text = "分类：";
            // 
            // tsClass1
            // 
            this.tsClass1.Enabled = false;
            this.tsClass1.Name = "tsClass1";
            this.tsClass1.Size = new System.Drawing.Size(121, 31);
            // 
            // tsClass2
            // 
            this.tsClass2.Enabled = false;
            this.tsClass2.Name = "tsClass2";
            this.tsClass2.Size = new System.Drawing.Size(121, 31);
            // 
            // tsClass3
            // 
            this.tsClass3.Enabled = false;
            this.tsClass3.Name = "tsClass3";
            this.tsClass3.Size = new System.Drawing.Size(121, 31);
            // 
            // tsClass4
            // 
            this.tsClass4.Name = "tsClass4";
            this.tsClass4.Size = new System.Drawing.Size(44, 28);
            this.tsClass4.Text = "未选择";
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
            // gb1
            // 
            this.gb1.Controls.Add(this.label2);
            this.gb1.Controls.Add(this.btnOneKeyOk);
            this.gb1.Controls.Add(this.txtOneKeyUrl);
            this.gb1.Controls.Add(this.label1);
            this.gb1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb1.Location = new System.Drawing.Point(0, 31);
            this.gb1.Margin = new System.Windows.Forms.Padding(2);
            this.gb1.Name = "gb1";
            this.gb1.Padding = new System.Windows.Forms.Padding(2);
            this.gb1.Size = new System.Drawing.Size(1225, 53);
            this.gb1.TabIndex = 3;
            this.gb1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "分类";
            // 
            // btnOneKeyOk
            // 
            this.btnOneKeyOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOneKeyOk.Enabled = false;
            this.btnOneKeyOk.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnOneKeyOk.Image = global::TxoooProductUpload.Properties.Resources.sync;
            this.btnOneKeyOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOneKeyOk.Location = new System.Drawing.Point(1101, 11);
            this.btnOneKeyOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnOneKeyOk.Name = "btnOneKeyOk";
            this.btnOneKeyOk.Size = new System.Drawing.Size(105, 37);
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
            this.txtOneKeyUrl.Location = new System.Drawing.Point(422, 19);
            this.txtOneKeyUrl.Margin = new System.Windows.Forms.Padding(2);
            this.txtOneKeyUrl.Name = "txtOneKeyUrl";
            this.txtOneKeyUrl.Size = new System.Drawing.Size(664, 23);
            this.txtOneKeyUrl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(381, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "链接：";
            // 
            // rchBoxLog
            // 
            this.rchBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rchBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchBoxLog.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.rchBoxLog.Location = new System.Drawing.Point(0, 84);
            this.rchBoxLog.Margin = new System.Windows.Forms.Padding(2);
            this.rchBoxLog.Name = "rchBoxLog";
            this.rchBoxLog.Size = new System.Drawing.Size(1225, 537);
            this.rchBoxLog.TabIndex = 4;
            this.rchBoxLog.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 651);
            this.Controls.Add(this.rchBoxLog);
            this.Controls.Add(this.gb1);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tsClass1;
        private System.Windows.Forms.ToolStripComboBox tsClass2;
        private System.Windows.Forms.ToolStripComboBox tsClass3;
        private System.Windows.Forms.ToolStripLabel tsClass4;
        private System.Windows.Forms.Label label2;
    }
}
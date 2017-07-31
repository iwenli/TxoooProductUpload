namespace TxoooProductUpload.UI.ImageDownload
{
    partial class Crawler
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
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tcImgManage = new System.Windows.Forms.TabControl();
            this.tpHead = new System.Windows.Forms.TabPage();
            this.lblStatPicDownload = new System.Windows.Forms.Label();
            this.lblPgSt = new System.Windows.Forms.Label();
            this.btnAddSource = new System.Windows.Forms.Button();
            this.txtSourceSite = new System.Windows.Forms.TextBox();
            this.pbImageDown = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.pbPageGrab = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tpOther = new System.Windows.Forms.TabPage();
            this.btnStartTask = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tcImgManage.SuspendLayout();
            this.tpHead.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.ForeColor = System.Drawing.Color.DarkGray;
            this.txtLog.Location = new System.Drawing.Point(0, 252);
            this.txtLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(1003, 326);
            this.txtLog.TabIndex = 1;
            this.txtLog.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tcImgManage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 252);
            this.panel1.TabIndex = 0;
            // 
            // tcImgManage
            // 
            this.tcImgManage.Controls.Add(this.tpHead);
            this.tcImgManage.Controls.Add(this.tpOther);
            this.tcImgManage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcImgManage.Location = new System.Drawing.Point(0, 0);
            this.tcImgManage.Name = "tcImgManage";
            this.tcImgManage.SelectedIndex = 0;
            this.tcImgManage.Size = new System.Drawing.Size(1003, 252);
            this.tcImgManage.TabIndex = 0;
            // 
            // tpHead
            // 
            this.tpHead.Controls.Add(this.lblStatPicDownload);
            this.tpHead.Controls.Add(this.lblPgSt);
            this.tpHead.Controls.Add(this.btnGenerate);
            this.tpHead.Controls.Add(this.btnStartTask);
            this.tpHead.Controls.Add(this.btnAddSource);
            this.tpHead.Controls.Add(this.txtSourceSite);
            this.tpHead.Controls.Add(this.pbImageDown);
            this.tpHead.Controls.Add(this.label2);
            this.tpHead.Controls.Add(this.pbPageGrab);
            this.tpHead.Controls.Add(this.label1);
            this.tpHead.Location = new System.Drawing.Point(4, 26);
            this.tpHead.Name = "tpHead";
            this.tpHead.Padding = new System.Windows.Forms.Padding(3);
            this.tpHead.Size = new System.Drawing.Size(995, 222);
            this.tpHead.TabIndex = 0;
            this.tpHead.Text = "头像抓取";
            this.tpHead.UseVisualStyleBackColor = true;
            // 
            // lblStatPicDownload
            // 
            this.lblStatPicDownload.Location = new System.Drawing.Point(515, 71);
            this.lblStatPicDownload.Name = "lblStatPicDownload";
            this.lblStatPicDownload.Size = new System.Drawing.Size(472, 17);
            this.lblStatPicDownload.TabIndex = 4;
            this.lblStatPicDownload.Text = "-";
            this.lblStatPicDownload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPgSt
            // 
            this.lblPgSt.Location = new System.Drawing.Point(515, 13);
            this.lblPgSt.Name = "lblPgSt";
            this.lblPgSt.Size = new System.Drawing.Size(472, 17);
            this.lblPgSt.TabIndex = 4;
            this.lblPgSt.Text = "-";
            this.lblPgSt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAddSource
            // 
            this.btnAddSource.Location = new System.Drawing.Point(327, 137);
            this.btnAddSource.Name = "btnAddSource";
            this.btnAddSource.Size = new System.Drawing.Size(219, 35);
            this.btnAddSource.TabIndex = 3;
            this.btnAddSource.Text = "添加来源JSON(&G)";
            this.btnAddSource.UseVisualStyleBackColor = true;
            // 
            // txtSourceSite
            // 
            this.txtSourceSite.Location = new System.Drawing.Point(9, 138);
            this.txtSourceSite.Multiline = true;
            this.txtSourceSite.Name = "txtSourceSite";
            this.txtSourceSite.Size = new System.Drawing.Size(296, 78);
            this.txtSourceSite.TabIndex = 2;
            // 
            // pbImageDown
            // 
            this.pbImageDown.Location = new System.Drawing.Point(8, 90);
            this.pbImageDown.Name = "pbImageDown";
            this.pbImageDown.Size = new System.Drawing.Size(979, 29);
            this.pbImageDown.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "图片下载进度";
            // 
            // pbPageGrab
            // 
            this.pbPageGrab.Location = new System.Drawing.Point(8, 33);
            this.pbPageGrab.Name = "pbPageGrab";
            this.pbPageGrab.Size = new System.Drawing.Size(979, 29);
            this.pbPageGrab.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "页面抓取进度";
            // 
            // tpOther
            // 
            this.tpOther.Location = new System.Drawing.Point(4, 26);
            this.tpOther.Name = "tpOther";
            this.tpOther.Padding = new System.Windows.Forms.Padding(3);
            this.tpOther.Size = new System.Drawing.Size(995, 222);
            this.tpOther.TabIndex = 1;
            this.tpOther.Text = "图片管理";
            this.tpOther.UseVisualStyleBackColor = true;
            // 
            // btnStartTask
            // 
            this.btnStartTask.Location = new System.Drawing.Point(768, 132);
            this.btnStartTask.Name = "btnStartTask";
            this.btnStartTask.Size = new System.Drawing.Size(219, 35);
            this.btnStartTask.TabIndex = 3;
            this.btnStartTask.Text = "开始抓取任务(&S)";
            this.btnStartTask.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(327, 181);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(219, 35);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "生成头像文件库(&S)";
            this.btnGenerate.UseVisualStyleBackColor = true;
            // 
            // Crawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 578);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Crawler";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false);
            this.tcImgManage.ResumeLayout(false);
            this.tpHead.ResumeLayout(false);
            this.tpHead.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tcImgManage;
        private System.Windows.Forms.TabPage tpHead;
        private System.Windows.Forms.Label lblStatPicDownload;
        private System.Windows.Forms.Label lblPgSt;
        private System.Windows.Forms.Button btnAddSource;
        private System.Windows.Forms.TextBox txtSourceSite;
        private System.Windows.Forms.ProgressBar pbImageDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pbPageGrab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tpOther;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnStartTask;
    }
}
namespace TxoooProductUpload.UI.Main
{
    partial class Comment
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtJson = new System.Windows.Forms.RichTextBox();
            this.gbAction = new System.Windows.Forms.GroupBox();
            this.btnAddComments = new System.Windows.Forms.Button();
            this.btnGetProductInfo = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbAction.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.gbAction);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 313);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtJson);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 126);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(674, 184);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "这里输入商品评价JSON";
            // 
            // txtJson
            // 
            this.txtJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJson.Location = new System.Drawing.Point(3, 19);
            this.txtJson.Name = "txtJson";
            this.txtJson.Size = new System.Drawing.Size(668, 162);
            this.txtJson.TabIndex = 0;
            this.txtJson.Text = "";
            // 
            // gbAction
            // 
            this.gbAction.Controls.Add(this.btnAddComments);
            this.gbAction.Controls.Add(this.btnGetProductInfo);
            this.gbAction.Controls.Add(this.txtUrl);
            this.gbAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbAction.Location = new System.Drawing.Point(3, 19);
            this.gbAction.Name = "gbAction";
            this.gbAction.Size = new System.Drawing.Size(674, 107);
            this.gbAction.TabIndex = 0;
            this.gbAction.TabStop = false;
            this.gbAction.Text = "操作";
            // 
            // btnAddComments
            // 
            this.btnAddComments.Location = new System.Drawing.Point(548, 60);
            this.btnAddComments.Name = "btnAddComments";
            this.btnAddComments.Size = new System.Drawing.Size(123, 39);
            this.btnAddComments.TabIndex = 3;
            this.btnAddComments.Text = "添加评价(&A)";
            this.btnAddComments.UseVisualStyleBackColor = true;
            // 
            // btnGetProductInfo
            // 
            this.btnGetProductInfo.Location = new System.Drawing.Point(404, 60);
            this.btnGetProductInfo.Name = "btnGetProductInfo";
            this.btnGetProductInfo.Size = new System.Drawing.Size(123, 39);
            this.btnGetProductInfo.TabIndex = 2;
            this.btnGetProductInfo.Text = "解析商品信息(&L)";
            this.btnGetProductInfo.UseVisualStyleBackColor = true;
            // 
            // txtUrl
            // 
            this.txtUrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUrl.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUrl.Location = new System.Drawing.Point(3, 19);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(668, 32);
            this.txtUrl.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLog);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 313);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(680, 210);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtLog
            // 
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 19);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(674, 188);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "";
            // 
            // Comment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 523);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Comment";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加评价";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.gbAction.ResumeLayout(false);
            this.gbAction.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gbAction;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.RichTextBox txtJson;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnAddComments;
        private System.Windows.Forms.Button btnGetProductInfo;
    }
}
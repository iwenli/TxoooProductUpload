namespace TxoooProductUpload.UI.Forms
{
    partial class ApplyForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnOK = new CCWin.SkinControl.SkinButton();
            this.txtUrl = new CCWin.SkinControl.SkinTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.skinComboBox1 = new CCWin.SkinControl.SkinComboBox();
            this.mchTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mchTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.skinComboBox1);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.txtUrl);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(746, 519);
            this.panel1.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox1.Location = new System.Drawing.Point(0, 229);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(746, 290);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOK.DownBack = null;
            this.btnOK.Location = new System.Drawing.Point(638, 14);
            this.btnOK.MouseBack = null;
            this.btnOK.Name = "btnOK";
            this.btnOK.NormlBack = null;
            this.btnOK.Size = new System.Drawing.Size(95, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "抓取店铺信息";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // txtUrl
            // 
            this.txtUrl.BackColor = System.Drawing.Color.Transparent;
            this.txtUrl.DownBack = null;
            this.txtUrl.Icon = null;
            this.txtUrl.IconIsButton = false;
            this.txtUrl.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtUrl.IsPasswordChat = '\0';
            this.txtUrl.IsSystemPasswordChar = false;
            this.txtUrl.Lines = new string[0];
            this.txtUrl.Location = new System.Drawing.Point(62, 11);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(0);
            this.txtUrl.MaxLength = 32767;
            this.txtUrl.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtUrl.MouseBack = null;
            this.txtUrl.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtUrl.Multiline = false;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.NormlBack = null;
            this.txtUrl.Padding = new System.Windows.Forms.Padding(5);
            this.txtUrl.ReadOnly = false;
            this.txtUrl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUrl.Size = new System.Drawing.Size(566, 28);
            // 
            // 
            // 
            this.txtUrl.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUrl.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUrl.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtUrl.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtUrl.SkinTxt.Name = "BaseText";
            this.txtUrl.SkinTxt.Size = new System.Drawing.Size(556, 18);
            this.txtUrl.SkinTxt.TabIndex = 0;
            this.txtUrl.SkinTxt.Text = "skinTextBox1";
            this.txtUrl.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtUrl.SkinTxt.WaterText = "淘宝天猫店铺地址";
            this.txtUrl.TabIndex = 3;
            this.txtUrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUrl.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtUrl.WaterText = "淘宝天猫店铺地址";
            this.txtUrl.WordWrap = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "网址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "店铺类型：";
            // 
            // skinComboBox1
            // 
            this.skinComboBox1.DataSource = this.mchTypeBindingSource;
            this.skinComboBox1.DisplayMember = "Name";
            this.skinComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox1.FormattingEnabled = true;
            this.skinComboBox1.Location = new System.Drawing.Point(88, 59);
            this.skinComboBox1.Name = "skinComboBox1";
            this.skinComboBox1.Size = new System.Drawing.Size(121, 22);
            this.skinComboBox1.TabIndex = 6;
            this.skinComboBox1.ValueMember = "Id";
            this.skinComboBox1.WaterText = "";
            // 
            // mchTypeBindingSource
            // 
            this.mchTypeBindingSource.DataSource = typeof(TxoooProductUpload.Common.MchCache.MchType);
            // 
            // ApplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(754, 551);
            this.Controls.Add(this.panel1);
            this.Name = "ApplyForm";
            this.Text = "商家入驻";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mchTypeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CCWin.SkinControl.SkinTextBox txtUrl;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinButton btnOK;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private CCWin.SkinControl.SkinComboBox skinComboBox1;
        private System.Windows.Forms.BindingSource mchTypeBindingSource;
    }
}
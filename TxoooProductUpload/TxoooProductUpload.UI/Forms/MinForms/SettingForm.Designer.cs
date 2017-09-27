namespace TxoooProductUpload.UI.Forms.MinForms
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.skinTabControl1 = new CCWin.SkinControl.SkinTabControl();
            this.skinTabPage1 = new CCWin.SkinControl.SkinTabPage();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.txtMaxThreadCount = new CCWin.SkinControl.SkinTextBox();
            this.txtRandomMaxValue = new CCWin.SkinControl.SkinTextBox();
            this.txtRandomMinValue = new CCWin.SkinControl.SkinTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.skinTabControl1.SuspendLayout();
            this.skinTabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinTabControl1
            // 
            this.skinTabControl1.AnimatorType = CCWin.SkinControl.AnimationType.HorizSlide;
            this.skinTabControl1.CloseRect = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.skinTabControl1.Controls.Add(this.skinTabPage1);
            this.skinTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTabControl1.HeadBack = null;
            this.skinTabControl1.ImgTxtOffset = new System.Drawing.Point(0, 0);
            this.skinTabControl1.ItemSize = new System.Drawing.Size(70, 36);
            this.skinTabControl1.Location = new System.Drawing.Point(4, 28);
            this.skinTabControl1.Name = "skinTabControl1";
            this.skinTabControl1.PageArrowDown = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageArrowDown")));
            this.skinTabControl1.PageArrowHover = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageArrowHover")));
            this.skinTabControl1.PageCloseHover = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageCloseHover")));
            this.skinTabControl1.PageCloseNormal = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageCloseNormal")));
            this.skinTabControl1.PageDown = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageDown")));
            this.skinTabControl1.PageHover = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageHover")));
            this.skinTabControl1.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Left;
            this.skinTabControl1.PageNorml = null;
            this.skinTabControl1.SelectedIndex = 0;
            this.skinTabControl1.Size = new System.Drawing.Size(324, 317);
            this.skinTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.skinTabControl1.TabIndex = 0;
            // 
            // skinTabPage1
            // 
            this.skinTabPage1.BackColor = System.Drawing.Color.White;
            this.skinTabPage1.Controls.Add(this.label2);
            this.skinTabPage1.Controls.Add(this.label1);
            this.skinTabPage1.Controls.Add(this.txtRandomMinValue);
            this.skinTabPage1.Controls.Add(this.txtRandomMaxValue);
            this.skinTabPage1.Controls.Add(this.txtMaxThreadCount);
            this.skinTabPage1.Controls.Add(this.skinLabel3);
            this.skinTabPage1.Controls.Add(this.skinLabel2);
            this.skinTabPage1.Controls.Add(this.skinLabel1);
            this.skinTabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTabPage1.Location = new System.Drawing.Point(0, 36);
            this.skinTabPage1.Name = "skinTabPage1";
            this.skinTabPage1.Size = new System.Drawing.Size(324, 281);
            this.skinTabPage1.TabIndex = 0;
            this.skinTabPage1.TabItemImage = null;
            this.skinTabPage1.Text = "基本设置";
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(17, 26);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(92, 17);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = "并行任务数目：";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(17, 120);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(92, 17);
            this.skinLabel2.TabIndex = 0;
            this.skinLabel2.Text = "间隔最大时长：";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(17, 155);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(92, 17);
            this.skinLabel3.TabIndex = 0;
            this.skinLabel3.Text = "间隔最小时长：";
            // 
            // txtMaxThreadCount
            // 
            this.txtMaxThreadCount.BackColor = System.Drawing.Color.Transparent;
            this.txtMaxThreadCount.DownBack = null;
            this.txtMaxThreadCount.Icon = null;
            this.txtMaxThreadCount.IconIsButton = false;
            this.txtMaxThreadCount.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtMaxThreadCount.IsPasswordChat = '\0';
            this.txtMaxThreadCount.IsSystemPasswordChar = false;
            this.txtMaxThreadCount.Lines = new string[0];
            this.txtMaxThreadCount.Location = new System.Drawing.Point(112, 18);
            this.txtMaxThreadCount.Margin = new System.Windows.Forms.Padding(0);
            this.txtMaxThreadCount.MaxLength = 32767;
            this.txtMaxThreadCount.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtMaxThreadCount.MouseBack = null;
            this.txtMaxThreadCount.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtMaxThreadCount.Multiline = false;
            this.txtMaxThreadCount.Name = "txtMaxThreadCount";
            this.txtMaxThreadCount.NormlBack = null;
            this.txtMaxThreadCount.Padding = new System.Windows.Forms.Padding(5);
            this.txtMaxThreadCount.ReadOnly = false;
            this.txtMaxThreadCount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMaxThreadCount.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.txtMaxThreadCount.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaxThreadCount.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaxThreadCount.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtMaxThreadCount.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtMaxThreadCount.SkinTxt.Name = "BaseText";
            this.txtMaxThreadCount.SkinTxt.Size = new System.Drawing.Size(175, 18);
            this.txtMaxThreadCount.SkinTxt.TabIndex = 0;
            this.txtMaxThreadCount.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtMaxThreadCount.SkinTxt.WaterText = "";
            this.txtMaxThreadCount.TabIndex = 1;
            this.txtMaxThreadCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMaxThreadCount.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtMaxThreadCount.WaterText = "";
            this.txtMaxThreadCount.WordWrap = true;
            // 
            // txtRandomMaxValue
            // 
            this.txtRandomMaxValue.BackColor = System.Drawing.Color.Transparent;
            this.txtRandomMaxValue.DownBack = null;
            this.txtRandomMaxValue.Icon = null;
            this.txtRandomMaxValue.IconIsButton = false;
            this.txtRandomMaxValue.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtRandomMaxValue.IsPasswordChat = '\0';
            this.txtRandomMaxValue.IsSystemPasswordChar = false;
            this.txtRandomMaxValue.Lines = new string[0];
            this.txtRandomMaxValue.Location = new System.Drawing.Point(112, 115);
            this.txtRandomMaxValue.Margin = new System.Windows.Forms.Padding(0);
            this.txtRandomMaxValue.MaxLength = 32767;
            this.txtRandomMaxValue.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtRandomMaxValue.MouseBack = null;
            this.txtRandomMaxValue.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtRandomMaxValue.Multiline = false;
            this.txtRandomMaxValue.Name = "txtRandomMaxValue";
            this.txtRandomMaxValue.NormlBack = null;
            this.txtRandomMaxValue.Padding = new System.Windows.Forms.Padding(5);
            this.txtRandomMaxValue.ReadOnly = false;
            this.txtRandomMaxValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRandomMaxValue.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.txtRandomMaxValue.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRandomMaxValue.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRandomMaxValue.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtRandomMaxValue.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtRandomMaxValue.SkinTxt.Name = "BaseText";
            this.txtRandomMaxValue.SkinTxt.Size = new System.Drawing.Size(175, 18);
            this.txtRandomMaxValue.SkinTxt.TabIndex = 0;
            this.txtRandomMaxValue.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtRandomMaxValue.SkinTxt.WaterText = "";
            this.txtRandomMaxValue.TabIndex = 3;
            this.txtRandomMaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRandomMaxValue.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtRandomMaxValue.WaterText = "";
            this.txtRandomMaxValue.WordWrap = true;
            // 
            // txtRandomMinValue
            // 
            this.txtRandomMinValue.BackColor = System.Drawing.Color.Transparent;
            this.txtRandomMinValue.DownBack = null;
            this.txtRandomMinValue.Icon = null;
            this.txtRandomMinValue.IconIsButton = false;
            this.txtRandomMinValue.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtRandomMinValue.IsPasswordChat = '\0';
            this.txtRandomMinValue.IsSystemPasswordChar = false;
            this.txtRandomMinValue.Lines = new string[0];
            this.txtRandomMinValue.Location = new System.Drawing.Point(112, 147);
            this.txtRandomMinValue.Margin = new System.Windows.Forms.Padding(0);
            this.txtRandomMinValue.MaxLength = 32767;
            this.txtRandomMinValue.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtRandomMinValue.MouseBack = null;
            this.txtRandomMinValue.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtRandomMinValue.Multiline = false;
            this.txtRandomMinValue.Name = "txtRandomMinValue";
            this.txtRandomMinValue.NormlBack = null;
            this.txtRandomMinValue.Padding = new System.Windows.Forms.Padding(5);
            this.txtRandomMinValue.ReadOnly = false;
            this.txtRandomMinValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRandomMinValue.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.txtRandomMinValue.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRandomMinValue.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRandomMinValue.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtRandomMinValue.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtRandomMinValue.SkinTxt.Name = "BaseText";
            this.txtRandomMinValue.SkinTxt.Size = new System.Drawing.Size(175, 18);
            this.txtRandomMinValue.SkinTxt.TabIndex = 0;
            this.txtRandomMinValue.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtRandomMinValue.SkinTxt.WaterText = "";
            this.txtRandomMinValue.TabIndex = 3;
            this.txtRandomMinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRandomMinValue.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtRandomMinValue.WaterText = "";
            this.txtRandomMinValue.WordWrap = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(18, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 58);
            this.label1.TabIndex = 4;
            this.label1.Text = "间隔时长表示抓取商品间隔时间（毫秒），该时间鉴于最大值和最小值之间每次随机产生！最大值默认5000毫秒，最小值默认1000毫秒";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(17, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 33);
            this.label2.TabIndex = 5;
            this.label2.Text = "并行任务数值越大，执行抓取商品越快，但是注意机器性能,正常建议50以下.";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 349);
            this.Controls.Add(this.skinTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.Text = "系统设置";
            this.skinTabControl1.ResumeLayout(false);
            this.skinTabPage1.ResumeLayout(false);
            this.skinTabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinTabControl skinTabControl1;
        private CCWin.SkinControl.SkinTabPage skinTabPage1;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinTextBox txtMaxThreadCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinTextBox txtRandomMinValue;
        private CCWin.SkinControl.SkinTextBox txtRandomMaxValue;
    }
}
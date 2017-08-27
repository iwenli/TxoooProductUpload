namespace TxoooProductUpload.UI.Forms.MinForms
{
    partial class AboutForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.label1 = new System.Windows.Forms.Label();
            this.sp = new CCWin.SkinControl.SkinPanel();
            this.btnOK = new CCWin.SkinControl.SkinButton();
            this.textBoxDescription = new CCWin.SkinControl.SkinLabel();
            this.labelCompanyName = new CCWin.SkinControl.SkinLabel();
            this.sp.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // sp
            // 
            this.sp.BackColor = System.Drawing.Color.Transparent;
            this.sp.Controls.Add(this.btnOK);
            this.sp.Controls.Add(this.textBoxDescription);
            this.sp.Controls.Add(this.labelCompanyName);
            this.sp.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.sp.DownBack = null;
            this.sp.Location = new System.Drawing.Point(0, 30);
            this.sp.MouseBack = null;
            this.sp.Name = "sp";
            this.sp.NormlBack = null;
            this.sp.Size = new System.Drawing.Size(375, 220);
            this.sp.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BaseColor = System.Drawing.Color.Transparent;
            this.btnOK.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnOK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOK.DownBack = null;
            this.btnOK.DownBaseColor = System.Drawing.Color.Transparent;
            this.btnOK.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnOK.Location = new System.Drawing.Point(303, 188);
            this.btnOK.MouseBack = null;
            this.btnOK.Name = "btnOK";
            this.btnOK.NormlBack = null;
            this.btnOK.Size = new System.Drawing.Size(61, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.Color.Transparent;
            this.textBoxDescription.BorderColor = System.Drawing.Color.Transparent;
            this.textBoxDescription.BorderSize = 0;
            this.textBoxDescription.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxDescription.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxDescription.Location = new System.Drawing.Point(23, 81);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(331, 49);
            this.textBoxDescription.TabIndex = 0;
            this.textBoxDescription.Text = "警告：本程序受著作权法和国际公约的保护，未经授权擅自\r\n         复制或散步本程序的部分或全部，将承受相应的法律\r\n         责任。";
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.BackColor = System.Drawing.Color.Transparent;
            this.labelCompanyName.BorderColor = System.Drawing.Color.Gray;
            this.labelCompanyName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCompanyName.Location = new System.Drawing.Point(11, 166);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(343, 19);
            this.labelCompanyName.TabIndex = 0;
            this.labelCompanyName.Text = "skinLabel1";
            this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(375, 250);
            this.CloseBoxSize = new System.Drawing.Size(30, 27);
            this.CloseDownBack = global::TxoooProductUpload.UI.Properties.Resources.sysbtn_close_down;
            this.CloseMouseBack = global::TxoooProductUpload.UI.Properties.Resources.sysbtn_close_hover;
            this.CloseNormlBack = global::TxoooProductUpload.UI.Properties.Resources.sysbtn_close_normal;
            this.Controls.Add(this.sp);
            this.EffectCaption = CCWin.TitleType.Title;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShadowWidth = 6;
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";
            this.TitleColor = System.Drawing.Color.White;
            this.sp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinPanel sp;
        private CCWin.SkinControl.SkinLabel labelCompanyName;
        private CCWin.SkinControl.SkinLabel textBoxDescription;
        private CCWin.SkinControl.SkinButton btnOK;
    }
}

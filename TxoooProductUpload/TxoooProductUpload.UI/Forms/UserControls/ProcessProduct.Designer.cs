namespace TxoooProductUpload.UI.Forms.UserControls
{
    partial class ProcessProduct
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ProcessBar = new CCWin.SkinControl.SkinProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LabelStateMessage = new CCWin.SkinControl.SkinLabel();
            this.SuspendLayout();
            // 
            // ProcessBar
            // 
            this.ProcessBar.Back = null;
            this.ProcessBar.BackColor = System.Drawing.Color.Transparent;
            this.ProcessBar.BarBack = null;
            this.ProcessBar.BarRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.ProcessBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProcessBar.ForeColor = System.Drawing.Color.Red;
            this.ProcessBar.Location = new System.Drawing.Point(0, 184);
            this.ProcessBar.Name = "ProcessBar";
            this.ProcessBar.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.ProcessBar.Size = new System.Drawing.Size(690, 23);
            this.ProcessBar.TabIndex = 0;
            this.ProcessBar.TextFormat = CCWin.SkinControl.SkinProgressBar.TxtFormat.Proportion;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 184);
            this.panel1.TabIndex = 1;
            // 
            // LabelStateMessage
            // 
            this.LabelStateMessage.BackColor = System.Drawing.Color.Transparent;
            this.LabelStateMessage.BorderColor = System.Drawing.Color.White;
            this.LabelStateMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelStateMessage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelStateMessage.Location = new System.Drawing.Point(0, 207);
            this.LabelStateMessage.Name = "LabelStateMessage";
            this.LabelStateMessage.Size = new System.Drawing.Size(690, 17);
            this.LabelStateMessage.TabIndex = 2;
            this.LabelStateMessage.Text = "正在完善商品信息，请勿执行其他操作...";
            this.LabelStateMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProcessProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LabelStateMessage);
            this.Controls.Add(this.ProcessBar);
            this.Controls.Add(this.panel1);
            this.Name = "ProcessProduct";
            this.Size = new System.Drawing.Size(690, 422);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        protected internal CCWin.SkinControl.SkinProgressBar ProcessBar;
        protected internal CCWin.SkinControl.SkinLabel LabelStateMessage;
    }
}

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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProcessBar = new CCWin.SkinControl.SkinProgressBar();
            this.LabelStateMessage = new CCWin.SkinControl.SkinLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(80, 228);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(610, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(80, 228);
            this.panel3.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LabelStateMessage);
            this.panel1.Controls.Add(this.ProcessBar);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 228);
            this.panel1.TabIndex = 1;
            // 
            // ProcessBar
            // 
            this.ProcessBar.Back = null;
            this.ProcessBar.BackColor = System.Drawing.Color.Transparent;
            this.ProcessBar.BarBack = null;
            this.ProcessBar.BarRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.ProcessBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProcessBar.ForeColor = System.Drawing.Color.Red;
            this.ProcessBar.Location = new System.Drawing.Point(80, 205);
            this.ProcessBar.Margin = new System.Windows.Forms.Padding(30);
            this.ProcessBar.Name = "ProcessBar";
            this.ProcessBar.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.ProcessBar.Size = new System.Drawing.Size(530, 23);
            this.ProcessBar.TabIndex = 2;
            this.ProcessBar.TextFormat = CCWin.SkinControl.SkinProgressBar.TxtFormat.Proportion;
            // 
            // LabelStateMessage
            // 
            this.LabelStateMessage.BackColor = System.Drawing.Color.Transparent;
            this.LabelStateMessage.BorderColor = System.Drawing.Color.White;
            this.LabelStateMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelStateMessage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelStateMessage.Location = new System.Drawing.Point(80, 188);
            this.LabelStateMessage.Name = "LabelStateMessage";
            this.LabelStateMessage.Size = new System.Drawing.Size(530, 17);
            this.LabelStateMessage.TabIndex = 3;
            this.LabelStateMessage.Text = "正在完善商品信息，请勿执行其他操作...";
            this.LabelStateMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProcessProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ProcessProduct";
            this.Size = new System.Drawing.Size(690, 422);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        protected internal CCWin.SkinControl.SkinLabel LabelStateMessage;
        protected internal CCWin.SkinControl.SkinProgressBar ProcessBar;
    }
}

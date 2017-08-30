namespace TxoooProductUpload.UI.Forms.SubForms
{
    partial class CrawlProductsForm
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
            this.spanTop = new CCWin.SkinControl.SkinPanel();
            this.SuspendLayout();
            // 
            // spanTop
            // 
            this.spanTop.BackColor = System.Drawing.Color.Transparent;
            this.spanTop.BackgroundImage = global::TxoooProductUpload.UI.Properties.Resources.BaiduShurufa_2014_8_2_16_32_58;
            this.spanTop.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.spanTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.spanTop.DownBack = null;
            this.spanTop.Location = new System.Drawing.Point(0, 0);
            this.spanTop.MouseBack = null;
            this.spanTop.Name = "spanTop";
            this.spanTop.NormlBack = null;
            this.spanTop.Size = new System.Drawing.Size(1000, 30);
            this.spanTop.TabIndex = 0;
            // 
            // CrawlProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 433);
            this.Controls.Add(this.spanTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CrawlProductsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel spanTop;
    }
}
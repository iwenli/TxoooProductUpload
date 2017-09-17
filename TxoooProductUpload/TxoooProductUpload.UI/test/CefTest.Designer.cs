namespace TxoooProductUpload.UI
{
    partial class CefTest
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGo = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cefWebBrowser1 = new Xilium.CefGlue.WindowsForms.CefWebBrowser();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGo);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 47);
            this.panel1.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGo.Location = new System.Drawing.Point(825, 21);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 26);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "进入";
            this.btnGo.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(900, 21);
            this.textBox1.TabIndex = 0;
            // 
            // cefWebBrowser1
            // 
            this.cefWebBrowser1.BrowserSettings = null;
            this.cefWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cefWebBrowser1.Location = new System.Drawing.Point(0, 47);
            this.cefWebBrowser1.Name = "cefWebBrowser1";
            this.cefWebBrowser1.Size = new System.Drawing.Size(900, 340);
            this.cefWebBrowser1.StartUrl = "www.baidu.com";
            this.cefWebBrowser1.TabIndex = 2;
            this.cefWebBrowser1.Text = "cefWebBrowser1";
            // 
            // CefTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 387);
            this.Controls.Add(this.cefWebBrowser1);
            this.Controls.Add(this.panel1);
            this.Name = "CefTest";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox textBox1;
        private Xilium.CefGlue.WindowsForms.CefWebBrowser cefWebBrowser1;
    }
}


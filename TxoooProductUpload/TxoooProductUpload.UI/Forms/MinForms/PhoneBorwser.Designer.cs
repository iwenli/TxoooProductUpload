namespace TxoooProductUpload.UI
{
    partial class PhoneBorwser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhoneBorwser));
            this.paLweb = new System.Windows.Forms.Panel();
            this.cefWebBrowser1 = new Xilium.CefGlue.WindowsForms.CefWebBrowser();
            this.cms = new CCWin.SkinControl.SkinContextMenuStrip();
            this.cmsGo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsIn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsClose = new System.Windows.Forms.ToolStripMenuItem();
            this.paLweb.SuspendLayout();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // paLweb
            // 
            this.paLweb.Controls.Add(this.cefWebBrowser1);
            this.paLweb.Location = new System.Drawing.Point(23, 77);
            this.paLweb.Name = "paLweb";
            this.paLweb.Size = new System.Drawing.Size(307, 544);
            this.paLweb.TabIndex = 0;
            // 
            // cefWebBrowser1
            // 
            this.cefWebBrowser1.BrowserSettings = null;
            this.cefWebBrowser1.Dock = System.Windows.Forms.DockStyle.Left;
            this.cefWebBrowser1.Location = new System.Drawing.Point(0, 0);
            this.cefWebBrowser1.Name = "cefWebBrowser1";
            this.cefWebBrowser1.Size = new System.Drawing.Size(325, 544);
            this.cefWebBrowser1.StartUrl = "";
            this.cefWebBrowser1.TabIndex = 1;
            // 
            // cms
            // 
            this.cms.Arrow = System.Drawing.Color.Black;
            this.cms.Back = System.Drawing.Color.White;
            this.cms.BackRadius = 4;
            this.cms.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.cms.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cms.Fore = System.Drawing.Color.Black;
            this.cms.HoverFore = System.Drawing.Color.White;
            this.cms.ItemAnamorphosis = true;
            this.cms.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cms.ItemBorderShow = true;
            this.cms.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cms.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cms.ItemRadius = 4;
            this.cms.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsGo,
            this.cmsIn,
            this.toolStripSeparator1,
            this.cmsClose});
            this.cms.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cms.Name = "cms";
            this.cms.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.cms.Size = new System.Drawing.Size(137, 76);
            this.cms.SkinAllColor = true;
            this.cms.TitleAnamorphosis = true;
            this.cms.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.cms.TitleRadius = 4;
            this.cms.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // cmsGo
            // 
            this.cmsGo.Name = "cmsGo";
            this.cmsGo.Size = new System.Drawing.Size(136, 22);
            this.cmsGo.Text = "继续浏览";
            // 
            // cmsIn
            // 
            this.cmsIn.Name = "cmsIn";
            this.cmsIn.Size = new System.Drawing.Size(136, 22);
            this.cmsIn.Text = "粘贴并浏览";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // cmsClose
            // 
            this.cmsClose.Name = "cmsClose";
            this.cmsClose.Size = new System.Drawing.Size(136, 22);
            this.cmsClose.Text = "关闭";
            // 
            // PhoneBorwser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 703);
            this.ContextMenuStrip = this.cms;
            this.Controls.Add(this.paLweb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PhoneBorwser";
            this.SkinBack = ((System.Drawing.Image)(resources.GetObject("$this.SkinBack")));
            this.Text = "手机浏览器";
            this.paLweb.ResumeLayout(false);
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel paLweb;
        private CCWin.SkinControl.SkinContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem cmsGo;
        private Xilium.CefGlue.WindowsForms.CefWebBrowser cefWebBrowser1;
        private System.Windows.Forms.ToolStripMenuItem cmsIn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmsClose;
    }
}
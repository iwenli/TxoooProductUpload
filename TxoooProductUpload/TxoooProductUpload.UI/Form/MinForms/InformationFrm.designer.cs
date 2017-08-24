namespace TxoooProductUpload.UI
{
    partial class InformationFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformationFrm));
            this.timShow = new System.Windows.Forms.Timer(this.components);
            this.lblState = new CCWin.SkinControl.SkinLabel();
            this.pnlHeadImg = new CCWin.SkinControl.SkinPanel();
            this.lblMsg = new CCWin.SkinControl.SkinLabel();
            this.skinButtom1 = new CCWin.SkinControl.SkinButton();
            this.SuspendLayout();
            // 
            // timShow
            // 
            this.timShow.Enabled = true;
            this.timShow.Interval = 3000;
            this.timShow.Tick += new System.EventHandler(this.timShow_Tick);
            // 
            // lblState
            // 
            this.lblState.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lblState.AutoSize = true;
            this.lblState.BackColor = System.Drawing.Color.Transparent;
            this.lblState.BorderColor = System.Drawing.Color.White;
            this.lblState.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblState.Location = new System.Drawing.Point(7, 136);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(0, 17);
            this.lblState.TabIndex = 0;
            // 
            // pnlHeadImg
            // 
            this.pnlHeadImg.BackColor = System.Drawing.Color.White;
            this.pnlHeadImg.BackgroundImage = global::TxoooProductUpload.UI.Properties.Resources.head_d;
            this.pnlHeadImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHeadImg.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.pnlHeadImg.DownBack = null;
            this.pnlHeadImg.Location = new System.Drawing.Point(13, 45);
            this.pnlHeadImg.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeadImg.MouseBack = null;
            this.pnlHeadImg.Name = "pnlHeadImg";
            this.pnlHeadImg.NormlBack = null;
            this.pnlHeadImg.Radius = 4;
            this.pnlHeadImg.Size = new System.Drawing.Size(60, 60);
            this.pnlHeadImg.TabIndex = 6;
            // 
            // lblMsg
            // 
            this.lblMsg.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.BorderColor = System.Drawing.Color.White;
            this.lblMsg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.Location = new System.Drawing.Point(82, 46);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(163, 68);
            this.lblMsg.TabIndex = 22;
            // 
            // skinButtom1
            // 
            this.skinButtom1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.skinButtom1.BackColor = System.Drawing.Color.Transparent;
            this.skinButtom1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.skinButtom1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButtom1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.skinButtom1.DownBack = null;
            this.skinButtom1.DrawType = CCWin.SkinControl.DrawStyle.None;
            this.skinButtom1.Image = ((System.Drawing.Image)(resources.GetObject("skinButtom1.Image")));
            this.skinButtom1.Location = new System.Drawing.Point(228, 137);
            this.skinButtom1.Margin = new System.Windows.Forms.Padding(0);
            this.skinButtom1.MouseBack = null;
            this.skinButtom1.Name = "skinButtom1";
            this.skinButtom1.NormlBack = null;
            this.skinButtom1.Size = new System.Drawing.Size(16, 16);
            this.skinButtom1.TabIndex = 127;
            this.skinButtom1.UseVisualStyleBackColor = false;
            // 
            // InformationFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Back = ((System.Drawing.Image)(resources.GetObject("$this.Back")));
            this.BackLayout = false;
            this.BorderPalace = ((System.Drawing.Image)(resources.GetObject("$this.BorderPalace")));
            this.CanResize = false;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.ClientSize = new System.Drawing.Size(258, 160);
            this.CloseBoxSize = new System.Drawing.Size(25, 26);
            this.CloseDownBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseDownBack")));
            this.CloseMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseMouseBack")));
            this.CloseNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseNormlBack")));
            this.ControlBoxOffset = new System.Drawing.Point(0, -1);
            this.Controls.Add(this.pnlHeadImg);
            this.Controls.Add(this.skinButtom1);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblState);
            this.DropBack = false;
            this.EffectWidth = 2;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaxSize = new System.Drawing.Size(28, 20);
            this.MinimizeBox = false;
            this.MiniSize = new System.Drawing.Size(28, 20);
            this.Name = "InformationFrm";
            this.ShowInTaskbar = false;
            this.Text = "";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmInformation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timShow;
        private CCWin.SkinControl.SkinLabel lblState;
        private CCWin.SkinControl.SkinLabel lblMsg;
        private CCWin.SkinControl.SkinPanel pnlHeadImg;
        private CCWin.SkinControl.SkinButton skinButtom1;
    }
}
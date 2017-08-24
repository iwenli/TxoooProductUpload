namespace TxoooProductUpload.UI
{
    partial class MsgBox
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
            this.lblMsg = new CCWin.SkinControl.SkinLabel();
            this.iconBox = new System.Windows.Forms.PictureBox();
            this.timerHide = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lblMsg.AutoEllipsis = true;
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblMsg.BorderSize = 4;
            this.lblMsg.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMsg.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblMsg.ForeColor = System.Drawing.Color.White;
            this.lblMsg.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblMsg.Location = new System.Drawing.Point(84, 60);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(145, 64);
            this.lblMsg.TabIndex = 103;
            // 
            // iconBox
            // 
            this.iconBox.BackColor = System.Drawing.Color.Transparent;
            this.iconBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iconBox.Location = new System.Drawing.Point(10, 53);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(68, 75);
            this.iconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconBox.TabIndex = 102;
            this.iconBox.TabStop = false;
            // 
            // timerHide
            // 
            this.timerHide.Enabled = true;
            this.timerHide.Interval = 2000;
            this.timerHide.Tick += new System.EventHandler(this.timerHide_Tick);
            // 
            // MsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Back = global::TxoooProductUpload.UI.Properties.Resources.infoBg;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(86)))), ((int)(((byte)(87)))));
            this.BackLayout = false;
            this.BorderPalace = global::TxoooProductUpload.UI.Properties.Resources.BackPalace;
            this.CanResize = false;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.ClientSize = new System.Drawing.Size(233, 161);
            this.CloseBoxSize = new System.Drawing.Size(39, 20);
            this.CloseDownBack = global::TxoooProductUpload.UI.Properties.Resources.btn_close_down;
            this.CloseMouseBack = global::TxoooProductUpload.UI.Properties.Resources.btn_close_highlight;
            this.CloseNormlBack = global::TxoooProductUpload.UI.Properties.Resources.btn_close_disable;
            this.ControlBoxOffset = new System.Drawing.Point(0, -1);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.iconBox);
            this.DropBack = false;
            this.EffectBack = System.Drawing.Color.WhiteSmoke;
            this.EffectWidth = 3;
            this.MaximizeBox = false;
            this.MaxSize = new System.Drawing.Size(28, 20);
            this.MinimizeBox = false;
            this.MiniSize = new System.Drawing.Size(28, 20);
            this.Name = "MsgBox";
            this.ShadowColor = System.Drawing.Color.Transparent;
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox iconBox;
        public System.Windows.Forms.Timer timerHide;
        public CCWin.SkinControl.SkinLabel lblMsg;
    }
}
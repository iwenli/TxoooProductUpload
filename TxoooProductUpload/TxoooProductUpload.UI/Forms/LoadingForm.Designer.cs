namespace TxoooProductUpload.UI.Forms
{
    partial class LoadingForm
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
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.logTxt = new CCWin.SkinControl.SkinChatRichTextBox();
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.LoadMessage = new CCWin.SkinControl.SkinLabel();
            this.gifBox1 = new CCWin.SkinControl.GifBox();
            this.skinPanel1.SuspendLayout();
            this.skinPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.BorderColor = System.Drawing.Color.Silver;
            this.skinPanel1.Controls.Add(this.logTxt);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(4, 156);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Padding = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.skinPanel1.Size = new System.Drawing.Size(467, 283);
            this.skinPanel1.TabIndex = 1;
            // 
            // logTxt
            // 
            this.logTxt.BackColor = System.Drawing.Color.White;
            this.logTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.logTxt.Location = new System.Drawing.Point(10, 10);
            this.logTxt.Name = "logTxt";
            this.logTxt.ReadOnly = true;
            this.logTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.logTxt.SelectControl = null;
            this.logTxt.SelectControlIndex = 0;
            this.logTxt.SelectControlPoint = new System.Drawing.Point(0, 0);
            this.logTxt.Size = new System.Drawing.Size(452, 263);
            this.logTxt.TabIndex = 3;
            this.logTxt.Text = "";
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.LoadMessage);
            this.skinPanel2.Controls.Add(this.gifBox1);
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(4, 28);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(467, 128);
            this.skinPanel2.TabIndex = 2;
            // 
            // LoadMessage
            // 
            this.LoadMessage.BackColor = System.Drawing.Color.Transparent;
            this.LoadMessage.BorderColor = System.Drawing.Color.White;
            this.LoadMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadMessage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LoadMessage.Location = new System.Drawing.Point(0, 90);
            this.LoadMessage.Name = "LoadMessage";
            this.LoadMessage.Size = new System.Drawing.Size(467, 38);
            this.LoadMessage.TabIndex = 3;
            this.LoadMessage.Text = "正在执行操作,请稍等...";
            this.LoadMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gifBox1
            // 
            this.gifBox1.BorderColor = System.Drawing.Color.Transparent;
            this.gifBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.gifBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gifBox1.Image = global::TxoooProductUpload.UI.Properties.Resources.Rainbow;
            this.gifBox1.Location = new System.Drawing.Point(0, 0);
            this.gifBox1.Name = "gifBox1";
            this.gifBox1.Size = new System.Drawing.Size(467, 90);
            this.gifBox1.TabIndex = 1;
            this.gifBox1.Text = "gifBox1";
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(475, 443);
            this.ControlBox = false;
            this.Controls.Add(this.skinPanel1);
            this.Controls.Add(this.skinPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingForm";
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinChatRichTextBox logTxt;
        private CCWin.SkinControl.SkinPanel skinPanel2;
        private CCWin.SkinControl.SkinLabel LoadMessage;
        private CCWin.SkinControl.GifBox gifBox1;
    }
}
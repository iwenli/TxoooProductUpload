namespace TxoooProductUpload.UI.Forms
{
    partial class ChangeLocationForm
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
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.txtSearch = new CCWin.SkinControl.SkinWaterTextBox();
            this.btnSearch = new CCWin.SkinControl.SkinButton();
            this.label1 = new System.Windows.Forms.Label();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.skinPanel4 = new CCWin.SkinControl.SkinPanel();
            this.lbLocation2 = new System.Windows.Forms.ListBox();
            this.lbLocation1 = new System.Windows.Forms.ListBox();
            this.skinPanel3 = new CCWin.SkinControl.SkinPanel();
            this.btnCancel = new CCWin.SkinControl.SkinButton();
            this.btnOk = new CCWin.SkinControl.SkinButton();
            this.lblClass = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.skinPanel2.SuspendLayout();
            this.skinPanel1.SuspendLayout();
            this.skinPanel4.SuspendLayout();
            this.skinPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.txtSearch);
            this.skinPanel2.Controls.Add(this.btnSearch);
            this.skinPanel2.Controls.Add(this.label1);
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(0, 0);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(402, 39);
            this.skinPanel2.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(84, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(230, 21);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSearch.WaterText = "输入关键词搜索";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSearch.DownBack = null;
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(320, 9);
            this.btnSearch.MouseBack = null;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.NormlBack = null;
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "搜索(&S)";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "类目搜索：";
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.skinPanel1.Controls.Add(this.skinPanel4);
            this.skinPanel1.Controls.Add(this.skinPanel3);
            this.skinPanel1.Controls.Add(this.skinPanel2);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(4, 28);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(402, 452);
            this.skinPanel1.TabIndex = 1;
            // 
            // skinPanel4
            // 
            this.skinPanel4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.skinPanel4.Controls.Add(this.lbLocation2);
            this.skinPanel4.Controls.Add(this.lbLocation1);
            this.skinPanel4.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel4.DownBack = null;
            this.skinPanel4.Location = new System.Drawing.Point(0, 39);
            this.skinPanel4.MouseBack = null;
            this.skinPanel4.Name = "skinPanel4";
            this.skinPanel4.NormlBack = null;
            this.skinPanel4.Size = new System.Drawing.Size(402, 343);
            this.skinPanel4.TabIndex = 2;
            // 
            // lbLocation2
            // 
            this.lbLocation2.BackColor = System.Drawing.SystemColors.Info;
            this.lbLocation2.FormattingEnabled = true;
            this.lbLocation2.ItemHeight = 12;
            this.lbLocation2.Location = new System.Drawing.Point(207, 7);
            this.lbLocation2.Name = "lbLocation2";
            this.lbLocation2.Size = new System.Drawing.Size(188, 328);
            this.lbLocation2.TabIndex = 1;
            // 
            // lbLocation1
            // 
            this.lbLocation1.BackColor = System.Drawing.SystemColors.Info;
            this.lbLocation1.FormattingEnabled = true;
            this.lbLocation1.ItemHeight = 12;
            this.lbLocation1.Location = new System.Drawing.Point(10, 7);
            this.lbLocation1.Name = "lbLocation1";
            this.lbLocation1.Size = new System.Drawing.Size(188, 328);
            this.lbLocation1.TabIndex = 1;
            // 
            // skinPanel3
            // 
            this.skinPanel3.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel3.Controls.Add(this.btnCancel);
            this.skinPanel3.Controls.Add(this.btnOk);
            this.skinPanel3.Controls.Add(this.lblClass);
            this.skinPanel3.Controls.Add(this.label2);
            this.skinPanel3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinPanel3.DownBack = null;
            this.skinPanel3.Location = new System.Drawing.Point(0, 382);
            this.skinPanel3.MouseBack = null;
            this.skinPanel3.Name = "skinPanel3";
            this.skinPanel3.NormlBack = null;
            this.skinPanel3.Size = new System.Drawing.Size(402, 70);
            this.skinPanel3.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancel.DownBack = null;
            this.btnCancel.Location = new System.Drawing.Point(315, 35);
            this.btnCancel.MouseBack = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOk.DownBack = null;
            this.btnOk.Location = new System.Drawing.Point(219, 35);
            this.btnOk.MouseBack = null;
            this.btnOk.Name = "btnOk";
            this.btnOk.NormlBack = null;
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Tag = "ok";
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClass.ForeColor = System.Drawing.Color.Blue;
            this.lblClass.Location = new System.Drawing.Point(117, 9);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(0, 17);
            this.lblClass.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "您选择的发货地是：";
            // 
            // ChangeLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 484);
            this.Controls.Add(this.skinPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeLocationForm";
            this.Text = "选择商品发货地";
            this.skinPanel2.ResumeLayout(false);
            this.skinPanel2.PerformLayout();
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel4.ResumeLayout(false);
            this.skinPanel3.ResumeLayout(false);
            this.skinPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel2;
        private CCWin.SkinControl.SkinButton btnSearch;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinPanel skinPanel4;
        private CCWin.SkinControl.SkinPanel skinPanel3;
        private CCWin.SkinControl.SkinButton btnCancel;
        private CCWin.SkinControl.SkinButton btnOk;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbLocation2;
        private System.Windows.Forms.ListBox lbLocation1;
        private CCWin.SkinControl.SkinWaterTextBox txtSearch;
    }
}
namespace TxoooProductUpload.UI.Main
{
    partial class CommentImages
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lab_remark = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lv = new System.Windows.Forms.ListView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsDel = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsShow = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(707, 433);
            this.panel1.TabIndex = 163;
            // 
            // il
            // 
            this.il.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.il.ImageSize = new System.Drawing.Size(160, 160);
            this.il.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.lab_remark);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(707, 55);
            this.panel2.TabIndex = 167;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(141, 22);
            this.btnAdd.TabIndex = 167;
            this.btnAdd.Tag = "Add";
            this.btnAdd.Text = "自定义添加图片(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // lab_remark
            // 
            this.lab_remark.AutoSize = true;
            this.lab_remark.Location = new System.Drawing.Point(168, 21);
            this.lab_remark.Name = "lab_remark";
            this.lab_remark.Size = new System.Drawing.Size(71, 12);
            this.lab_remark.TabIndex = 170;
            this.lab_remark.Text = "最多6张图片";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(620, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 171;
            this.btnSave.Tag = "Save";
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lv
            // 
            this.lv.ContextMenuStrip = this.cms;
            this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv.LargeImageList = this.il;
            this.lv.Location = new System.Drawing.Point(0, 0);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(705, 431);
            this.lv.TabIndex = 2;
            this.lv.UseCompatibleStateImageBehavior = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(529, 17);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 171;
            this.btnCancel.Tag = "Cancel";
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsDel,
            this.cmsShow});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(140, 48);
            // 
            // cmsDel
            // 
            this.cmsDel.Name = "cmsDel";
            this.cmsDel.Size = new System.Drawing.Size(139, 22);
            this.cmsDel.Tag = "del";
            this.cmsDel.Text = "删除(&D)";
            // 
            // cmsShow
            // 
            this.cmsShow.Name = "cmsShow";
            this.cmsShow.Size = new System.Drawing.Size(139, 22);
            this.cmsShow.Tag = "show";
            this.cmsShow.Text = "查看大图(&S)";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CommentImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 488);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommentImages";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "评价图片";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lab_remark;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem cmsDel;
        private System.Windows.Forms.ToolStripMenuItem cmsShow;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
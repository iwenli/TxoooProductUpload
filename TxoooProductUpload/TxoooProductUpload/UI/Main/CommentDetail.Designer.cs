namespace TxoooProductUpload.UI.Main
{
    partial class CommentDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommentDetail));
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsDel = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvComments = new System.Windows.Forms.DataGridView();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.ts = new System.Windows.Forms.ToolStrip();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.st = new System.Windows.Forms.StatusStrip();
            this.nickNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeadImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.propertyNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productReviewDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expressReviewDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.likeCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reviewImageBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.reviewContentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mchReplyContentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reviewImageUrls = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeadImageUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.ts.SuspendLayout();
            this.SuspendLayout();
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsDel});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(118, 26);
            // 
            // cmsDel
            // 
            this.cmsDel.Name = "cmsDel";
            this.cmsDel.Size = new System.Drawing.Size(117, 22);
            this.cmsDel.Text = "删除(&D)";
            // 
            // dgvComments
            // 
            this.dgvComments.AllowUserToAddRows = false;
            this.dgvComments.AllowUserToDeleteRows = false;
            this.dgvComments.AllowUserToOrderColumns = true;
            this.dgvComments.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvComments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvComments.AutoGenerateColumns = false;
            this.dgvComments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvComments.BackgroundColor = System.Drawing.Color.White;
            this.dgvComments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nickNameDataGridViewTextBoxColumn,
            this.HeadImage,
            this.propertyNameDataGridViewTextBoxColumn,
            this.productReviewDataGridViewTextBoxColumn,
            this.expressReviewDataGridViewTextBoxColumn,
            this.likeCountDataGridViewTextBoxColumn,
            this.addTimeDataGridViewTextBoxColumn,
            this.reviewImageBtn,
            this.reviewContentDataGridViewTextBoxColumn,
            this.mchReplyContentDataGridViewTextBoxColumn,
            this.reviewImageUrls,
            this.HeadImageUrl});
            this.dgvComments.ContextMenuStrip = this.cms;
            this.dgvComments.DataSource = this.bs;
            this.dgvComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComments.Location = new System.Drawing.Point(0, 25);
            this.dgvComments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvComments.MultiSelect = false;
            this.dgvComments.Name = "dgvComments";
            this.dgvComments.RowHeadersWidth = 50;
            this.dgvComments.RowTemplate.Height = 32;
            this.dgvComments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComments.ShowCellErrors = false;
            this.dgvComments.ShowCellToolTips = false;
            this.dgvComments.Size = new System.Drawing.Size(1067, 552);
            this.dgvComments.TabIndex = 3;
            // 
            // bs
            // 
            this.bs.DataSource = typeof(TxoooProductUpload.Service.Entities.Commnet.ReviewDataSoruce);
            // 
            // ts
            // 
            this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSave});
            this.ts.Location = new System.Drawing.Point(0, 0);
            this.ts.Name = "ts";
            this.ts.Size = new System.Drawing.Size(1067, 25);
            this.ts.TabIndex = 1;
            this.ts.Text = "toolStrip1";
            // 
            // tsSave
            // 
            this.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsSave.Image = ((System.Drawing.Image)(resources.GetObject("tsSave.Image")));
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(87, 22);
            this.tsSave.Text = "保存并上传(&S)";
            // 
            // st
            // 
            this.st.Location = new System.Drawing.Point(0, 577);
            this.st.Name = "st";
            this.st.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.st.Size = new System.Drawing.Size(1067, 22);
            this.st.TabIndex = 0;
            this.st.Text = "statusStrip1";
            // 
            // nickNameDataGridViewTextBoxColumn
            // 
            this.nickNameDataGridViewTextBoxColumn.DataPropertyName = "NickName";
            this.nickNameDataGridViewTextBoxColumn.Frozen = true;
            this.nickNameDataGridViewTextBoxColumn.HeaderText = "昵称";
            this.nickNameDataGridViewTextBoxColumn.Name = "nickNameDataGridViewTextBoxColumn";
            this.nickNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nickNameDataGridViewTextBoxColumn.Width = 57;
            // 
            // HeadImage
            // 
            this.HeadImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.HeadImage.Frozen = true;
            this.HeadImage.HeaderText = "头像";
            this.HeadImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.HeadImage.Name = "HeadImage";
            this.HeadImage.ReadOnly = true;
            this.HeadImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.HeadImage.Width = 57;
            // 
            // propertyNameDataGridViewTextBoxColumn
            // 
            this.propertyNameDataGridViewTextBoxColumn.DataPropertyName = "PropertyName";
            this.propertyNameDataGridViewTextBoxColumn.Frozen = true;
            this.propertyNameDataGridViewTextBoxColumn.HeaderText = "评价属性";
            this.propertyNameDataGridViewTextBoxColumn.Name = "propertyNameDataGridViewTextBoxColumn";
            this.propertyNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.propertyNameDataGridViewTextBoxColumn.Width = 81;
            // 
            // productReviewDataGridViewTextBoxColumn
            // 
            this.productReviewDataGridViewTextBoxColumn.DataPropertyName = "ProductReview";
            this.productReviewDataGridViewTextBoxColumn.Frozen = true;
            this.productReviewDataGridViewTextBoxColumn.HeaderText = "商品打分";
            this.productReviewDataGridViewTextBoxColumn.Name = "productReviewDataGridViewTextBoxColumn";
            this.productReviewDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.productReviewDataGridViewTextBoxColumn.Width = 81;
            // 
            // expressReviewDataGridViewTextBoxColumn
            // 
            this.expressReviewDataGridViewTextBoxColumn.DataPropertyName = "ExpressReview";
            this.expressReviewDataGridViewTextBoxColumn.Frozen = true;
            this.expressReviewDataGridViewTextBoxColumn.HeaderText = "快递打分";
            this.expressReviewDataGridViewTextBoxColumn.Name = "expressReviewDataGridViewTextBoxColumn";
            this.expressReviewDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.expressReviewDataGridViewTextBoxColumn.Width = 81;
            // 
            // likeCountDataGridViewTextBoxColumn
            // 
            this.likeCountDataGridViewTextBoxColumn.DataPropertyName = "LikeCount";
            this.likeCountDataGridViewTextBoxColumn.Frozen = true;
            this.likeCountDataGridViewTextBoxColumn.HeaderText = "点赞数";
            this.likeCountDataGridViewTextBoxColumn.Name = "likeCountDataGridViewTextBoxColumn";
            this.likeCountDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.likeCountDataGridViewTextBoxColumn.Width = 69;
            // 
            // addTimeDataGridViewTextBoxColumn
            // 
            this.addTimeDataGridViewTextBoxColumn.DataPropertyName = "AddTime";
            this.addTimeDataGridViewTextBoxColumn.Frozen = true;
            this.addTimeDataGridViewTextBoxColumn.HeaderText = "评价时间";
            this.addTimeDataGridViewTextBoxColumn.Name = "addTimeDataGridViewTextBoxColumn";
            this.addTimeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.addTimeDataGridViewTextBoxColumn.Width = 81;
            // 
            // reviewImageBtn
            // 
            this.reviewImageBtn.Frozen = true;
            this.reviewImageBtn.HeaderText = "评价图片";
            this.reviewImageBtn.Name = "reviewImageBtn";
            this.reviewImageBtn.ReadOnly = true;
            this.reviewImageBtn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.reviewImageBtn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.reviewImageBtn.Text = "查看";
            this.reviewImageBtn.Width = 81;
            // 
            // reviewContentDataGridViewTextBoxColumn
            // 
            this.reviewContentDataGridViewTextBoxColumn.DataPropertyName = "ReviewContent";
            this.reviewContentDataGridViewTextBoxColumn.HeaderText = "评价内容";
            this.reviewContentDataGridViewTextBoxColumn.Name = "reviewContentDataGridViewTextBoxColumn";
            this.reviewContentDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.reviewContentDataGridViewTextBoxColumn.Width = 81;
            // 
            // mchReplyContentDataGridViewTextBoxColumn
            // 
            this.mchReplyContentDataGridViewTextBoxColumn.DataPropertyName = "MchReplyContent";
            this.mchReplyContentDataGridViewTextBoxColumn.HeaderText = "商户回复";
            this.mchReplyContentDataGridViewTextBoxColumn.Name = "mchReplyContentDataGridViewTextBoxColumn";
            this.mchReplyContentDataGridViewTextBoxColumn.Width = 81;
            // 
            // reviewImageUrls
            // 
            this.reviewImageUrls.DataPropertyName = "ReviewImgs";
            this.reviewImageUrls.HeaderText = "评价图片URl";
            this.reviewImageUrls.Name = "reviewImageUrls";
            this.reviewImageUrls.Visible = false;
            this.reviewImageUrls.Width = 101;
            // 
            // HeadImageUrl
            // 
            this.HeadImageUrl.DataPropertyName = "HeadPic";
            this.HeadImageUrl.HeaderText = "头像url";
            this.HeadImageUrl.Name = "HeadImageUrl";
            this.HeadImageUrl.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HeadImageUrl.Visible = false;
            this.HeadImageUrl.Width = 72;
            // 
            // CommentDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 599);
            this.Controls.Add(this.dgvComments);
            this.Controls.Add(this.ts);
            this.Controls.Add(this.st);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "CommentDetail";
            this.ShowIcon = false;
            this.Text = "评价筛选";
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip st;
        private System.Windows.Forms.ToolStrip ts;
        private System.Windows.Forms.DataGridView dgvComments;
        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem cmsDel;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn nickNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn HeadImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn propertyNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productReviewDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expressReviewDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn likeCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reviewContentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mchReplyContentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reviewImageUrls;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeadImageUrl;
        private System.Windows.Forms.DataGridViewButtonColumn reviewImageBtn;
    }
}
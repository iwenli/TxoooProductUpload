namespace TxoooProductUpload.UI.Forms.SubForms
{
    partial class ProductManageForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("所有商品");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductManageForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ProductBindSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProductDGV = new CCWin.SkinControl.SkinDataGridView();
            this.skinTreeView = new CCWin.SkinControl.SkinTreeView();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tsBtnDownAllSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsBtnUpAllSelect = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDeleteAllSelect = new System.Windows.Forms.ToolStripButton();
            this.rslpsp2 = new System.Windows.Forms.ToolStripLabel();
            this.tsBtnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.rslpsp1 = new System.Windows.Forms.ToolStripLabel();
            this.ts = new CCWin.SkinControl.SkinToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.productnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producttypenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OnColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.OffColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.EditColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.loading = new CCWin.SkinControl.GifBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProductBindSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDGV)).BeginInit();
            this.ts.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductBindSource
            // 
            this.ProductBindSource.DataSource = typeof(TxoooProductUpload.Entities.Resporse.Txooo.ManageProductInfo);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ProductName";
            this.dataGridViewTextBoxColumn1.HeaderText = "所属类目";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Brand";
            this.dataGridViewTextBoxColumn2.HeaderText = "品牌";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "RegionName";
            this.dataGridViewTextBoxColumn3.HeaderText = "发货地";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ShowPrice";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn4.HeaderText = "售价";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PremiumRatio";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Format = "P";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn5.HeaderText = "溢价";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ToolTipText = "溢价比例";
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "H5Url";
            this.dataGridViewTextBoxColumn18.HeaderText = "H5Url";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Visible = false;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "SettlementRatio";
            this.dataGridViewTextBoxColumn16.HeaderText = "SettlementRatio";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Visible = false;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "RegionCode";
            this.dataGridViewTextBoxColumn15.HeaderText = "RegionCode";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "ClassId";
            this.dataGridViewTextBoxColumn14.HeaderText = "ClassId";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "ClassType";
            this.dataGridViewTextBoxColumn13.HeaderText = "ClassType";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn12.HeaderText = "Id";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "CommnetCnt";
            this.dataGridViewTextBoxColumn11.HeaderText = "评价数";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "SellCnt";
            this.dataGridViewTextBoxColumn10.HeaderText = "总销量";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "DealCnt";
            this.dataGridViewTextBoxColumn8.HeaderText = "确认收货量";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewCheckBoxColumn4
            // 
            this.dataGridViewCheckBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewCheckBoxColumn4.DataPropertyName = "IsRefund";
            this.dataGridViewCheckBoxColumn4.HeaderText = "7天";
            this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
            this.dataGridViewCheckBoxColumn4.Width = 50;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewCheckBoxColumn3.DataPropertyName = "IsVirtual";
            this.dataGridViewCheckBoxColumn3.HeaderText = "虚拟";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.Width = 50;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "IsNew";
            this.dataGridViewCheckBoxColumn2.HeaderText = "新品";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Postage";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn7.HeaderText = "邮费";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IsFreePostage";
            this.dataGridViewCheckBoxColumn1.HeaderText = "包邮";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "FavCnt";
            this.dataGridViewTextBoxColumn9.HeaderText = "收藏量";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn6.HeaderText = "所属类目";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Url";
            this.dataGridViewTextBoxColumn17.HeaderText = "Url";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ProductDGV);
            this.panel1.Controls.Add(this.skinTreeView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 542);
            this.panel1.TabIndex = 130;
            // 
            // ProductDGV
            // 
            this.ProductDGV.AllowUserToAddRows = false;
            this.ProductDGV.AllowUserToDeleteRows = false;
            this.ProductDGV.AlternatingCellBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DimGray;
            this.ProductDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ProductDGV.AutoGenerateColumns = false;
            this.ProductDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProductDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ProductDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProductDGV.ColumnFont = null;
            this.ProductDGV.ColumnForeColor = System.Drawing.Color.DimGray;
            this.ProductDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.ProductDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productnameDataGridViewTextBoxColumn,
            this.producttypenameDataGridViewTextBoxColumn,
            this.statenameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.OnColumn,
            this.OffColumn,
            this.EditColumn,
            this.DeleteColumn});
            this.ProductDGV.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.ProductDGV.DataSource = this.ProductBindSource;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductDGV.DefaultCellStyle = dataGridViewCellStyle7;
            this.ProductDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductDGV.EnableHeadersVisualStyles = false;
            this.ProductDGV.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.ProductDGV.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ProductDGV.HeadFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProductDGV.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.ProductDGV.Location = new System.Drawing.Point(152, 0);
            this.ProductDGV.Margin = new System.Windows.Forms.Padding(10);
            this.ProductDGV.MouseCellBackColor = System.Drawing.Color.White;
            this.ProductDGV.MultiSelect = false;
            this.ProductDGV.Name = "ProductDGV";
            this.ProductDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.ProductDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.ProductDGV.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.ProductDGV.RowTemplate.Height = 23;
            this.ProductDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductDGV.Size = new System.Drawing.Size(840, 542);
            this.ProductDGV.SkinGridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ProductDGV.TabIndex = 20;
            this.ProductDGV.TitleBack = null;
            this.ProductDGV.TitleBackColorBegin = System.Drawing.Color.White;
            this.ProductDGV.TitleBackColorEnd = System.Drawing.SystemColors.Control;
            // 
            // skinTreeView
            // 
            this.skinTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.skinTreeView.ItemHeight = 20;
            this.skinTreeView.Location = new System.Drawing.Point(0, 0);
            this.skinTreeView.Name = "skinTreeView";
            treeNode1.Name = "treeNode1";
            treeNode1.Tag = "-2";
            treeNode1.Text = "所有商品";
            this.skinTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.skinTreeView.Size = new System.Drawing.Size(152, 542);
            this.skinTreeView.TabIndex = 0;
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(12, 21);
            this.toolStripLabel3.Text = " ";
            // 
            // tsBtnDownAllSelect
            // 
            this.tsBtnDownAllSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnDownAllSelect.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDownAllSelect.Image")));
            this.tsBtnDownAllSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDownAllSelect.Name = "tsBtnDownAllSelect";
            this.tsBtnDownAllSelect.Size = new System.Drawing.Size(74, 21);
            this.tsBtnDownAllSelect.Text = "批量下架(&L)";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(12, 21);
            this.toolStripLabel2.Text = " ";
            // 
            // tsBtnUpAllSelect
            // 
            this.tsBtnUpAllSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnUpAllSelect.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnUpAllSelect.Image")));
            this.tsBtnUpAllSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnUpAllSelect.Name = "tsBtnUpAllSelect";
            this.tsBtnUpAllSelect.Size = new System.Drawing.Size(76, 21);
            this.tsBtnUpAllSelect.Text = "批量上架(&C)";
            // 
            // tsBtnDeleteAllSelect
            // 
            this.tsBtnDeleteAllSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnDeleteAllSelect.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDeleteAllSelect.Image")));
            this.tsBtnDeleteAllSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDeleteAllSelect.Name = "tsBtnDeleteAllSelect";
            this.tsBtnDeleteAllSelect.Size = new System.Drawing.Size(77, 21);
            this.tsBtnDeleteAllSelect.Text = "批量删除(&D)";
            this.tsBtnDeleteAllSelect.ToolTipText = "批量删除";
            // 
            // rslpsp2
            // 
            this.rslpsp2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.rslpsp2.Name = "rslpsp2";
            this.rslpsp2.Size = new System.Drawing.Size(24, 21);
            this.rslpsp2.Text = "    ";
            // 
            // tsBtnEdit
            // 
            this.tsBtnEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnEdit.Image")));
            this.tsBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEdit.Name = "tsBtnEdit";
            this.tsBtnEdit.Size = new System.Drawing.Size(75, 21);
            this.tsBtnEdit.Text = "编辑本页(&S)";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(12, 21);
            this.toolStripLabel5.Text = " ";
            // 
            // rslpsp1
            // 
            this.rslpsp1.Name = "rslpsp1";
            this.rslpsp1.Size = new System.Drawing.Size(24, 21);
            this.rslpsp1.Text = "    ";
            // 
            // ts
            // 
            this.ts.Arrow = System.Drawing.Color.White;
            this.ts.Back = System.Drawing.Color.White;
            this.ts.BackColor = System.Drawing.Color.Transparent;
            this.ts.BackgroundImage = global::TxoooProductUpload.UI.Properties.Resources.BaiduShurufa_2014_8_2_16_32_58;
            this.ts.BackRadius = 4;
            this.ts.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.ts.Base = System.Drawing.Color.Transparent;
            this.ts.BaseFore = System.Drawing.Color.Black;
            this.ts.BaseForeAnamorphosis = false;
            this.ts.BaseForeAnamorphosisBorder = 4;
            this.ts.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.ts.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.ts.BaseHoverFore = System.Drawing.Color.Black;
            this.ts.BaseItemAnamorphosis = true;
            this.ts.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.ts.BaseItemBorderShow = true;
            this.ts.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("ts.BaseItemDown")));
            this.ts.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ts.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("ts.BaseItemMouse")));
            this.ts.BaseItemNorml = ((System.Drawing.Image)(resources.GetObject("ts.BaseItemNorml")));
            this.ts.BaseItemPressed = System.Drawing.Color.Transparent;
            this.ts.BaseItemRadius = 2;
            this.ts.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.ts.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(128)))), ((int)(((byte)(134)))));
            this.ts.BindTabControl = null;
            this.ts.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.ts.Fore = System.Drawing.Color.Black;
            this.ts.GripMargin = new System.Windows.Forms.Padding(0);
            this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts.HoverFore = System.Drawing.Color.White;
            this.ts.ItemAnamorphosis = false;
            this.ts.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.ts.ItemBorderShow = false;
            this.ts.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.ts.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.ts.ItemRadius = 1;
            this.ts.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rslpsp1,
            this.toolStripLabel5,
            this.tsBtnEdit,
            this.rslpsp2,
            this.tsBtnDeleteAllSelect,
            this.toolStripLabel1,
            this.tsBtnUpAllSelect,
            this.toolStripLabel2,
            this.tsBtnDownAllSelect,
            this.toolStripLabel3,
            this.toolStripLabel4});
            this.ts.Location = new System.Drawing.Point(0, 0);
            this.ts.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.ts.Name = "ts";
            this.ts.Padding = new System.Windows.Forms.Padding(0, 3, 0, 4);
            this.ts.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.ts.Size = new System.Drawing.Size(992, 31);
            this.ts.SkinAllColor = true;
            this.ts.TabIndex = 129;
            this.ts.Text = "skinToolStrip3";
            this.ts.TitleAnamorphosis = false;
            this.ts.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.ts.TitleRadius = 4;
            this.ts.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(12, 21);
            this.toolStripLabel1.Text = " ";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(12, 21);
            this.toolStripLabel4.Text = " ";
            // 
            // productnameDataGridViewTextBoxColumn
            // 
            this.productnameDataGridViewTextBoxColumn.DataPropertyName = "product_name";
            this.productnameDataGridViewTextBoxColumn.HeaderText = "商品名称";
            this.productnameDataGridViewTextBoxColumn.Name = "productnameDataGridViewTextBoxColumn";
            this.productnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // producttypenameDataGridViewTextBoxColumn
            // 
            this.producttypenameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.producttypenameDataGridViewTextBoxColumn.DataPropertyName = "product_type_name";
            this.producttypenameDataGridViewTextBoxColumn.HeaderText = "所属分类";
            this.producttypenameDataGridViewTextBoxColumn.Name = "producttypenameDataGridViewTextBoxColumn";
            this.producttypenameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statenameDataGridViewTextBoxColumn
            // 
            this.statenameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.statenameDataGridViewTextBoxColumn.DataPropertyName = "state_name";
            this.statenameDataGridViewTextBoxColumn.HeaderText = "状态";
            this.statenameDataGridViewTextBoxColumn.Name = "statenameDataGridViewTextBoxColumn";
            this.statenameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "价格";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Width = 60;
            // 
            // OnColumn
            // 
            this.OnColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OnColumn.HeaderText = "上架";
            this.OnColumn.Name = "OnColumn";
            this.OnColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OnColumn.Text = "上架";
            this.OnColumn.UseColumnTextForLinkValue = true;
            this.OnColumn.Width = 60;
            // 
            // OffColumn
            // 
            this.OffColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OffColumn.HeaderText = "下架";
            this.OffColumn.Name = "OffColumn";
            this.OffColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OffColumn.Text = "下架";
            this.OffColumn.UseColumnTextForLinkValue = true;
            this.OffColumn.Width = 60;
            // 
            // EditColumn
            // 
            this.EditColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EditColumn.HeaderText = "编辑";
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EditColumn.Text = "编辑";
            this.EditColumn.UseColumnTextForLinkValue = true;
            this.EditColumn.Width = 60;
            // 
            // DeleteColumn
            // 
            this.DeleteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DeleteColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.DeleteColumn.HeaderText = "删除";
            this.DeleteColumn.Name = "DeleteColumn";
            this.DeleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DeleteColumn.Text = "删除";
            this.DeleteColumn.UseColumnTextForLinkValue = true;
            this.DeleteColumn.Width = 60;
            // 
            // loading
            // 
            this.loading.BackColor = System.Drawing.Color.White;
            this.loading.BorderColor = System.Drawing.Color.Transparent;
            this.loading.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.loading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loading.Image = global::TxoooProductUpload.UI.Properties.Resources.Rainbow;
            this.loading.Location = new System.Drawing.Point(0, 31);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(992, 542);
            this.loading.TabIndex = 138;
            this.loading.Text = "loading";
            // 
            // ProductManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 573);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ts);
            this.Name = "ProductManageForm";
            this.Text = "商品管理";
            ((System.ComponentModel.ISupportInitialize)(this.ProductBindSource)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductDGV)).EndInit();
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected internal System.Windows.Forms.BindingSource ProductBindSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton tsBtnDownAllSelect;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton tsBtnUpAllSelect;
        private System.Windows.Forms.ToolStripButton tsBtnDeleteAllSelect;
        private System.Windows.Forms.ToolStripLabel rslpsp2;
        protected internal System.Windows.Forms.ToolStripButton tsBtnEdit;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripLabel rslpsp1;
        private CCWin.SkinControl.SkinToolStrip ts;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private CCWin.SkinControl.SkinTreeView skinTreeView;
        private CCWin.SkinControl.SkinDataGridView ProductDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn productnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn producttypenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn OnColumn;
        private System.Windows.Forms.DataGridViewLinkColumn OffColumn;
        private System.Windows.Forms.DataGridViewLinkColumn EditColumn;
        private System.Windows.Forms.DataGridViewLinkColumn DeleteColumn;
        private CCWin.SkinControl.GifBox loading;
    }
}
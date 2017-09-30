using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.UI.Common.Extended.Winform;
using CCWin;
using TxoooProductUpload.UI.Common.Const;
using TxoooProductUpload.UI.Common;
using TxoooProductUpload.Entities.Product;
using System.Threading;
using TxoooProductUpload.UI.Service.Cache.ProductCache;
using TxoooProductUpload.UI.Forms.SubForms;

namespace TxoooProductUpload.UI.Forms.UserControls
{
    public partial class ProcessProductResult : UserControl
    {

        #region 属性
        /// <summary>
        /// 商品缓存
        /// </summary>
        public ProductCacheData ProductCache { set; get; }
        #endregion

        public ProcessProductResult()
        {
            InitializeComponent();
            ProductCache = ProductCacheContext.Instance.Data;
            Load += ProcessProductResult_Load;
        }

        void ProcessProductResult_Load(object sender, EventArgs e)
        {
            ProductDGV.DataError += (_s, _e) => { };  //重写DataError事件
            InitDgvAllSelect(); //全选相关
            InitTsBtnEvent();  //批量操作相关
            InitContextMenuEvent();  //右键菜单相关
            //ProductBindSource.DataSource
        }



        #region 右键菜单相关
        void InitContextMenuEvent()
        {
            toolStripMenuItem1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem2.Click += ToolStripMenuItem_Click;
            toolStripMenuItem3.Click += ToolStripMenuItem_Click;
            toolStripMenuItem4.Click += ToolStripMenuItem_Click;
            toolStripMenuItem5.Click += ToolStripMenuItem_Click;
            toolStripMenuItem6.Click += ToolStripMenuItem_Click;
        }

        void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProductDGV.SelectedRows.Count == 1)
            {
                var row = ProductDGV.SelectedRows[0];
                var list = new List<DataGridViewRow>();
                list.Add(row);
                switch ((sender as ToolStripMenuItem).Tag.ToString())
                {
                    case "1":  //查看pc
                        Utils.OpenUrl(ProductDGV.SelectedRows[0].Cells["UrlColumn"].Value.ToString());
                        break;
                    case "2":  //查看手机
                        Utils.OpenUrl(ProductDGV.SelectedRows[0].Cells["H5UrlColumn"].Value.ToString(), true);
                        break;
                    case "3":  //编辑
                        var id = Convert.ToInt64(ProductDGV.SelectedRows[0].Cells["idDataGridViewTextBoxColumn"].Value.ToString());
                        var prodcutList = ProductCache.WaitUploadImageList.Where(m => m.Id == id);
                        new ProductEditForm(prodcutList).ShowDialog(this);
                        break;
                    case "4":  //删除
                        ProductDGV.Rows.Remove(row);
                        break;
                    case "5":  //更改分类
                        SetClassAllSelectRows(list);
                        break;
                    case "6":  //更改发货地
                        SetLocationAllSelectRows(list);
                        break;
                }
            }
        }
        #endregion

        #region 批量操作相关
        /// <summary>
        /// 批量操作相关初始化
        /// </summary>
        void InitTsBtnEvent()
        {
            tsBtnSetClassAllSelect.Click += TsBtnAllSelect_Click;
            tsBtnDeleteAllSelect.Click += TsBtnAllSelect_Click;
            tsBtnSetLocationAllSelect.Click += TsBtnAllSelect_Click;
            tsBtnUploadImageAllSelect.Click += TsBtnAllSelect_Click;
            tsBtnUpload.Click += TsBtnAllSelect_Click;
            tsBtnEditAllSelect.Click += TsBtnAllSelect_Click;
        }

        /// <summary>
        /// 批量操作事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TsBtnAllSelect_Click(object sender, EventArgs e)
        {
            ToolStripButton current = sender as ToolStripButton;
            switch (current.Name.ToString())
            {
                case "tsBtnSetClassAllSelect":
                    SetClassAllSelectRows(GetSelectRow());
                    break;
                case "tsBtnDeleteAllSelect":
                    DeleteAllSelectRows(GetSelectRow());
                    break;
                case "tsBtnSetLocationAllSelect":
                    SetLocationAllSelectRows(GetSelectRow());
                    break;
                case "tsBtnUploadImageAllSelect":  //转换图片
                    UploadProductImage();
                    break;
                case "tsBtnUpload":  //上传商品
                    UploadProduct();
                    break;
                case "tsBtnEditAllSelect":  //审核
                    EditAllSelectProduct();
                    break;
            }
        }

        /// <summary>
        /// 编辑商品
        /// </summary>
        void EditAllSelectProduct()
        {
            tsBtnUploadImageAllSelect.Enabled = true;
            new ProductEditForm(ProductCache.WaitUploadImageList).ShowDialog(this);
        }

        /// <summary>
        /// 上传商品
        /// </summary>
        void UploadProduct()
        {
            tsBtnUpload.Enabled = false;
            var allCount = ProductCache.WaitUploadList.Count;
            if (allCount < 1)
            {
                MessageBoxEx.Show("没有可以上传的商品.");
                return;
            }
            var loadForm = new ProductUploadLoading("正在上传商品...", 1);
            if (loadForm.ShowDialog(this) == DialogResult.OK)
            {
                ProductBindSource.DataSource = null;
                //上传失败的继续上传
                ProductCache.WaitUploadList.AddRange(ProductCache.UploadFailList);
                ProductCache.UploadFailList.Clear();
                ProductBindSource.DataSource = ProductCache.WaitUploadList;
                MessageBoxEx.Show("本次上传商品{1}个{0},成功{2}个{0},失败{3}个.".
                    FormatWith("", allCount, ProductCache.UploadSuccessList.Count,
                    ProductCache.UploadFailList.Count));
            }
        }

        /// <summary>
        /// 批量上传商品图片
        /// </summary>
        void UploadProductImage()
        {
            tsBtnUploadImageAllSelect.Enabled = false;
            tsBtnUpload.Enabled = true;
            var allCount = ProductCache.WaitUploadImageList.Count;
            var loadForm = new ProductUploadLoading("正在上传图片，请稍等...", 0);
            if (loadForm.ShowDialog(this) == DialogResult.OK)
            {
                ProductBindSource.DataSource = null;
                ProductBindSource.DataSource = ProductCache.WaitUploadList;
                ProductCache.WaitUploadImageList.Clear();
                MessageShowLable.Text = "本次共处理{0}个商品，处理成功{1}个商品，已更新"
                    .FormatWith(allCount, ProductCache.WaitUploadList.Count);
                tsBtnUpload.Enabled = true;
            }
        }
        /// <summary>
        /// 批量设置选中行的发货地
        /// </summary>
        void SetLocationAllSelectRows(List<DataGridViewRow> rows)
        {
            if (rows != null)
            {
                ChangeLocationForm cangeLocationForm = new ChangeLocationForm();

                cangeLocationForm.OnChangeLocation += (s, eventArgs) =>
                {
                    foreach (var row in rows)
                    {
                        row.Cells["RegionCodeColumn"].Value = eventArgs.RegionCode;
                        row.Cells["RegionNameColumn"].Value = eventArgs.RegionName;
                    }
                };
                cangeLocationForm.ShowDialog(this);
            }
        }
        /// <summary>
        /// 批量设置选中行的分类
        /// </summary>
        void SetClassAllSelectRows(List<DataGridViewRow> rows)
        {
            if (rows != null)
            {
                ChangeClassForm changeClassForm = new ChangeClassForm();

                changeClassForm.OnChangeClass += (s, eventArgs) =>
                {
                    //MessageBoxEx.Show("修改为了" + eventArgs.ClassId);
                    foreach (var row in rows)
                    {
                        row.Cells["ClassTypeColumn"].Value = eventArgs.TypeService;
                        row.Cells["SettlementRatioColumn"].Value = eventArgs.Proportion;
                        row.Cells["PremiumRatioColumn"].Value = eventArgs.Proportion;
                        row.Cells["ClassIdColumn"].Value = eventArgs.ClassId;
                        row.Cells["ClassNameColumn"].Value = eventArgs.ClassNameShow;
                    }
                    tsBtnEditAllSelect.Enabled = true;
                };
                changeClassForm.ShowDialog(this);
            }
        }

        /// <summary>
        /// 删除选中行
        /// </summary>
        void DeleteAllSelectRows(List<DataGridViewRow> rows)
        {
            if (rows != null)
            {
                foreach (var item in rows)
                {
                    ProductDGV.Rows.Remove(item);
                }
            }
        }

        /// <summary>
        /// 获取选中的行 无选中返回null
        /// </summary>
        /// <returns></returns>
        List<DataGridViewRow> GetSelectRow()
        {
            ProductDGV.EndEdit();
            var selRows = ProductDGV.Rows.OfType<DataGridViewRow>().Where(m => m.Cells[0].Value != null && m.Cells[0].Value.ToString() == "True").ToList();
            if (selRows.Count == 0)
            {
                MessageBoxEx.Show("请选中要操作的商品", AppInfo.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return selRows;
        }
        #endregion

        #region DataGridView全选
        /// <summary>
        /// DataGridView全选初始化
        /// </summary>
        void InitDgvAllSelect()
        {
            DataGridViewCheckBoxColumn colCB = new DataGridViewCheckBoxColumn();
            DataGridViewCheckBoxHeaderCell cbHeader = new DataGridViewCheckBoxHeaderCell();
            colCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colCB.Selected = false;
            colCB.HeaderText = "全选";
            colCB.Width = 30;
            colCB.HeaderCell = cbHeader;
            ProductDGV.Columns.Insert(0, colCB);
            cbHeader.OnCheckBoxClicked += CbHeader_OnCheckBoxClicked;
        }

        void CbHeader_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {
            ProductDGV.EndEdit();
            ProductDGV.Rows.OfType<DataGridViewRow>().ToList().ForEach(t => t.Cells[0].Value = e.CheckedState);
        }
        #endregion
    }
}

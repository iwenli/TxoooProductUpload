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

namespace TxoooProductUpload.UI.Forms.UserControls
{
    public partial class ProcessProductResult : UserControl
    {
        public ProcessProductResult()
        {
            InitializeComponent();

            Load += ProcessProductResult_Load;
        }

        void ProcessProductResult_Load(object sender, EventArgs e)
        {
            InitDgvAllSelect(); //全选相关
            InitTsBtnEvent();  //批量操作相关
            InitContextMenuEvent();  //右键菜单相关
            //ProductBindSource.DataSource
        }

        void UploadProductImage()
        {
            Task.Run(async () =>
            {
                var list = ProductBindSource.DataSource as List<ProductSourceInfo>;
                var uploadEndList = await App.Context.ProductService.UploadProductImageSync(list);
                await Task.Run(() =>
                {
                    Invoke(new Action(() =>
                    {
                        ProductBindSource.DataSource = uploadEndList;
                    }));
                });

            });
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
                        MessageBoxEx.Show("暂不支持编辑商品");
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

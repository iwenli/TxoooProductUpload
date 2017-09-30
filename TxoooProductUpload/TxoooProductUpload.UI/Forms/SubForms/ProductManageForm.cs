using CCWin;
using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.Entities.Resporse.Txooo;
using TxoooProductUpload.UI.Common.Const;
using TxoooProductUpload.UI.Common.Extended.Winform;
using Iwenli;

namespace TxoooProductUpload.UI.Forms.SubForms
{
    public partial class ProductManageForm : Form
    {
        /// <summary>
        /// 商品各状态数量
        /// </summary>
        List<ProductStateInfo> ProductStateCache = new List<ProductStateInfo>();
        /// <summary>
        /// 本店铺商品缓存
        /// </summary>
        List<ManageProductInfo> ProductCache = new List<ManageProductInfo>();
        int _allProductCount = 0;

        public ProductManageForm()
        {
            InitializeComponent();
            Load += ProductManageForm_Load;
        }
        async void ProductManageForm_Load(object sender, EventArgs e)
        {
            Init();
            ProductDGV.DataError += (_s, _e) => { };  //重写DataError事件
            InitDgvAllSelect(); //全选相关
            BindEvent();
        }

        void BindEvent()
        {
            skinTreeView.AfterSelect += SkinTreeView_AfterSelect;
            tsBtnDeleteAllSelect.Click += Button_Click;
            tsBtnUpAllSelect.Click += Button_Click;
            tsBtnDownAllSelect.Click += Button_Click;
            tsBtnEdit.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var currentBtn = sender as ToolStripButton;
            switch (currentBtn.Name)
            {
                case "tsBtnDeleteAllSelect":
                    DeleteAllSelectRows(GetSelectRow());
                    break;
                case "tsBtnUpAllSelect":
                    UpAndDownAllSelectRows(GetSelectRow(), true);
                    break;
                case "tsBtnDownAllSelect":
                    UpAndDownAllSelectRows(GetSelectRow(), false);
                    break;
                case "tsBtnEdit":
                    break;
            }
        }

        /// <summary>
        /// 上下架商品
        /// </summary>
        void UpAndDownAllSelectRows(List<DataGridViewRow> rows, bool isShow)
        {
            if (rows != null)
            {
                List<long> productIds = new List<long>();
                foreach (var item in rows)
                {
                    var product = item.DataBoundItem as ManageProductInfo;
                    if (product != null)
                    {
                        productIds.Add(product.product_id);
                    }
                }
                try
                {
                    if (App.Context.BaseContent.ProductService.UpProducts(productIds, isShow))
                    {
                        MessageBoxEx.Show("{0}成功".FormatWith(isShow ? "上架" : "下架"));
                        Init();
                    }
                    else
                    {
                        MessageBoxEx.Show("{0}失败".FormatWith(isShow ? "上架" : "下架"));
                    }
                }
                catch (Exception ex)
                {
                    this.LogError("{0}商品异常：{1}".FormatWith(isShow ? "上架" : "下架", ex.Message), ex);
                }
            }
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        void DeleteAllSelectRows(List<DataGridViewRow> rows)
        {
            if (rows != null)
            {
                foreach (var item in rows)
                {
                    var product = item.DataBoundItem as ManageProductInfo;
                    try
                    {
                        if (App.Context.BaseContent.ProductService.DelProduct(product.product_id))
                        {
                            ProductDGV.Rows.Remove(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        this.LogError("删除商品异常：" + ex.Message, ex);
                    }
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

        /// <summary>
        /// 变更节点 商品状态分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SkinTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var tag = Convert.ToInt32(e.Node.Tag);
            switch (tag)
            {
                case -2:  //所有
                    tsBtnDownAllSelect.Enabled = tsBtnUpAllSelect.Enabled = true;
                    break;
                case -1:
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    tsBtnDownAllSelect.Enabled = tsBtnUpAllSelect.Enabled = false;
                    break;
                case 5: //售卖中
                    tsBtnDownAllSelect.Enabled = true;
                    tsBtnUpAllSelect.Enabled = false;
                    break;
                case 6:  //等待上架
                    tsBtnDownAllSelect.Enabled = false;
                    tsBtnUpAllSelect.Enabled = true;
                    break;
            }
            ProductBindSource.DataSource = null;
            if (tag == -2)
            {
                ProductBindSource.DataSource = ProductCache;
            }
            else
            {
                var list = ProductCache.Where(m => m.pro_state == tag).ToList();
                if (list != null && list.Count > 0)
                {
                    ProductBindSource.DataSource = ProductCache.Where(m => m.pro_state == tag);
                }
            }
        }

        /// <summary>
        /// 更新页面状态
        /// </summary>
        public void Init()
        {
            InitProductState();
        }

        async void InitProductState()
        {
            loading.Visible = true;
            try
            {
                ProductStateCache = await App.Context.BaseContent.ProductService.GetProductStateCountAsync();
                await Task.Delay(1000);
                _allProductCount = ProductStateCache.Select(m => m.pro_count).Sum();
                ProductCache = await App.Context.BaseContent.ProductService.GetProductListForCrawl(0, _allProductCount);
                await Task.Delay(1000);
                //_allProductCount = 100;
                skinTreeView.Nodes[0].Text = "全部商品({0})".FormatWith(_allProductCount);
                skinTreeView.Nodes[0].Nodes.Clear();
                foreach (var state in ProductStateCache)
                {
                    if (state.pro_count > 0)
                    {
                        TreeNode tn = new TreeNode();
                        tn.Tag = state.alias_name;
                        tn.Text = state.class_name + "({0})".FormatWith(state.pro_count);
                        skinTreeView.Nodes[0].Nodes.Insert(0, tn);
                    }
                }
                skinTreeView.SelectedNode = skinTreeView.Nodes[0];  //选中根节点

                ProductBindSource.DataSource = null;
                ProductBindSource.DataSource = ProductCache;
            }
            catch (Exception ex)
            {
                this.LogError("获取商品列表异常：" + ex.Message, ex);
            }
            loading.Visible = false;
        }

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

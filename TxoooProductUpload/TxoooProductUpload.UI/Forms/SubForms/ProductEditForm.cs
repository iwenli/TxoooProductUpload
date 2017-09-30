using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.Entities.Product;
using TxoooProductUpload.UI.Common.Const;
using TxoooProductUpload.UI.Service.Cache.ProductCache;

namespace TxoooProductUpload.UI.Forms.SubForms
{
    public partial class ProductEditForm : BaseForm
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        #region 属性
        /// <summary>
        /// 待审核商品
        /// </summary>
        public IEnumerable<ProductSourceInfo> ProductList { set; get; }
        #endregion

        public ProductEditForm(IEnumerable<ProductSourceInfo> list)
        {
            InitializeComponent();
            ProductList = list;
            SendMessage(lvThumImages.Handle, 0x1035, 0, 0x10000 * 10 + 10);
            Load += ProductEditForm_Load;
        }

        private void ProductEditForm_Load(object sender, EventArgs e)
        {
            InitSkinTreeView();
            skinTreeView.AfterSelect += SkinTreeView_AfterSelect;

        }
        /// <summary>
        /// 变更节点 商品状态分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SkinTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var tag = Convert.ToInt64(e.Node.Tag);
            BindProductInfo(ProductList.FirstOrDefault(m => m.Id == tag));
        }

        /// <summary>
        /// 绑定信息
        /// </summary>
        /// <param name="product"></param>
        void BindProductInfo(ProductSourceInfo product)
        {
            //绑定详情信息
            StringBuilder html = new StringBuilder();
            foreach (var url in product.DetailImgList)
            {
                html.AppendFormat(CommonString.DetialFormat, string.Empty, url);
            }
            this.htmlEditor1.BodyInnerHTML = html.ToString();

            //绑定主图信息
            //刷新Listview
            imageList1.Images.Clear();
            lvThumImages.Items.Clear();
            int i = 0;
            foreach (var url in product.ThumImgList)
            {
                imageList1.Images.Add(url, App.Context.BaseContent.ImageService.GetImageByUrl(url));
                lvThumImages.Items.Add(url, "", i++);
            }
            skinTabControl1.SelectedIndex = 0;
        }

        /// <summary>
        /// 初始化SkinTreeView
        /// </summary>
        void InitSkinTreeView()
        {
            skinTreeView.Nodes.Clear();
            foreach (var product in ProductList)
            {
                if (product.Id > 0)
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = product.Id;
                    tn.Text = product.ProductName;
                    skinTreeView.Nodes.Insert(0, tn);
                }
            }
            skinTreeView.SelectedNode = skinTreeView.Nodes[0];  //选中根节点
        }
    }
}

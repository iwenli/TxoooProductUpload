using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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
        /// 当前编辑商品
        /// </summary>
        public ProductSourceInfo CurrentProductSourceInfo { set; get; }
        /// <summary>
        /// 待审核商品
        /// </summary>
        public IEnumerable<ProductSourceInfo> ProductList { set; get; }
        #endregion

        public ProductEditForm(IEnumerable<ProductSourceInfo> list)
        {
            InitializeComponent();
            ProductList = list;
            SendMessage(lvThumImages.Handle, 0x1035, 0, 0x10000 * 110 + 130);
            Load += ProductEditForm_Load;
        }

        void ProductEditForm_Load(object sender, EventArgs e)
        {
            InitSkinTreeView();
            skinTreeView.AfterSelect += SkinTreeView_AfterSelect;
            tsBtnSaveAndNext.Click += TsBtnSaveAndNext_Click;
            tsBtnSave.Click += TsBtnSaveAndNext_Click;
            //删除商品按钮事件
            tsBtnDelete.Click += (_s, _e) =>
            {
                if (CurrentProductSourceInfo != null)
                {
                    (ProductList as List<ProductSourceInfo>).Remove(CurrentProductSourceInfo);
                    TreeNode node = skinTreeView.SelectedNode;     //获得选中节点的值
                    var nextNode = node.NextVisibleNode;
                    skinTreeView.SelectedNode = nextNode;
                    skinTreeView.Nodes.Remove(node);
                }
            };

            //删除评价图片菜单
            lvThumImages.MouseClick += (_s, _e) =>
            {
                if (_e.Button == MouseButtons.Right && this.lvThumImages.SelectedItems.Count == 1)
                {
                    ListViewItem xy = lvThumImages.GetItemAt(_e.X, _e.Y);
                    if (xy != null)
                    {
                        Point point = this.PointToClient(lvThumImages.PointToScreen(new Point(_e.X, _e.Y)));
                        this.cmsThumImage.Show(this, point);
                    }
                }
            };
            //删除图片事件
            tsmiDeleteImage.Click += (_s, _e) =>
            {
                CurrentProductSourceInfo.ThumImgList.Remove(lvThumImages.SelectedItems[0].Name);
                lvThumImages.RemoveSelectedItems();
            };
            // 查看大图
            tsmiShowImage.Click += (_s, _e) =>
            {

                //new OriginalImage(lvThumImages.SelectedItems[0].Name).ShowDialog(this);
                new OriginalImage(CurrentProductSourceInfo.ThumImgList, lvThumImages.SelectedItems[0].Index).ShowDialog(this);
            };
            //上传图片辅助工具
            tsBtnOpenUploadFile.Click += (_s, _e) =>
            {
                System.Diagnostics.Process.Start("上传文件.exe");
            };
            // 查看大图
            lvThumImages.DoubleClick += (_s, _e) =>
            {
                new OriginalImage(CurrentProductSourceInfo.ThumImgList, 0).ShowDialog(this);
            };
        }

        #region 全局键盘
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (lvThumImages.SelectedItems.Count > 0)
            {
                //MessageBox.Show(keyData.ToString());
                switch (keyData)
                {
                    case Keys.Back:
                    case Keys.Delete:
                        CurrentProductSourceInfo.ThumImgList.Remove(lvThumImages.SelectedItems[0].Name);
                        lvThumImages.RemoveSelectedItems();
                        break;
                        //case Keys.Enter:
                        //    break;
                }
            }
            return false;
        }
        #endregion

        /// <summary>
        /// 保存和保存并变价下一个事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TsBtnSaveAndNext_Click(object sender, EventArgs e)
        {
            var currentBtn = sender as ToolStripButton;
            SaveProduct();
            if (currentBtn.Name == "tsBtnSaveAndNext")
            {
                TreeNode node = skinTreeView.SelectedNode;     //获得选中节点的值
                var nextNode = node.NextVisibleNode;
                if (nextNode == null)
                {
                    MessageBoxEx.Show("当前商品已经是最后一个.");
                    return;
                }
                skinTreeView.SelectedNode = nextNode;
            }
        }

        /// <summary>
        /// 保存商品信息
        /// </summary>
        void SaveProduct()
        {
            Regex reg = new Regex(@"src=""([\s\S]+)""", RegexOptions.Multiline);
            var matches = reg.Matches(htmlEditorDetail.BodyHtml);
            //查出所有姑娘的地址，然后与已下载和已入列的对比，排除重复后将其加入下载队列
            var images = Regex.Matches(htmlEditorDetail.BodyHtml, @"src=""([\s\S]+?)""", RegexOptions.IgnoreCase | RegexOptions.Singleline)
                                .Cast<Match>().Select(s => s.Groups[1].Value).ToArray();
            CurrentProductSourceInfo.DetailImgList.Clear();
            CurrentProductSourceInfo.DetailImgList.AddRange(images);
            //htmlEditorDetail.BodyHtml
        }



        /// <summary>
        /// 变更节点 商品状态分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SkinTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var tag = Convert.ToInt64(e.Node.Tag);
            NextInit(tag);
        }

        /// <summary>
        /// 绑定信息
        /// </summary>
        void BindProductInfo()
        {
            tsBtnSave.Enabled = tsBtnSaveAndNext.Enabled = skinTreeView.Enabled = false;
            //绑定详情信息
            StringBuilder html = new StringBuilder();
            foreach (var url in CurrentProductSourceInfo.DetailImgList)
            {
                html.AppendFormat(CommonString.DetialFormat, string.Empty, url);
            }
            this.htmlEditorDetail.BodyInnerHTML = html.ToString();

            //绑定主图信息
            //刷新Listview
            imageList1.Images.Clear();
            lvThumImages.Items.Clear();
            int i = 0;
            foreach (var url in CurrentProductSourceInfo.ThumImgList)
            {
                imageList1.Images.Add(url, App.Context.BaseContent.ImageService.GetImageByUrl(url));
                lvThumImages.Items.Add(url, "", i++);
            }
            skinTabControl1.SelectedIndex = 0;

            //绑定其他信息
            txtPName.Text = CurrentProductSourceInfo.ProductName;
            txtPLoacation.Text = CurrentProductSourceInfo.RegionName;
            txtPClass.Text = CurrentProductSourceInfo.ClassNameShow;
            txtPrice.Value = (decimal)CurrentProductSourceInfo.ShowPrice;
            tbBrand.Text = CurrentProductSourceInfo.Brand;

            if (CurrentProductSourceInfo.IsNew)
            {
                rbTypeNew.Checked = true;
            }
            else
            {
                rbTypeOld.Checked = true;
            }
            if (CurrentProductSourceInfo.IsVirtual)
            {
                rbVirtualTrue.Checked = true;
            }
            else
            {
                rbVirtualFalse.Checked = true;
            }
            if (CurrentProductSourceInfo.IsFreePostage)
            {
                rbPostageTrue.Checked = true;
                tbPostage.Value = tbLinit.Value = tbappend.Value = 0;
                gbPostage.Enabled = false;
            }
            else
            {
                rbPostageFalse.Checked = true;
                tbPostage.Value = (decimal)CurrentProductSourceInfo.Postage;
                tbLinit.Value = CurrentProductSourceInfo.Limit;
                tbappend.Value = (decimal)CurrentProductSourceInfo.Append;
                gbPostage.Enabled = true;
            }
            if (CurrentProductSourceInfo.IsRefund)
            {
                rbRefundTrue.Checked = true;
            }
            else
            {
                rbRefundFalse.Checked = true;
            }
            tsBtnSave.Enabled = tsBtnSaveAndNext.Enabled = skinTreeView.Enabled = true;
            GC.Collect();
            //Task.Run(() =>
            //{
            //    Invoke(new Action(() =>
            //    {

            //    }));
            //});
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
                    skinTreeView.Nodes.Add(tn);//.Insert(0, tn);
                }
            }
            if (ProductList.LastOrDefault() != null)
            {
                skinTreeView.SelectedNode = skinTreeView.Nodes[0];  //选中根节点
                NextInit(ProductList.LastOrDefault().Id);
            }
        }

        /// <summary>
        /// 绑定下一个商品
        /// </summary>
        /// <param name="id"></param>
        void NextInit(long id)
        {
            CurrentProductSourceInfo = ProductList.FirstOrDefault(m => m.Id == id);
            BindProductInfo();
        }
    }
}

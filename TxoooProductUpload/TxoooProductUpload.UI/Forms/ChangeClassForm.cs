using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FSLib.Data;
using CCWin;
using CCWin.SkinControl;
using TxoooProductUpload.Service.Entities;

namespace TxoooProductUpload.UI.Forms
{
    public partial class ChangeClassForm : BaseForm
    {
        #region 变量
        int _typeService = 1;  //产品分类类型
        long _classId = 0;  //分类id
        int _proportion = 0; //返现比例 
        string _classNameShow = string.Empty;
        IEnumerable<ProductClassInfo> _searchResultList;
        int _searchIndex = 0;
        #endregion

        /// <summary>
        /// 修改分类类型时 发生
        /// </summary>
        public event EventHandler<ChangeClassEventArgs> OnChangeClass;

        /// <summary>
        /// 引发 <see cref="OnChangeClass" /> 事件
        /// </summary>
        protected virtual void ChangeClass(ChangeClassEventArgs args)
        {
            OnChangeClass?.Invoke(this, args);
        }

        public ChangeClassForm()
        {
            InitializeComponent();
            Load += ChangeClassForm_Load;
        }

        void ChangeClassForm_Load(object sender, EventArgs e)
        {
            lbClass1.ItemHeight = lbClass2.ItemHeight = lbClass3.ItemHeight = lbClass4.ItemHeight = 16;
            lbClass1.DrawItem += ListBox_DrawItem;
            lbClass2.DrawItem += ListBox_DrawItem;
            lbClass3.DrawItem += ListBox_DrawItem;
            lbClass4.DrawItem += ListBox_DrawItem;

            InitClassListBoxEvent();
            txtSearch.TextChanged += TxtSearch_TextChanged;
            btnSearch.Click += Btn_Click;
            btnNext.Click += Btn_Click;
            btnPrev.Click += Btn_Click;
            txtSearch.KeyUp += TxtSearch_KeyUp;

            btnOk.Click += BtnOkOrCancel_Click;
            btnCancel.Click += BtnOkOrCancel_Click;
        }

        /// <summary>
        /// 重绘ComboBox项间距
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            var obj = sender as ListBox;
            if (e.Index < 0)
            {
                return;
            }
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(obj.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.X, e.Bounds.Y + 3);
        }

        void BtnOkOrCancel_Click(object sender, EventArgs e)
        {
            var currentBtn = sender as SkinButton;
            switch (currentBtn.Name)
            {
                case "btnOk":
                    DialogResult = DialogResult.Yes;
                    ChangeClass(new ChangeClassEventArgs(_classId, _typeService, _proportion, _classNameShow));
                    break;
                case "btnCancel":
                    break;
            }
            this.Close();
        }

        #region 查询分类相关
        void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                SearchClass();
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var currentObj = sender as SkinButton;
            switch (currentObj.Name)
            {
                case "btnSearch":
                    SearchClass();
                    break;
                case "btnNext":
                    if (_searchIndex < _searchResultList.Count() - 1)
                    {
                        _searchIndex++;
                        PositionItem(_searchResultList.ElementAt(_searchIndex));
                    }
                    break;
                case "btnPrev":
                    if (_searchIndex > 0)
                    {
                        _searchIndex--;
                        PositionItem(_searchResultList.ElementAt(_searchIndex));
                    }
                    break;
            }
            if (_searchResultList == null || _searchResultList.Count() == 0)
            {
                btnNext.Enabled = btnPrev.Enabled = false;
                return;
            }
            else
            {
                btnPrev.Enabled = btnNext.Enabled = true;
                if (_searchIndex == 0 && _searchResultList.Count() > 1)
                {
                    btnNext.Enabled = true;
                    btnPrev.Enabled = false;
                }
                if (_searchIndex == _searchResultList.Count() - 1 && _searchResultList.Count() > 1)
                {
                    btnNext.Enabled = false;
                    btnPrev.Enabled = true;
                }
            }
        }

        void SearchClass()
        {
            _searchResultList = App.Context.BaseContent.CacheContext.Data.ProductClassList.Where(m => m.ClassName.IndexOf(txtSearch.Text) > -1);
            _searchIndex = 0;

            if (_searchResultList == null || _searchResultList.Count() == 0)
            {
                MessageBoxEx.Show("没有类目[{0}]".FormatWith(txtSearch.Text));
            }
            else
            {
                PositionItem(_searchResultList.ElementAt(_searchIndex));
            }
        }

        void PositionItem(ProductClassInfo classObj)
        {
            if (classObj != null)
            {
                //先找顶级  parentId= 1 || 3439
                //1级是固定的  所以不动  只会搜索出来2级 和 3级
                if (App.Context.BaseContent.CacheContext.Data.ProductClassList.Where(m => m.ParentId == classObj.ClassId).ToList().Count > 0)
                {  //2级
                    lbClass1.SelectedItem = App.Context.BaseContent.ClassDataService.RootClassList.FirstOrDefault(m => m.ClassId == classObj.ParentId);
                    lbClass2.SelectedItem = classObj;
                }
                else
                {
                    //3级
                    //先找一个2级的
                    var class2Obj = App.Context.BaseContent.CacheContext.Data
                       .ProductClassList.FirstOrDefault(m => m.ClassId == classObj.ParentId);
                    lbClass1.SelectedItem = App.Context.BaseContent.ClassDataService.RootClassList.FirstOrDefault(m => m.ClassId == class2Obj.ParentId);
                    lbClass2.SelectedItem = class2Obj;
                    lbClass3.SelectedItem = classObj;
                }
            }
        }

        void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = txtSearch.TextLength != 0;
        }

        #endregion

        #region ListBox级联事件
        void InitClassListBoxEvent()
        {
            lbClass1.SelectedIndexChanged += Class_SelectedIndexChanged;
            lbClass2.SelectedIndexChanged += Class_SelectedIndexChanged;
            lbClass3.SelectedIndexChanged += Class_SelectedIndexChanged;
            lbClass4.SelectedIndexChanged += Class_SelectedIndexChanged;

            lbClass1.ValueMember = lbClass2.ValueMember = lbClass3.ValueMember = "ClassId";
            lbClass1.DisplayMember = lbClass2.DisplayMember = lbClass3.DisplayMember = "ClassName";
            lbClass1.DataSource = App.Context.BaseContent.ClassDataService.RootClassList;
        }

        void Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentItem = sender as ListBox;
            var value = Convert.ToInt32(currentItem.SelectedValue.ToString());
            if (currentItem.Name == "lbClass1")
            {
                _typeService = value == 1 ? 1 : 2;
                lbClass2.DataSource = App.Context.BaseContent.CacheContext.Data.ProductClassList.Where(m => m.ParentId == value).ToList();
            }
            else if (currentItem.Name == "lbClass2")
            {
                lbClass3.DataSource = App.Context.BaseContent.CacheContext.Data.ProductClassList.Where(m => m.ParentId == value).ToList();
            }
            else if (currentItem.Name == "lbClass3")
            {
                lbClass4.DataSource = App.Context.BaseContent.CacheContext.Data.ProductClassList.FirstOrDefault(m => m.ClassId == value).RadioNums;
                _classId = value;
            }
            _proportion = Convert.ToInt32(lbClass4.SelectedValue ?? "0");
            _classNameShow = "{0} >> {1}".FormatWith(lbClass2.SelectedItem, lbClass3.SelectedItem);
            lblClass.Text = "{0} >> {1} >> {2} - 返现比例[{3}%]".FormatWith(
                lbClass1.SelectedItem, lbClass2.SelectedItem,
                lbClass3.SelectedItem, _proportion);
        }
        #endregion
    }

    /// <summary>
    /// 分类修改事件数据
    /// </summary>
    public class ChangeClassEventArgs : EventArgs
    {
        /// <summary>
        /// 产品分类类型
        /// </summary>
        public int TypeService { set; get; }
        /// <summary>
        /// 分类id
        /// </summary>
        public long ClassId { set; get; }
        /// <summary>
        /// 返现比例
        /// </summary>
        public double Proportion { set; get; }

        public string ClassNameShow { set; get; }

        /// <summary>
        /// 初始化一个 ChangeClassEventArgs 实例
        /// </summary>
        public ChangeClassEventArgs() { }
        /// <summary>
        ///  初始化一个 ChangeClassEventArgs 实例
        /// </summary>
        /// <param name="id">分类id</param>
        /// <param name="type">产品分类类型</param>
        /// <param name="propor">返现比例</param>
        public ChangeClassEventArgs(long id, int type, int propor)
        {
            ClassId = id;
            TypeService = type;
            Proportion = propor / 100.00;
        }

        /// <summary>
        ///  初始化一个 ChangeClassEventArgs 实例
        /// </summary>
        /// <param name="id">分类id</param>
        /// <param name="type">产品分类类型</param>
        /// <param name="propor">返现比例</param>
        /// <param name="classNameShow">显示的类目 子类目>父类 格式</param>
        public ChangeClassEventArgs(long id, int type, int propor, string classNameShow) :
            this(id, type, propor)
        {
            ClassNameShow = classNameShow;
        }
    }
}

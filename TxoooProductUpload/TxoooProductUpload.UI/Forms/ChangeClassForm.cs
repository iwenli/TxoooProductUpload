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

namespace TxoooProductUpload.UI.Forms
{
    public partial class ChangeClassForm : BaseForm
    {
        #region 变量
        int _typeService = 1;  //产品分类类型
        long _classId = 0;  //分类id
        int _proportion = 0; //返现比例 
        string _classNameShow = string.Empty;
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
            InitClassListBoxEvent();
            txtSearch.TextChanged += TxtSearch_TextChanged;
            btnSearch.Click += BtnSearch_Click;
            txtSearch.KeyUp += TxtSearch_KeyUp;

            btnOk.Click += BtnOkOrCancel_Click;
            btnCancel.Click += BtnOkOrCancel_Click;
        }

        void BtnOkOrCancel_Click(object sender, EventArgs e)
        {
            var currentBtn = sender as SkinButton;
            switch (currentBtn.Name)
            {
                case "btnOk":
                    DialogResult = DialogResult.Yes;
                    ChangeClass(new ChangeClassEventArgs(_classId, _typeService, _proportion,_classNameShow));
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

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchClass();
        }

        void SearchClass()
        {
            var classObj = App.Context.BaseContent.CacheContext.Data.ProductClassList.FirstOrDefault(m => m.ClassName.IndexOf(txtSearch.Text) > -1);
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
                return;
            }
            MessageBoxEx.Show("没有类目[{0}]".FormatWith(txtSearch.Text));
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
            _classNameShow = "{0} >> {1}".FormatWith(lbClass2.SelectedItem,lbClass3.SelectedItem);
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
        public ChangeClassEventArgs(long id,int type,int propor)
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
        public ChangeClassEventArgs(long id, int type, int propor,string classNameShow):
            this(id,type,propor)
        {
            ClassNameShow = classNameShow;
        }
    }
}

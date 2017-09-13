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
    public partial class ChangeLocationForm : BaseForm
    {
        #region 变量
        string _regionName = string.Empty;  //发货地地址
        int _regionCode = 0;  //发货地代码
        #endregion

        /// <summary>
        /// 修改发货地时 发生
        /// </summary>
        public event EventHandler<ChangeLocationEventArgs> OnChangeLocation;

        /// <summary>
        /// 引发 <see cref="OnChangeLocation" /> 事件
        /// </summary>
        protected virtual void ChangeLocation(ChangeLocationEventArgs args)
        {
            OnChangeLocation?.Invoke(this, args);
        }

        public ChangeLocationForm()
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

            lbLocation1.DataSource = App.Context.BaseContent.CacheContext
                .Data.AreaList.Where(m => m.parent_id == 1).ToList();
        }

        void BtnOkOrCancel_Click(object sender, EventArgs e)
        {
            var currentBtn = sender as SkinButton;
            switch (currentBtn.Name)
            {
                case "btnOk":
                    DialogResult = DialogResult.Yes;
                    ChangeLocation(new ChangeLocationEventArgs(_regionName,_regionCode));
                    break;
                case "btnCancel":
                    break;
            }
            this.Close();
        }

        #region 查询发货地
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
            var location = App.Context.BaseContent.CacheContext.Data.AreaList.FirstOrDefault(m => m.region_name.IndexOf(txtSearch.Text) > -1);
            if (location != null)
            {
                //先找顶级  parentId= 1
                if (location.parent_id==1)
                {  //1级
                    lbLocation1.DataSource = App.Context.BaseContent.CacheContext
                            .Data.AreaList.Where(m => m.parent_id == 1).ToList();
                    lbLocation1.SelectedItem = location;
                }
                else
                {
                    //2级
                    var parentLocation = App.Context.BaseContent.CacheContext.Data.AreaList.FirstOrDefault(m => m.region_id == location.parent_id);

                    lbLocation1.DataSource = App.Context.BaseContent.CacheContext
                           .Data.AreaList.Where(m => m.parent_id == 1).ToList();
                    lbLocation1.SelectedItem = parentLocation;
                    lbLocation2.SelectedItem = location;
                }
                return;
            }
            MessageBoxEx.Show("没有地址[{0}]".FormatWith(txtSearch.Text));
        } 

        void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = txtSearch.TextLength != 0;
        }

        #endregion

        #region ListBox级联事件
        void InitClassListBoxEvent()
        {
            lbLocation1.SelectedIndexChanged += ListBox_SelectedIndexChanged;
            lbLocation2.SelectedIndexChanged += ListBox_SelectedIndexChanged;

            lbLocation1.ValueMember = lbLocation2.ValueMember= "ClassId";
            lbLocation1.DisplayMember = lbLocation2.DisplayMember =  "ClassName";
        }

        void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentItem = sender as ListBox; 
            var selectDate = currentItem.SelectedItem as AreaInfo;

            if (currentItem.Name == "lbLocation1")
            {
                //过滤直辖市
                if (new int[] { 110000, 120000, 310000, 500000 }.Contains(selectDate.region_code))
                {
                    lblClass.Text = "{0}".FormatWith(lbLocation1.SelectedItem);
                    _regionName = selectDate.region_name;
                    _regionCode = selectDate.region_code;
                    lbLocation2.Enabled = false;
                    lbLocation2.DataSource = null;
                    return;
                }
                lbLocation2.DataSource = App.Context.BaseContent.CacheContext.Data.AreaList.Where(m => m.parent_id == selectDate.region_id).ToList();
                lbLocation2.Enabled = true;
            }
            else if (currentItem.Name == "lbLocation2")
            {
                _regionName = selectDate.region_name;
                _regionCode = selectDate.region_code;
                lblClass.Text = "{0} >> {1}".FormatWith(lbLocation1.SelectedItem, lbLocation2.SelectedItem);
            } 
        }
        #endregion
    }

    /// <summary>
    /// 分类发货地事件数据
    /// </summary>
    public class ChangeLocationEventArgs : EventArgs
    {
        /// <summary>
        /// 发货地
        /// </summary>
        public string RegionName { set; get; }
        /// <summary>
        /// 发货地代码
        /// </summary>
        public int RegionCode { set; get; }


        /// <summary>
        /// 初始化一个 ChangeLocationEventArgs 实例
        /// </summary>
        public ChangeLocationEventArgs() { }

        /// <summary>
        ///  初始化一个 ChangeLocationEventArgs 实例
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        public ChangeLocationEventArgs(string name ,int code)
        {
            RegionName = name;
            RegionCode = code;
        }
    }
}

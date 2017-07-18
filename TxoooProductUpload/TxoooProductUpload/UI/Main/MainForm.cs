using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TxoooProductUpload.UI.Main
{
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using TxoooProductUpload.Service;
    using TxoooProductUpload.Service.Entities;
    using TxoooProductUpload.Common;

    public partial class MainForm : Form
    {

        #region 商品上传需要的参数
        //product_id商品id
        //new_old新品1，二手2
        //product_imgs商品图片逗号分隔
        //product_name名称
        //product_brand品牌
        //region_code发货地代码（直辖市id：2,3,10,23）
        //region_name 发货地名称
        //is_virtual是否虚拟商品1是，0否
        //product_ispostage是否包邮（True包邮，Flase不包邮）
        //product_postage邮费详情{"postage":"10","append":"5","limit":"7"}（postage运费，append每增加一件加，limit宝贝数量达到）
        //refund支持七天无理由1支持，0不支持
        //product_type商品类别id（最底级）
        //product_details商品详情
        //submit_product提交或保存商品（1提交，0保存）
        //product_details_type 详情类型（0手机，1pc）
        //product_type_service 商品分类类型 （1产品，2服务）

        //map_id_+数字 规格id（新增规格默认值0）
        //json_info_+数字 规格名称（数字从0开始顺序排列，如：json_info_0，json_info_1）
        //market_price_+数字 市场价
        //price_+数字 会员价
        //remain_inventory_+数字 库存
        //property_map_img_数字 图片
        //is_default_+数字 是否默认
        //radio_num_+数字 结算比例

        //share_id_+数字推广语id
        //share_content_+数字 推广语（数字从0开始顺序排列，如：share_content_0，share_content_1）
        #endregion

        long _classId = 0;
        long _regionCode = 0;
        string _regionName = string.Empty;
        int _new_old = 1;
        bool _is_virtual = false;
        bool _product_ispostage = false;
        int _refund = 1;
        int _postage = 0;
        int _append = 0;
        int _limit = 0;
        int _typeService = 1;



        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await InitServiceContext();
            InitToolbar();
            InitStatusBar();
            InitFormControl();
            //InitQueryParamEdit();
        }

        void InitFormControl()
        {

            btnOneKeyOk.Click += async (s, e) => await ProcessProduct();
            txtOneKeyUrl.Click += (s, e) => ClipboardToTextBox();

            //分类CombBox级联事件
            tsClass1.SelectedIndexChanged += async (s, e) => await cbClass_SelectedIndexChanged(s, e);
            tsClass2.SelectedIndexChanged += async (s, e) => await cbClass_SelectedIndexChanged(s, e);
            tsClass3.SelectedIndexChanged += async (s, e) => await cbClass_SelectedIndexChanged(s, e);

            //发货地CombBox级联事件
            cbArea1.SelectedIndexChanged += async (s, e) => await cbArea_SelectedIndexChanged(s, e);
            cbArea2.SelectedIndexChanged += async (s, e) => await cbArea_SelectedIndexChanged(s, e);
            cbArea3.SelectedIndexChanged += async (s, e) => await cbArea_SelectedIndexChanged(s, e);

            //RadioButton Change事件 
            rbTypeNew.CheckedChanged += (s, e) => rb_CheckedChanged(s, e);
            rbVirtualTrue.CheckedChanged += (s, e) => rb_CheckedChanged(s, e);
            rbPostageTrue.CheckedChanged += (s, e) => rb_CheckedChanged(s, e);
            rbRefundTrue.CheckedChanged += (s, e) => rb_CheckedChanged(s, e);

            //NumericUpDown Change事件    
            tbPostage.ValueChanged += (s, e) => tb_CheckedChanged(s, e);
            tbappend.ValueChanged += (s, e) => tb_CheckedChanged(s, e);
            tbLinit.ValueChanged += (s, e) => tb_CheckedChanged(s, e);

        }


        #region 状态栏和工具栏事件

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        void InitToolbar()
        {
            tsExit.Click += (s, e) => Close();
            tsLogin.Enabled = !(tsImgManage.Enabled =
                tsDataPack.Enabled = gbSetting.Enabled = gbSearch.Enabled = gbBase.Enabled =
               tsLogout.Enabled = _context.Session.IsLogined);
            tsLogin.Click += (s, e) => new Login(_context).ShowDialog(this);
            tsLogout.Click += (s, e) => _context.Session.Logout();
            this.txtOneKeyUrl.SetHintText("请输入天猫、淘宝、京东、阿里巴巴等商品链接");
            //捕捉登录状态变化事件，在登录状态发生变化的时候重设登录状态
            _context.Session.IsLoginedChanged += async (s, e) =>
             {
                 tsLogin.Enabled = !(tsImgManage.Enabled =
                  tsDataPack.Enabled = gbSetting.Enabled = gbSearch.Enabled = gbBase.Enabled =
                 tsLogout.Enabled = _context.Session.IsLogined);
                 tsLogin.Text = _context.Session.IsLogined ? string.Format("已登录为【{0} ({1})】", _context.Session.LoginInfo.DisplayName, _context.Session.LoginInfo.UserName) : "登录(&I)";
                 if (_context.Session.IsLogined)
                 {
                     try
                     {
                         foreach (var item in _context.ClassDataService.RootClassList)
                         {
                             tsClass1.Items.Add(item);
                         }
                         var areaList = await _context.AreaDataService.LoadAreaDatasAsync();
                         foreach (var item in areaList)
                         {
                             cbArea1.Items.Add(item);
                         }
                     }
                     catch (Exception ex)
                     {

                         throw;
                     }

                 }
             };
        }

        /// <summary>
        /// 初始化状态栏
        /// </summary>
        void InitStatusBar()
        {
            //绑定链接处理
            foreach (var label in st.Items.OfType<ToolStripStatusLabel>().Where(s => s.IsLink && s.Tag != null))
            {
                label.Click += (s, e) =>
                {
                    try
                    {
                        Process.Start((s as ToolStripStatusLabel).Tag.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "错误：无法打开网址，错误信息：" + ex.Message + "。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                };
            }
        }

        /// <summary>
        /// 表示开始一个操作
        /// </summary>
        /// <param name="opName">当前操作的名称</param>
        /// <param name="maxItemsCount">当前操作如果需要显示进度，那么提供任务总数；不提供则为跑马灯等待</param>
        /// <param name="disableForm">是否禁用当前窗口的操作</param>
        void BeginOperation(string opName, int maxItemsCount = 100, bool disableForm = false)
        {
            stStatus.Text = opName.DefaultForEmpty("正在操作，请稍等...");
            stProgress.Visible = true;
            stProgress.Maximum = maxItemsCount > 0 ? maxItemsCount : 100;
            stProgress.Style = maxItemsCount > 0 ? ProgressBarStyle.Blocks : ProgressBarStyle.Marquee;
            if (disableForm)
            {
                btnOneKeyOk.Enabled = false;
            }
        }

        /// <summary>
        /// 操作结束
        /// </summary>
        void EndOperation()
        {
            stStatus.Text = "就绪.";
            stProgress.Visible = false;
            btnOneKeyOk.Enabled = true;
        }

        #endregion

        #region 分类相关
        /// <summary>
        /// 分类ComboBoxChanged事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        async Task cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox currentTsCombbox = sender as ComboBox;
            ComboBox updateCombbox;
            var selectDate = currentTsCombbox.SelectedItem as ProductClassInfo;

            if (currentTsCombbox.Name == "tsClass1")
            {
                _typeService = selectDate.ClassId == 1 ? 1 : 2;
                updateCombbox = tsClass2;
                tsClass2.Text = tsClass3.Text = string.Empty;
                tsClass2.Items.Clear();
                tsClass3.Items.Clear();
            }
            else if (currentTsCombbox.Name == "tsClass2")
            {
                updateCombbox = tsClass3;
                tsClass3.Text = string.Empty;
                tsClass3.Items.Clear();
            }
            else
            {
                if (currentTsCombbox.Name == "tsClass3")
                {
                    stStatus.Text = tsClass4.Text = "当前选择分类：" + selectDate.ClassName;
                    _classId = selectDate.ClassId;
                }
                return;
            }
            var classList = await _context.ClassDataService.LoadClassDatasAsync(selectDate.ClassId);
            foreach (var item in classList)
            {
                updateCombbox.Items.Add(item);
            }
        }

        /// <summary>
        /// 验证分类是否选择
        /// </summary>
        /// <returns></returns>
        bool CheckClass()
        {
            if (_classId == 0)
            {
                MessageBox.Show("还没有选择分类呐^_^", "创业赚钱");
                tsClass1.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region 发货地相关
        /// <summary>
        /// 分类ComboBoxChanged事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        async Task cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox currentTsCombbox = sender as ComboBox;
            ComboBox updateCombbox;
            var selectDate = currentTsCombbox.SelectedItem as AreaInfo;

            if (currentTsCombbox.Name == "cbArea1")
            {
                updateCombbox = cbArea2;
                cbArea2.Text = cbArea3.Text = string.Empty;
                cbArea2.Items.Clear();
                cbArea3.Items.Clear();
            }
            else if (currentTsCombbox.Name == "cbArea2")
            {
                updateCombbox = cbArea3;
                cbArea3.Text = string.Empty;
                cbArea3.Items.Clear();
            }
            else
            {
                if (currentTsCombbox.Name == "cbArea3")
                {
                    _regionName = stStatus.Text = lbArea.Text = "当前选择发货地：" + selectDate.region_name;
                    _regionCode = selectDate.region_code;
                }
                return;
            }
            var list = await _context.AreaDataService.LoadAreaDatasAsync(selectDate.region_id);
            foreach (var item in list)
            {
                updateCombbox.Items.Add(item);
            }
        }

        /// <summary>
        /// 验证分类是否选择
        /// </summary>
        /// <returns></returns>
        bool CheckArea()
        {
            if (_regionCode == 0)
            {
                MessageBox.Show("还没有选择发货地哟^_^", "创业赚钱");
                cbArea1.Focus();
                return false;
            }
            return true;
        }
        #endregion


        #region 服务接入

        ServiceContext _context;

        /// <summary>
        /// 初始化服务状态
        /// </summary>
        async Task InitServiceContext()
        {
            _context = new ServiceContext();
            BeginOperation("正在初始化配置信息...", 0, true);
            await Task.Delay(1000);
            EndOperation();
        }

        #endregion

        #region 一键上传
        ProductResult _result;
        async Task ProcessProduct()
        {
            string productUrl = txtOneKeyUrl.Text.Trim();
            productUrl = productUrl == "" ? "https://m.1688.com/offer/553470493129.html" : productUrl;
            //"https://detail.1688.com/offer/552578137902.html";
            //http://m.1688.com/offer/552578137902.html

            //"https://item.taobao.com/item.htm?id=547040661236";
            // http://h5.m.taobao.com/awp/core/detail.htm?id=547040661236

            //"https://detail.tmall.com/item.htm?id=528221266420";
            // https://detail.m.tmall.com/item.htm?id=528221266420
            if (string.IsNullOrEmpty(productUrl))
            {
                MessageBox.Show(this, "哎呀，没有商品链接，逗我呢 o(╯□╰)o", "哎呀", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOneKeyUrl.Focus();
                return;
            }

            //if (!CheckClass() || !CheckArea() || !CheckBaseInfo()) { return; }

            _result = null;
            Exception exception = null;
            BeginOperation("正在解析商品...", 0, true);
            try
            {
                _result = await _context.UrlConvertProductService.ProcessProduct(productUrl);
                //await _context.CommonService.UploadImg("http://avatar.csdn.net/2/5/C/1_weini_xiong.jpg");

            }
            catch (Exception ex)
            {
                exception = ex;
            }
            finally
            {
                EndOperation();
            }

            if (_result != null)
            {
                stStatus.Text = string.Format("解析成功商品来源：" + _result.Source);
                //开始处理本地参数
                _result.product_type = _classId;
                _result.region_code = _regionCode;
                _result.region_name = _regionName;
                _result.new_old  = _new_old;
                _result.is_virtual = Convert.ToInt32( _is_virtual);
                _result.product_ispostage = _product_ispostage;
                _result.refund = _refund;
                _result.Postage = _postage;
                _result.Append = _append;
                _result.Limit = _limit;
                _result.product_type_service = _typeService;
                _result.product_brand = tbBrand.Text.Trim();
                rchBoxLog.Text = _result.ToString();
            }
            else
            {
                stStatus.Text = "处理出错，错误信息：" + exception.Message;
            }
        }

        #endregion

        #region 单击文本框将剪切板内容复制到文本框
        /// <summary>
        /// 单击文本框将剪切板内容复制到文本框
        /// </summary>
        void ClipboardToTextBox()
        {
            Regex urlReg = new Regex("item.taobao.com|detail.tmall.com|detail.1688.com|item.jd.com|m.1688.com");//url
            if (string.IsNullOrEmpty(txtOneKeyUrl.Text))
            {
                string getTxt = Clipboard.GetText();
                if (urlReg.IsMatch(getTxt))
                {
                    txtOneKeyUrl.Text = getTxt;
                }
            }
            else
            {
                txtOneKeyUrl.SelectAll();
            }
        }
        #endregion

        /// <summary>
        /// RadioButton Change事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton currentButton = sender as RadioButton;
            switch (currentButton.Name)
            {
                case "rbTypeNew":  //发布类型为新品
                    _new_old = Convert.ToInt32(rbTypeNew.Checked);
                    stStatus.Text = "发布类型为新品：" + (_new_old == 1 ? "新品" : "二手");
                    break;
                case "rbVirtualTrue":  //是虚拟商品
                    _is_virtual = rbVirtualTrue.Checked;
                    stStatus.Text = "是虚拟商品：" + (_is_virtual ? "是" : "不是");

                    if (_is_virtual)//如果是虚拟商品  包邮 和 退货 不可设置
                    {
                        tbPostage.Value = tbappend.Value = tbLinit.Value = _postage = _append = _limit = 0;
                        rbPostageTrue.Checked = rbRefundTrue.Checked = false;
                        rbPostageFalse.Checked = rbRefundFalse.Checked = true;
                    }
                    gbIspostage.Enabled = gbRefund.Enabled = gbPostage.Enabled = !_is_virtual;

                    break;
                case "rbPostageTrue":  //包邮
                    _product_ispostage = rbPostageTrue.Checked;
                    stStatus.Text = "是否包邮：" + (_product_ispostage ? "包邮" : "不包邮");

                    if (_product_ispostage)//包邮则清空包邮设置
                    {
                        tbPostage.Value = tbappend.Value = tbLinit.Value = _postage = _append = _limit = 0;
                    }
                    gbPostage.Enabled = !_product_ispostage;
                    break;
                case "rbRefundTrue":  //支持7天无理由退货
                    _refund = Convert.ToInt32(rbRefundTrue.Checked);
                    stStatus.Text = "是否支持7天无理由退货：" + (_refund == 1 ? "支持" : "不支持");
                    break;
            }

        }
        /// <summary>
        /// 邮费  Change事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tb_CheckedChanged(object sender, EventArgs e)
        {
            NumericUpDown currentButton = sender as NumericUpDown;
            switch (currentButton.Name)
            {
                case "tbPostage":  //邮费
                    _postage = Convert.ToInt32(tbPostage.Value);
                    stStatus.Text = "当前邮费金额：" + _postage;
                    break;
                case "tbappend":  //递增邮费
                    _append = Convert.ToInt32(tbappend.Value);
                    stStatus.Text = "当前每增加一件邮费金额：" + _append;

                    break;
                case "tbLinit":  //包邮件数
                    _limit = Convert.ToInt32(tbLinit.Value);
                    stStatus.Text = "当前满足包邮件数：" + _limit;
                    break;
            }

        }
        /// <summary>
        /// 验证基本信息
        /// </summary>
        /// <returns></returns>
        bool CheckBaseInfo()
        {
            if (!_product_ispostage && _postage == 0)
            {
                MessageBox.Show("还没有设置邮费哟^_^", "创业赚钱");
                tbPostage.Focus();
                return false;
            }
            return true;
        }
    }
}

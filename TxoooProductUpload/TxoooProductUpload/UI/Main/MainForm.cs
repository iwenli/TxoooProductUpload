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
    using Newtonsoft.Json;

    public partial class MainForm : Form
    {
        //h5.m.taobao.com/awp/core/detail.htm|item.taobao.com|
        Regex urlReg = new Regex("detail.tmall.com|detail.m.tmall.com|detail.1688.com|item.jd.com|item.m.jd.com|m.1688.com");//url
        long _classId = 0;
        long _regionCode = 0;
        string _regionName = string.Empty;
        int _new_old = 1;
        bool _is_virtual = false;
        bool _product_ispostage = false;
        int _refund = 1;
        int _postage = 1;
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
        }

        #region 状态栏和工具栏事件
        /// <summary>
        /// 页面功能控件事件
        /// </summary>
        void InitFormControl()
        {

            btnOneKeyOk.Click += async (s, e) => await ProcessProduct();
            txtOneKeyUrl.Click += (s, e) => ClipboardToTextBox();

            //分类CombBox级联事件
            tsClass1.SelectedIndexChanged += (s, e) => cbClass_SelectedIndexChanged(s, e);
            tsClass2.SelectedIndexChanged += (s, e) => cbClass_SelectedIndexChanged(s, e);
            tsClass3.SelectedIndexChanged += (s, e) => cbClass_SelectedIndexChanged(s, e);

            //发货地CombBox级联事件
            cbArea1.SelectedIndexChanged += (s, e) => cbArea_SelectedIndexChanged(s, e);
            cbArea2.SelectedIndexChanged += (s, e) => cbArea_SelectedIndexChanged(s, e);

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
        /// <summary>
        /// 初始化工具栏
        /// </summary>
        void InitToolbar()
        {
            tsExit.Click += (s, e) => Close();
            tsLogin.Enabled = !(tsImgManage.Enabled =
                tsDataPack.Enabled = gbSetting.Enabled = gbSearch.Enabled = gbBase.Enabled = tsComment.Enabled =
               tsLogout.Enabled = _context.Session.IsLogined);
            tsComment.Click += (s, e) => { new Comment(_context).ShowDialog(this); };
            tsLogin.Click += Login;
            tsLogout.Click += Logout;
            this.txtOneKeyUrl.SetHintText("请输入天猫、淘宝、京东、阿里巴巴等商品链接");
            //捕捉登录状态变化事件，在登录状态发生变化的时候重设登录状态
            _context.Session.IsLoginedChanged += async (s, e) => await LoginedChanged();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Login(object sender, EventArgs e)
        {
            AppendLog("登录中...");
            if (new Login(_context).ShowDialog(this) != DialogResult.OK)
            {
                AppendLog("登录取消...");
            }
        }
        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Logout(object sender, EventArgs e)
        {
            //清空数据
            //foreach (Control ctl in gbArea.Controls)
            //{
            //    if (ctl is ComboBox)
            //    {
            //        var combobox = ctl as ComboBox;
            //        if (combobox.DataSource != null)
            //        {
            //            combobox.DataSource = null;
            //        }
            //    }
            //}
            //foreach (Control ctl in gbClass.Controls)
            //{
            //    if (ctl is ComboBox)
            //    {
            //        var combobox = ctl as ComboBox;
            //        if (combobox.DataSource != null)
            //        {
            //            combobox.DataSource = null;
            //        }
            //    }
            //}
            //txtLog.Text = string.Empty;
            _context.CacheContext.Save();
            _context.Session.Logout();

            AppendLog("退出登录成功！");
        }


        /// <summary>
        /// 登录状态变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async Task LoginedChanged()
        {
            tsLogin.Enabled = !(tsImgManage.Enabled =
             tsDataPack.Enabled = gbSetting.Enabled = gbSearch.Enabled = gbBase.Enabled = tsComment.Enabled =
            tsLogout.Enabled = _context.Session.IsLogined);
            tsLogin.Text = _context.Session.IsLogined ? string.Format("已登录为【{0} ({1})】", _context.Session.LoginInfo.DisplayName, _context.Session.LoginInfo.UserName) : "登录(&I)";
            if (_context.Session.IsLogined)
            {
                AppendLog("登录成功...");
                AppendLog(tsLogin.Text);
                try
                {
                    BeginOperation("开始更新缓存数据...");
                    await _context.CacheContext.Update(_context);
                    //绑定combobox
                    tsClass1.DataSource = _context.ClassDataService.RootClassList;
                    cbArea1.DataSource = _context.CacheContext.Cache.AreaList.Where(m => m.parent_id == 1).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    EndOperation("缓存更新完成...");
                }
            }
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
            AppendLog(stStatus.Text);
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
        void EndOperation(string opName = "就绪.")
        {
            AppendLog(opName);
            stStatus.Text = opName;
            stProgress.Visible = false;
            btnOneKeyOk.Enabled = true;
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void AppendLog(string message, params object[] args)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    AppendLog(message, args);
                }));
                return;
            }
            string timeL = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtLog.AppendText(timeL + " => ");
            //txtLog.AppendText(Environment.NewLine);  //换行显示

            if (args == null || args.Length == 0)
            {
                txtLog.AppendText(message);
            }
            else
            {
                txtLog.AppendText(string.Format(message, args));
            }
            txtLog.AppendText(Environment.NewLine);
            txtLog.ScrollToCaret();
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
            //productUrl = productUrl == "" ? "https://detail.tmall.com/item.htm?id=537253492455" : productUrl;
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

            if (!CheckClass() || !CheckArea() || !CheckBaseInfo() || !CheckUrl(productUrl)) { return; }

            _result = null;
            int index = 0;
            BeginOperation(string.Format("正在解析商品[{0}]...", productUrl), 0, true);
            try
            {
                _result = await _context.UrlConvertProductService.ProcessProduct(productUrl);
            }
            catch (Exception ex)
            {
                AppendLog("解析商品出错，错误信息：{0}", ex.Message);
                return;
            }
            finally
            {
                EndOperation(string.Format("解析商品完成,商品来源：{0}，开始上传主图", _result.Source));
            }

            #region 上传
            if (_result != null)
            {
                #region 处理主图
                try
                {
                    await Task.Delay(500);
                    if (_result.ThumImg == null || _result.ThumImg.Count == 0)
                    {
                        _result.product_imgs = string.Empty;
                    }
                    else
                    {
                        List<string> imgList = new List<string>();
                        index = 1;
                        //排除sku主图
                        var thumImg = _result.ThumImg;
                        if (_result.Source == "阿里巴巴")
                        {
                            var skuImgs = _result.SKU1688.Where(m => m.prop == "颜色").FirstOrDefault().value.Where(m => !m.imageUrl.IsNullOrEmpty()).Select(m => m.imageUrl).ToList();
                            thumImg = _result.ThumImg.Where(m => !skuImgs.Contains(m)).ToList();
                        }
                        foreach (var item in thumImg)
                        {
                            BeginOperation(string.Format("正在上传第[{0}]张主图...", index), 0, true);
                            var txImgUrl = await _context.CommonService.UploadImg(item);
                            imgList.Add(txImgUrl);
                            EndOperation(string.Format("第[{0}]张主图上传完成，返回结果{1}...", index++, txImgUrl));
                        }
                        _result.product_imgs = imgList.Join(",");
                    }
                }
                catch (Exception ex)
                {
                    AppendLog("上传主图出错，错误信息：{0}", ex.Message);
                    return;
                }
                #endregion

                #region 处理详情
                try
                {
                    await Task.Delay(500);
                    if (_result.product_details.IsNullOrEmpty())
                    {
                        if (_result.DetailImg == null || _result.DetailImg.Count == 0)
                        {
                            _result.product_details = string.Empty;
                        }
                        else
                        {
                            List<string> detailList = new List<string>();
                            index = 1;
                            foreach (var item in _result.DetailImg)
                            {
                                BeginOperation(string.Format("正在处理第[{0}]张详情图片...", index), 0, true);
                                detailList.Add(string.Format("<p></p><img src=\"{0}\">", await _context.CommonService.UploadImg(item)));
                                EndOperation(string.Format("第[{0}]张详情图片护理完成...", index++));
                            }
                            _result.product_details = detailList.Join("");
                        }
                    }
                }
                catch (Exception ex)
                {
                    AppendLog("处理详情出错，错误信息：{0}", ex.Message);
                    return;
                }
                #endregion

                #region 生成SKU
                try
                {
                    await Task.Delay(500);
                    //0-编号 1-sku名称（颜色+尺码） 2-价格 3-图片 4-是否默认（id=0为默认）
                    string propertyFormat = "&map_id_{0}=0&json_info_{0}={1}&price_{0}={2}&market_price_{0}={2}&remain_inventory_{0}=100&property_map_img_{0}={3}&radio_num_{0}=10&is_default_{0}={4}";
                    index = 0;
                    switch (_result.Source)
                    {
                        case "阿里巴巴":
                            {
                                var colorList = _result.SKU1688.Where(m => m.prop == "颜色").FirstOrDefault().value;
                                BeginOperation("开始处理商品SKU...", colorList.Length, true);
                                foreach (var colorItem in colorList)
                                {
                                    string colorImg = _result.ThumImg.LastOrDefault();
                                    if (!colorItem.imageUrl.IsNullOrEmpty())
                                    {
                                        colorImg = await _context.CommonService.UploadImg(colorItem.imageUrl);
                                    }
                                    foreach (var sizeItem in _result.SKU1688.Where(m => m.prop == "尺码").FirstOrDefault().value)
                                    {
                                        var name = string.Format("颜色:{0} | 尺码:{1}", colorItem.name, sizeItem.name);
                                        _result.product_property += string.Format(propertyFormat, index++, name, _result.ProductPrice, colorImg, (index == 1).ToString().ToLower());
                                        AppendLog(name + "处理完成...");
                                    }
                                }
                            }
                            break;
                        case "京东":
                            {
                                var colorList = _result.SKUJD.colorSize;
                                BeginOperation("开始处理商品SKU...", colorList.Count, true);
                                foreach (var colorItem in colorList)
                                {
                                    string colorImg = _result.ThumImg.LastOrDefault();
                                    if (!colorItem.image.IsNullOrEmpty())
                                    {
                                        colorImg = await _context.CommonService.UploadImg(colorItem.image);
                                    }
                                    var name = string.Format("{0}:{1} | {2}:{3}", _result.SKUJD.colorSizeTitle.colorName
                                        , colorItem.color, _result.SKUJD.colorSizeTitle.sizeName, colorItem.size);
                                    _result.product_property += string.Format(propertyFormat, index++, name, _result.ProductPrice, colorImg, (index == 1).ToString().ToLower());
                                    AppendLog(name + "处理完成...");
                                }
                            }
                            break;
                        case "天猫":
                            {
                                var colorList = _result.SKUTmall;
                                BeginOperation("开始处理商品SKU...", colorList.Count, true);
                                if (colorList.Count != 2)
                                {
                                    new Exception("商品sku解析错误");
                                    EndOperation("商品sku解析错误");
                                    return;
                                }
                                foreach (var colorItem in colorList[1].values)
                                {
                                    foreach (var sizeitem in colorList[0].values)
                                    {
                                        string colorImg = _result.ThumImg.LastOrDefault();
                                        if (!colorItem.image.IsNullOrEmpty())
                                        {
                                            colorImg = await _context.CommonService.UploadImg(colorItem.image);
                                        }
                                        var name = string.Format("{0}:{1} | {2}:{3}", colorList[1].text
                                            , colorItem.text, colorList[0].text, sizeitem.text);
                                        _result.product_property += string.Format(propertyFormat, index++, name, _result.ProductPrice, colorImg, (index == 1).ToString().ToLower());
                                        AppendLog(name + "处理完成...");
                                    }
                                }
                            }
                            break;
                    }
                    EndOperation("SKU处理完成...");
                }
                catch (Exception ex)
                {
                    AppendLog("生成SKU出错，错误信息：{0}", ex.Message);
                    return;
                }
                #endregion

                #region 处理本地参数
                AppendLog("开始附加本地设置...");
                _result.product_type = _classId;
                AppendLog("尝试自动识别发货地...");
                if (!_result.DiscernLcation())
                {
                    AppendLog("识别失败，使用系统设置...");
                }
                else
                {
                    AppendLog("识别成功，当前产品发货地已更改为：{0}", _result.region_name);
                    _result.region_code = _regionCode;
                    _result.region_name = _regionName;
                }
                _result.new_old = _new_old;
                _result.is_virtual = Convert.ToInt32(_is_virtual);
                _result.product_ispostage = _product_ispostage;
                _result.refund = _refund;
                _result.Postage = _postage;
                _result.Append = _append;
                _result.Limit = _limit;
                _result.product_type_service = _typeService;
                _result.product_brand = tbBrand.Text.Trim();  //品牌
                _result.share = tbShare.Text.Trim(); //分享
                #endregion

                #region 开始上传商品
                try
                {
                    BeginOperation("开始上传商品...", 0, true);
                    var productUploadResult = await _context.ProductService.UploadProduct(_result);

                    if (productUploadResult.success)
                    {
                        AppendLog("上传成功，商品id={0}...", productUploadResult.msg);
                    }
                    else
                    {
                        AppendLog("上传失败，原因：{0}...", productUploadResult.msg);
                    }
                }
                catch (Exception ex)
                {
                    AppendLog("生成SKU出错，错误信息：{0}", ex.Message);
                }
                #endregion
                EndOperation();
            }
            #endregion
        }

        #endregion

        #region 单击文本框将剪切板内容复制到文本框
        /// <summary>
        /// 单击文本框将剪切板内容复制到文本框
        /// </summary>
        void ClipboardToTextBox()
        {

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

        /// <summary>
        /// 验证url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        bool CheckUrl(string url)
        {
            var result = urlReg.IsMatch(url);
            if (!result)
            {
                MessageBox.Show("暂时只支持天猫，阿里巴巴，和京东！\n如有其他需求，请联系作者!");
            }
            return result;
        }
        #endregion

        #region 分类相关
        /// <summary>
        /// 分类ComboBoxChanged事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        void cbClass_SelectedIndexChanged(object sender, EventArgs e)
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
            var classList = _context.CacheContext.Cache.ProductClassList.Where(m => m.ParentId == selectDate.ClassId).ToList();
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
        void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox currentTsCombbox = sender as ComboBox;
            ComboBox updateCombbox;
            var selectDate = currentTsCombbox.SelectedItem as AreaInfo;

            if (currentTsCombbox.Name == "cbArea1")
            {
                updateCombbox = cbArea2;
                cbArea2.Text = string.Empty;
                cbArea2.Items.Clear();
                //过滤直辖市
                if (new int[] { 110000, 120000, 310000, 500000 }.Contains(selectDate.region_code))
                {
                    _regionName = selectDate.region_name;
                    stStatus.Text = lbArea.Text = "当前选择发货地：" + selectDate.region_name;
                    _regionCode = selectDate.region_code;
                    cbArea2.Enabled = false;
                    return;
                }
                cbArea2.Enabled = true;
            }
            else
            {
                if (currentTsCombbox.Name == "cbArea2")
                {
                    _regionName = selectDate.region_name;
                    stStatus.Text = lbArea.Text = "当前选择发货地：" + selectDate.region_name;
                    _regionCode = selectDate.region_code;
                }
                return;
            }
            var list = _context.CacheContext.Cache.AreaList.Where(m => m.parent_id == selectDate.region_id).ToList();
            //await _context.AreaDataService.LoadAreaDatasAsync(selectDate.region_id);
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

        #region 验证
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
                    AppendLog("发布类型变更为：" + (_new_old == 1 ? "新品" : "二手"));
                    break;
                case "rbVirtualTrue":  //是虚拟商品
                    _is_virtual = rbVirtualTrue.Checked;
                    AppendLog("是否虚拟商品变更为：" + (_is_virtual ? "是" : "不是"));

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
                    AppendLog("是否包邮变更为：" + (_product_ispostage ? "包邮" : "不包邮"));
                    if (_product_ispostage)//包邮则清空包邮设置
                    {
                        tbPostage.Value = tbappend.Value = tbLinit.Value = _postage = _append = _limit = 0;
                    }
                    gbPostage.Enabled = !_product_ispostage;
                    break;
                case "rbRefundTrue":  //支持7天无理由退货
                    _refund = Convert.ToInt32(rbRefundTrue.Checked);
                    AppendLog("是否支持7天无理由退货变更为：" + (_refund == 1 ? "支持" : "不支持"));
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
        #endregion

    }
}

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
            //InitQueryParamEdit();
        }

        #region 状态栏和工具栏事件

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        void InitToolbar()
        {
            tsExit.Click += (s, e) => Close();
            tsLogin.Enabled = !(tsImgManage.Enabled =
               tsClass1.Enabled = tsClass2.Enabled = tsClass3.Enabled =
               tsDataPack.Enabled =
               btnOneKeyOk.Enabled = txtOneKeyUrl.Enabled =
               tsLogout.Enabled = _context.Session.IsLogined);
            tsLogin.Click += (s, e) => new Login(_context).ShowDialog(this);
            tsLogout.Click += (s, e) => _context.Session.Logout();
            this.txtOneKeyUrl.SetHintText("请输入天猫、淘宝、京东、阿里巴巴等商品链接");
            //捕捉登录状态变化事件，在登录状态发生变化的时候重设登录状态
            _context.Session.IsLoginedChanged += (s, e) =>
            {
                tsLogin.Enabled = !(tsImgManage.Enabled =
                tsClass1.Enabled = tsClass2.Enabled = tsClass3.Enabled =
                tsDataPack.Enabled =
                btnOneKeyOk.Enabled = txtOneKeyUrl.Enabled =
                tsLogout.Enabled = _context.Session.IsLogined);
                tsLogin.Text = _context.Session.IsLogined ? string.Format("已登录为【{0} ({1})】", _context.Session.LoginInfo.DisplayName, _context.Session.LoginInfo.UserName) : "登录(&I)";
            };
            btnOneKeyOk.Click += (s, e) => ProcessProduct();
            txtOneKeyUrl.Click += (s, e) => ClipboardToTextBox();

            //CombBox级联事件
            tsClass1.SelectedIndexChanged += (s, e) => tsClass_SelectedIndexChanged(s,e);
            tsClass2.SelectedIndexChanged += (s, e) => tsClass_SelectedIndexChanged(s, e);
            tsClass3.SelectedIndexChanged += (s, e) => tsClass_SelectedIndexChanged(s, e);
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


        async Task tsClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox currentTsCombbox = sender as ToolStripComboBox;
            ToolStripComboBox updateCombbox;
            if (currentTsCombbox.Name == "tsClass1") { updateCombbox = tsClass2; }
            else if (currentTsCombbox.Name == "tsClass2") { updateCombbox = tsClass3; }
            else
            {
                if (currentTsCombbox.Name == "tsClass3")
                {
                    tsClass4.Text = currentTsCombbox.Text;
                }
                return;
            }
            long id = (currentTsCombbox.SelectedItem as ProductClassInfo).ClassId;
            var classList = await _context.ClassDataService.LoadClaassDatasAsync(id);
            updateCombbox.Items.Clear();
            foreach (var item in classList)
            {
                updateCombbox.Items.Add(item);
            }
        }



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
            foreach (var item in _context.ClassDataService.RootClassList)
            {
                tsClass1.Items.Add(item);
            }
            EndOperation();
        }

        #endregion

        #region 一键上传
        ProductResult _result;
        async Task ProcessProduct()
        {
            string productUrl = txtOneKeyUrl.Text.Trim();
            productUrl = "https://detail.1688.com/offer/552578137902.html";
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

            _result = null;
            Exception exception = null;
            BeginOperation("正在解析商品...", 0, true);
            try
            {
                _result = await _context.UrlConvertProductService.ProcessProduct(productUrl);
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
            Regex urlReg = new Regex("item.taobao.com|detail.tmall.com|detail.1688.com|item.jd.com");//url
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
    }
}

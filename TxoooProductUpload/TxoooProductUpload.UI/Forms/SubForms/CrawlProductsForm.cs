using CCWin;
using CCWin.SkinControl;
using HtmlAgilityPack;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.Entities;
using TxoooProductUpload.Entities.Product;
using TxoooProductUpload.Service.Crawl;
using TxoooProductUpload.UI.CefGlue.Browser;
using TxoooProductUpload.UI.Common;
using TxoooProductUpload.UI.Common.Const;
using TxoooProductUpload.UI.Common.Extended.Winform;
using TxoooProductUpload.UI.Service.Cache.ProductCache;
using TxoooProductUpload.UI.Service.Entities;
using Xilium.CefGlue.WindowsForms;

namespace TxoooProductUpload.UI.Forms.SubForms
{

    /// <summary>
    /// 抓取商品
    /// </summary>
    public partial class CrawlProductsForm : Form
    {
        #region 变量
        CefWebBrowser _webBrowser;
        UserControls.ProcessProduct _process1;
        UserControls.ProcessProductResult _processResult;

        int _allTaskCount = 0;
        bool _isAuto = false;  //自动抓取全部列表
        ProductHelper _productHelper = new ProductHelper();
        CrawlType _crawlType = CrawlType.None;
        static readonly object _lockObject = new object();
        #endregion

        #region 属性
        /// <summary>
        /// 商品缓存
        /// </summary>
        ProductCacheData ProductCache { set; get; }
        #endregion

        public CrawlProductsForm()
        {
            InitializeComponent();
            ProductCacheContext.Instance.Init();
            ProductCache = ProductCacheContext.Instance.Data;
            Load += CrawlProductsForm_Load;
        }

        /// <summary>
        /// 页面加载时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CrawlProductsForm_Load(object sender, EventArgs e)
        {
            InitUI();
            InitMenuEvent();
            InitDgv();
            InitControlBtnEvent();

            bs.DataSource = ProductCache.WaitProcessList;

            tsBtnAutoAll.Click += TsBtnAutoAll_Click;
            tssBtnBatchDel.Click += (_s, _e) => { DeleteRows(); };
            tsTxtUrl.TextChanged += TsTxtUrl_TextChanged;
        }

        /// <summary>
        /// 初始化页面控件
        /// </summary>
        void InitUI()
        {
            #region 浏览器
            _webBrowser = new CefWebBrowser();
            _webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            //webBrowser.Location = new System.Drawing.Point(0, 31);
            //webBrowser.Name = "webBrowser";
            //webBrowser.Size = new System.Drawing.Size(992, 320);
            _webBrowser.StartUrl = "www.taobao.com";
            //webBrowser.TabIndex = 127;
            skinSplitContainer1.Panel1.Controls.Add(_webBrowser);

            #endregion
            #region 后续处理界面
            _process1 = new UserControls.ProcessProduct();
            _process1.Dock = DockStyle.Fill;
            _process1.Visible = false;
            this.Controls.Add(_process1);

            _processResult = new UserControls.ProcessProductResult();
            _processResult.Dock = DockStyle.Fill;
            _processResult.Visible = false;
            this.Controls.Add(_processResult);
            #endregion
        }

        #region 页面变更时发生
        void TsTxtUrl_TextChanged(object sender, EventArgs e)
        {
            var url = tsTxtUrl.Text.Trim();
            if (url.IndexOf("s.taobao.com/search") > 1)
            {
                _crawlType = CrawlType.TaoBaoSearch;
            }
            else if (url.IndexOf("item.taobao.com") > 1)
            {
                _crawlType = CrawlType.TaoBaoItem;
            }
            else if (url.IndexOf("detail.tmall.com") > 1)
            {
                _crawlType = CrawlType.TmallItem;
            }
            else if (url.IndexOf("tmall.com/search") > 1 || url.IndexOf("tmall.com/category") > 1)
            {
                _crawlType = CrawlType.TmallStore;
            }
            else
            {
                _crawlType = CrawlType.None;
            }

            tsBtnAutoAll.Enabled = tsBtnOneProduct.Enabled = tsBtnPageProducts.Enabled = false;
            switch (_crawlType)
            {
                case CrawlType.TaoBaoSearch:
                case CrawlType.TmallStore:
                    tsBtnAutoAll.Enabled = tsBtnPageProducts.Enabled = true;
                    break;
                case CrawlType.TaoBaoItem:
                case CrawlType.TmallItem:
                    tsBtnOneProduct.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 底部控制菜单相关
        /// <summary>
        /// 底部控制菜单事件绑定
        /// </summary>
        void InitControlBtnEvent()
        {
            tssBtnNext.Click += ControlBtn_Click;
            tssBtnPrevious.Click += ControlBtn_Click;
            tssBtnNew.Click += ControlBtn_Click;
            tssBtnBack.Click += ControlBtn_Click;
            tssBtnRevert.Click += ControlBtn_Click;
        }

        /// <summary>
        /// 底部控制菜单事件入口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ControlBtn_Click(object sender, EventArgs e)
        {
            ToolStripStatusLabel current = sender as ToolStripStatusLabel;
            switch (current.Tag.ToString())
            {
                case "prev":
                    Previous();
                    break;
                case "next":
                    NextProcess();
                    break;
                case "new":
                    Init();
                    break;
                case "back":
                    BackUpTask();
                    break;
                case "revert":
                    RevertTask();
                    break;
            }
        }

        /// <summary>
        /// 重新开始
        /// </summary>
        void Init()
        {
            ProductCacheContext.Instance.Save();
            ProductCacheContext.Instance.Init();
            bs.DataSource = null;
            ProductCache = ProductCacheContext.Instance.Data;
            bs.DataSource = ProductCache.WaitProcessList;
            tssBtnNext.Enabled = skinSplitContainer1.Visible = true;
            _processResult.tsBtnUpload.Enabled = _processResult.tsBtnUploadImageAllSelect.Enabled
                = _processResult.tsBtnEditAllSelect.Enabled
            = _processResult.Visible = _process1.Visible = tssBtnPrevious.Enabled = false;
            OpenNewUrl("www.taobao.com");
        }

        /// <summary>
        /// 上一步
        /// </summary>
        void Previous()
        {
            ProductCache.WaitProcessList.AddRange(ProductCache.ProcessFailList);
            ProductCache.ProcessFailList.Clear();
            bs.DataSource = null;
            bs.DataSource = ProductCache.WaitProcessList;
            tssBtnNext.Enabled = skinSplitContainer1.Visible = true;
            _process1.Visible = tssBtnPrevious.Enabled = false;
        }

        /// <summary>
        /// 下一步处理
        /// </summary>
        void NextProcess()
        {
            Task.Run(() =>
           {
               _allTaskCount = ProductCache.WaitProcessList.Count;
               var showCount = _allTaskCount;
               var existsCount = ProductCache.WaitUploadImageList.Count;
               if (_allTaskCount > 0)
               {
                   Invoke(new Action(() =>
                   {
                       tssBtnNext.Enabled = skinSplitContainer1.Visible = false;
                       _process1.Visible = true;
                       _process1.ProcessBar.Maximum = ProductCache.WaitProcessList.Count;
                       _process1.ProcessBar.Value = _process1.ProcessBar.Minimum = 0;
                   }));
                   var cts = new CancellationTokenSource();
                   var taskCount = AppSetting.MaxThreadCount;
                   if (taskCount > _allTaskCount)
                   {
                       taskCount = taskCount > _allTaskCount ? _allTaskCount : taskCount;
                   }
                   var tasks = new Task[taskCount];
                   for (int i = 0; i < taskCount; i++)
                   {
                       tasks[i] = new Task(() => GrabDetailTask(cts.Token), cts.Token, TaskCreationOptions.LongRunning);
                       tasks[i].Start();
                   }
                   Task.Run(async () =>
                   {
                       while (true)
                       {
                           lock (ProductCache.WaitProcessList)
                           {
                               if (_allTaskCount == 0)
                               {
                                   ProcessProductDetailResult(showCount, ProductCache.WaitUploadImageList.Count - existsCount);
                                   break;
                               }
                           }
                           await Task.Delay(1000);
                       }
                   });
               }
               else
               {
                   ProcessProductDetailResult(0, 0);
               }
           });
        }

        /// <summary>
        /// 自动抓取 和 暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TsBtnAutoAll_Click(object sender, EventArgs e)
        {
            if (tsBtnAutoAll.Text == "自动(&A)")
            {
                _isAuto = true;
                tsBtnAutoAll.Text = "暂停(&S)";
                CrawProductBase();
            }
            else
            {
                _isAuto = false;
                tsBtnAutoAll.Text = "自动(&A)";
            }
        }
        /// <summary>
        /// 删除选中行
        /// </summary>
        void DeleteRows()
        {
            var rows = GetSelectRow();
            if (rows != null)
            {
                foreach (var item in rows)
                {
                    sdgvProduct.Rows.Remove(item);
                }
            }
        }

        /// <summary>
        /// 备份任务
        /// </summary>
        void BackUpTask()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.Filter = "任务文件 (*.dat)|*.dat";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.Title = "保存任务进度";
            if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName.Length > 0)
            {
                ProductCacheContext.Instance.Save(saveFileDialog.FileName);
                MessageBox.Show("存储任务进度成功！", "保存");
            }
        }
        /// <summary>
        /// 还原任务
        /// </summary>
        void RevertTask()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "任务文件 (*.dat)|*.dat";
            openFileDialog.FilterIndex = 2;
            openFileDialog.Title = "还原任务进度";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ProductCacheContext.Instance.LoadData(openFileDialog.FileName);
                    ProductCache = ProductCacheContext.Instance.Data;
                    ProductCache.WaitProcessList.AddRange(ProductCache.ProcessFailList);
                    ProductCache.ProcessFailList.Clear();
                    ProductCache.WaitUploadImageList.AddRange(ProductCache.UploadImageFailList);
                    ProductCache.UploadImageFailList.Clear();
                    ProductCache.WaitUploadList.AddRange(ProductCache.UploadFailList);
                    ProductCache.UploadFailList.Clear();
                    if (ProductCache.WaitProcessList.Count == 0 &&
                        ProductCache.WaitUploadImageList.Count == 0 &&
                        ProductCache.WaitUploadList.Count == 0)
                    {
                        MessageBoxEx.Show("该任务意见完成,没有需要处理的商品了!");
                    }
                    else
                    {
                        MessageBoxEx.Show("还原任务成功,待完善详情{0}个,待上传图片{1}个,待上传商品{2}个.".
                            FormatWith(ProductCache.WaitProcessList.Count, ProductCache.WaitUploadImageList.Count,
                        ProductCache.WaitUploadList.Count));
                        if (ProductCache.WaitProcessList.Count > 0)
                        {
                            bs.DataSource = null;
                            bs.DataSource = ProductCache.WaitProcessList;
                            _processResult.tsBtnUpload.Enabled = _processResult.tsBtnUploadImageAllSelect.Enabled
                            = tssBtnNext.Enabled = skinSplitContainer1.Visible = true;
                            _processResult.Visible = _process1.Visible = tssBtnPrevious.Enabled = false;
                        }
                        else
                        {
                            ProcessProductDetailResult(0,0);
                            _processResult.MessageShowLable.Text = "还原成功,待上传图片商品{0}个,待上传商品{1}个."
                            .FormatWith(ProductCache.WaitUploadImageList.Count, ProductCache.WaitUploadList.Count);
                            if (ProductCache.WaitUploadImageList.Count == 0) {
                                _processResult.tsBtnUploadImageAllSelect.Enabled = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文件出错：" + ex.Message);
                }
            }
        }
        /// <summary>
        /// 获取选中的行 无选中返回null
        /// </summary>
        /// <returns></returns>
        List<DataGridViewRow> GetSelectRow()
        {
            sdgvProduct.EndEdit();
            var selRows = sdgvProduct.Rows.OfType<DataGridViewRow>().Where(m => m.Cells[0].Value != null && m.Cells[0].Value.ToString() == "True").ToList();
            if (selRows.Count == 0)
            {
                MessageBoxEx.Show("请选中要操作的商品", AppInfo.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return selRows;
        }
        #endregion

        #region 商品展示表格相关
        void InitDgv()
        {
            InitDgvAllSelect();
            sdgvProduct.CellContentClick += SdgvProduct_CellContentClick;
            sdgvProduct.DataError += (s, e) => { };  //重写DataError事件
            sdgvProduct.SelectionChanged += (_s, _e) =>
            {
                tssBtnNext.Enabled = sdgvProduct.Rows.Count > 0;
            };
        }
        /// <summary>
        /// 单元格单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SdgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewCell cell = sdgvProduct.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (sdgvProduct.Columns[e.ColumnIndex] == Delete)
                {
                    //删除
                    sdgvProduct.Rows.Remove(sdgvProduct.Rows[e.RowIndex]);
                }
                if (sdgvProduct.Columns[e.ColumnIndex] == ShowPhone)
                {
                    Utils.OpenUrl(sdgvProduct.Rows[e.RowIndex].Cells["h5UrlDataGridViewTextBoxColumn"].Value.ToString(), true);
                }
                if (sdgvProduct.Columns[e.ColumnIndex] == ShowPc)
                {
                    Utils.OpenUrl(sdgvProduct.Rows[e.RowIndex].Cells["urlDataGridViewTextBoxColumn"].Value.ToString());
                }
            }
        }

        void InitDgvAllSelect()
        {
            DataGridViewCheckBoxColumn colCB = new DataGridViewCheckBoxColumn();
            DataGridViewCheckBoxHeaderCell cbHeader = new DataGridViewCheckBoxHeaderCell();
            colCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colCB.HeaderText = "全选";
            colCB.Width = 30;
            colCB.HeaderCell = cbHeader;
            sdgvProduct.Columns.Insert(0, colCB);
            cbHeader.OnCheckBoxClicked += CbHeader_OnCheckBoxClicked;
        }

        void CbHeader_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {
            sdgvProduct.EndEdit();
            sdgvProduct.Rows.OfType<DataGridViewRow>().ToList().ForEach(t => t.Cells[0].Value = e.CheckedState);
        }
        #endregion

        #region 浏览器控制菜单相关事件
        void InitMenuEvent()
        {
            tsBtnGO.Click += TsBtnGO_Click;
            tsBtnLeft.Click += TsBtnLeft_Click;
            tsBtnRight.Click += TsBtnRight_Click;
            tsBtnRefresh.Click += TsBtnRefresh_Click;
            tsTxtUrl.KeyUp += TsTxtUrl_KeyUp;
            _webBrowser.AddressChanged += WebBrowser_AddressChanged;

            _webBrowser.LoadEnd += WebBrowser_LoadEnd;
            tsBtnPageProducts.Click += TsBtnTest_Click;
            tsBtnOneProduct.Click += TsBtnTest_Click;
        }


        void WebBrowser_LoadEnd(object sender, Xilium.CefGlue.WindowsForms.LoadEndEventArgs e)
        {
            //var url = tsTxtUrl.Text;
            //tsBtnAutoAll.Enabled = tsBtnPageProducts.Enabled = url.IndexOf("s.taobao.com/search") > 1;
        }

        void WebBrowser_AddressChanged(object sender, Xilium.CefGlue.WindowsForms.AddressChangedEventArgs e)
        {
            tsTxtUrl.Text = _webBrowser.Browser.GetMainFrame().Url;
            tsBtnLeft.Enabled = _webBrowser.Browser.CanGoBack;
            tsBtnRight.Enabled = _webBrowser.Browser.CanGoForward;
            if (_isAuto)
            {
                Thread.Sleep(1000);
                CrawProductBase();
            }
        }


        /// <summary>
        /// 获取页面HTML
        /// </summary>
        /// <param name="callBack"></param>
        void HtmlChange(Action<string> callBack)
        {
            if (_webBrowser.Browser.GetMainFrame().IsMain)
            {
                var visitor = new SourceVisitor(callBack);
                _webBrowser.Browser.GetMainFrame().GetSource(visitor);
            }
        }
        /// <summary>
        /// 抓取商品按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TsBtnTest_Click(object sender, EventArgs e)
        {
            CrawProductBase();
        }

        void TsBtnRefresh_Click(object sender, EventArgs e)
        {
            _webBrowser.Browser.Reload();
        }

        void TsBtnRight_Click(object sender, EventArgs e)
        {
            _webBrowser.Browser.GoForward();
        }

        void TsBtnLeft_Click(object sender, EventArgs e)
        {
            _webBrowser.Browser.GoBack();
        }

        void TsTxtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                OpenNewUrl(tsTxtUrl.Text.Trim());
            }
        }

        void TsBtnGO_Click(object sender, EventArgs e)
        {
            OpenNewUrl(tsTxtUrl.Text.Trim());
        }

        /// <summary>
        /// 在webBrowser中打开新url
        /// </summary>
        /// <param name="url"></param>
        void OpenNewUrl(string url)
        {
            _webBrowser.Browser.GetMainFrame().LoadUrl(url);
        }
        #endregion

        #region 抓取商品
        #region 抓取商品基本信息
        /// <summary>
        /// 抓取商品基本信息
        /// </summary>
        void CrawProductBase()
        {
            HtmlChange(Html =>
            {
                BeginInvoke(new Action(() =>
                {
                    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                    document.LoadHtml(Html);

                    var list = _productHelper.GetProductsFromDocument(document, _crawlType);
                    foreach (var item in list)
                    {
                        if (IsEsists(item)) { continue; }
                        bs.Add(item);
                    }
                    if (sdgvProduct.Rows.Count > 8)
                    {
                        sdgvProduct.FirstDisplayedScrollingRowIndex = sdgvProduct.Rows.Count - 1;
                    }

                    if (_isAuto)
                    {
                        AuthCraw(document);
                    }
                }));
            });
        }
        /// <summary>
        /// 自动抓取
        /// </summary>
        /// <param name="document"></param>
        void AuthCraw(HtmlAgilityPack.HtmlDocument document)
        {
            switch (_crawlType)
            {
                case CrawlType.TaoBaoSearch:
                    //循环到最后一页  退出循环
                    if (document.DocumentNode.SelectNodes("//span[@class='icon icon-btn-next-2-disable']") != null)
                    {
                        _isAuto = false;
                        MessageBoxEx.Show("抓取完毕，共抓取商品{0}条".FormatWith(sdgvProduct.Rows.Count));
                        return;
                    }
                    //下一页
                    _webBrowser.Browser.GetMainFrame().ExecuteJavaScript("document.getElementsByClassName('icon-btn-next-2')[0].click()", "", 0);
                    break;
                case CrawlType.TmallStore:
                    //循环到最后一页  退出循环
                    if (document.DocumentNode.SelectNodes("//b[@class='ui-page-s-next']") != null)
                    {
                        _isAuto = false;
                        MessageBoxEx.Show("抓取完毕，共抓取商品{0}条".FormatWith(sdgvProduct.Rows.Count));
                        return;
                    }
                    //下一页
                    _webBrowser.Browser.GetMainFrame().ExecuteJavaScript("document.getElementsByClassName('ui-page-s-next')[0].click()", "", 0);
                    break;
            }
        }
        #endregion

        #region 抓取详细信息
        /// <summary>
        /// 开始抓取详情页
        /// </summary>
        async void GrabDetailTask(CancellationToken token)
        {
            try
            {
                ProductHelper productHelper = new ProductHelper();

                ProductSourceInfo task;
                while (!token.IsCancellationRequested)
                {
                    task = null;
                    lock (ProductCache.WaitProcessList)
                    {
                        if (ProductCache.WaitProcessList.Count > 0)
                        {
                            task = ProductCache.WaitProcessList[0];
                            ProductCache.WaitProcessList.Remove(task);
                        }
                    }
                    //没有则退出
                    if (task == null)
                    {
                        break;
                    }

                    if (!task.IsProcess)
                    {
                        productHelper.ProcessItem(task);
                    }
                    App.Context.ProductService.DiscernLcation(task);
                    if (task.IsProcess)
                    {
                        lock (ProductCache.ProcessFailList)
                        {
                            ProductCache.WaitUploadImageList.Add(task);

                            if (ProductCache.ProcessFailList.Count > 0 && ProductCache.ProcessFailList.Count % 20 == 0)
                            {
                                //每成功20个手动释放一下内存
                                GC.Collect();
                                //保存任务数据，防止什么时候宕机了任务进度回滚太多
                                ProductCacheContext.Instance.Save();
                            }
                        }
                    }
                    else
                    {
                        lock (ProductCache.ProcessFailList)
                        {
                            ProductCache.ProcessFailList.Add(task);
                        }
                    }
                    Invoke(new Action(() =>
                    {
                        var value = _process1.ProcessBar.Value + 1;
                        //Iwenli.LogHelper.LogDebug(this, value.ToString());
                        _process1.ProcessBar.Value = value;
                    }));
                    //等待一定时间  继续执行
                    await Task.Delay(Utils.RandomInt(), token);
                    lock (_lockObject)
                    {
                        _allTaskCount--;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        /// <summary>
        /// 商品处理回调
        /// </summary>
        /// <param name="allCount"></param>
        /// <param name="successCount"></param>
        void ProcessProductDetailResult(int allCount, int successCount)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    ProcessProductDetailResult(allCount, successCount);
                })); return;
            }
            _processResult.ProductCache = ProductCache;
            _processResult.ProductBindSource.DataSource = null;
            _processResult.ProductBindSource.DataSource = ProductCache.WaitUploadImageList;
            _processResult.MessageShowLable.Text = "本次共处理{0}个商品，处理成功{1}个商品，已经追加到集合中"
                .FormatWith(allCount, successCount);
            _process1.Visible = skinSplitContainer1.Visible = false;
            _processResult.Visible = true;
            //tssBtnNext.Enabled = tssBtnPrevious.Enabled = 
            ProductCacheContext.Instance.Save();
        }

        /// <summary>
        /// 判断商品是否抓取过
        /// </summary>
        /// <returns></returns>
        bool IsEsists(ProductSourceInfo product)
        {
            //当前集合中没有  并且已经上传商品缓存中没有
            if (ProductCache.WaitProcessList.FirstOrDefault(m => m.Id == product.Id) != null ||
               App.Context.BaseContent.CacheContext.Data.ProductSourceTxoooList.Exists
               (m => m.SourceId == product.Id.ToString()))
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}
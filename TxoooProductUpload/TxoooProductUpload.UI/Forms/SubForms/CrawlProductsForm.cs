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
    /// ץȡ��Ʒ
    /// </summary>
    public partial class CrawlProductsForm : Form
    {
        #region ����
        CefWebBrowser _webBrowser;
        UserControls.ProcessProduct _process1;
        UserControls.ProcessProductResult _processResult;

        int _allTaskCount = 0;
        bool _isAuto = false;  //�Զ�ץȡȫ���б�
        ProductHelper _productHelper = new ProductHelper();
        CrawlType _crawlType = CrawlType.None;
        static readonly object _lockObject = new object();
        #endregion

        #region ����
        /// <summary>
        /// ��Ʒ����
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
        /// ҳ�����ʱ����
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
        /// ��ʼ��ҳ��ؼ�
        /// </summary>
        void InitUI()
        {
            #region �����
            _webBrowser = new CefWebBrowser();
            _webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            //webBrowser.Location = new System.Drawing.Point(0, 31);
            //webBrowser.Name = "webBrowser";
            //webBrowser.Size = new System.Drawing.Size(992, 320);
            _webBrowser.StartUrl = "www.tmall.com";
            //webBrowser.TabIndex = 127;
            skinSplitContainer1.Panel1.Controls.Add(_webBrowser);

            #endregion
            #region �����������
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

        #region ҳ����ʱ����
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
            else if (url.IndexOf("tmall.com/search.htm") > 1 )
            {
                _crawlType = CrawlType.TmallStore;
            }
            else if ( url.IndexOf("tmall.com/search_product.htm") > 1)
            {
                _crawlType = CrawlType.TmallSearch;
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
                case CrawlType.TmallSearch:
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

        #region �ײ����Ʋ˵����
        /// <summary>
        /// �ײ����Ʋ˵��¼���
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
        /// �ײ����Ʋ˵��¼����
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
        /// ���¿�ʼ
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
        /// ��һ��
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
        /// ��һ������
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
        /// �Զ�ץȡ �� ��ͣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TsBtnAutoAll_Click(object sender, EventArgs e)
        {
            if (tsBtnAutoAll.Text == "�Զ�(&A)")
            {
                _isAuto = true;
                tsBtnAutoAll.Text = "��ͣ(&S)";
                CrawProductBase();
            }
            else
            {
                _isAuto = false;
                tsBtnAutoAll.Text = "�Զ�(&A)";
            }
        }
        /// <summary>
        /// ɾ��ѡ����
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
        /// ��������
        /// </summary>
        void BackUpTask()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.Filter = "�����ļ� (*.dat)|*.dat";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.Title = "�����������";
            if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName.Length > 0)
            {
                ProductCacheContext.Instance.Save(saveFileDialog.FileName);
                MessageBox.Show("�洢������ȳɹ���", "����");
            }
        }
        /// <summary>
        /// ��ԭ����
        /// </summary>
        void RevertTask()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "�����ļ� (*.dat)|*.dat";
            openFileDialog.FilterIndex = 2;
            openFileDialog.Title = "��ԭ�������";
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
                        MessageBoxEx.Show("������������,û����Ҫ�������Ʒ��!");
                    }
                    else
                    {
                        MessageBoxEx.Show("��ԭ����ɹ�,����������{0}��,���ϴ�ͼƬ{1}��,���ϴ���Ʒ{2}��.".
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
                            _processResult.MessageShowLable.Text = "��ԭ�ɹ�,���ϴ�ͼƬ��Ʒ{0}��,���ϴ���Ʒ{1}��."
                            .FormatWith(ProductCache.WaitUploadImageList.Count, ProductCache.WaitUploadList.Count);
                            if (ProductCache.WaitUploadImageList.Count == 0) {
                                _processResult.tsBtnUploadImageAllSelect.Enabled = false;
                            }
                            _processResult.tsBtnEditAllSelect.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("���ļ�����" + ex.Message);
                }
            }
        }
        /// <summary>
        /// ��ȡѡ�е��� ��ѡ�з���null
        /// </summary>
        /// <returns></returns>
        List<DataGridViewRow> GetSelectRow()
        {
            sdgvProduct.EndEdit();
            var selRows = sdgvProduct.Rows.OfType<DataGridViewRow>().Where(m => m.Cells[0].Value != null && m.Cells[0].Value.ToString() == "True").ToList();
            if (selRows.Count == 0)
            {
                MessageBoxEx.Show("��ѡ��Ҫ��������Ʒ", AppInfo.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return selRows;
        }
        #endregion

        #region ��Ʒչʾ������
        void InitDgv()
        {
            InitDgvAllSelect();
            sdgvProduct.CellContentClick += SdgvProduct_CellContentClick;
            sdgvProduct.DataError += (s, e) => { };  //��дDataError�¼�
            sdgvProduct.SelectionChanged += (_s, _e) =>
            {
                tssBtnNext.Enabled = sdgvProduct.Rows.Count > 0;
            };
        }
        /// <summary>
        /// ��Ԫ�񵥻�
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
                    //ɾ��
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
            colCB.HeaderText = "ȫѡ";
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

        #region ��������Ʋ˵�����¼�
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
        /// ��ȡҳ��HTML
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
        /// ץȡ��Ʒ��ť�¼�
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
        /// ��webBrowser�д���url
        /// </summary>
        /// <param name="url"></param>
        void OpenNewUrl(string url)
        {
            _webBrowser.Browser.GetMainFrame().LoadUrl(url);
        }
        #endregion

        #region ץȡ��Ʒ
        #region ץȡ��Ʒ������Ϣ
        /// <summary>
        /// ץȡ��Ʒ������Ϣ
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
        /// �Զ�ץȡ
        /// </summary>
        /// <param name="document"></param>
        void AuthCraw(HtmlAgilityPack.HtmlDocument document)
        {
            switch (_crawlType)
            {
                case CrawlType.TaoBaoSearch:
                    //ѭ�������һҳ  �˳�ѭ��
                    if (document.DocumentNode.SelectNodes("//span[@class='icon icon-btn-next-2-disable']") != null)
                    {
                        _isAuto = false;
                        MessageBoxEx.Show("ץȡ��ϣ���ץȡ��Ʒ{0}��".FormatWith(sdgvProduct.Rows.Count));
                        return;
                    }
                    //��һҳ
                    _webBrowser.Browser.GetMainFrame().ExecuteJavaScript("document.getElementsByClassName('icon-btn-next-2')[0].click()", "", 0);
                    break;
                case CrawlType.TmallStore:
                    //ѭ�������һҳ  �˳�ѭ��
                    if (document.DocumentNode.SelectNodes("//b[@class='ui-page-s-next']") != null)
                    {
                        _isAuto = false;
                        MessageBoxEx.Show("ץȡ��ϣ���ץȡ��Ʒ{0}��".FormatWith(sdgvProduct.Rows.Count));
                        return;
                    }
                    //��һҳ
                    _webBrowser.Browser.GetMainFrame().ExecuteJavaScript("document.getElementsByClassName('ui-page-s-next')[0].click()", "", 0);
                    break;
            }
        }
        #endregion

        #region ץȡ��ϸ��Ϣ
        /// <summary>
        /// ��ʼץȡ����ҳ
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
                    //û�����˳�
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
                                //ÿ�ɹ�20���ֶ��ͷ�һ���ڴ�
                                GC.Collect();
                                //�����������ݣ���ֹʲôʱ��崻���������Ȼع�̫��
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
                    //�ȴ�һ��ʱ��  ����ִ��
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
        /// ��Ʒ����ص�
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
            _processResult.MessageShowLable.Text = "���ι�����{0}����Ʒ������ɹ�{1}����Ʒ���Ѿ�׷�ӵ�������"
                .FormatWith(allCount, successCount);
            _process1.Visible = skinSplitContainer1.Visible = false;
            _processResult.Visible = true;
            //tssBtnNext.Enabled = tssBtnPrevious.Enabled = 
            ProductCacheContext.Instance.Save();
        }

        /// <summary>
        /// �ж���Ʒ�Ƿ�ץȡ��
        /// </summary>
        /// <returns></returns>
        bool IsEsists(ProductSourceInfo product)
        {
            //��ǰ������û��  �����Ѿ��ϴ���Ʒ������û��
            if (ProductCache.WaitProcessList.FirstOrDefault(m => m.Id == product.Id) != null && App.Context.ProductService.IsEsists(product))
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}
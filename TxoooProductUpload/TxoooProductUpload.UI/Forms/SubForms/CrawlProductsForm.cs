using System;
using System.Windows.Forms;
using TxoooProductUpload.UI.CefGlue.Browser;
using TxoooProductUpload.UI.Common.Extended.Winform;
using HtmlAgilityPack;
using TxoooProductUpload.Entities.Product;
using CCWin.SkinControl;
using System.Linq;
using System.Collections.Generic;
using CCWin;
using TxoooProductUpload.UI.Common;
using TxoooProductUpload.UI.Service.Entities;
using TxoooProductUpload.UI.Common.Const;
using System.Threading.Tasks;
using System.Threading;

namespace TxoooProductUpload.UI.Forms.SubForms
{

    /// <summary>
    /// 抓取商品
    /// </summary>
    public partial class CrawlProductsForm : Form
    {

        bool _isAuto = false;  //自动抓取全部列表

        List<ProductSourceInfo> _productList = new List<ProductSourceInfo>();
        CrawlType _crawlType = CrawlType.None;
        ///// <summary>
        ///// 当前页面的html
        ///// </summary>
        //public string Html { set; get; }


        public CrawlProductsForm()
        {
            InitializeComponent();

            Load += CrawlProductsForm_Load;
        }

        private void CrawlProductsForm_Load(object sender, EventArgs e)
        {
            InitMenuEvent();
            InitDgv();
            InitControlBtnEvent();

            tsTxtUrl.TextChanged += TsTxtUrl_TextChanged;

            bs.DataSource = _productList;

            tsBtnAutoAll.Click += TsBtnAutoAll_Click;
        }

        private void TsBtnAutoAll_Click(object sender, EventArgs e)
        {
            //NextPageList();
            if (tsBtnAutoAll.Text == "自动")
            {
                _isAuto = true;
                tsBtnAutoAll.Text = "暂停";
                CrawProduct();
            }
            else
            {
                _isAuto = false;
                tsBtnAutoAll.Text = "自动";
            }
        }

        #region 页面变更时发生
        void TsTxtUrl_TextChanged(object sender, EventArgs e)
        {
            var url = tsTxtUrl.Text.Trim();
            if (url.IndexOf("s.taobao.com/search") > -1)
            {
                _crawlType = CrawlType.TaoBaoSearch;
            }
            else if (url.IndexOf("item.taobao.com") > -1)
            {
                _crawlType = CrawlType.TaoBaoItem;
            }

            switch (_crawlType)
            {
                case CrawlType.None:
                    tsBtnAutoAll.Enabled = tsBtnOneProduct.Enabled = tsBtnPageProducts.Enabled = false;
                    break;
                case CrawlType.TaoBaoSearch:
                    tsBtnAutoAll.Enabled = tsBtnPageProducts.Enabled = true;
                    break;
                case CrawlType.TaoBaoItem:
                    tsBtnOneProduct.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 底部控制菜单相关
        void InitControlBtnEvent()
        {
            tssBtnBatchDel.Click += ControlBtn_Click;
            tssBtnBatchEditClass.Click += ControlBtn_Click;
            tssBtnNext.Click += ControlBtn_Click;
            tssBtnPrevious.Click += ControlBtn_Click;
        }


        void ControlBtn_Click(object sender, EventArgs e)
        {
            ToolStripStatusLabel current = sender as ToolStripStatusLabel;
            switch (current.Tag.ToString())
            {
                case "prev":
                    break;
                case "next":
                    break;
                case "del":
                    DeleteRows();
                    break;
                case "class":
                    break;
                default:
                    break;
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

        #region 商品展示表格相关  第一步用的
        void InitDgv()
        {
            InitDgvAllSelect();
            sdgvProduct.CellContentClick += SdgvProduct_CellContentClick;
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

        #region 控制菜单相关事件
        void InitMenuEvent()
        {
            tsBtnGO.Click += TsBtnGO_Click;
            tsBtnLeft.Click += TsBtnLeft_Click;
            tsBtnRight.Click += TsBtnRight_Click;
            tsBtnRefresh.Click += TsBtnRefresh_Click;
            tsTxtUrl.KeyUp += TsTxtUrl_KeyUp;
            webBrowser.AddressChanged += WebBrowser_AddressChanged;

            webBrowser.LoadEnd += WebBrowser_LoadEnd;

            tsBtnPageProducts.Click += TsBtnTest_Click;
        }


        void WebBrowser_LoadEnd(object sender, Xilium.CefGlue.WindowsForms.LoadEndEventArgs e)
        {
            //var url = tsTxtUrl.Text;
            //tsBtnAutoAll.Enabled = tsBtnPageProducts.Enabled = url.IndexOf("s.taobao.com/search") > -1;
        }

        void WebBrowser_AddressChanged(object sender, Xilium.CefGlue.WindowsForms.AddressChangedEventArgs e)
        {
            tsTxtUrl.Text = webBrowser.Browser.GetMainFrame().Url;
            tsBtnLeft.Enabled = webBrowser.Browser.CanGoBack;
            tsBtnRight.Enabled = webBrowser.Browser.CanGoForward;
            if (_isAuto)
            {
                Thread.Sleep(1000);
                CrawProduct();
            }
        }


        /// <summary>
        /// 获取页面HTML
        /// </summary>
        /// <param name="callBack"></param>
        void HtmlChange(Action<string> callBack)
        {
            if (webBrowser.Browser.GetMainFrame().IsMain)
            {
                var visitor = new SourceVisitor(callBack);
                webBrowser.Browser.GetMainFrame().GetSource(visitor);
            }
        }

        void TsBtnTest_Click(object sender, EventArgs e)
        {
            CrawProduct();
        }

        void TsBtnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser.Browser.Reload();
        }

        void TsBtnRight_Click(object sender, EventArgs e)
        {
            webBrowser.Browser.GoForward();
        }

        void TsBtnLeft_Click(object sender, EventArgs e)
        {
            webBrowser.Browser.GoBack();
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
            webBrowser.Browser.GetMainFrame().LoadUrl(tsTxtUrl.Text);
        }
        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ChangeClassForm changeClassForm = new ChangeClassForm();

            changeClassForm.OnChangeClass += (s, eventArgs) =>
           {
               MessageBoxEx.Show("修改为了" + eventArgs.ClassId);
           };
            changeClassForm.ShowDialog(this);
        }

        #region 抓取商品
        /// <summary>
        /// 抓取商品
        /// </summary>
        void CrawProduct()
        {
            HtmlChange(Html =>
            {
                BeginInvoke(new Action(() =>
                {
                    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                    document.LoadHtml(Html);

                    var productNodeList = document.GetElementbyId("mainsrp-itemlist").SelectNodes("//div[starts-with(@class,'item J_MouserOnverReq')]");
                    HtmlNode temp = null;
                    foreach (HtmlNode categoryNode in productNodeList)
                    {
                        temp = HtmlNode.CreateNode(categoryNode.OuterHtml);
                        var picElement = temp.SelectSingleNode("//a[starts-with(@class,'pic-link')]");
                        var idStr = picElement.Attributes["trace-nid"].Value;
                        if (!string.IsNullOrEmpty(idStr))
                        {
                            var id = Convert.ToInt64(idStr);
                            if (_productList.Exists(m => m.Id == id)) { continue; }

                            ProductSourceInfo product = new ProductSourceInfo(id);
                            product.SourceType = temp.SelectSingleNode("//span[@class='icon-service-tianmao']") == null ?
                                SourceType.Taobao : SourceType.Tamll;

                            product.ShowPrice = Convert.ToDouble(picElement.Attributes["trace-price"].Value ?? "0");
                            product.FirstImg = picElement.SelectSingleNode("//img").Attributes["data-src"].Value;

                            product.IsFreePostage = temp.SelectSingleNode("//span[@class='baoyou-intitle icon-service-free']") != null;
                            product.ProductName = temp.SelectSingleNode("//a[@class='J_ClickStat']").InnerText.Trim();

                            product.DealCnt = Convert.ToInt32(temp.SelectSingleNode("//div[@class='deal-cnt']").InnerText.Trim().Replace("人付款", ""));
                            product.UserNick = temp.SelectSingleNode("//a[@class='shopname J_MouseEneterLeave J_ShopInfo']").InnerText;
                            product.UserId = Convert.ToInt64(temp.SelectSingleNode("//a[@class='shopname J_MouseEneterLeave J_ShopInfo']").Attributes["data-userid"].Value);
                            product.Location = temp.SelectSingleNode("//div[@class='location']").InnerText.Trim();

                            bs.Add(product);
                        }
                    }
                    sdgvProduct.FirstDisplayedScrollingRowIndex = sdgvProduct.Rows.Count - 1;
                    if (_isAuto)
                    {
                        //循环到最后一页  退出循环
                        if (document.DocumentNode.SelectNodes("//span[@class='icon icon-btn-next-2-disable']") != null)
                        {
                            _isAuto = false;
                            MessageBoxEx.Show("抓取完毕，共抓取商品{0}条".FormatWith(sdgvProduct.Rows.Count));
                            return;
                        }
                        NextPageList();
                    }
                }));
            });
        }
        #endregion

        /// <summary>
        /// 下一页
        /// </summary>
        void NextPageList()
        {
            webBrowser.Browser.GetMainFrame().ExecuteJavaScript("document.getElementsByClassName('icon-btn-next-2')[0].click()", "", 0);
        }
    }
}

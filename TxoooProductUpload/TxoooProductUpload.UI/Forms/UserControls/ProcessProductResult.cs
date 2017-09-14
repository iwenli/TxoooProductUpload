using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.UI.Common.Extended.Winform;
using CCWin;
using TxoooProductUpload.UI.Common.Const;
using TxoooProductUpload.UI.Common;
using TxoooProductUpload.Entities.Product;
using System.Threading;
using TxoooProductUpload.UI.Service.Cache.ProductCache;

namespace TxoooProductUpload.UI.Forms.UserControls
{
    public partial class ProcessProductResult : UserControl
    {
        #region 变量
        int _threadCount = 5;   //处理任务线程数 
        List<ProductSourceInfo> _waitUploadImageList;
        #endregion

        #region 属性
        /// <summary>
        /// 商品缓存
        /// </summary>
        ProductCacheData ProductCache { set; get; }
        #endregion

        public ProcessProductResult()
        {
            InitializeComponent();
            ProductCache = ProductCacheContext.Instance.Data;
            Load += ProcessProductResult_Load;
        }

        void ProcessProductResult_Load(object sender, EventArgs e)
        {
            ProductDGV.DataError += (_s, _e) => { };  //重写DataError事件
            InitDgvAllSelect(); //全选相关
            InitTsBtnEvent();  //批量操作相关
            InitContextMenuEvent();  //右键菜单相关
            //ProductBindSource.DataSource
        }

        void UploadProductImage()
        {
            Task.Run(() =>
            {
                //var list = ProductBindSource.DataSource as List<ProductSourceInfo>;
                //Parallel.For(0, list.Count, (i) => {
                //    //ProductSourceInfo product = list[i];
                //    App.Context.ProductService.UploadProductImage(list[i]);
                //});
                //MessageBoxEx.Show("图片处理完成");
                _waitUploadImageList = new List<ProductSourceInfo>();
                _waitUploadImageList.AddRange(ProductCache.WaitUploadImageList);
                Invoke(new Action(() =>
                {
                    tsBtnUploadImageAllSelect.Enabled = false;
                }));
                
                var cts = new CancellationTokenSource();
                var tasks = new Task[_threadCount];
                for (int i = 0; i < _threadCount; i++)
                {
                    tasks[i] = new Task(() => UploadImageTask(cts.Token), cts.Token, TaskCreationOptions.LongRunning);
                    tasks[i].Start();
                }
                Task.Run(async () =>
                {
                    while (true)
                    {
                        var allCount = ProductCache.WaitUploadImageList.Count;
                        if (allCount == ProductCache.WaitUploadList.Count + ProductCache.UploadImageFailList.Count)
                        {
                            MessageBoxEx.Show("图片处理完成");
                            Invoke(new Action(() =>
                            {
                                ProductBindSource.DataSource = null;
                                ProductBindSource.DataSource = ProductCache.WaitUploadList;
                                ProductCache.WaitUploadImageList.Clear();
                                MessageShowLable.Text = "本次共处理{0}个商品，处理成功{1}个商品，已更新"
                                    .FormatWith(allCount, ProductCache.WaitUploadList.Count);
                            }));
                            break;
                        }
                        await Task.Delay(1000);
                    }
                });
            });
        }

        #region 右键菜单相关
        void InitContextMenuEvent()
        {
            toolStripMenuItem1.Click += ToolStripMenuItem_Click;
            toolStripMenuItem2.Click += ToolStripMenuItem_Click;
            toolStripMenuItem3.Click += ToolStripMenuItem_Click;
            toolStripMenuItem4.Click += ToolStripMenuItem_Click;
            toolStripMenuItem5.Click += ToolStripMenuItem_Click;
            toolStripMenuItem6.Click += ToolStripMenuItem_Click;
        }

        void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProductDGV.SelectedRows.Count == 1)
            {
                var row = ProductDGV.SelectedRows[0];
                var list = new List<DataGridViewRow>();
                list.Add(row);
                switch ((sender as ToolStripMenuItem).Tag.ToString())
                {
                    case "1":  //查看pc
                        Utils.OpenUrl(ProductDGV.SelectedRows[0].Cells["UrlColumn"].Value.ToString());
                        break;
                    case "2":  //查看手机
                        Utils.OpenUrl(ProductDGV.SelectedRows[0].Cells["H5UrlColumn"].Value.ToString(), true);
                        break;
                    case "3":  //编辑
                        MessageBoxEx.Show("暂不支持编辑商品");
                        break;
                    case "4":  //删除
                        ProductDGV.Rows.Remove(row);
                        break;
                    case "5":  //更改分类
                        SetClassAllSelectRows(list);
                        break;
                    case "6":  //更改发货地
                        SetLocationAllSelectRows(list);
                        break;
                }
            }
        }
        #endregion

        #region 批量操作相关
        /// <summary>
        /// 批量操作相关初始化
        /// </summary>
        void InitTsBtnEvent()
        {
            tsBtnSetClassAllSelect.Click += TsBtnAllSelect_Click;
            tsBtnDeleteAllSelect.Click += TsBtnAllSelect_Click;
            tsBtnSetLocationAllSelect.Click += TsBtnAllSelect_Click;
            tsBtnUploadImageAllSelect.Click += TsBtnAllSelect_Click;
        }

        /// <summary>
        /// 批量操作事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TsBtnAllSelect_Click(object sender, EventArgs e)
        {
            ToolStripButton current = sender as ToolStripButton;
            switch (current.Name.ToString())
            {
                case "tsBtnSetClassAllSelect":
                    SetClassAllSelectRows(GetSelectRow());
                    break;
                case "tsBtnDeleteAllSelect":
                    DeleteAllSelectRows(GetSelectRow());
                    break;
                case "tsBtnSetLocationAllSelect":
                    SetLocationAllSelectRows(GetSelectRow());
                    break;
                case "tsBtnUploadImageAllSelect":  //转换图片
                    UploadProductImage();
                    break;
            }
        }

        /// <summary>
        /// 批量设置选中行的发货地
        /// </summary>
        void SetLocationAllSelectRows(List<DataGridViewRow> rows)
        {
            if (rows != null)
            {
                ChangeLocationForm cangeLocationForm = new ChangeLocationForm();

                cangeLocationForm.OnChangeLocation += (s, eventArgs) =>
                {
                    foreach (var row in rows)
                    {
                        row.Cells["RegionCodeColumn"].Value = eventArgs.RegionCode;
                        row.Cells["RegionNameColumn"].Value = eventArgs.RegionName;
                    }
                };
                cangeLocationForm.ShowDialog(this);
            }
        }
        /// <summary>
        /// 批量设置选中行的分类
        /// </summary>
        void SetClassAllSelectRows(List<DataGridViewRow> rows)
        {
            if (rows != null)
            {
                ChangeClassForm changeClassForm = new ChangeClassForm();

                changeClassForm.OnChangeClass += (s, eventArgs) =>
                {
                    //MessageBoxEx.Show("修改为了" + eventArgs.ClassId);
                    foreach (var row in rows)
                    {
                        row.Cells["ClassTypeColumn"].Value = eventArgs.TypeService;
                        row.Cells["SettlementRatioColumn"].Value = eventArgs.Proportion;
                        row.Cells["PremiumRatioColumn"].Value = eventArgs.Proportion;
                        row.Cells["ClassIdColumn"].Value = eventArgs.ClassId;
                        row.Cells["ClassNameColumn"].Value = eventArgs.ClassNameShow;
                    }
                };
                changeClassForm.ShowDialog(this);
            }
        }

        /// <summary>
        /// 删除选中行
        /// </summary>
        void DeleteAllSelectRows(List<DataGridViewRow> rows)
        {
            if (rows != null)
            {
                foreach (var item in rows)
                {
                    ProductDGV.Rows.Remove(item);
                }
            }
        }

        /// <summary>
        /// 获取选中的行 无选中返回null
        /// </summary>
        /// <returns></returns>
        List<DataGridViewRow> GetSelectRow()
        {
            ProductDGV.EndEdit();
            var selRows = ProductDGV.Rows.OfType<DataGridViewRow>().Where(m => m.Cells[0].Value != null && m.Cells[0].Value.ToString() == "True").ToList();
            if (selRows.Count == 0)
            {
                MessageBoxEx.Show("请选中要操作的商品", AppInfo.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return selRows;
        }
        #endregion

        #region DataGridView全选
        /// <summary>
        /// DataGridView全选初始化
        /// </summary>
        void InitDgvAllSelect()
        {
            DataGridViewCheckBoxColumn colCB = new DataGridViewCheckBoxColumn();
            DataGridViewCheckBoxHeaderCell cbHeader = new DataGridViewCheckBoxHeaderCell();
            colCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colCB.HeaderText = "全选";
            colCB.Width = 30;
            colCB.HeaderCell = cbHeader;
            ProductDGV.Columns.Insert(0, colCB);
            cbHeader.OnCheckBoxClicked += CbHeader_OnCheckBoxClicked;
        }

        void CbHeader_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {
            ProductDGV.EndEdit();
            ProductDGV.Rows.OfType<DataGridViewRow>().ToList().ForEach(t => t.Cells[0].Value = e.CheckedState);
        }
        #endregion

        #region 上传商品图片
        /// <summary>
        /// 上传商品图片
        /// </summary>
        async void UploadImageTask(CancellationToken token)
        {
            try
            {
                ProductSourceInfo task;
                while (!token.IsCancellationRequested)
                {
                    task = null;
                    lock (_waitUploadImageList)
                    {
                        if (_waitUploadImageList.Count > 0)
                        {
                            task = _waitUploadImageList[0];
                            _waitUploadImageList.Remove(task);
                        }
                    }
                    //没有则退出
                    if (task == null)
                    {
                        break;
                    }
                    try
                    {
                        await App.Context.ProductService.UploadProductImage(task);
                        lock (ProductCache.WaitUploadList)
                        {
                            ProductCache.WaitUploadList.Add(task);

                            if (ProductCache.WaitUploadList.Count > 0 && ProductCache.WaitUploadList.Count % 20 == 0)
                            {
                                //每成功20个手动释放一下内存
                                GC.Collect();
                                //保存任务数据，防止什么时候宕机了任务进度回滚太多
                                ProductCacheContext.Instance.Save();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lock (ProductCache.UploadImageFailList)
                        {
                            ProductCache.UploadImageFailList.Add(task);
                        }
                        Iwenli.LogHelper.LogError(this,
                            "[上传图片]{0}商品{1}异常：{2}".FormatWith(task.SourceName, task.Id, ex.Message));
                    }
                    //等待一分钟 在执行下一个
                    await Task.Delay(1000, token);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion
    }
}

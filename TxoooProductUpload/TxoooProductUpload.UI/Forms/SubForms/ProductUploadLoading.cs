using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.Common;
using TxoooProductUpload.Entities.Product;
using TxoooProductUpload.Service;
using TxoooProductUpload.UI.Service.Cache.ProductCache;
using Iwenli;
using TxoooProductUpload.UI.Common;

namespace TxoooProductUpload.UI.Forms.SubForms
{
    public partial class ProductUploadLoading : LoadingForm
    {
        #region 变量
        List<ProductSourceInfo> _waitUploadImageList;
        int _processType = -1;
        #endregion

        #region 属性
        /// <summary>
        /// 商品缓存
        /// </summary>
        ProductCacheData ProductCache { set; get; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 任务显示等待的名称，任务类型0上传图片  1上传商品
        /// </summary>
        /// <param name="title"></param>
        /// <param name="processType"></param>
        public ProductUploadLoading(string title, int processType) : base(title)
        {
            InitializeComponent();
            _processType = processType;
            Load += ProductUploadLoading_Load;
        }

        private ProductUploadLoading() { }
        #endregion

        async void ProductUploadLoading_Load(object sender, EventArgs e)
        {
            App.Context.ProductService.OnSendMessage += Event_OnSendMessage;
            ProductCache = ProductCacheContext.Instance.Data;
            await Task.Delay(1000);
            await RunTask();
        }

        /// <summary>
        /// 启动任务
        /// </summary>
        /// <returns></returns>
        async Task RunTask()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(async () =>
                {
                    await RunTask();
                }));
                return;
            }
            if (_processType == 0)
            {
                MaxTaskCount = ProductCache.WaitUploadImageList.Count;
                UploadImage();
            }
            else if (_processType == 1)
            {
                MaxTaskCount = ProductCache.WaitUploadList.Count;
                UploadProduct();
            }
            UploadProgressSatate();
        }

        #region 上传商品图片
        /// <summary>
        /// 批量上传商品图片
        /// </summary>
        void UploadImage()
        {
            var taskCount = AppSetting.MaxThreadCount;
            var allCount = ProductCache.WaitUploadImageList.Count;
            if (allCount <= 0) return;

            AppendLogWarning("[全局]开始上传图片到图片服务器...");
            AppendLogWarning("[全局]上传线程{0}个...", taskCount);
            _waitUploadImageList = new List<ProductSourceInfo>();
            _waitUploadImageList.AddRange(ProductCache.WaitUploadImageList);
            var cts = new CancellationTokenSource();
            if (taskCount > allCount)
            {
                taskCount = taskCount > allCount ? allCount : taskCount;
            }
            var tasks = new Task[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                tasks[i] = new Task(() => UploadImageTask(cts.Token), cts.Token, TaskCreationOptions.LongRunning);
                tasks[i].Start();
                AppendLogWarning("[全局]线程{0}启动...", i + 1);
            }

            Task.Run(async () =>
            {
                while (true)
                {
                    if (allCount > 0 && allCount == ProductCache.WaitUploadList.Count + ProductCache.UploadImageFailList.Count)
                    {
                        CloseWithResult("图片处理完成...");
                        break;
                    }
                    await Task.Delay(1000);
                }
            });
        }

        /// <summary>
        /// 上传商品图片任务
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
                            AppendLog("{0} 商品 [{1}] 上传图片完成...", task.SourceName, task.Id);
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
                        AppendLogError("{0} 商品 [{1}] 上传图片异常：{2}", task.SourceName, task.Id, ex.Message);
                        Iwenli.LogHelper.LogError(this,
                            "[上传图片]{0}商品{1}异常：{2}".FormatWith(task.SourceName, task.Id, ex.Message), ex);
                    }
                    TaskIndex++;
                    UploadProgressSatate();
                    //等待一分钟 在执行下一个
                    await Task.Delay(1000, token);
                }
            }
            catch (Exception ex)
            {
                Iwenli.LogHelper.LogError(this, "[上传图片]任务异常：{0}".FormatWith(ex.Message), ex);
            }
        }
        #endregion

        #region 上传商品
        /// <summary>
        /// 上传商品入口
        /// </summary>
        void UploadProduct()
        {
            int taskCount = AppSetting.MaxThreadCount;
            //商品上传线程减半
            if (taskCount > 8)
            {
                taskCount = (int)Math.Truncate(taskCount / 2.0);
            }

            var allCount = ProductCache.WaitUploadList.Count;
            if (allCount <= 0) return;

            AppendLogWarning("[全局]开始上传商品...");
            AppendLogWarning("[全局]上传线程共{0}个...", taskCount);
            var cts = new CancellationTokenSource();
            if (taskCount > allCount)
            {
                taskCount = taskCount > allCount ? allCount : taskCount;
            }
            var tasks = new Task[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                tasks[i] = new Task(() => UploadTask(cts.Token), cts.Token, TaskCreationOptions.LongRunning);
                tasks[i].Start();
                AppendLogWarning("[全局]线程{0}启动...", i + 1);
            }
            Task.Run(async () =>
            {
                while (true)
                {
                    if (ProductCache.WaitUploadList.Count == 0 && allCount == ProductCache.UploadFailList.Count + ProductCache.UploadSuccessList.Count)
                    {
                        try
                        {
                            var result = await App.Context.ProductService.InsertProductsSourceAsync(ProductCache.UploadSuccessList);
                            if (!result)
                            {
                                this.LogError("上传商品来源失败");
                            }
                        }
                        catch (Exception ex)
                        {
                            this.LogError("上传商品来源异常：" + ex.Message, ex);
                        }

                        CloseWithResult("商品上传完成...");
                        break;
                    }
                    await Task.Delay(1500);
                }
            });
        }
        /// <summary>
        /// 上传商品任务
        /// </summary>
        async void UploadTask(CancellationToken token)
        {
            try
            {
                ProductSourceInfo task;
                while (!token.IsCancellationRequested)
                {
                    task = null;
                    lock (ProductCache)
                    {
                        if (ProductCache.WaitUploadList.Count > 0)
                        {
                            task = ProductCache.WaitUploadList[0];
                            ProductCache.WaitUploadList.Remove(task);
                        }
                    }
                    //没有则退出
                    if (task == null)
                    {
                        break;
                    }
                    try
                    {
                        await App.Context.ProductService.UploadProduct(task);
                        lock (ProductCache.UploadSuccessList)
                        {
                            ProductCache.UploadSuccessList.Add(task);
                            AppendLog("{0} 商品 {1} 上传成功,新商品链接：{2}...", task.SourceName, task.Id, task.GetTxoooUrl(ApiList.IsTest));
                            if (ProductCache.UploadSuccessList.Count > 0 && ProductCache.UploadSuccessList.Count % 20 == 0)
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
                        lock (ProductCache.UploadFailList)
                        {
                            ProductCache.UploadFailList.Add(task);
                        }
                        AppendLogError("{0} 商品 [{1}] 上传异常：{2}", task.SourceName, task.Id, ex.Message);
                        Iwenli.LogHelper.LogError(this,
                            "[上传商品]{0}商品{1}异常：{2}".FormatWith(task.SourceName, task.Id, ex.Message), ex);
                    }
                    TaskIndex++;
                    UploadProgressSatate();
                    //等待一分钟 在执行下一个
                    await Task.Delay(1000, token);
                }
            }
            catch (Exception ex)
            {
                Iwenli.LogHelper.LogError(this, "[上传商品]任务异常：{0}".FormatWith(ex.Message), ex);
            }

        }
        #endregion

        /// <summary>
        /// 全局退出处理
        /// </summary>
        /// <param name="msg"></param>
        async void CloseWithResult(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    CloseWithResult(msg);
                }));
                return;
            }
            AppendLogWarning("[全局]{0}", msg);
            await Task.Delay(2000);
            DialogResult = DialogResult.OK;
            Close();
        }


    }
}

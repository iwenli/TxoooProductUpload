using FSLib.Network.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.Common;
using TxoooProductUpload.Network;
using TxoooProductUpload.Service;
using TxoooProductUpload.Service.ImageDownload;

namespace TxoooProductUpload.UI.ImageDownload
{
    /// <summary>
    /// 抓取头像
    /// </summary>
    partial class Crawler : FormBase
    {
        #region 页面变量
        /// <summary>
        /// 取消令牌来源
        /// </summary>
        //CancellationTokenSource _cts = null;
        /// <summary>
        /// 设置是否允许关闭的标记位
        /// </summary>
        bool _shutdownFlag = false;
        /// <summary>
        /// 图像抓取任务
        /// </summary>
        Task _imageTask = null;
        /// <summary>
        /// 详情抓取任务
        /// </summary>
        Task _detailTask = null;
        /// <summary>
        /// 页面抓取任务
        /// </summary>
        Task _pageTask = null;
        #endregion

        /// <summary>
        /// 抓取图片
        /// </summary>
        /// <param name="serviceContext"></param>
        public Crawler(ServiceContext serviceContext)
        {
            _context = serviceContext;
            InitializeComponent();
            Init();
        }

        public Crawler()
        {
            _context = new ServiceContext();
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        void Init()
        {
            this.Text = "图片管理  " + ConstParams.APP_NAME;
            _pageTask = _detailTask = _imageTask = null;

            //启动任务
            StartTask();

            //下载按钮
            btnAddSource.Click += (s, e) => { RunTask(); };

        }

        #region 事件
        void StartTask()
        {
            var cts = new CancellationTokenSource();
            AppendLog(txtLog, "[全局] 正在初始化...");
            TaskContext.Instance.Init();
            AppendLog(txtLog, "[全局] 初始化完成...");

            AppendLog(txtLog, "[全局] 启动站点检测任务...");
            _pageTask = new Task(() => GrabDetailPagesTaskThreadEntry(cts.Token), cts.Token, TaskCreationOptions.LongRunning);
            _pageTask.Start();
            AppendLog(txtLog, "[全局] 站点检测任务已启动...");

            AppendLog(txtLog, "[全局] 启动详情页抓取任务...");
            _detailTask = new Task(() => GrabImageListTaskThreadEntry(cts.Token), cts.Token, TaskCreationOptions.LongRunning);
            _detailTask.Start();
            AppendLog(txtLog, "[全局] 详情页抓取任务已启动...");

            AppendLog(txtLog, "[全局] 启动图片下载任务...");
            _imageTask = new Task(() => DownloadImageTaskEntry(cts.Token), cts.Token, TaskCreationOptions.LongRunning);
            _imageTask.Start();
            AppendLog(txtLog, "[全局] 图片下载任务已启动...");
            //捕捉窗口关闭事件
            //主要是给一个机会等待任务完成并把任务数据都保存
            FormClosing += async (s, e) =>
            {
                if (_shutdownFlag)
                    return;
                e.Cancel = !_shutdownFlag;
                AppendLogWarning(txtLog, "[全局] 等待任务结束...");
                try
                {
                    cts.Cancel();
                    await _pageTask;
                    await _detailTask;
                    await _imageTask;
                }
                catch (Exception ex)
                {
                    AppendLogError(txtLog, "[全局] 异常发生在=>{0}", ex.Message);
                }
                _shutdownFlag = true;
                TaskContext.Instance.Save();
                Close();
            };
        }
        /// <summary>
        /// 创图关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //async void FormClosingEvent(object sender, FormClosingEventArgs e)
        //{
        //    if (_shutdownFlag)
        //        return;
        //    e.Cancel = !_shutdownFlag;
        //    AppendLogWarning(txtLog, "[全局] 等待任务结束...");
        //    try
        //    {
        //        _cts.Cancel();
        //        await _sourceTask;
        //        //await _pageTask;
        //        //await _detailTask;
        //        //await _imageTask;
        //    }
        //    catch (Exception ex)
        //    {
        //        AppendLogError(txtLog, "[全局] 异常发生在=>{0}", ex.Message);
        //    }
        //    _shutdownFlag = true;
        //    TaskContext.Instance.Save();
        //    Close();
        //}

        private void RunTask()
        {
            //验证url
            var url = txtSourceSite.Text.Trim();
            if (!url.IsUrl())
            {
                IS("请输入正确网址！");
                return;
            }
            var data = TaskContext.Instance.Data;
            if (data.WaitForProcessSourceTasks.Where(m => m.Url == url).Count() > 0 || data.SourceProcessed.ContainsKey(url))
            {
                IS("该站点已经处理过！");
                return;
            }

            lock (data.WaitForProcessSourceTasks)
            {
                data.WaitForProcessSourceTasks.Enqueue(new SourceTask() { Url = url });
            }
            AppendLog(txtLog, "[全局] 添加站点成功...");
        }
        #endregion

        #region  抓取任务
        /// <summary>
        /// 抓取详情页
        /// </summary>
        /// <param name="token"></param>
        async void GrabDetailPagesTaskThreadEntry(CancellationToken token)
        {
            //AppendLogWarning(txtLog, "[图片来源检测] 正在加载来源数据...");
            var client = _context.Session.NetClient;
            var data = TaskContext.Instance.Data;

            ////这里创建了一个 CancellationTokenSource 的局部变量，主要是为了在循环中对请求也能进行中断
            //CancellationTokenSource tcs = new CancellationTokenSource();
            //token.Register(() => tcs?.Cancel());

            SourceTask task;

            while (!token.IsCancellationRequested)
            {
                task = null;

                #region 站点数据
                //检查下载队列，看是否有姑娘的地址搭讪到了……
                lock (data.WaitForProcessSourceTasks)
                {
                    if (data.WaitForProcessSourceTasks.Count > 0)
                    {
                        task = data.WaitForProcessSourceTasks.Dequeue();
                    }
                }
                //没有或已经下载过的话，则休息后重新检查
                if (task == null || data.SourceProcessed.ContainsKey(task.Url))
                {
                    AppendLogWarning(txtLog, "[图片来源站点] 暂无待处理站点,5秒后重新检测...");
                    //等待5秒再去检测
                    Thread.Sleep(5000);
                    //tcs = null;
                    continue;
                }
                AppendLog(txtLog, "[图片来源站点] 开始处理站点：{0}...", task.Url);
                #endregion

                #region 处理页面
                var hasMore = true;
                var page = 1;
                string urlFormat = @"http://www.qqmofasi.com/touxiang/page-{0}.html";
                while (hasMore)
                {
                    if (page % 100 == 0)
                    {
                        AppendLog(txtLog, "[断点]  当前页面", task.Url, page);
                    }
                    AppendLog(txtLog, "[页面列表] 正在加载站点：{0} 的第 {1} 页...", task.Url, page);
                    var ctx = client.Create<string>(HttpMethod.Get, urlFormat.FormatWith(page), allowAutoRedirect: true);
                    await ctx.SendAsync();
                    if (!ctx.IsValid())
                    {
                        //失败 10秒后重试
                        AppendLog(txtLog, "[页面列表] 站点：{0} 的第 {1} 页下载失败，稍后重试", task.Url, page);
                        Thread.Sleep(new TimeSpan(0, 0, 10));
                    }
                    else
                    {
                        //下载成功，获得列表
                        var matches = Regex.Matches(ctx.Result, @"<a href=['""]([^['""]+)['""] class=['""]item_tit['""] title=['""]([^['""]+)['""]>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                        //新的任务
                        var newTasks = matches.Cast<Match>()
                                            .Select(s => new PageTask(s.Groups[2].Value, s.Groups[1].Value))
                                            .Where(s => !data.PageDownloaded.ContainsKey(s.Url) && !data.WaitForDownloadPageTasks.Any(_ => _.Url == s.Url))
                                            .ToArray();
                        if (newTasks.Length > 0)
                        {
                            lock (data.WaitForDownloadPageTasks)
                            {
                                newTasks.ForEach(s =>
                                {
                                    data.WaitForDownloadPageTasks.Enqueue(s);
                                });
                            }
                            AppendLog(txtLog, "[页面列表] 站点：{0} 已建立 {1} 个新任务到队列中...", task.Url, newTasks.Length);
                            UpdatePageDetailGrabStatus();
                        }
                        //else if (data.FullyDownloaded)
                        //{
                        //    //没有更多记录，退出循环
                        //    AppendLog(txtLog, "[页面列表] 站点：{0} 没有更多新纪录，退出抓取...", task.Url);
                        //    break;
                        //}
                        //如果没有下一页，则中止
                        if (!Regex.IsMatch(ctx.Result, @"<a href=['""]/touxiang/page-\w+.html['""]>下页<\/a>", RegexOptions.IgnoreCase))
                        {
                            AppendLog(txtLog, "[页面列表] 站点：{0} 没有更多新纪录，尝试检查其他站点...", task.Url);
                            hasMore = false;
                            continue;
                        }
                        //等待2秒继续
                        Thread.Sleep(2000);
                        page++;
                    }
                }
                #endregion

                //存放来源到已处理列表
                data.SourceProcessed.Add(task.Url, task);
            }

        }

        /// <summary>
        /// 详情下载分解图片
        /// </summary>
        /// <param name="token"></param>
        void GrabImageListTaskThreadEntry(CancellationToken token)
        {
            var client = new HttpClient();
            var data = TaskContext.Instance.Data;

            PageTask currentTask;

            //token是用来控制队列退出的
            while (!token.IsCancellationRequested)
            {
                currentTask = null;

                //对队列进行加锁，防止详情页爬虫意外修改队列
                lock (data.WaitForDownloadPageTasks)
                {
                    //如果有任务，则出队
                    if (data.WaitForDownloadPageTasks.Count > 0)
                    {
                        currentTask = data.WaitForDownloadPageTasks.Dequeue();
                    }
                }
                //如果没有任务，则等待100毫秒后继续查询任务
                if (currentTask == null)
                {
                    Thread.Sleep(100);
                    continue;
                }

                AppendLog(txtLog, "[详情页抓取] 正在抓取页面 【{0}】 ...", currentTask.Name);

                //防止该死的标题过长……这个是后来加的，因为后拉发现有的标题居然长到让文件系统报错了……
                currentTask.Root = currentTask.Name.GetSubString(40);

                //创建上下文。注意 allowAutoRedirect，因为这里可能会存在重定向，而我们并不关心不是302.
                var ctx = client.Create<string>(HttpMethod.Get, currentTask.Url, allowAutoRedirect: true);

                //这里用的是同步模式，非任务模式。这个方法会阻塞当前线程直到请求结束
                ctx.Send();

                if (ctx.IsValid())
                {
                    //页面有效
                    var html = ctx.Result;

                    //查出所有头像，然后与已下载和已入列的对比，排除重复后将其加入下载队列

                    //List<ImageDownloadTask> imgTaskList = new List<ImageDownloadTask>();
                    var imgTasks = Regex.Matches(html, @"<img src=['""]([^['""]+)['""].*?title=['""]([^['""]+)['""]\s/>", RegexOptions.IgnoreCase | RegexOptions.Singleline)
                    .Cast<Match>().Select(s => new ImageDownloadTask(s.Groups[1].Value, currentTask.Root))
                    .Where(s =>
                    {
                        var ret = !data.DownloadedImages.ContainsKey(s.Url) && !data.ImageDownloadTasks.Any(_ => _.Url == s.Url);
                        if (!ret)
                        {
                            AppendLog(txtLog, "[详情页抓取] 图片地址 {0} 已加入队列过，此次跳过.", s);
                        }
                        return ret;
                    })
                    .ToArray();
                    if (imgTasks.Length > 0)
                    {
                        lock (data.ImageDownloadTasks)
                        {
                            imgTasks.ForEach(task =>
                            {
                                data.ImageDownloadTasks.Enqueue(task);
                            });
                        }
                        UpdateImageDownloadStatus();
                        AppendLog(txtLog, "[详情页抓取] 从页面 【{0}】中获得 {1} 图片地址到任务列表 ...", currentTask.Url, imgTasks.Length);
                    }
                    else
                    {
                        AppendLog(txtLog, "[详情页抓取] 从页面 【{0}】中未获得任何图片地址，请检查是否正常 ...", currentTask.Url);
                    }
                    data.PageDownloaded.Add(currentTask.Url, currentTask);
                    UpdatePageDetailGrabStatus();
                    Thread.Sleep(1000);
                }
                else
                {
                    //不成功，则将当前任务重新入队后，继续处理
                    lock (data.WaitForDownloadPageTasks)
                    {
                        data.WaitForDownloadPageTasks.Enqueue(currentTask);
                    }
                    UpdatePageDetailGrabStatus();
                    AppendLog(txtLog, "[详情页抓取] 页面抓取失败，重新入队等待处理。");
                    Thread.Sleep(2000);
                }
            }
        }

        /// <summary>
        /// 图片下载任务
        /// </summary>
        /// <param name="token"></param>
        async void DownloadImageTaskEntry(CancellationToken token)
        {
            var client = new HttpClient();
            var data = TaskContext.Instance.Data;
            var random = new Random();
            var cleanupcount = 0;

            //这里创建了一个 CancellationTokenSource 的局部变量，主要是为了在循环中对请求也能进行中断
            CancellationTokenSource tcs = null;
            token.Register(() => tcs?.Cancel());

            ImageDownloadTask task;

            while (!token.IsCancellationRequested)
            {
                task = null;

                //检查下载队列，看是否有姑娘的地址搭讪到了……
                lock (data.ImageDownloadTasks)
                {
                    if (data.ImageDownloadTasks.Count > 0)
                    {
                        task = data.ImageDownloadTasks.Dequeue();
                    }
                }
                //没有或已经下载过的话，则休息后重新检查
                if (task == null || data.DownloadedImages.ContainsKey(task.Url))
                {
                    Thread.Sleep(100);
                    continue;
                }

                //开始下载
                AppendLog(txtLog, "[图片下载] 正在下载自 {0} ...", task.Url);

                using (var ctx = client.Create<byte[]>(HttpMethod.Get, task.Url))
                {
                    //这里的token必须用新的，否则会导致内存短期内无法释放，内存暴涨
                    tcs = new CancellationTokenSource();
                    await ctx.SendAsync(tcs.Token);
                    tcs = null;

                    if (ctx.IsValid())
                    {
                        //成功，保存。优先取URL地址中的文件名作为保存的文件名
                        var targetFileName = new Uri(task.Url).Segments.LastOrDefault();

                        //如果文件名不合法，则重新生成随机的文件名
                        if (targetFileName.IsNullOrEmpty() || targetFileName.Length > 50 || Path.GetInvalidFileNameChars().Any(s => targetFileName.Contains(s)))
                        {
                            //包含无效的文件名，则重新生成随机的
                            targetFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + random.Next(int.MaxValue) + ".jpg";
                        }
                        task.DownloadRoot = TaskContext.Instance.OutputRoot + "//" + task.DownloadRoot;
                        //如果文件夹不存在，则创建 
                        if (!Directory.Exists(task.DownloadRoot))
                            Directory.CreateDirectory(task.DownloadRoot);

                        //写入文件
                        var targetFullPath = PathUtility.Combine(task.DownloadRoot, targetFileName);
                        File.WriteAllBytes(targetFullPath, ctx.Result);
                        //添加到已完成队列
                        data.DownloadedImages.Add(task.Url, new ImageDownloadTaskInfo() { Location = targetFullPath });

                        //记录
                        AppendLog(txtLog, "[图片下载] 下载成功. ({0})", ctx.Result.Length.ToString());
                    }
                    else
                    {
                        lock (data.ImageDownloadTasks)
                        {
                            data.ImageDownloadTasks.Enqueue(task);
                        }
                        AppendLog(txtLog, "[图片下载] 下载失败。重新加入队列以便于重新下载");
                    }
                }
                UpdateImageDownloadStatus();

                //等待一秒再下下一个图片
                await Task.Delay(1000, token);
                tcs = null;

                if (cleanupcount++ > 20)
                {
                    //每下载20个图片后手动释放一下内存
                    cleanupcount = 0;
                    GC.Collect();
                    //保存任务数据，防止什么时候宕机了任务进度回滚太多
                    TaskContext.Instance.Save();
                }
            }
        }
        #endregion

        #region 进度更新
        /// <summary>
        /// 更新页面抓取进度
        /// </summary>
        void UpdatePageDetailGrabStatus()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdatePageDetailGrabStatus));
                return;
            }
            var data = TaskContext.Instance.Data;
            pbPageGrab.Maximum = data.WaitForDownloadPageTasks.Count + data.PageDownloaded.Count;
            pbPageGrab.Value = pbPageGrab.Maximum - data.WaitForDownloadPageTasks.Count;
            lblPgSt.Text = string.Format("共 {0} 页面，已抓取 {1} 页面 ...", pbPageGrab.Maximum, pbPageGrab.Value);
        }
        /// <summary>
        /// 更新图片抓取进度
        /// </summary>
        void UpdateImageDownloadStatus()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateImageDownloadStatus));
                return;
            }

            var data = TaskContext.Instance.Data;
            pbImageDown.Maximum = data.DownloadedImages.Count + data.ImageDownloadTasks.Count;
            pbImageDown.Value = pbImageDown.Maximum - data.ImageDownloadTasks.Count;
            lblStatPicDownload.Text = string.Format("共 {0} 图片，已抓取 {1} 图片 ...", pbImageDown.Maximum, pbImageDown.Value);
        }

        #endregion
    }
}

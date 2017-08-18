using FSLib.Network.Http;
using Newtonsoft.Json;
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
using TxoooProductUpload.Service.ImageUpload;

namespace TxoooProductUpload.UI.ImageDownload
{
    /// <summary>
    /// 抓取头像
    /// </summary>
    partial class Crawler : FormBase
    {
        #region 页面变量
        /// <summary>
        /// 入库头像SQL Format
        /// </summary>
        string _insertSql = @"INSERT INTO iwenli_headPic(RawUrl, HeadUrl) VALUES('{0}','{1}')";
        /// <summary>
        /// 获取头像ID
        /// </summary>
        string _getIDSql = @"SELECT MAX(ID) AS ID FROM iwenli_headPic";

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
        /// <summary>
        /// 头像上传任务
        /// </summary>
        Task _uploadHeadPicTask = null;
        /// <summary>
        /// 头像入库任务
        /// </summary>
        Task _insertHeadPicTask = null;
        #endregion

        /// <summary>
        /// 抓取图片
        /// </summary>
        /// <param name="serviceContext"></param>
        public Crawler(ServiceContext serviceContext) : this()
        {
            _context = serviceContext;
            InitializeComponent();
            Init();
        }

        public Crawler()
        {
            _context = new ServiceContext();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        void Init()
        {
            this.Text = "图片管理  " + ConstParams.APP_NAME;
            _pageTask = _detailTask = _imageTask = _insertHeadPicTask = _uploadHeadPicTask = null;
            //添加来源JSON
            btnAddSource.Click += (s, e) => { AddSource(); };
            //开始抓取任务
            btnStartTask.Click += btnStartTask_Click;
            //添加来源按钮能否启用检测
            txtSourceSite.TextChanged += (s, e) => { btnAddSource.Enabled = !txtSourceSite.IsValueEmpty(); };
            //生成头像库任务
            btnGenerate.Click += btnGenerate_Click;


            AppendLog(txtLog, "[全局] 正在初始化...");
            Service.ImageDownload.TaskContext.Instance.Init();
            Service.ImageUpload.TaskContext.Instance.Init();
            AppendLog(txtLog, "[全局] 初始化完成...");
        }

        #region 事件
        /// <summary>
        /// 开始抓取任务
        /// </summary>
        void btnStartTask_Click(object sender, EventArgs e)
        {
            btnStartTask.Enabled = btnGenerate.Enabled = false;
            lblStatu1.Text = "页面抓取进度";
            lblStatu2.Text = "图像下载进度";
            var cts = new CancellationTokenSource();

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
            UpdatePageDetailGrabStatus();
            UpdateImageDownloadStatus();
            //捕捉窗口关闭事件
            //主要是给一个机会等待任务完成并把任务数据都保存
            FormClosing += async (s1, e1) =>
            {
                if (_shutdownFlag)
                    return;
                e1.Cancel = !_shutdownFlag;
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
                Service.ImageDownload.TaskContext.Instance.Save();
                Close();
            };
        }
        /// <summary>
        /// 生成头像库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnGenerate_Click(object sender, EventArgs e)
        {
            lblStatu1.Text = "头像上传进度";
            lblStatu2.Text = "头像入库进度";
            btnStartTask.Enabled = btnGenerate.Enabled = btnAddSource.Enabled = false;
            var cts = new CancellationTokenSource();

            //获取当前头像文件根目录
            var headPicDirectory = PathUtility.Combine(Environment.CurrentDirectory, "头像");
            var allHeadPicList = new List<string>();
            allHeadPicList.AddRange(Directory.GetFiles(headPicDirectory, "*.*", SearchOption.AllDirectories));//获取所有头像
            AppendLog(txtLog, "[全局] 本地共获取头像{0}张...", allHeadPicList.Count);

            var data = Service.ImageUpload.TaskContext.Instance.Data;
            //没有处理的头像
            var noProcessHeadPicList = allHeadPicList.Where(m => !data.WaitUploadPath.Contains(m)
                            && !data.WaitInsertImages.Select(_ => _.Path).Contains(m)
                            && !data.ProcessedImages.Select(_ => _.Path).Contains(m)).ToList();
            AppendLog(txtLog, "[全局] 没有进入任务的图片{0}张...", noProcessHeadPicList.Count);
            //进入任务队列
            foreach (var item in noProcessHeadPicList)
            {
                lock (data.WaitUploadPath)
                {
                    data.WaitUploadPath.Enqueue(item);
                }
            }
            AppendLog(txtLog, "[全局] 成功添加{0}张图片进入任务...", noProcessHeadPicList.Count);

            AppendLog(txtLog, "[全局] 启动上传头像任务...");
            _uploadHeadPicTask = new Task(() => UploadHeadPicTask(cts.Token), cts.Token, TaskCreationOptions.LongRunning);
            _uploadHeadPicTask.Start();
            AppendLog(txtLog, "[全局] 上传头像任务已启动...");

            AppendLog(txtLog, "[全局] 启动头像入库任务...");
            _insertHeadPicTask = new Task(() => InsertHeadPicTask(cts.Token), cts.Token, TaskCreationOptions.LongRunning);
            _insertHeadPicTask.Start();
            AppendLog(txtLog, "[全局] 头像入库任务已启动...");

            //try
            //{
            //    _uploadHeadPicTask.Wait(cts.Token);
            //    _insertHeadPicTask.Wait(cts.Token);
            //}
            //catch (Exception ex)
            //{
            //    AppendLogError(txtLog, ex.ToString());
            //}

            //捕捉窗口关闭事件
            //主要是给一个机会等待任务完成并把任务数据都保存
            FormClosing += async (s1, e1) =>
            {
                if (_shutdownFlag)
                    return;
                e1.Cancel = !_shutdownFlag;
                AppendLogWarning(txtLog, "[全局] 等待任务结束...");
                try
                {
                    cts.Cancel();
                    await _insertHeadPicTask;
                    await _uploadHeadPicTask;
                }
                catch (Exception ex)
                {
                    AppendLogError(txtLog, "[全局] 异常发生在=>{0}", ex.Message);
                }
                _shutdownFlag = true;
                Service.ImageUpload.TaskContext.Instance.Save();
                Close();
            };
        }

        /// <summary>
        /// 添加来源JSON
        /// </summary>

        private void AddSource()
        {
            //验证url
            var sourceJson = txtSourceSite.Text.Trim();
            if (sourceJson.IsNullOrEmpty())
            {
                IS("不能为空！");
                return;
            }
            try
            {
                var source = JsonConvert.DeserializeObject<SourceTask>(sourceJson);
                var taskData = Service.ImageDownload.TaskContext.Instance.Data;
                if (taskData.WaitForProcessSourceTasks.Where(m => m.Domain == source.Domain).Count() > 0
                    || taskData.SourceProcessed.ContainsKey(source.Domain)
                    || taskData.CurrentSourceTask.Domain == source.Domain)
                {
                    IS("该站点已经处理过！");
                    return;
                }

                lock (taskData.WaitForProcessSourceTasks)
                {
                    taskData.WaitForProcessSourceTasks.Enqueue(source);
                }
                AppendLog(txtLog, "[全局] 添加站点{0}成功...", source.Domain);
            }
            catch (Exception ex)
            {
                AppendLogError(txtLog, "[全局异常] 异常信息：{0}", ex.Message);
            }

        }
        #endregion

        #region 生成头像库任务
        /// <summary>
        /// 上传头像任务
        /// </summary>
        private async void UploadHeadPicTask(CancellationToken token)
        {
            var data = Service.ImageUpload.TaskContext.Instance.Data;
            string currentTask;
            //token是用来控制队列退出的
            while (!token.IsCancellationRequested)
            {
                currentTask = null;

                lock (data.WaitUploadPath)
                {
                    if (data.WaitUploadPath.Count > 0)
                    {
                        currentTask = data.WaitUploadPath.Dequeue();
                    }
                }
                //如果没有任务，则等待100毫秒后继续查询任务
                if (currentTask == null)
                {
                    Thread.Sleep(1000);
                    continue;
                }

                AppendLog(txtLog, "[上传头像] 正在上传头像【{0}】 ...", currentTask);

                string headPicUrl = null;
                try
                {
                    headPicUrl = await _context.ImageService.UploadImg(Image.FromFile(currentTask));
                    lock (data.WaitInsertImages)
                    {
                        data.WaitInsertImages.Enqueue(new Service.ImageUpload.HeadPicInfo()
                        {
                            Path = currentTask,
                            TxUrl = headPicUrl
                        });
                    }
                    AppendLog(txtLog, "[上传头像] 头像上传成功({0}) ...", headPicUrl);
                    UpdateUploadHeadPicGrabStatus();
                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    //不成功，则将当前任务重新入队后，继续处理
                    lock (data.WaitUploadPath)
                    {
                        data.WaitUploadPath.Enqueue(currentTask);
                    }
                    UpdateUploadHeadPicGrabStatus();
                    AppendLogError(txtLog, "[上传头像-异常] 发生在：{0}", ex.Message);
                    AppendLog(txtLog, "[上传头像] 头像【{0}】上传失败，重新入队等待处理。", currentTask);
                    Thread.Sleep(2000);
                }
            }
        }

        /// <summary>
        /// 头像入库任务
        /// </summary>
        void InsertHeadPicTask(CancellationToken token)
        {
            var cleanupcount = 0;
            var data = Service.ImageUpload.TaskContext.Instance.Data;
            HeadPicInfo currentTask;
            //token是用来控制队列退出的
            while (!token.IsCancellationRequested)
            {
                currentTask = null;

                lock (data.WaitInsertImages)
                {
                    if (data.WaitInsertImages.Count > 0)
                    {
                        currentTask = data.WaitInsertImages.Dequeue();
                    }
                }
                //如果没有任务，则等待100毫秒后继续查询任务
                if (currentTask == null)
                {
                    Thread.Sleep(100);
                    continue;
                }

                AppendLog(txtLog, "[头像入库] ({0})正在入库 ...", currentTask.TxUrl);

                try
                {
                    var id = 0;
                    if (DbHelperOleDb.ExecuteSql(_insertSql.FormatWith(currentTask.Path, currentTask.TxUrl)) == 1)
                    {
                        id = DbHelperOleDb.GetMaxID("ID", "iwenli_headPic") - 1;
                    }
                    if (id > 0)
                    {
                        currentTask.Id = id;
                        data.ProcessedImages.Add(currentTask);
                        AppendLog(txtLog, "[头像入库] 成功({0}) ...", id);
                        UpdateHeadPicInsertStatus();
                        Thread.Sleep(200);
                    }
                    else
                    {
                        throw new Exception("插入头像返回记录错误，当前返回id=" + id.ToString());
                    }
                }
                catch (Exception ex)
                {
                    //不成功，则将当前任务重新入队后，继续处理
                    lock (data.WaitInsertImages)
                    {
                        data.WaitInsertImages.Enqueue(currentTask);
                    }
                    UpdateHeadPicInsertStatus();
                    AppendLogError(txtLog, "[头像入库-异常] 发生在：{0}", ex.Message);
                    AppendLog(txtLog, "[头像入库] 头像【{0}】入库失败，重新入队等待处理。", currentTask.TxUrl);
                    Thread.Sleep(2000);
                }

                if (cleanupcount++ > 20)
                {
                    //每入库20个缓存固化
                    cleanupcount = 0;
                    GC.Collect();
                    //保存任务数据，防止什么时候宕机了任务进度回滚太多
                    //lock (Service.ImageUpload.TaskContext.Instance.Data)
                    //{

                    //}
                    try
                    {
                        Service.ImageUpload.TaskContext.Instance.Save();
                    }
                    catch (Exception ex)
                    {
                        AppendLogError(txtLog, "[固话数据异常] 发生在：{0}", ex.Message);
                    }
                }
            }
        }

        #region 进度更新
        /// <summary>
        /// 更新头像上传进度
        /// </summary>
        void UpdateUploadHeadPicGrabStatus()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateUploadHeadPicGrabStatus));
                return;
            }
            var data = Service.ImageUpload.TaskContext.Instance.Data;
            pbPageGrab.Maximum = data.WaitUploadPath.Count + data.WaitInsertImages.Count + data.ProcessedImages.Count;
            pbPageGrab.Value = pbPageGrab.Maximum - data.WaitUploadPath.Count;
            lblPgSt.Text = string.Format("共 {0} 张头像需上传，已上传 {1} 张 ...", pbPageGrab.Maximum, pbPageGrab.Value);
        }
        /// <summary>
        /// 更新头像入库进度
        /// </summary>
        void UpdateHeadPicInsertStatus()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateHeadPicInsertStatus));
                return;
            }

            var data = Service.ImageUpload.TaskContext.Instance.Data;
            pbImageDown.Maximum = data.WaitInsertImages.Count + data.ProcessedImages.Count;
            pbImageDown.Value = data.ProcessedImages.Count;
            lblStatPicDownload.Text = string.Format("共 {0} 张头像需入库，已入库 {1} 张 ...", pbImageDown.Maximum, pbImageDown.Value);
        }

        #endregion
        #endregion

        #region  抓取任务
        /// <summary>
        /// 抓取详情页
        /// </summary>
        /// <param name="token"></param>
        async void GrabDetailPagesTaskThreadEntry(CancellationToken token)
        {
            //AppendLogWarning(txtLog, "[图片来源检测] 正在加载来源数据...");
            var client = new HttpClient(); //_context.Session.NetClient;
            var data = Service.ImageDownload.TaskContext.Instance.Data;

            ////这里创建了一个 CancellationTokenSource 的局部变量，主要是为了在循环中对请求也能进行中断
            //CancellationTokenSource tcs = new CancellationTokenSource();
            //token.Register(() => tcs?.Cancel());

            SourceTask task = data.CurrentSourceTask;

            while (!token.IsCancellationRequested)
            {
                #region 站点数据
                if (task == null)
                {
                    //检查下载队列，看是否有没有检测的站点……
                    lock (data.WaitForProcessSourceTasks)
                    {
                        if (data.WaitForProcessSourceTasks.Count > 0)
                        {
                            data.CurrentSourceTask = task = data.WaitForProcessSourceTasks.Dequeue();
                        }
                    }
                }
                //没有或已经下载过的话，则休息后重新检查
                if (task == null)
                {
                    AppendLogWarning(txtLog, "[来源站点] 暂无待处理站点,5秒后重新检测...");
                    //等待5秒再去检测
                    Thread.Sleep(5000);
                    //tcs = null;
                    continue;
                }
                AppendLog(txtLog, "[来源站点] 开始处理站点：{0}...", task.Domain);
                #endregion

                #region 处理页面
                var hasMore = true;
                var page = 1;
                string urlFormat = task.PageFormat;
                while (hasMore)
                {
                    if (page % 100 == 0)
                    {
                        AppendLog(txtLog, "[调试]  当前域{0} 页面{1}", task.Domain, urlFormat.FormatWith(page));
                    }
                    AppendLog(txtLog, "[页面列表] 正在加载站点：{0} 的第 {1} 页...", task.Domain, page);
                    var ctx = client.Create<string>(HttpMethod.Get, urlFormat.FormatWith(page), allowAutoRedirect: true);
                    await ctx.SendAsync();
                    if (!ctx.IsValid())
                    {
                        //失败 10秒后重试
                        AppendLog(txtLog, "[页面列表] 站点：{0} 的第 {1} 页下载失败，稍后重试", task.Domain, page);
                        Thread.Sleep(new TimeSpan(0, 0, 10));
                    }
                    else
                    {
                        //下载成功，获得列表
                        var matches = Regex.Matches(ctx.Result, task.PageListPattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
                        //新的任务
                        var newTasks = matches.Cast<Match>()
                                            .Select(s => new PageTask(s.Groups[2].Value, s.Groups[1].Value, task.ImagePattern))
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
                            AppendLog(txtLog, "[页面列表] 站点：{0} 的第 {1} 页已建立 {2} 个新任务到队列中...", task.Domain, page, newTasks.Length);
                        }
                        else
                        {
                            AppendLog(txtLog, "[页面列表] 站点：{0} 的第 {1} 页没有检测到新任务...", task.Domain, page);
                        }
                        UpdatePageDetailGrabStatus();
                        //如果没有下一页，则中止
                        if (!Regex.IsMatch(ctx.Result, task.NextPagePattern, RegexOptions.IgnoreCase))
                        {
                            AppendLog(txtLog, "[页面列表] 站点：{0} 没有更多新纪录，尝试检查其他站点...", task.Url);
                            hasMore = false;
                            break;
                        }
                        //等待2秒继续
                        Thread.Sleep(2000);
                        page++;
                    }
                }
                #endregion

                //存放来源到已处理列表
                lock (data.SourceProcessed)
                {
                    data.SourceProcessed.Add(task.Domain, task);
                    data.CurrentSourceTask = task = null;
                }
            }

        }

        /// <summary>
        /// 详情下载分解图片
        /// </summary>
        /// <param name="token"></param>
        async void GrabImageListTaskThreadEntry(CancellationToken token)
        {
            var client = new HttpClient();
            var data = Service.ImageDownload.TaskContext.Instance.Data;

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
                await ctx.SendAsync();

                if (ctx.IsValid())
                {
                    //页面有效
                    var html = ctx.Result;

                    //查出所有头像，然后与已下载和已入列的对比，排除重复后将其加入下载队列
                    var imgTasks = Regex.Matches(html, currentTask.ImagePattern, RegexOptions.IgnoreCase | RegexOptions.Singleline)
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
                    Thread.Sleep(400);
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
            var data = Service.ImageDownload.TaskContext.Instance.Data;
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
                        task.DownloadRoot = Service.ImageDownload.TaskContext.Instance.OutputRoot + "//" + task.DownloadRoot;
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
                    Service.ImageDownload.TaskContext.Instance.Save();
                }
            }
        }

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
            var data = Service.ImageDownload.TaskContext.Instance.Data;
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

            var data = Service.ImageDownload.TaskContext.Instance.Data;
            pbImageDown.Maximum = data.DownloadedImages.Count + data.ImageDownloadTasks.Count;
            pbImageDown.Value = pbImageDown.Maximum - data.ImageDownloadTasks.Count;
            lblStatPicDownload.Text = string.Format("共 {0} 图片，已抓取 {1} 图片 ...", pbImageDown.Maximum, pbImageDown.Value);
        }

        #endregion
        #endregion

    }
}

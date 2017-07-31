using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.ImageDownload
{
    /// <summary>
    /// 抓取图像任务 上下文
    /// </summary>
    class TaskContext : ContextBase
    {

        /// <summary>
        /// 下载目录
        /// </summary>
        public string OutputRoot { get; set; }

        /// <summary>
        /// 任务数据
        /// </summary>
        public TaskData Data { get; private set; }

        #region 单例模式

        static TaskContext _instance;
        static readonly object _lockObject = new object();

        public static TaskContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new TaskContext();
                        }
                    }
                }

                return _instance;
            }
        }

        #endregion

        private TaskContext()
        {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            CacheName = "ImageDownloadTasks.dat";
            DataRoot = "data";
            OutputRoot = "头像";

            var root = System.Reflection.Assembly.GetExecutingAssembly().GetLocation();
            DataRoot = PathUtility.Combine(root, DataRoot);
            OutputRoot = PathUtility.Combine(root, OutputRoot);

            Directory.CreateDirectory(DataRoot);
            Directory.CreateDirectory(OutputRoot);

            Data = LoadData<TaskData>(CacheName);

            if (Data.CurrentSourceTask == null &&
                Data.SourceProcessed.Count == 0 &&
                Data.WaitForProcessSourceTasks.Count == 0)
            {
                GenerateSource();
            }
        }

        /// <summary>
        /// 生成站点数据初始库
        /// </summary>
        void GenerateSource()
        {
            Data.WaitForProcessSourceTasks.Enqueue(new SourceTask()
            {
                Url = "http://www.qqmofasi.com/touxiang/",
                PageFormat = "http://www.qqmofasi.com/touxiang/page-{0}.html",
                PageListPattern = @"<a href=['""]([^['""]+)['""] class=['""]item_tit['""] title=['""]([^['""]+)['""]>",
                NextPagePattern = @"<a href=['""]/touxiang/page-\w+.html['""]>下页<\/a>",
                ImagePattern = @"<img src=['""]([^['""]+)['""].*?title=['""]([^['""]+)['""]\s/>"
            });
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        public void Save()
        {
            SaveData(Data, CacheName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.ImageDownload
{
    /// <summary>
    /// 任务数据存储类
    /// </summary>
    class TaskData
    {
        public SourceTask CurrentSourceTask { get; set; }
        /// <summary>
        /// 已处理过的站点
        /// </summary>
        public Dictionary<string, SourceTask> SourceProcessed { get; set; }

        /// <summary>
        /// 等待处理过的站点队列
        /// </summary>
        public Queue<SourceTask> WaitForProcessSourceTasks { get; set; }

        /// <summary>
        /// 已下载的页面列表
        /// </summary>
        public Dictionary<string, PageTask> PageDownloaded { get; set; }

        /// <summary>
        /// 等待下载的页面队列任务
        /// </summary>
        public Queue<PageTask> WaitForDownloadPageTasks { get; set; }

        /// <summary>
        /// 已经下载的图片列表
        /// </summary>
        public Dictionary<string, ImageDownloadTaskInfo> DownloadedImages { get; set; }

        /// <summary>
        /// 准备下载的图片列表
        /// </summary>
        public Queue<ImageDownloadTask> ImageDownloadTasks { get; set; }

        /// <summary>
        /// 获得或设置是否已经完整下载过
        /// </summary>
        public bool FullyDownloaded { get; set; }

        public TaskData()
        {
            SourceProcessed = new Dictionary<string, SourceTask>(StringComparer.OrdinalIgnoreCase);
            PageDownloaded = new Dictionary<string, PageTask>(StringComparer.OrdinalIgnoreCase);
            DownloadedImages = new Dictionary<string, ImageDownloadTaskInfo>(StringComparer.OrdinalIgnoreCase);
            WaitForProcessSourceTasks = new Queue<SourceTask>();
            WaitForDownloadPageTasks = new Queue<PageTask>();
            ImageDownloadTasks = new Queue<ImageDownloadTask>();
            CurrentSourceTask = null;
        }
    }
}

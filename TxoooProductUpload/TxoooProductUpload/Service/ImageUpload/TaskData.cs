using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.ImageUpload
{
    /// <summary>
    /// 任务数据存储类
    /// </summary>
    class TaskData
    {
        /// <summary>
        /// 等待上传的图片路径队列
        /// </summary>
        public Queue<string> WaitUploadPath { set; get; }

        /// <summary>
        /// 等待入库的图片
        /// </summary>
        public Queue<HeadPicInfo> WaitInsertImages { set; get; }

        /// <summary>
        /// 已经入库的图片
        /// </summary>
        public List<HeadPicInfo> ProcessedImages { set; get; }


        public TaskData()
        {
            WaitUploadPath = new Queue<string>();
            WaitInsertImages = new Queue<HeadPicInfo>();
            ProcessedImages = new List<HeadPicInfo>();
        }
    }

    class HeadPicInfo
    {
        /// <summary>
        /// 数据库记录ID,方便索引
        /// </summary>
        public long Id { set; get; }
        /// <summary>
        /// 头像本地文件路径
        /// </summary>
        public string Path { set; get; }
        /// <summary>
        /// 服务器URl
        /// </summary>
        public string TxUrl { set; get; }
    }
}

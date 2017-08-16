using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.Cache.HeadPicCache
{
    /// <summary>
    /// 头像上下文管理
    /// </summary>
    class HeadPicContext : ContextBase
    {
        /// <summary>
        /// 头像数据，当前用户第一次打开时缓存，每张图只用一次（用完删除）
        /// </summary>
        public List<string> Data { get; private set; }

        /// <summary>
        /// 已经使用过的头像
        /// </summary>
        public List<string> Used { get; private set; }

        /// <summary>
        /// 无效构造器
        /// </summary>
        private HeadPicContext()
        {
            Used = new List<string>();
        }
        #region 单例模式
        static HeadPicContext _instance;
        static readonly object _lockObject = new object();

        public static HeadPicContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new HeadPicContext();
                        }
                    }
                }

                return _instance;
            }
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            CacheName = "headPicCache.db";
            DataRoot = "data";
            var root = System.Reflection.Assembly.GetExecutingAssembly().GetLocation();
            DataRoot = PathUtility.Combine(root, DataRoot);
            Directory.CreateDirectory(DataRoot);
            Data = LoadData<List<string>>(CacheName);
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

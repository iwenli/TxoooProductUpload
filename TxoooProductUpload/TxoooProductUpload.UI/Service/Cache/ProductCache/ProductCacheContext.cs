using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Service;

namespace TxoooProductUpload.UI.Service.Cache.ProductCache
{
    /// <summary>
    /// 商品抓取缓存上下文
    /// </summary>
    public class ProductCacheContext : ContextBase
    {
        /// <summary>
        /// 任务数据
        /// </summary>
        public ProductCacheData Data { get; private set; }

        #region 单例模式

        static ProductCacheContext _instance;
        static readonly object _lockObject = new object();

        public static ProductCacheContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new ProductCacheContext();
                        }
                    }
                }

                return _instance;
            }
        }

        #endregion

        private ProductCacheContext()
        {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            CacheName = "{0}.dat".FormatWith(DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));
            DataRoot = Path.Combine("data", "cacha", "product");

            var root = Environment.CurrentDirectory;
            DataRoot = PathUtility.Combine(root, DataRoot);
            Directory.CreateDirectory(DataRoot);
            Data = LoadData<ProductCacheData>(CacheName);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        public void Save()
        {
            SaveData(Data, CacheName);
        }

        /// <summary>
        /// 保存商品抓取任务数据
        /// </summary>
        /// <param name="file">任务文件路径</param>
        public void Save(string file)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(file));

            if (Data == null)
            {
                File.Delete(file);
            }
            else
            {
                File.WriteAllText(file, JsonConvert.SerializeObject(Data));
            }
        }

        /// <summary>
        /// 读取任务数据
        /// </summary>
        /// <param name="file"></param>
        public void LoadData(string file)
        {
            if (File.Exists(file))
            {
                var result = JsonConvert.DeserializeObject<ProductCacheData>(File.ReadAllText(file));
                Data = result == null ? new ProductCacheData() : result;
                return;
            }
            Data = new ProductCacheData();
        }
    }
}

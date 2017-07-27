using FSLib.Network.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.Common;
using TxoooProductUpload.Service.Entities;
using TxoooProductUpload.Service.Entities.Web;

namespace TxoooProductUpload.Service
{
    /// <summary>
    /// 缓存管理上下文
    /// </summary>
    class CacheContext
    {
        /// <summary>
        /// 缓存目录
        /// </summary>
        public string DataRoot { get; private set; }

        /// <summary>
        /// 缓存数据
        /// </summary>
        public Cache Cache { get; private set; }

        #region 单例模式

        static CacheContext _instance;
        static readonly object _lockObject = new object();

        public static CacheContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new CacheContext();
                        }
                    }
                }

                return _instance;
            }
        }

        #endregion

        private CacheContext()
        {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            var root = System.Reflection.Assembly.GetExecutingAssembly().GetLocation();
            DataRoot = PathUtility.Combine(root, "data");
            Directory.CreateDirectory(DataRoot);
            Cache = LoadData<Cache>("cacha.dat");
            Cache.IsLine = !ApiList.IsTest;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        public void Save()
        {
            SaveData(Cache, "cacha.dat");
        }

        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Update(ServiceContext context)
        {
            if (AppConfig.IsRemember)
            {
                Cache.LoginInfo = context.Session.LoginInfo;
            }
            else {
                Cache.LoginInfo = null;
            }
            if ((Cache.LastUpdateTime != null && Cache.LastUpdateTime.AddDays(1) < DateTime.Now)
                || Cache.ProductClassList.Count == 0 || Cache.AreaList.Count == 0
                || !ApiList.IsTest != Cache.IsLine)
            {
                Cache.ProductClassList.Clear();
                Cache.AreaList.Clear();
                Cache.ProductClassList.AddRange(await context.ClassDataService.GetAllProductClass());
                Cache.AreaList.AddRange(await context.AreaDataService.LoadAreaDatasAsync(1));
                var list = Cache.AreaList.ToList();
                try
                {
                    foreach (var item in list)
                    {
                        if (new int[] { 110000, 120000, 310000, 500000 }.Contains(item.region_code))
                        {
                            continue;
                        }
                        var childList = await context.AreaDataService.LoadAreaDatasAsync(item.region_id);
                        Cache.AreaList.AddRange(childList);
                    }
                    Cache.LastUpdateTime = DateTime.Now;
                    Cache.IsLine = !ApiList.IsTest;
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
            Save();
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        T LoadData<T>(string path) where T : class, new()
        {
            var file = PathUtility.Combine(DataRoot, path);
            if (File.Exists(file))
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
            }
            return new T();
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="path"></param>
        void SaveData<T>(T data, string path)
        {
            var file = PathUtility.Combine(DataRoot, path);
            Directory.CreateDirectory(Path.GetDirectoryName(file));

            if (data == null)
            {
                File.Delete(file);
            }
            else
            { 
                File.WriteAllText(file, JsonConvert.SerializeObject(data));
            }
        }
    }

    /// <summary>
    /// 缓存数据
    /// </summary>
    class Cache
    {
        /// <summary>
        /// 城市信息
        /// </summary>
        public List<AreaInfo> AreaList { get; set; }
        /// <summary>
        /// 分类信息
        /// </summary>
        public List<ProductClassInfo> ProductClassList { get; set; }
        /// <summary>
        /// 最后一次更新缓存时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; }
        /// <summary>
        /// 登陆信息
        /// </summary>
        public LoginInfo LoginInfo { get; set; }
        /// <summary>
        /// 是否线上环境
        /// </summary>
        public bool IsLine { get; set; }

        public Cache()
        {
            AreaList = new List<AreaInfo>();
            ProductClassList = new List<ProductClassInfo>();
        }

    }
}

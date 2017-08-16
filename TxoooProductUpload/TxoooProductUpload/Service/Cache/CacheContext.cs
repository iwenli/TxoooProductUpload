using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.Common;

namespace TxoooProductUpload.Service
{
    /// <summary>
    /// 缓存管理上下文
    /// </summary>
    class CacheContext : ContextBase
    {

        /// <summary>
        /// 缓存数据
        /// </summary>
        public CacheData Data { get; private set; }

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
            CacheName = "cacha.dat";
            DataRoot = "data";
            var root = System.Reflection.Assembly.GetExecutingAssembly().GetLocation();
            DataRoot = PathUtility.Combine(root, DataRoot);
            Directory.CreateDirectory(DataRoot);
            Data = LoadData<CacheData>(CacheName);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        public void Save()
        {
            SaveData(Data, CacheName);
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
                Data.LoginInfo = context.Session.LoginInfo;
            }
            else
            {
                Data.LoginInfo = null;
            }
            if ((Data.LastUpdateTime != null && Data.LastUpdateTime.AddDays(1) < DateTime.Now)
                || Data.ProductClassList.Count == 0 || Data.AreaList.Count == 0
                || !ApiList.IsTest != Data.IsLine)
            {
                Data.ProductClassList.Clear();
                Data.AreaList.Clear();
                Data.ProductClassList.AddRange(await context.ClassDataService.GetAllProductClass());
                Data.AreaList.AddRange(await context.AreaDataService.LoadAreaDatasAsync(1));
                var list = Data.AreaList.ToList();
                try
                {
                    foreach (var item in list)
                    {
                        if (new int[] { 110000, 120000, 310000, 500000 }.Contains(item.region_code))
                        {
                            continue;
                        }
                        var childList = await context.AreaDataService.LoadAreaDatasAsync(item.region_id);
                        Data.AreaList.AddRange(childList);
                    }
                    Data.LastUpdateTime = DateTime.Now;
                    Data.IsLine = !ApiList.IsTest;
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
            Save();
        }

    }
}

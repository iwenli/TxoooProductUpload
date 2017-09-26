using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.Common;
using TxoooProductUpload.Network;

namespace TxoooProductUpload.Service
{
    /// <summary>
    /// 缓存管理上下文
    /// </summary>
    public class CacheContext : ContextBase
    {
        /// <summary>
        /// 服务上下文
        /// </summary>
        public ServiceContext ServiceContext { get; set; }

        /// <summary>
        /// 缓存数据
        /// </summary>
        public CacheData Data { get; private set; }

        #region 单例模式

        protected static CacheContext _instance;
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
                            _instance.Init();
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
                for (int i = 0; i < list.Count; i++)
                {
                    if (!new int[] { 110000, 120000, 310000, 500000 }.Contains(list[i].region_code))
                    {
                        try
                        {
                            Data.AreaList.AddRange(await ServiceContext.AreaDataService.LoadAreaDatasAsync(list[i].region_id));
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                //更新商品来源集合缓存
                var maxId = 0L;
                if (Data.ProductSourceTxoooList.Count > 0) {
                    maxId = Data.ProductSourceTxoooList.Last().Id;
                }
                Data.ProductSourceTxoooList.AddRange(await context.ProductService.GetProductsSourceListAsync(maxId));
            }
            Save();
        }
        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Update()
        {
            if ((Data.LastUpdateTime != null && Data.LastUpdateTime.AddDays(1) < DateTime.Now)
                || Data.ProductClassList.Count == 0 || Data.AreaList.Count == 0
                || !ApiList.IsTest != Data.IsLine)
            {
                Data.ProductClassList.Clear();
                Data.AreaList.Clear();
                Data.ProductClassList.AddRange(await ServiceContext.ClassDataService.GetAllProductClass());
                Data.AreaList.AddRange(await ServiceContext.AreaDataService.LoadAreaDatasAsync(1));
                var list = Data.AreaList.ToList();
                //Parallel.For(0, list.Count, async (i) =>
                for (int i = 0; i < list.Count; i++)
                {
                    if (!new int[] { 110000, 120000, 310000, 500000 }.Contains(list[i].region_code))
                    {
                        try
                        {
                            Data.AreaList.AddRange(await ServiceContext.AreaDataService.LoadAreaDatasAsync(list[i].region_id));
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                    }
                }
                Data.LastUpdateTime = DateTime.Now;
                Data.IsLine = !ApiList.IsTest; 
            }
            Save();
        }
        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAlways()
        {
            Data.ProductClassList.Clear();
            Data.AreaList.Clear();
            Data.ProductClassList.AddRange(await ServiceContext.ClassDataService.GetAllProductClass());
            Data.AreaList.AddRange(await ServiceContext.AreaDataService.LoadAreaDatasAsync(1));
            var list = Data.AreaList.ToList();
            //Parallel.For(0, list.Count, async (i) =>
            for (int i = 0; i < list.Count; i++)
            {
                if (!new int[] { 110000, 120000, 310000, 500000 }.Contains(list[i].region_code))
                {
                    try
                    {
                        Data.AreaList.AddRange(await ServiceContext.AreaDataService.LoadAreaDatasAsync(list[i].region_id));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
            }
            Data.LastUpdateTime = DateTime.Now;
            Data.IsLine = !ApiList.IsTest;
            Save();
            return true;
        }
    }
}

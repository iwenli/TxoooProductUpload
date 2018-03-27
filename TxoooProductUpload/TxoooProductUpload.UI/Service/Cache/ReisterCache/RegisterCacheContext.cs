/*----------------------------------------------------------------
 *  Copyright (C) 2017 天下商机（txooo.com）版权所有
 * 
 *  文 件 名：RegisterCacheContext
 *  所属项目：
 *  创建用户：张玉龙(HouWeiya)
 *  创建时间：2018/1/22 8:57:19
 *  
 *  功能描述：
 *          1、
 *          2、 
 * 
 *  修改标识：  
 *  修改描述：
 *  待 完 善：
 *          1、 
----------------------------------------------------------------*/

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Service;

namespace TxoooProductUpload.UI.Service.Cache.ReisterCache
{
    /// <summary>
    /// 注册数据上下文
    /// </summary>
    public class RegisterCacheContext : ContextBase
    {
        /// <summary>
        /// 任务数据
        /// </summary>
        public RegisterCahceData Data { get; private set; }

        #region 单例模式

        static RegisterCacheContext _instance;
        static readonly object _lockObject = new object();

        public static RegisterCacheContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new RegisterCacheContext();
                        }
                    }
                }

                return _instance;
            }
        }

        #endregion

        private RegisterCacheContext()
        {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            CacheName = "register.dat";//.FormatWith(DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));
            DataRoot = Path.Combine("Data", "Cacha", "Register");

            var root = Environment.CurrentDirectory;
            DataRoot = PathUtility.Combine(root, DataRoot);
            Directory.CreateDirectory(DataRoot);
            Data = LoadData<RegisterCahceData>(CacheName);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        public void Save()
        {
            SaveData(Data, CacheName);
        }

        /// <summary>
        /// 保存任务数据
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
                var result = JsonConvert.DeserializeObject<RegisterCahceData>(File.ReadAllText(file));
                Data = result == null ? new RegisterCahceData() : result;
                return;
            }
            Data = new RegisterCahceData();
        }
    }
}

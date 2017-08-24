using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service
{
    /// <summary>
    /// 通用的上下文缓存基类
    /// </summary>
    public abstract class ContextBase
    {
        /// <summary>
        /// 缓存名称
        /// </summary>
        protected string CacheName { get; set; }

        /// <summary>
        /// 上下文存储目录,相对路径
        /// </summary>
        protected string DataRoot { get; set; }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        protected T LoadData<T>(string path) where T : class, new()
        {
            var file = PathUtility.Combine(DataRoot, path);
            if (File.Exists(file))
            {
                var result = JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
                return result == null ? new T() : result;
            }
            return new T();
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="path"></param>
        protected void SaveData<T>(T data, string path)
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
}

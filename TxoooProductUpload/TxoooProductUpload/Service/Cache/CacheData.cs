using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Service.Entities;

namespace TxoooProductUpload.Service
{
    /// <summary>
    /// 缓存数据
    /// </summary>
    public class CacheData
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

        public CacheData()
        {
            AreaList = new List<AreaInfo>();
            ProductClassList = new List<ProductClassInfo>();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Entities
{
    /// <summary>
    /// 抓取类型
    /// </summary>
    public enum CrawlType
    {
        /// <summary>
        /// 不支持的
        /// </summary>
        None,
        /// <summary>
        /// 淘宝搜索
        /// </summary>
        TaoBaoSearch,
        /// <summary>
        /// 淘宝商品
        /// </summary>
        TaoBaoItem,
        /// <summary>
        /// 淘宝店铺
        /// </summary>
        TaoBaoStore,
        /// <summary>
        /// 天猫搜索
        /// </summary>
        TmallSearch,
        /// <summary>
        /// 天猫商品
        /// </summary>
        TmallItem,
        /// <summary>
        /// 天猫店铺
        /// </summary>
        TmallStore
    }
}

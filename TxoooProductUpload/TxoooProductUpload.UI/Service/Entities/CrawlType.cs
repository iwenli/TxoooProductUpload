using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.UI.Service.Entities
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
        TaoBaoItem
    }
}

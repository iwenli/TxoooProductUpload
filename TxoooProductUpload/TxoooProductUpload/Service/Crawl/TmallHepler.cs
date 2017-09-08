using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Entities.Product;
using TxoooProductUpload.Network;

namespace TxoooProductUpload.Service.Crawl
{
    /// <summary>
    /// 天猫相关处理
    /// </summary>
    public class TmallHepler : IHelper
    {
        /// <summary>
        /// 从天猫详情抓取商品信息
        /// </summary>
        /// <param name="client"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool ProcessItem(NetClient client, ref ProductSourceInfo product)
        {
            bool ret = false;

            return ret;
        }
    }
}

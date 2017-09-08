using FSLib.Network.Http;
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
    /// 商品抓取公共入口
    /// </summary>
    public class ProductHelper
    {
        NetClient _netClient;
        TmallHepler _tmallHelper;
        /// <summary>
        /// 网络请求对象
        /// </summary>
        public NetClient NetClient
        {
            set
            {
                _netClient = value;
            }
            get { return _netClient; } 

        }

        #region 构造函数
        /// <summary>
        /// 初始化一个 ProductHelper 实例
        /// </summary>
        public ProductHelper()
        {
            _netClient = new NetClient();
        }

        /// <summary>
        /// 初始化一个 ProductHelper 实例
        /// </summary>
        /// <param name="netClient"></param>
        public ProductHelper(NetClient netClient)
        {
            _netClient = netClient;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool GetProductInfo(ref ProductSourceInfo product)
        {
            bool ret = false;

            return ret;
        }
    }
}

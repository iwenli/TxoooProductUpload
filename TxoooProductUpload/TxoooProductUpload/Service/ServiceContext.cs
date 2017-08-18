using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using TxoooProductUpload.Common;

namespace TxoooProductUpload.Service
{
    /// <summary>
    /// 服务状态上下文
    /// </summary>
    class ServiceContext
    {
        public ServiceContext()
        {
            Session = new Session();
            UrlConvertProductService = new UrlConvertProductService(this); 
            ClassDataService = new ClassDataService(this);
            AreaDataService = new AreaDataService(this);
            ImageService = new ImageService(this);
            ProductService = new ProductService(this);
            CacheContext = CacheContext.Instance;
            CacheContext.Init();
        }
         

        public OleDbConnection OleDbConnection { set; get; }

        /// <summary>
        /// 获得当前的会话状态
        /// </summary>
        public Session Session { get; private set; }

        /// <summary>
        /// 获得当前解析商品服务
        /// </summary>
        public UrlConvertProductService UrlConvertProductService { get; private set; }

        /// <summary>
        /// 获得发货地数据
        /// </summary>
        public AreaDataService AreaDataService { get; private set; }
        /// <summary>
        /// 获得商品分类数据
        /// </summary>
        public ClassDataService ClassDataService { get; private set; }

        /// <summary>
        /// 通用数据服务
        /// </summary>
        public ImageService ImageService { get; private set; }

        /// <summary>
        /// 商品对接tx服务
        /// </summary>
        public ProductService ProductService { get; private set; }
        /// <summary>
        /// 缓存上下文
        /// </summary>
        public CacheContext CacheContext { get; private set; }
    }
}

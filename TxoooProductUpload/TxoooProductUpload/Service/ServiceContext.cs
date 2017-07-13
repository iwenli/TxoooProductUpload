using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            CommonService = new CommonService(this);
        }

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
        public CommonService CommonService { get; private set; }

    }
}

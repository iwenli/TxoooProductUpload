using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.UI.Service
{
    /// <summary>
    /// UI服务上下文
    /// </summary>
     class ServiceContext
    {
        #region 构造器
        #region 单例模式

        static ServiceContext _instance;
        static readonly object _lockObject = new object();
        /// <summary>
        /// 实例化一个 ServiceContext 单例对象
        /// </summary>
        public static ServiceContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new ServiceContext();
                        }
                    }
                }

                return _instance;
            }
        }

        #endregion
        /// <summary>
        /// 禁用
        /// </summary>
        ServiceContext()
        {
            UserService = new UserService();
            BaseContent = new TxoooProductUpload.Service.ServiceContext();
        } 
        #endregion

        /// <summary>
        /// 登录相关
        /// </summary>
        public UserService UserService { private set; get; }

        /// <summary>
        /// 业务逻辑服务
        /// </summary>
        public TxoooProductUpload.Service.ServiceContext BaseContent { private set; get; }
    }
}

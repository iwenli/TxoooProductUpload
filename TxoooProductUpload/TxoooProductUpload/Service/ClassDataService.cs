using FSLib.Network.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.Common;
using TxoooProductUpload.Service.Entities;

namespace TxoooProductUpload.Service
{
    /// <summary>
    /// 分类数据服务
    /// </summary>
    class ClassDataService : ServiceBase
    {
        /// <summary>
		/// 当前分类
		/// </summary>
		List<ProductClassInfo> _rootClassList = new List<ProductClassInfo>();


        /// <summary>
        /// 所有的车站列表
        /// </summary>
        public List<ProductClassInfo> RootClassList
        {
            get { return _rootClassList; }
        }


        public ClassDataService(ServiceContext context) : base(context)
        {
            _rootClassList.Add(new ProductClassInfo() { ClassId = 1, ClassName = "产品类" });
            _rootClassList.Add(new ProductClassInfo() { ClassId = 3439, ClassName = "门店服务类" });
        }

        /// <summary>
        /// 异步加载分类数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductClassInfo>> LoadClassDatasAsync(long id = 1)
        {
            var stCtx = ServiceContext.Session.NetClient
                .Create<List<ProductClassInfo>>(HttpMethod.Get, ApiList.GetProductClassByParentIdV3, data: new { parentId = id });

            //等待任务完成
            return await stCtx.SendAsync();
        }

        /// <summary>
        /// 获取所有分类
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductClassInfo>> GetAllProductClass()
        {
            var stCtx = ServiceContext.Session.NetClient
                                .Create<List<ProductClassInfo>>(HttpMethod.Get, ApiList.GetAllProductClassV2, ApiList.HostMch);
            try
            {
                //等待任务完成
                await stCtx.SendAsync();
                if (!stCtx.IsValid())
                {
                    new Exception("ClassDataService未能提交请求GetAllProductClass");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            return stCtx.Result;
        }
    }
}

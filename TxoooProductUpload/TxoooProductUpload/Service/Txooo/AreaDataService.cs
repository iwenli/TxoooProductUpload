using FSLib.Network.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Common;
using TxoooProductUpload.Service.Entities;
using TxoooProductUpload.Service.Entities.Web;

namespace TxoooProductUpload.Service
{
    /// <summary>
    /// 地域数据服务
    /// </summary>
    public class AreaDataService : ServiceBase
    {

        public AreaDataService(ServiceContext context) : base(context)
        {
        }

        /// <summary>
        /// 异步加载地域数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<AreaInfo>> LoadAreaDatasAsync(long id = 1)
        {
            var param = new { userid = ServiceContext.Session.Token.userid, token = ServiceContext.Session.Token.token, parentId = id };
            var stCtx = ServiceContext.Session.NetClient
                .Create<WebResponseResult<AreaInfo>>(HttpMethod.Get, ApiList.GetArea, data: param);

            await stCtx.SendAsync();
            if (!stCtx.IsValid())
            {
                new Exception("AreaDataService未能提交请求");
            }
            var areaResult = stCtx.Result;
            return areaResult.Data.ToList();
        }
    }
}

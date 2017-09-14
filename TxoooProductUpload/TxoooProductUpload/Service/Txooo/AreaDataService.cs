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
            try
            {
                var param = new { userid = Session.Token.userid, token = Session.Token.token, parentId = id };
                var stCtx = NetClient.Create<WebResponseResult<AreaInfo>>(HttpMethod.Get, ApiList.GetArea, data: param);

                await stCtx.SendAsync();
                if (!stCtx.IsValid())
                {
                    new Exception("AreaDataService未能提交请求");
                }
                var areaResult = stCtx.Result;
                return areaResult.Data.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("加载地域数据异常", ex);
            }
        }
    }
}

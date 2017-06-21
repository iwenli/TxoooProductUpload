using FSLib.Network.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Service.Entities;

namespace TxoooProductUpload.Service
{
    class Ali1688Service:ServiceBase
    {
        public Ali1688Service(ServiceContext context) : base(context)
		{
        }
 

       /// <summary>
       /// 处理1688商品
       /// </summary>
       /// <param name="productUrl"></param>
       /// <returns></returns>
        public async Task<ProductResult> ProcessProduct(string productUrl)
        {
            var client = ServiceContext.Session.NetClient; 
            

            //发送查询请求
            var ctx = client.Create<string>( HttpMethod.Get, productUrl, "https://www.1688.com/");
            await ctx.SendAsync();

            if (!ctx.IsValid())
            {
                throw ctx.Exception ?? new Exception("未能查询。");
            }

            if (ctx.Result == null)
            {
                //服务器返回错误信息
                throw new Exception("未知错误信息");
            }

            return JsonConvert.DeserializeObject<ProductResult>(ctx.Result);
        }

    }
}

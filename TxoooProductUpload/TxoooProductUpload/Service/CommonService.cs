using FSLib.Network.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TxoooProductUpload.Service.Entities;

namespace TxoooProductUpload.Service
{
    /// <summary>
    /// 公共操作服务
    /// </summary>
    public class CommonService : ServiceBase
    {
        public CommonService(ServiceContext context) : base(context)
        {
        }

        /// <summary>
        /// 获取IP
        /// </summary>
        /// <returns></returns>
        public async Task<IpInfo> GetIp()
        {
            var ipReg = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}", RegexOptions.IgnoreCase);
            var url = @"http://1212.ip138.com/ic.asp";
            var ctx = NetClient.Create<string>(HttpMethod.Get, url, allowAutoRedirect: true);
            await ctx.SendAsync();
            if (!ctx.IsValid())
            {
                throw new Exception("请求未能提交" + url);
            }
            var info = new Regex(@"(?<=<center>).+?(?=</center>)").Match(ctx.Result).Value;
            var ip = new IpInfo();
            ip.Ip = ipReg.Match(info).Value;
            var index = info.LastIndexOf("：");
            if (index > -1)
            {
                var city = info.Substring(index + 1).Split(' ');
                ip.Address = city[0];
                if (city.Length == 2)
                {
                    ip.Type = city[1];
                }
            }
            return ip;
        }
    }
}

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
            url = @"http://www.ip168.com/json.do?view=myipaddress";
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

        /// <summary>
        /// 发送微信通知 Server酱免费服务
        /// </summary>
        /// <param name="title">消息标题</param>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public async Task SendWxNotify(string title, string msg)
        {
            var url = @"https://sc.ftqq.com/SCU4952T19b4d5800b74cc1a7af7cdae0aebf02e586bc33d6943c.send";
            var ctx = NetClient.Create<string>(HttpMethod.Post, url,
                data: new { text = title, desp = msg }, allowAutoRedirect: true);
            await ctx.SendAsync();

        }
    }
}

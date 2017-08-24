using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.Entities
{
    /// <summary>
    /// IP地址，从http://1212.ip138.com/ic.asp获取
    /// </summary>
    public class IpInfo
    {
        /// <summary>
        /// IP
        /// </summary>
        public string Ip { set; get; }
        /// <summary>
        /// 归属地
        /// </summary>
        public string Address { set; get; }
        /// <summary>
        /// 运营商
        /// </summary>
        public string Type { set; get; }

        public override string ToString()
        {
            return string.Format("您的IP是：[{0}]{1}来自：{2} {3}", Ip, Environment.NewLine, Address, Type);
        }
    }
}

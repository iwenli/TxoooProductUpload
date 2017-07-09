using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TxoooProductUpload.Service.Entities
{
    /// <summary>
    /// 登录信息
    /// </summary>
    class LoginInfo
    {

        /// <summary>
        /// 获得或设置当前的显示名
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 登陆者商户信息
        /// </summary>
        public MchInfo MchInfo { get; set; }
}

    class MchInfo
    {
        public int UserId { get; set; }
        public int MchId { get; set; }
        public string NickName { get; set; }
        public string HeaPic { get; set; }
        public int MchClass { get; set; }
        public string ComName { get; set; }
        public string MchLogo { get; set; }
        public int FreeCheckDay { get; set; }
        public string NewMsg { get; set; }
        public int TemplateOpen { get; set; }
        public int AgentId { get; set; }
    }
}

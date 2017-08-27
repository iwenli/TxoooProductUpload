using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TxoooProductUpload.Service.Entities
{
    /// <summary>
    /// 登录信息
    /// </summary>
    [Serializable]
    public class LoginInfo
    {
        /// <summary>
        /// 初始化一个 LoginInfo 对象
        /// </summary>
        /// <param name="uName"></param>
        /// <param name="pWd"></param>
        /// <param name="isRemember"></param>
        public LoginInfo(string uName, string pWd, bool isRemember, bool isTest) : this(uName, pWd, isRemember)
        {
            IsTest = isTest;
        }
        /// <summary>
        /// 初始化一个 LoginInfo 对象
        /// </summary>
        /// <param name="uName"></param>
        /// <param name="pWd"></param>
        /// <param name="isRemember"></param>
        public LoginInfo(string uName, string pWd, bool isRemember) : this()
        {
            UserName = uName;
            Password = pWd;
            RememberPwd = isRemember;
        }

        /// <summary>
        /// 初始化一个 LoginInfo 对象
        /// </summary>
        public LoginInfo()
        {
            LastLoginTime = DateTime.Now;
        }
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
        /// 记住密码
        /// </summary>
        public bool RememberPwd { get; set; }

        /// <summary>
        /// 最后一次登陆时间
        /// </summary>
        public DateTime LastLoginTime { set; get; }
        /// <summary>
        /// 是否测试环境
        /// </summary>
        public bool IsTest { set; get; }

        /// <summary>
        /// 登陆者商户信息
        /// </summary>
        public MchInfo MchInfo { get; set; }
    }
    [Serializable]
    public class MchInfo
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

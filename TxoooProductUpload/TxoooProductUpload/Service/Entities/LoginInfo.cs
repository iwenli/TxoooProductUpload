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
    }

    class UserInfo {

        public int user_id { get; set; }
        public string nick_name { get; set; }
        public string head_pic { get; set; }
    }
}

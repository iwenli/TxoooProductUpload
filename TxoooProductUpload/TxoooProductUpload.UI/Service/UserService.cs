using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Common;

namespace TxoooProductUpload.UI.Service
{
    /// <summary>
    /// 用户相关服务
    /// </summary>
    class UserService : ServiceBase
    {
        public UserService()
        {
            MsgTemplate = "[登录消息]{0}";
        }


        internal async Task Msg()
        {
            for (int i = 0; i < 50; i++)
            {
                await Task.Delay(600);
                InfoMessage(MsgTemplate, "正常消息");
                if (i % 5 == 0)
                {
                    WarnMessage(MsgTemplate, "警告消息");
                }
                if (i % 3 == 0)
                {
                    ErrorMessage(MsgTemplate, "错误信息");
                }
                if (i % 7 == 0)
                {
                    FatalMessage(MsgTemplate, "致命消息");
                }
            }
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public void RegisterSync()
        {
            Task.Run(() =>
            {
                var url = AppConfig.GetItem("register");
                if (!url.IsNullOrEmpty())
                {
                    Process.Start(url);
                }
            });
        }
        /// <summary>
        /// 找回密码
        /// </summary>
        /// <returns></returns>
        public void FindPassWordSync()
        {
            Task.Run(() =>
            {
                var url = AppConfig.GetItem("findpwd");
                if (!url.IsNullOrEmpty())
                {
                    Process.Start(url);
                }
            }); 
        }
    }
}

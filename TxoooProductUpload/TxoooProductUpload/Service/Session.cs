using FSLib.Network.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TxoooProductUpload.Network;
using TxoooProductUpload.Service.Entities;
using TxoooProductUpload.Service.Entities.Web;

namespace TxoooProductUpload.Service
{
    /// <summary>
	/// 表示当前的登录会话，以及一些必须的状态信息。
	/// </summary>
	class Session
    {
        bool _isLogined;

        public Session()
        {
            NetClient = new NetClient();
        }

        /// <summary>
        /// 获得当前使用的网络对象，每个网络对象都是会话关联的。
        /// </summary>
        public NetClient NetClient { get; private set; }

        LoginInfo _loginInfo;

        /// <summary>
        /// 获得当前的登录信息
        /// </summary>
        public LoginInfo LoginInfo
        {
            get { return _loginInfo; }
            private set { _loginInfo = value; }
        }

        /// <summary>
        /// 获得当前是否已经登录
        /// </summary>
        public bool IsLogined
        {
            get { return _isLogined; }
            private set
            {
                if (_isLogined == value)
                    return;

                _isLogined = value;
                OnIsLoginedChanged();
            }
        }

        /// <summary>
        /// 登录状态发生变化
        /// </summary>
        public event EventHandler IsLoginedChanged;

        /// <summary>
        /// 引发 <see cref="IsLoginedChanged" /> 事件
        /// </summary>
        protected virtual void OnIsLoginedChanged()
        {
            var handler = IsLoginedChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        /// <summary>
        /// 注销登录
        /// </summary>
        public void Logout()
        {
            LoginInfo = null;
            NetClient = new NetClient();
            IsLogined = false;
        }

        /// <summary>
        /// 登录。如果返回异常则说明登录失败
        /// </summary>
        /// <param name="verifyPoints"></param>
        /// <returns></returns>
        public async Task<Exception> LoginAsync(string username, string password)
        {
            IsLogined = false;
            LoginInfo = new LoginInfo()
            {
                UserName = username,
                Password = password
            };
            var loginData = new 
            {
                userName = LoginInfo.UserName,
                passWord= LoginInfo.Password
            };
            //var loginCheck = NetClient.Create<WebResponseResult<LoginAsyncResult>>(
            //                                 HttpMethod.Post,
            //                                "https://passport.7518.cn/Txooo/SalesV2/Passport/Ajax/SalesAjax.ajax/LoginV2",
            //                                "https://0.u.7518.cn",
            //                                loginData
            //    );
            var loginCheck = NetClient.Create<string>(
                                            HttpMethod.Post,
                                           "https://passport.7518.cn/Txooo/SalesV2/Passport/Ajax/SalesAjax.ajax/LoginV2",
                                           "https://0.u.7518.cn",
                                           loginData
               );

            //商户api
            //登录 https://testmch.7518.cn/Txooo/Sales/Mch/Passport/Ajax/MchAjax.ajax/LoginV2   u p
            //获取token https://testmch.7518.cn/open/Passport/Login   u p

            //var loginCheck = NetClient.Create<string>(
            //                                HttpMethod.Post,
            //                               "https://testmch.7518.cn/Txooo/Sales/Mch/Passport/Ajax/MchAjax.ajax/LoginV2",
            //                               "https://testmch.7518.cn/",
            //                               loginData
            //   );
            await loginCheck.SendAsync();
            if (!loginCheck.IsValid())
            {
                return loginCheck.Exception ?? new Exception("未能提交请求");
            }
            var loginResult = JsonConvert.DeserializeObject<LoginAsyncResult>(loginCheck.Result.Replace("(", "").Replace(")", ""));
            if (!loginResult.IsSuceess)
            {
                return new Exception(loginResult.msg);
            }

            //登录好了。等等。。我们好像想拿到显示的中文名？
            //所以多加一个请求吧。
            var realNameCtx = NetClient.Create<string>(
                                                     HttpMethod.Post,
                                                    "https://0.u.7518.cn/Txooo/SalesV2/Member/Ajax/UserAjax.ajax/GetUserInfo",
                                                    "https://0.u.7518.cn/Member/team.html"
                );
            await realNameCtx.SendAsync();
            if (realNameCtx.IsValid())
            {
                //匹配出名字信息
                if (realNameCtx.Result != "nouser")
                {
                    LoginInfo.DisplayName = JsonConvert.DeserializeObject<List<UserInfo>>(realNameCtx.Result.Replace("\r\n",""))[0].nick_name;
                }
            }
            //这里失败了我们就随便起个名字，嗯。
            if (LoginInfo.DisplayName.IsNullOrEmpty())
                LoginInfo.DisplayName = "路人甲";
            


            IsLogined = true;

            return null;
        }
    }
}

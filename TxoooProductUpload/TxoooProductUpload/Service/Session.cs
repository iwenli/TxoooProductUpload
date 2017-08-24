using FSLib.Network.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TxoooProductUpload.Common;
using TxoooProductUpload.Network;
using TxoooProductUpload.Service.Entities;
using TxoooProductUpload.Service.Entities.Web;

namespace TxoooProductUpload.Service
{
    /// <summary>
    /// 表示当前的登录会话，以及一些必须的状态信息。
    /// </summary>
    public class Session
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

        LoginAsyncResult _token;
        /// <summary>
        /// APP接口调用Token
        /// </summary>
        public LoginAsyncResult Token
        {
            get { return _token; }
            private set { _token = value; }
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
            var webLoginData = new
            {
                userName = LoginInfo.UserName,
                passWord = LoginInfo.Password
            };
            var apploginData = new
            {
                username = LoginInfo.UserName,
                password = LoginInfo.Password.MD5().ToLower()
            };
            //网页登录
            var webResult = NetClient.Create<string>(HttpMethod.Post, ApiList.MchWebLogin, data: webLoginData);
            webResult.Send();

            //app登陆
            var loginCheck = NetClient.Create<LoginAsyncResult>(HttpMethod.Post, ApiList.Login, data: apploginData);
            await loginCheck.SendAsync();
            if (!loginCheck.IsValid())
            {
                return loginCheck.Exception ?? new Exception("未能提交请求");
            }
            _token = loginCheck.Result;
            if (!_token.IsSuceess)
            {
                return new Exception(_token.msg);
            }

            //登录好了。等等。。我们好像想拿到显示的中文名？
            //所以多加一个请求吧。
            var realNameCtx = NetClient.Create<WebResponseResult<MchInfo>>(
                                                     HttpMethod.Get,
                                                    ApiList.GetMchStateInfo,
                                                    "https://0.u.7518.cn/",
                                                    _token
                );
            await realNameCtx.SendAsync();
            if (realNameCtx.IsValid())
            {
                //匹配出名字信息
                if (realNameCtx.Result.success && realNameCtx.Result.Data.Length > 0)
                {
                    _loginInfo.MchInfo = realNameCtx.Result.Data[0];
                    LoginInfo.DisplayName = _loginInfo.MchInfo.ComName + "-" + _loginInfo.MchInfo.NickName;
                }
            }
            //这里失败了我们就随便起个名字，嗯。
            if (LoginInfo.DisplayName.IsNullOrEmpty())
                LoginInfo.DisplayName = "路人甲";

            IsLogined = true;
            ApiList.Token = _token;
            return null;
        }


        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns></returns>
        public async Task<LoginInfo> LoginAsync(LoginInfo loginInfo)
        {
            IsLogined = false;
            LoginInfo = loginInfo;
            var webLoginData = new
            {
                userName = LoginInfo.UserName,
                passWord = LoginInfo.Password
            };
            var apploginData = new
            {
                username = LoginInfo.UserName,
                password = LoginInfo.Password.MD5().ToLower()
            };
            //网页登录
            var webResult = NetClient.Create<string>(HttpMethod.Post, ApiList.MchWebLogin, data: webLoginData);
            webResult.Send();

            //app登陆
            var loginCheck = NetClient.Create<LoginAsyncResult>(HttpMethod.Post, ApiList.Login, data: apploginData);
            await loginCheck.SendAsync();
            if (!loginCheck.IsValid())
            {
                throw loginCheck.Exception ?? new Exception(string.Format("未能提交请求{0}", ApiList.Login));
            }
            _token = loginCheck.Result;
            if (!_token.IsSuceess)
            {
                throw new Exception(_token.msg);
            }

            //登录好了。等等。。我们好像想拿到显示的中文名？
            //所以多加一个请求吧。
            var realNameCtx = NetClient.Create<WebResponseResult<MchInfo>>(
                                                     HttpMethod.Get,
                                                    ApiList.GetMchStateInfo,
                                                    "https://0.u.7518.cn/",
                                                    _token
                );
            await realNameCtx.SendAsync();
            if (!realNameCtx.IsValid())
            {
                throw realNameCtx.Exception ?? new Exception(string.Format("未能提交请求{0}", ApiList.GetMchStateInfo));
            }
            //匹配出名字信息
            if (realNameCtx.Result.success && realNameCtx.Result.Data.Length > 0)
            {
                _loginInfo.MchInfo = realNameCtx.Result.Data[0];
                LoginInfo.DisplayName = _loginInfo.MchInfo.ComName + "-" + _loginInfo.MchInfo.NickName;
            }
            //这里失败了我们就随便起个名字，嗯。
            if (LoginInfo.DisplayName.IsNullOrEmpty())
                LoginInfo.DisplayName = "路人甲";
            
            IsLogined = true;
            ApiList.Token = _token;
            return LoginInfo;
        }
    }
}

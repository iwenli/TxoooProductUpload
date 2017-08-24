using CCWin.SkinControl;
using Iwenli;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Common;
using TxoooProductUpload.Service.Entities;

namespace TxoooProductUpload.UI.Service
{
    /// <summary>
    /// 用户相关服务
    /// </summary>
    class UserService : ServiceBase
    {
        /// <summary>
        /// 头像缓存目录
        /// </summary>
        string _cachePath;
        public UserService()
        {
            MsgTemplate = "[登录消息]{0}";
            _cachePath = GetCachePath("user");
        }


        //internal async Task Msg()
        //{
        //    for (int i = 0; i < 50; i++)
        //    {
        //        await Task.Delay(600);
        //        InfoMessage(MsgTemplate, "正常消息");
        //        if (i % 5 == 0)
        //        {
        //            WarnMessage(MsgTemplate, "警告消息");
        //        }
        //        if (i % 3 == 0)
        //        {
        //            ErrorMessage(MsgTemplate, "错误信息");
        //        }
        //        if (i % 7 == 0)
        //        {
        //            FatalMessage(MsgTemplate, "致命消息");
        //        }
        //    }
        //}

        /// <summary>
        /// 从缓存中获取头像
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Image GetHeadPic(string userName)
        {
            var targetFullPath = Path.Combine(_cachePath, userName + ".jpg");
            if (File.Exists(targetFullPath))
            {
                return Image.FromFile(targetFullPath);
            }
            else
            {
                return Properties.Resources.head_d;
            }
        }
        /// <summary>
        /// 存储用户头像
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task SaveHeadPicSync(LoginInfo login)
        {
            //如果不是默认头像才保持
            if (login.MchInfo.HeaPic != ConstParams.DEFAULT_HEAD_PIC)
            {
                //如果文件夹不存在，则创建 
                if (!Directory.Exists(_cachePath))
                {
                    Directory.CreateDirectory(_cachePath);
                }
                try
                {
                    var url = login.MchInfo.HeaPic.Insert(login.MchInfo.HeaPic.LastIndexOf("."), "_1_250_250_3");
                    //获取图像
                    var imgBytes = await App.Context.BaseContent.ImageService.GetImageStreamByImgUrl(login.MchInfo.HeaPic + ",1,200,200,3");
                    //写入文件
                    var targetFullPath = Path.Combine(_cachePath, login.UserName + ".jpg");
                    File.WriteAllBytes(targetFullPath, imgBytes);
                }
                catch (Exception ex)
                {
                    this.LogError("保存头像异常", ex);
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

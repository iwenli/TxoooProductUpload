using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Common;

namespace TxoooProductUpload.UI.Common
{
    /// <summary>
    /// 从配置文件中获取或设置
    /// </summary>
    public class AppConfigInfo
    {
        /// <summary>
        ///  Txooo用户默认头像URL
        /// </summary>
        public static string TxoooUserDefultHeadPic
        {
            set
            {
                AppConfig.ModifyItem("TxoooUserDefultHeadPic", value);
            }
            get
            {
                return AppConfig.GetItem("TxoooUserDefultHeadPic");
            }
        }
        /// <summary>
        /// 是否发送微信通知
        /// </summary>
        public static bool IsSendWsNotify
        {
            set
            {
                AppConfig.ModifyItem("IsSendWsNotify", value.ToString());
            }
            get
            {
                return Convert.ToBoolean(AppConfig.GetItem("IsSendWsNotify"));
            }
        }
        /// <summary>
        /// 是否启用自动更新
        /// </summary>
        public static bool IsAutoUpdate
        {
            set
            {
                AppConfig.ModifyItem("IsAutoUpdate", value.ToString());
            }
            get
            {
                return Convert.ToBoolean(AppConfig.GetItem("IsAutoUpdate"));
            }
        }
        /// <summary>
        ///  找回密码URL
        /// </summary>
        public static string FindPassWordUrl
        {
            set
            {
                AppConfig.ModifyItem("FindPassWordUrl", value);
            }
            get
            {
                return AppConfig.GetItem("FindPassWordUrl");
            }
        }

        /// <summary>
        ///  用户注册URL
        /// </summary>
        public static string RegisterUrl
        {
            set
            {
                AppConfig.ModifyItem("RegisterUrl", value);
            }
            get
            {
                return AppConfig.GetItem("RegisterUrl");
            }
        }
        /// <summary>
        ///  联系作者URL通过QQ
        /// </summary>
        public static string ContactAuthorUrl
        {
            set
            {
                AppConfig.ModifyItem("ContactAuthorUrl", value);
            }
            get
            {
                return AppConfig.GetItem("ContactAuthorUrl");
            }
        }

        /// <summary>
        ///  Txooo用户默认头像URL
        /// </summary>
        public static string[] DetailImageFilter
        {
            set
            {
                AppConfig.ModifyItem("TxoooUserDefultHeadPic", string.Join(",", value));
            }
            get
            {
                return AppConfig.GetItem("TxoooUserDefultHeadPic")?.Split(',');
            }
        }
    }
}

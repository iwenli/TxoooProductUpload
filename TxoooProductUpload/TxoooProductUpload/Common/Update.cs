using FSLib.App.SimpleUpdater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Common
{
    /// <summary>
    /// 软件更新相关
    /// </summary>
    public class Update
    {
        /// <summary>
        /// 是否启用更新
        /// </summary>
        public static bool Enable
        {
            set
            {
                AppConfig.ModifyItem("update", value.ToString());
            }
            get
            {
                return Convert.ToBoolean(AppConfig.GetItem("update"));
            }
        }
        /// <summary>
        /// 检测并更新
        /// </summary>
        public static async Task<Version> CheckUpdateTask()
        {
            Version newVersion = null;
            if (Enable)
            {
                //任务模式检测更新
                var updater = Updater.CreateUpdaterInstance(@"http://iwenli.org/soft/7518/{0}", "update_c.xml");
                try
                {
                    newVersion = await updater.CheckUpdateTask();
                }
                catch (Exception ex)
                {
                    Iwenli.LogHelper.GetLogger("App-Update").Error("升级程序异常", ex);
                }
            }
            return newVersion;
        }
    }
}

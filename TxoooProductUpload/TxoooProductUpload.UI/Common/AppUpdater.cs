using FSLib.App.SimpleUpdater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Common;

namespace TxoooProductUpload.UI.Common
{
    /// <summary>
    /// 系统更新
    /// </summary>
    class AppUpdater
    {
        
        /// <summary>
        /// 检测并更新
        /// </summary>
        public static async Task<Version> CheckUpdateTask()
        {
            Version newVersion = null;
            if (AppConfigInfo.IsAutoUpdate)
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

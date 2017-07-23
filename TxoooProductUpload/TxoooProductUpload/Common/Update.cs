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
    class Update
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
        public static async void CheckUpdateTask()
        {
            if (Enable)
            {
                var updater = Updater.CreateUpdaterInstance(@"http://iwenli.org/soft/7518/{0}", "update_c.xml");
                //任务模式检测更新
                Version newVersion = null;
                try
                {
                    newVersion = await updater.CheckUpdateTask();
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: " + updater.Context.Exception.Message);
                }
            }
        }
    }
}

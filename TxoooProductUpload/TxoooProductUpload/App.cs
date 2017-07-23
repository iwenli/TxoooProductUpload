using FSLib.App.SimpleUpdater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TxoooProductUpload.Common;
using TxoooProductUpload.UI.Main;

namespace TxoooProductUpload
{
    static class App
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Update.CheckUpdateTask();
            Application.Run(new MainForm());
        }
    }
}

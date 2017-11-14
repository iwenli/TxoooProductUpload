using FSLib.App.SimpleUpdater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TxoooProductUpload.Common;
using TxoooProductUpload.UI;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Update.CheckUpdateTask().Result == null)
            {
                //Application.Run(new MainForm());
                Application.Run(new UI.ImageDownload.Crawler(new Service.ServiceContext()));
            }
        }
    }
}

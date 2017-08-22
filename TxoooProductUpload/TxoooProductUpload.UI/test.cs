using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TxoooProductUpload.UI
{
    static class test
    {
        public static Form MainForm { set; get; }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if ((CefGlue.WlCefGlueLoader.InitCEF() == 0))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MainForm = new CefTest();
                Application.Run(MainForm);
            }
        }
    }
}

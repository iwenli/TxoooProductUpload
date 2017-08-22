using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TxoooProductUpload.Common;

namespace TxoooProductUpload.UI
{
    static class App
    {
        public static Form MainForm { set; get; }
        static System.Threading.Mutex _mutex;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (CanRun())
            {
                MainForm = new BaseForm();
                Application.Run(MainForm);
            }
        }

        /// <summary>
        /// 是否可以启动窗体
        /// 暂无运行的窗体  &&  没有需要更新的版本
        /// </summary>
        /// <returns></returns>
        static bool CanRun()
        {
            bool canRun;
            Attribute guid_attr = Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(GuidAttribute));
            string guid = ((GuidAttribute)guid_attr).Value;
            _mutex = new System.Threading.Mutex(true, guid, out canRun);
            if (!canRun)
            {
                MessageBox.Show("已经在运行了。", ConstParams.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                _mutex.ReleaseMutex();
            }
            return canRun && Update.CheckUpdateTask().Result == null;
        }
    }
}

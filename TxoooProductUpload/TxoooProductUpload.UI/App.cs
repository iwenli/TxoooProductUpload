using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TxoooProductUpload.Common;
using Iwenli;

namespace TxoooProductUpload.UI
{
    static class App
    {
        static System.Threading.Mutex _mutex;

        /// <summary>
        /// 全局上下文
        /// </summary>
        public static Service.ServiceContext Context { get; private set; }

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
                try
                {
                    Context = Service.ServiceContext.Instance;
                    Application.Run(new LoginForm());
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger("App").LogError(ex.Message, ex);
                }
                
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
                new MsgBox("已经在运行了。", "", Handler.MessageType.FATAL).ShowDialog();
            }
            else {
                canRun = Update.CheckUpdateTask().Result == null;
            }
            return canRun;
        }
    }
}

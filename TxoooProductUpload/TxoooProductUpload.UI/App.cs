using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Iwenli;
using CCWin;
using TxoooProductUpload.UI.Common.Const;
using TxoooProductUpload.UI.Common;
using TxoooProductUpload.UI.Forms.SubForms;

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
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            JsonConvertSettings();

            //App.Context = Service.ServiceContext.Instance;
            ////Application.Run(new Msgtest());

            if (CanRun() && CefGlue.WlCefGlueLoader.InitCEF(args) == 0)
            {
                try
                {
                    Context = Service.ServiceContext.Instance;
                    //TxoooProductUpload.UI.Main.MainForm()
                    Application.Run(new LoginForm());
                    //Application.Run(new CrawlProductsForm());
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger("App").LogError(ex.Message, ex);
                }

                CefGlue.WlCefGlueLoader.ShutDownCEF();
                Application.Exit();//退出整个应用程序。（无法退出单独开启的线程）
                Application.ExitThread();//释放所有线程　
            }
        }

        /// <summary>
        /// 全局序列化设置
        /// </summary>
        static void JsonConvertSettings()
        {
            Newtonsoft.Json.JsonSerializerSettings setting = new Newtonsoft.Json.JsonSerializerSettings();
            Newtonsoft.Json.JsonConvert.DefaultSettings = new Func<Newtonsoft.Json.JsonSerializerSettings>(() =>
            {
                //日期类型默认格式化处理
                setting.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
                setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";

                //空值处理
                setting.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

                ////高级用法九中的Bool类型转换 设置
                //setting.Converters.Add(new BoolConvert("是,否"));

                return setting;
            });
        }
        /// <summary>
        /// 是否可以启动窗体
        /// 暂无运行的窗体  &&  没有需要更新的版本  && 网络
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
                MessageBoxEx.Show("已经在运行了!", AppInfo.AssemblyTitle,
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                canRun = IsConnect();
                if (!canRun)
                {
                    MessageBoxEx.Show("网络异常，请检查网络是否连接!", AppInfo.AssemblyTitle,
                                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    canRun = AppUpdater.CheckUpdateTask().Result == null;
                }
            }
            return canRun;
        }

        #region 联网校验
        private const int INTERNET_CONNECTION_MODEM = 1;
        private const int INTERNET_CONNECTION_LAN = 2;
        [DllImport("winInet.dll ")]
        private static extern bool InternetGetConnectedState(
        ref int dwFlag,
        int dwReserved
        );
        /// <summary>
        /// 是否联网
        /// </summary>
        static bool IsConnect()
        {
            Int32 dwFlag = new int();
            bool result = true;
            if (!InternetGetConnectedState(ref dwFlag, 0))
            {
                LogHelper.GetLogger("netWork").LogInfo("网络连接已断开...");
                result = false;
            }
            else if ((dwFlag & INTERNET_CONNECTION_MODEM) != 0)
            {
                LogHelper.GetLogger("netWork").LogInfo("网络已连接[调治解调器]...");
            }
            else if ((dwFlag & INTERNET_CONNECTION_LAN) != 0)
            {
                LogHelper.GetLogger("netWork").LogInfo("网络已连接[网卡]...");
            }
            return result;
        }
        #endregion
    }
}

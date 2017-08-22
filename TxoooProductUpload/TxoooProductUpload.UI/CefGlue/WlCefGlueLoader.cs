using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace TxoooProductUpload.UI.CefGlue
{
    class WlCefGlueLoader : IDisposable
    {
        #region IDisposable

        ~WlCefGlueLoader()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        #endregion

        public static int InitCEF()
        {
            try
            {
                //此行代码用于加载CEF的运行时
                CefRuntime.Load();
            }
            catch (DllNotFoundException ex)
            {
                return 1;
            }
            catch (CefRuntimeException ex)
            {
                return 2;
            }
            catch (Exception ex)
            {
                return 3;
            }

            //此行代码可以收集命令行参数，用于传递给CEF浏览器
            string[] args = new string[0];
            var mainArgs = new CefMainArgs(args);

            var app = new WlCefApp();

            //用于启动第二个进程，至于用第二个进程做什么，我没有深入研究过（可以是浏览器的第二个进程、也可以是一个可执行文件的）
            //注意：CefRuntime.ExecuteProcess方法必须在程序的入口处调用；
            var exitCode = CefRuntime.ExecuteProcess(mainArgs, app);
            //System.Diagnostics.Trace.WriteLine("CefRuntime.ExecuteProcess return: " + exitCode);
            if (exitCode != -1)
            {
                return exitCode;
            }

            var settings = new CefSettings
            {
#if DEBUG
                //BrowserSubprocessPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Cef3Process.exe"),
                SingleProcess = true,//此处目的是使用多进程。注意：强烈不建议使用单进程，单进程不稳定，而且Chromium内核不支持
#else
                SingleProcess = false,
#endif

                //此处的目的是让浏览器的消息循环在一个单独的线程中执行
                //注意：强烈建议设置成true,要不然你得在你的程序中自己处理消息循环；自己调用CefDoMessageLoopWork()
                MultiThreadedMessageLoop = true,

                LogSeverity = CefLogSeverity.Disable,
                LogFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"log\CefGlue.log"),

                //CachePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"cache"),
                //CommandLineArgsDisabled = true,
                Locale = "zh_CN",
                LocalesDirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"locales"),
                //RemoteDebuggingPort = 7789,
            };

            //这句代码把创建的配置信息和命令行信息传递个cef的运行时
            //此函数必须在应用程序的主线程中调用
            CefRuntime.Initialize(mainArgs, settings, app);

            //如果你在前面设置的MultiThreadedMessageLoop为false，
            //那么你可以加入如上代码，自行调用CefRuntime.DoMessageLoopWork();
            if (!settings.MultiThreadedMessageLoop)
            {
                System.Windows.Forms.Application.Idle += (sender, e) => { CefRuntime.DoMessageLoopWork(); };
            }

            return 0;
        }

        private static string GetPath(string v)
        {
            return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, v));
        }

        public static void ShutDownCEF()
        {
            try
            {
                //主进程结束时，要释放CEF的资源，并结束浏览器的进程。
                CefRuntime.Shutdown();
            }
            catch (Exception)
            {
            }
        }
    }
}

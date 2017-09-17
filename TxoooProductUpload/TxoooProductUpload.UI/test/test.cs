using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TxoooProductUpload.UI.CefGlue;
using Xilium.CefGlue;

namespace TxoooProductUpload.UI.Test
{
    internal sealed class DemoApp : CefApp
    {
        protected override void OnBeforeCommandLineProcessing(string processType, CefCommandLine commandLine)
        {
            commandLine.AppendSwitch("--ppapi-flash-path", Environment.CurrentDirectory + "\\plugins\\pepflashplayer.dll");
            commandLine.AppendSwitch("--ppapi-flash-version", "20.0.0.267");
        }
    }

    static class test
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            if (WlCefGlueLoader.InitCEF(args) == 0)
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
                catch (Exception ex)
                {
                }

                WlCefGlueLoader.ShutDownCEF();
                Application.Exit();//退出整个应用程序。（无法退出单独开启的线程）
                Application.ExitThread();//释放所有线程　
            }
            return 0;

            //try
            //{
            //    CefRuntime.Load();
            //}
            //catch (DllNotFoundException ex)
            //{
            //    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return 1;
            //}
            //catch (CefRuntimeException ex)
            //{
            //    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return 2;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return 3;
            //}

            //var mainArgs = new CefMainArgs(args);
            //var app = new DemoApp();

            //var exitCode = CefRuntime.ExecuteProcess(mainArgs, app);
            //if (exitCode != -1)
            //    return exitCode;

            //var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            //var localFolder = Path.GetDirectoryName(new Uri(codeBase).LocalPath);
            //var browserProcessPath = CombinePaths(localFolder, "..", "..", "..",
            //    "CefGlue.Demo.WinForms", "bin", "Release", "Xilium.CefGlue.Demo.WinForms.exe");

            //var settings = new CefSettings
            //{
            //    //BrowserSubprocessPath = browserProcessPath,
            //    // UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1",
            //    SingleProcess = false,
            //    MultiThreadedMessageLoop = true,
            //    LogSeverity = CefLogSeverity.Disable,
            //    LogFile = "CefGlue.log",
            //};

            //CefRuntime.Initialize(mainArgs, settings, app);


            //if (!settings.MultiThreadedMessageLoop)
            //{
            //    Application.Idle += (sender, e) => { CefRuntime.DoMessageLoopWork(); };
            //}

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());

            //CefRuntime.Shutdown();
            //return 0;
        }

        public static string CombinePaths(params string[] paths)
        {
            if (paths == null)
            {
                throw new ArgumentNullException("paths");
            }
            return paths.Aggregate(Path.Combine);
        }
    }
}

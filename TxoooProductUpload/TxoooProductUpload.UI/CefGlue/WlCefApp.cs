using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace TxoooProductUpload.UI.CefGlue
{
    /// <summary>
    /// CefApp: 与进程，命令行参数，代理，资源管理相关的回调类，用于让 CEF3 的调用者们定制自己的逻辑
    /// </summary>
    internal sealed class WlCefApp : CefApp
    {
        ///// <summary>
        ///// Browser进程处理类
        ///// </summary>
        //private CefBrowserProcessHandler _browserProcessHandler = new WlCefBrowserProcessHandler();

        ///// <summary>
        ///// Render进程处理类
        ///// </summary>
        //private CefRenderProcessHandler _renderProcessHandler = new WlCefRenderProcessHandler();

        //OnBeforeCommandLineProcessing 函数在你的程序启动 CEF 和 Chromium 之前给你提供了修改命令行参数的机会；
        protected override void OnBeforeCommandLineProcessing(string processType, CefCommandLine commandLine)
        {
            //Console.WriteLine("OnBeforeCommandLineProcessing: {0} {1}", processType, commandLine);

            //commandLine.AppendArgument("enable-npapi");
            //commandLine.AppendSwitch("enable-media-stream", "enable-media-stream");
            //commandLine.AppendSwitch("process-per-site");
            //commandLine.AppendSwitch("ppapi-flash-version", "23.0.0.185");//PepperFlash\manifest.json中的version
            //commandLine.AppendSwitch("ppapi-flash-path", "PepperFlash\\pepflashplayer.dll");
            //Flash插件加载
            //commandLine.AppendSwitch("--ppapi-flash-path", Environment.CurrentDirectory + "\\plugins\\pepflashplayer.dll");
            //commandLine.AppendSwitch("--ppapi-flash-version", "20.0.0.267");


            // TODO: currently on linux platform location of locales and pack files are determined
            // incorrectly (relative to main module instead of libcef.so module).
            // Once issue http://code.google.com/p/chromiumembedded/issues/detail?id=668 will be resolved
            // this code can be removed.
            //if (CefRuntime.Platform == CefRuntimePlatform.Linux)
            //{
            //    var path = new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath;
            //    path = Path.GetDirectoryName(path);

            //    commandLine.AppendSwitch("resources-dir-path", path);
            //    commandLine.AppendSwitch("locales-dir-path", Path.Combine(path, "locales"));
            //}
        }

        //protected override CefBrowserProcessHandler GetBrowserProcessHandler()
        //{
        //    return _browserProcessHandler;
        //}

        //protected override CefRenderProcessHandler GetRenderProcessHandler()
        //{
        //    return _renderProcessHandler;
        //}
    }
}

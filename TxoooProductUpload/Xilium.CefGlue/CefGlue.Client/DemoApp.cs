namespace Xilium.CefGlue.Client
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xilium.CefGlue;

    internal sealed class DemoApp : CefApp
    {

        protected override void OnBeforeCommandLineProcessing(string processType, CefCommandLine commandLine)
        {
            //commandLine.AppendSwitch("--ppapi-flash-path", Environment.CurrentDirectory + "\\plugins\\pepflashplayer.dll");
            //commandLine.AppendSwitch("--ppapi-flash-version", "20.0.0.267");
            //if (CefRuntime.Platform == CefRuntimePlatform.Linux)
            //{
            //    var path = new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath;
            //    path = Path.GetDirectoryName(path);

            //    commandLine.AppendSwitch("resources-dir-path", path);
            //    commandLine.AppendSwitch("locales-dir-path", Path.Combine(path, "locales"));
            //}
        }
    }
}

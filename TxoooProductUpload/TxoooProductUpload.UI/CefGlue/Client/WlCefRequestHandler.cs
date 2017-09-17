using System;
using System.Collections.Generic;
using System.Text;
using Xilium.CefGlue;
using Xilium.CefGlue.WindowsForms;

namespace TxoooProductUpload.UI.CefGlue
{
    /// <summary>
    /// 用于监听资源加载，重定向等信息
    /// </summary>
    sealed class WlCefRequestHandler : CefRequestHandler
    {
        private readonly CefWebBrowser _core;

        public WlCefRequestHandler(CefWebBrowser core)
        {
            _core = core;
        }

        //protected override void OnPluginCrashed(CefBrowser browser, string pluginPath)
        //{
        //    _core.InvokeIfRequired(() => _core.OnPluginCrashed(new PluginCrashedEventArgs(pluginPath)));
        //}

        //protected override void OnRenderProcessTerminated(CefBrowser browser, CefTerminationStatus status)
        //{
        //    _core.InvokeIfRequired(() => _core.OnRenderProcessTerminated(new RenderProcessTerminatedEventArgs(status)));
        //}
    }
}

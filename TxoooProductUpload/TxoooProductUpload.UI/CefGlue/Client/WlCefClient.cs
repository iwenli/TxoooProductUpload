using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xilium.CefGlue;
using Xilium.CefGlue.WindowsForms;


namespace TxoooProductUpload.UI.CefGlue
{    
    
    //CefClient: 回调管理类，该类的对象作为参数可以被传递给CefCreateBrowser() 或者 CefCreateBrowserSync() 函数。该类的主要接口如下：
    /*
     * CefContextMenuHandler，回调类，主要用于处理 Context Menu 事件。
     * CefDialogHandler，回调类，主要用来处理对话框事件。
     * CefDisplayHandler，回调类，处理与页面状态相关的事件，如页面加载情况的变化，地址栏变化，标题变化等事件。
     * CefDownloadHandler，回调类，主要用来处理文件下载。
     * CefFocusHandler，回调类，主要用来处理焦点事件。
     * CefGeolocationHandler，回调类，用于申请 geolocation 权限。
     * CefJSDialogHandler，回调类，主要用来处理 JS 对话框事件。
     * CefKeyboardHandler，回调类，主要用来处理键盘输入事件。
     * CefLifeSpanHandler，回调类，主要用来处理与浏览器生命周期相关的事件，与浏览器对象的创建、销毁以及弹出框的管理。
     * CefLoadHandler，回调类，主要用来处理浏览器页面加载状态的变化，如页面加载开始，完成，出错等。
     * CefRenderHandler，回调类，主要用来处在在窗口渲染功能被关闭的情况下的事件。
     * CefRequestHandler，回调类，主要用来处理与浏览器请求相关的的事件，如资源的的加载，重定向等。     
     */

    class WlCefClient : CefClient
    {
        private readonly CefWebBrowser _core;

        //用于控制popup对话框的创建和关闭等操作
        private readonly WlCefLifeSpanHandler _lifeSpanHandler;
        //用于监听页面加载状态，地址变化，标题等得信息
        private readonly WlCefDisplayHandler _displayHandler;
        //以用来监听frame的加载开始，完成，错误等信息
        private readonly WlCefLoadHandler _loadHandler;
        //用于监听资源加载，重定向等信息
        private readonly WlCefRequestHandler _requestHandler;

        public WlCefClient(CefWebBrowser core)
        {
            _core = core;
            _lifeSpanHandler = new WlCefLifeSpanHandler(_core);
            _displayHandler = new WlCefDisplayHandler(_core);
            _loadHandler = new WlCefLoadHandler(_core);
            _requestHandler = new WlCefRequestHandler(_core);
        }

        protected CefWebBrowser Core { get { return _core; } }

        protected override CefLifeSpanHandler GetLifeSpanHandler()
        {
            return _lifeSpanHandler;
        }

        protected override CefDisplayHandler GetDisplayHandler()
        {
            return _displayHandler;
        }

        protected override CefLoadHandler GetLoadHandler()
        {
            return _loadHandler;
        }

        protected override CefRequestHandler GetRequestHandler()
        {
            return _requestHandler;
        }

        /// <summary>
        /// 这个方法来处理跨进程消息
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="sourceProcess"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected override bool OnProcessMessageReceived(CefBrowser browser, CefProcessId sourceProcess, CefProcessMessage message)
        {
            if (message.Name == "JavascriptExecutedResult")
            {
                var process = Process.GetCurrentProcess();
                Trace.TraceInformation(string.Format("当前进程信息：{0}-{1}-{2}-{3}", process.Id, process.SessionId, process.ProcessName, process.StartTime));
                Trace.WriteLine(string.Format("Render::OnProcessMessageReceived: SourceProcess={0}", sourceProcess));
                Trace.WriteLine(string.Format("Message Name={0} IsValid={1} IsReadOnly={2}", message.Name, message.IsValid, message.IsReadOnly));
                string result = message.Arguments.GetString(0);
                Trace.WriteLine(""+result);
            }
            message.Arguments.SetString(2, "ddddd");
            return base.OnProcessMessageReceived(browser, sourceProcess, message);
        }
    }
}

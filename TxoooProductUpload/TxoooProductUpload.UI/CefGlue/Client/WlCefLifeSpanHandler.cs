using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Xilium.CefGlue;
using Xilium.CefGlue.WindowsForms;

namespace TxoooProductUpload.UI.CefGlue
{
    /// <summary>
    /// 用于控制popup对话框的创建和关闭等操作
    /// </summary>
    internal sealed class WlCefLifeSpanHandler : CefLifeSpanHandler
    {
        private readonly CefWebBrowser _core;

        public WlCefLifeSpanHandler(CefWebBrowser core)
        {
            _core = core;
        }

        protected override void OnAfterCreated(CefBrowser browser)
        {
            base.OnAfterCreated(browser);

        	_core.InvokeIfRequired(() => _core.OnBrowserAfterCreated(browser));
        }

        protected override bool DoClose(CefBrowser browser)
        {
            // TODO: ... dispose core
            return false;
        }

		protected override void OnBeforeClose(CefBrowser browser)
		{
			if (_core.InvokeRequired)
				_core.BeginInvoke((Action)_core.OnBeforeClose);
			else
				_core.OnBeforeClose();
		}

        protected override bool OnBeforePopup(CefBrowser browser, CefFrame frame, string targetUrl, string targetFrameName, CefWindowOpenDisposition targetDisposition, bool userGesture, CefPopupFeatures popupFeatures, CefWindowInfo windowInfo, ref CefClient client, CefBrowserSettings settings, ref bool noJavascriptAccess)
		{
            frame.LoadUrl(targetUrl);
            return true;
            // _core.Browser.GetMainFrame().LoadUrl(targetUrl);
            //return true;

            //var e = new BeforePopupEventArgs(frame, targetUrl, targetFrameName, popupFeatures, windowInfo, client, settings,
            //                     noJavascriptAccess);

            //_core.InvokeIfRequired(() => _core.OnBeforePopup(e));

            //client = e.Client;
            //noJavascriptAccess = e.NoJavascriptAccess;

            //return e.Handled;
        }
    }
}

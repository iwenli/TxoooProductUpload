using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xilium.CefGlue;

namespace TxoooProductUpload.UI.CefGlue
{
    /// <summary>
    /// 呼叫JS脚本交互类
    /// </summary>
    [System.Runtime.InteropServices.ComVisible(true)]
    public class TxCallJSEvent
    {
        public bool USBPhoneOk()
        {
            return false;
        }

        public string Call(string phone)
        {
            //Xilium.CefGlue.CefV8Context.GetCurrentContext().GetBrowser().GetMainFrame().ExecuteJavaScript();
            string _info = "发起呼叫\r\n";
            try
            {
                CefProcessMessage message = CefProcessMessage.Create("call");
                message.Arguments.SetString(0, phone);
                Xilium.CefGlue.CefV8Context.GetCurrentContext().GetBrowser().SendProcessMessage(CefProcessId.Browser, message);

               string _11 =  message.Arguments.GetString(1);
            }
            catch (Exception ex)
            {
                _info += ex.Message;
                _info += ex.StackTrace;
            }
            return _info;
        }
    }
}

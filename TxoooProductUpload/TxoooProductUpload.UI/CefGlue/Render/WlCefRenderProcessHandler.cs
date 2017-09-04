using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace TxoooProductUpload.UI.CefGlue
{
    #region 声明委托回调
    /// <summary>
    /// 网页脚本与后台程序交互方法
    /// 提示一：V8HandlerDelegate要在namespace下面定义，不要写到class里去了
    /// 提示二：如果 returnValue = null; 则会导致网页前端出现错误：Cannot read property ‘constructor’ of undefined
    /// 提示三：还存在其他的可能，导致导致网页前端出现错误：Cannot read property ‘constructor’ of undefined
    /// </summary>
    /// <param name=”name”>名称</param>
    /// <param name=”obj”>对象</param>
    /// <param name=”arguments”>参数</param>
    /// <param name=”returnValue”>返回值</param>
    /// <param name=”exception”>返回异常信息</param>
    /// <returns></returns>
    public delegate void V8HandlerDelegate(string name, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception);

    #endregion 声明委托回调

    class WlCefRenderProcessHandler : CefRenderProcessHandler
    {
        #region 处理来自Browser进程的消息

        internal static bool DumpProcessMessages { get; private set; }

        /// <summary>
        /// 处理来自Browser进程的消息
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="frame"></param>
        /// <param name="context"></param>
        protected override bool OnProcessMessageReceived(CefBrowser browser, CefProcessId sourceProcess, CefProcessMessage message)
        {
            var process = Process.GetCurrentProcess();
            Trace.TraceInformation(string.Format("当前进程信息：{0}-{1}-{2}-{3}", process.Id, process.SessionId, process.ProcessName, process.StartTime));
            Trace.WriteLine(string.Format("Render::OnProcessMessageReceived: SourceProcess={0}", sourceProcess));
            Trace.WriteLine(string.Format("Message Name={0} IsValid={1} IsReadOnly={2}", message.Name, message.IsValid, message.IsReadOnly));

            #region OLD
            //if (DumpProcessMessages)
            //{
            //    Console.WriteLine("Render::OnProcessMessageReceived: SourceProcess={0}", sourceProcess);
            //    Console.WriteLine("Message Name={0} IsValid={1} IsReadOnly={2}", message.Name, message.IsValid, message.IsReadOnly);
            //    var arguments = message.Arguments;
            //    for (var i = 0; i < arguments.Count; i++)
            //    {
            //        var type = arguments.GetValueType(i);
            //        object value;
            //        switch (type)
            //        {
            //            case CefValueType.Null: value = null; break;
            //            case CefValueType.String: value = arguments.GetString(i); break;
            //            case CefValueType.Int: value = arguments.GetInt(i); break;
            //            case CefValueType.Double: value = arguments.GetDouble(i); break;
            //            case CefValueType.Bool: value = arguments.GetBool(i); break;
            //            default: value = null; break;
            //        }

            //        Console.WriteLine("  [{0}] ({1}) = {2}", i, type, value);
            //    }
            //}

            ////var handled = MessageRouter.OnProcessMessageReceived(browser, sourceProcess, message);
            ////if (handled) return true;

            //if (message.Name == "myMessage2") return true;

            //var message2 = CefProcessMessage.Create("myMessage2");
            //var success = browser.SendProcessMessage(CefProcessId.Renderer, message2);
            //Console.WriteLine("Sending myMessage2 to renderer process = {0}", success);

            //var message3 = CefProcessMessage.Create("myMessage3");
            //var success2 = browser.SendProcessMessage(CefProcessId.Browser, message3);
            //Console.WriteLine("Sending myMessage3 to browser process = {0}", success);

            //return false; 
            #endregion
            if (message.Name == "ExecuteJavaScript")
            {
                string code = message.Arguments.GetString(0);
                var context = browser.GetMainFrame().V8Context;
                context.Enter();
                try
                {
                    var global = context.GetGlobal();
                    var evalFunc = global.GetValue("eval");
                    CefV8Value arg0 = CefV8Value.CreateString(code);

                    var rtn = evalFunc.ExecuteFunctionWithContext(context, evalFunc,
                        new CefV8Value[] { arg0 });
                    if (evalFunc.HasException)
                    {
                        var exception = evalFunc.GetException();
                        var message3 = CefProcessMessage.Create("Exception");
                        var arguments = message3.Arguments;
                        arguments.SetString(0, exception.Message + " At Line" + exception.LineNumber);
                        var success2 = browser.SendProcessMessage(CefProcessId.Browser, message3);

                    }
                    else
                    {
                        var message3 = CefProcessMessage.Create("JavascriptExecutedResult");
                        var arguments = message3.Arguments;
                        arguments.SetString(0, rtn.GetStringValue());
                        var success2 = browser.SendProcessMessage(CefProcessId.Browser, message3);
                    }
                }

                finally
                {
                    context.Exit();
                }
            }
            return false;
        }

        #endregion

        #region 事件

        /// <summary>
        /// js上下文创建后被调用的
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="frame"></param>
        /// <param name="context"></param>
        protected override void OnContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context)
        {
            //添加js全局顶级对象
            //var global = context.GetGlobal();
            //var extent = CefV8Value.CreateObject(null);
            //global.SetValue("txApp", extent, CefV8PropertyAttribute.None);

            foreach (KeyValuePair<string, object> kvp in CefRuntimeEx.GetObjects())
            {
                BindingHandler.Bind(kvp.Key, kvp.Value, context.GetGlobal()); //绑定方式一
                //BindingHandler.Bind(kvp.Key, kvp.Value, context.GetGlobal(), false); //绑定方式二
            }
            base.OnContextCreated(browser, frame, context);
        }


        /// <summary>
        /// 函数中释放任何V8所关联的Context
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="frame"></param>
        /// <param name="context"></param>
        protected override void OnContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context)
        {
            // MessageRouter.OnContextReleased releases captured CefV8Context (if have).
            //MessageRouter.OnContextReleased(browser, frame, context);

            // Release CefV8Context.
            context.Dispose();
        }

        protected override void OnWebKitInitialized()
        {
            ////原生方式注册 ExampleA
            //exampleA = new ExampleAv8Handler();
            //CefRuntime.RegisterExtension("exampleAExtensionName", ExampleAv8Handler.exampleAJavascriptCode, exampleA);

            ////回调方式注册 ExampleB
            //exampleB = new ExampleBv8Handler { CallBack = CallBackMethod };
            //CefRuntime.RegisterExtension("exampleBExtensionName", ExampleBv8Handler.exampleBJavascriptCode, exampleB);

            // 注册JS函数
            //RegisterJs();
            //CefRuntimeEx.RegisterJsObject("exampleObject", new ExampleObject());
            CefRuntimeEx.RegisterJsObject("txCallHelper", new TxCallJSEvent());

            base.OnWebKitInitialized();
        }

        #endregion

        //protected override bool OnBeforeNavigation(CefBrowser browser, CefFrame frame, CefRequest request, CefNavigationType navigation_type, bool isRedirect)
        //{
        //   return base.OnBeforeNavigation(browser, frame, request, navigation_type, false);
        //}
    }
}

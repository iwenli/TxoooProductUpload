using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xilium.CefGlue;

namespace TxoooProductUpload.UI.CefGlue
{
    ///官方原生方法分析
    /*
     调用：exampleA.myFunction ();
     * 
     弊端：
(1)、类对象必须继承CefV8Handler，所有操作方法，都必须写在该类Execute ( )里面
(2)、类对象的所有属性、方法，都需要在后台写出对应的JS脚本，进行注册绑定
(3)、如果想执行不同操作，就需要不断的写一大堆类对象，因为每个类只能做一件事
(4)、如果前台更新，或者类的属性、方法更新，将会产生繁杂的后续联动更新操作
     */

    public class ExampleAv8Handler : CefV8Handler
    {
        public const string exampleAJavascriptCode = @"function exampleA() {}
    if (!exampleA) exampleA = {};
    (function() {
        exampleA.__defineGetter__('myParam',
        function() {
            native function GetMyParam();
            return GetMyParam();
        });
        exampleA.__defineSetter__('myParam',
        function(arg0) {
            native function SetMyParam(arg0);
            SetMyParam(arg0);
        });
        exampleA.myFunction = function() {
            native function MyFunction();
            return MyFunction();
        };
        exampleA.getMyParam = function() {
            native function GetMyParam();
            return GetMyParam();
        };
        exampleA.setMyParam = function(arg0) {
            native function SetMyParam(arg0);
            SetMyParam(arg0);
        };
    })();";


        #region 声明常量变量
        /// <summary>
        /// 内容
        /// </summary>
        public string MyParam { get; set; }
        #endregion 声明常量变量
        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ExampleAv8Handler()
        {
            MyParam = "ExampleAv8Handlerler : flydoos@vip.qq.com";
        }
        #endregion 构造函数
        #region 事件
        /// <summary>
        /// 网页脚本与后台程序交互方法
        /// 提示一：如果 returnValue = null; 则会导致网页前端出现错误：Cannot read property ‘constructor’ of undefined
        /// 提示二：还存在其他的可能，导致导致网页前端出现错误：Cannot read property ‘constructor’ of undefined
        /// </summary>
        /// <param name=”name”>名称</param>
        /// <param name=”obj”>对象</param>
        /// <param name=”arguments”>参数</param>
        /// <param name=”returnValue”>返回值</param>
        /// <param name=”exception”>返回异常信息</param>
        /// <returns></returns>
        protected override bool Execute(string name, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception)
        {
            string result = string.Empty;
            switch (name)
            {
                case "MyFunction":
                    MyFunction();
                    break;
                case "GetMyParam":
                    result = GetMyParam();
                    break;
                case "SetMyParam":
                    result = SetMyParam(arguments[0].GetStringValue());
                    break;
                default:
                    MessageBox.Show(string.Format("JS调用C# >> {0} >> {1} 返回值", name, obj.GetType()), "系统提示", MessageBoxButtons.OK);
                    break;
            }
            returnValue = CefV8Value.CreateString(result);
            exception = null;
            return true;
        }
        #endregion 事件
        #region 方法
        /// <summary>
        /// 我的函数
        /// </summary>
        public void MyFunction()
        {
            MessageBox.Show("ExampleAv8Handlerler : JS调用C# >> MyFunction >> 无 返回值", "系统提示", MessageBoxButtons.OK);
        }
        /// <summary>
        /// 取值
        /// </summary>
        /// <returns></returns>
        public string GetMyParam()
        {
            return MyParam;
        }
        /// <summary>
        /// 赋值
        /// </summary>
        /// <param name=”value”>值</param>
        /// <returns></returns>
        public string SetMyParam(string value)
        {
            MyParam = value;
            return MyParam;
        }
        #endregion 方法
    }
}

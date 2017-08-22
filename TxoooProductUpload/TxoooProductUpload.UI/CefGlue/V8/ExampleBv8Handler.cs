using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xilium.CefGlue;

namespace TxoooProductUpload.UI.CefGlue
{
    /*委托回调方法分析
     * 优势：
(1)、与方法一相比，这个的优势在于不需要在类内部（ExampleBv8Handler），写操作代码。因为有些操作必须在外面编写的，通过回调可以解决这个问题。
弊端：
(1)、弊端与方法一类似，很不灵活；
     */


    /// <summary>
    /// 委托回调方法分析
    /// </summary>
    /// <summary>
    /// 绑定测试处理器
    /// </summary>
    public class ExampleBv8Handler : CefV8Handler
    {

        public const string exampleBJavascriptCode = @"function exampleB() {}
    if (!exampleB) exampleB = {};
    (function() {
        exampleB.__defineGetter__('myProperty',
        function() {
            native function MyProperty();
            return MyProperty();
        });
        exampleB.__defineGetter__('myReadOnlyProperty',
        function() {
            native function MyReadOnlyProperty();
            return MyReadOnlyProperty();
        });
        exampleB.__defineGetter__('myUnconvertibleProperty',
        function() {
            native function MyUnconvertibleProperty();
            return MyUnconvertibleProperty();
        });
        exampleB.repeat = function(str,n) {
            native function Repeat(str,n);
            return Repeat(str,n);
        };
        exampleB.echoVoid = function() {
            native function EchoVoid();
            EchoVoid();
        };
        exampleB.echoBoolean = function(arg0) {
            native function EchoBoolean(arg0);
            return EchoBoolean(arg0);
        };
        exampleB.echoNullableBoolean = function(arg0) {
            native function EchoNullableBoolean(arg0);
            return EchoNullableBoolean(arg0);
        };
        exampleB.echoSByte = function(arg0) {
            native function EchoSByte(arg0);
            return EchoSByte(arg0);
        };
        exampleB.echoNullableSByte = function(arg0) {
            native function EchoNullableSByte(arg0);
            return EchoNullableSByte(arg0);
        };
        exampleB.echoInt16 = function(arg0) {
            native function EchoInt16(arg0);
            return EchoInt16(arg0);
        };
        exampleB.echoNullableInt16 = function(arg0) {
            native function EchoNullableInt16(arg0);
            return EchoNullableInt16(arg0);
        };
        exampleB.echoInt32 = function(arg0) {
            native function EchoInt32(arg0);
            return EchoInt32(arg0);
        };
        exampleB.echoNullableInt32 = function(arg0) {
            native function EchoNullableInt32(arg0);
            return EchoNullableInt32(arg0);
        };
        exampleB.echoInt64 = function(arg0) {
            native function EchoInt64(arg0);
            return EchoInt64(arg0);
        };
        exampleB.echoNullableInt64 = function(arg0) {
            native function EchoNullableInt64(arg0);
            return EchoNullableInt64(arg0);
        };
        exampleB.echoByte = function(arg0) {
            native function EchoByte(arg0);
            return EchoByte(arg0);
        };
        exampleB.echoNullableByte = function(arg0) {
            native function EchoNullableByte(arg0);
            return EchoNullableByte(arg0);
        };
        exampleB.echoUInt16 = function(arg0) {
            native function EchoUInt16(arg0);
            return EchoUInt16(arg0);
        };
        exampleB.echoUInt32 = function(arg0) {
            native function EchoUInt32(arg0);
            return EchoUInt32(arg0);
        };
        exampleB.echoNullableUInt32 = function(arg0) {
            native function EchoNullableUInt32(arg0);
            return EchoNullableUInt32(arg0);
        };
        exampleB.echoUInt64 = function(arg0) {
            native function EchoUInt64(arg0);
            return EchoUInt64(arg0);
        };
        exampleB.echoNullableUInt64 = function(arg0) {
            native function EchoNullableUInt64(arg0);
            return EchoNullableUInt64(arg0);
        };
        exampleB.echoSingle = function(arg0) {
            native function EchoSingle(arg0);
            return EchoSingle(arg0);
        };
        exampleB.echoNullableSingle = function(arg0) {
            native function EchoNullableSingle(arg0);
            return EchoNullableSingle(arg0);
        };
        exampleB.echoDouble = function(arg0) {
            native function EchoDouble(arg0);
            return EchoDouble(arg0);
        };
        exampleB.echoNullableDouble = function(arg0) {
            native function EchoNullableDouble(arg0);
            return EchoNullableDouble(arg0);
        };
        exampleB.echoChar = function(arg0) {
            native function EchoChar(arg0);
            return EchoChar(arg0);
        };
        exampleB.echoNullableChar = function(arg0) {
            native function EchoNullableChar(arg0);
            return EchoNullableChar(arg0);
        };
        exampleB.echoDateTime = function(arg0) {
            native function EchoDateTime(arg0);
            return EchoDateTime(arg0);
        };
        exampleB.echoNullableDateTime = function(arg0) {
            native function EchoNullableDateTime(arg0);
            return EchoNullableDateTime(arg0);
        };
        exampleB.echoDecimal = function(arg0) {
            native function EchoDecimal(arg0);
            return EchoDecimal(arg0);
        };
        exampleB.echoNullableDecimal = function(arg0) {
            native function EchoNullableDecimal(arg0);
            return EchoNullableDecimal(arg0);
        };
        exampleB.echoString = function(arg0) {
            native function EchoString(arg0);
            return EchoString(arg0);
        };
        exampleB.lowercaseMethod = function(arg0) {
            native function LowercaseMethod(arg0);
            return LowercaseMethod(arg0);
        };
    })();";
        
        #region 声明常量变量
        /// <summary>
        /// 我的属性
        /// </summary>
        public int MyProperty { get; set; }
        /// <summary>
        /// 我的只读属性
        /// </summary>
        public string MyReadOnlyProperty { get; internal set; }
        /// <summary>
        /// 我不能转换的属性
        /// </summary>
        public Type MyUnconvertibleProperty { get; set; }
        /// <summary>
        /// 委托回调
        /// </summary>
        public V8HandlerDelegate CallBack { get; set; }
        #endregion 声明常量变量
        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ExampleBv8Handler()
        {
            MyProperty = 100;
            MyReadOnlyProperty = "flydoos@vip.qq.com";
            MyUnconvertibleProperty = GetType();
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
            returnValue = CefV8Value.CreateNull();
            exception = null;
            if (CallBack != null)
            {
                CallBack(name, obj, arguments, out returnValue, out exception);
            }
            return true;
        }
        #endregion 事件
        #region 方法
        /// <summary>
        /// 重复叠加字符串
        /// </summary>
        /// <param name=”str”>字符串</param>
        /// <param name=”n”>次数</param>
        /// <returns></returns>
        public string Repeat(string str, int n)
        {
            string result = String.Empty;
            for (int i = 0; i < n; i++)
            {
                result += str;
            }
            return result;
        }
        /// <summary>
        /// 无返回值
        /// </summary>
        public void EchoVoid()
        {
            MessageBox.Show("BindingTestAv8Handler : EchoVoid()");
        }
        /// <summary>
        /// 返回逻辑型
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public Boolean EchoBoolean(Boolean arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回可空逻辑型
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public Boolean? EchoNullableBoolean(Boolean? arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回 8 位有符号整数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public SByte EchoSByte(SByte arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回可空 8 位有符号整数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public SByte? EchoNullableSByte(SByte? arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回 16 位有符号整数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public Int16 EchoInt16(Int16 arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回可空 16 位有符号整数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public Int16? EchoNullableInt16(Int16? arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回 32 位有符号整数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public Int32 EchoInt32(Int32 arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回可空 32 位有符号整数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public Int32? EchoNullableInt32(Int32? arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回 64 位有符号整数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public Int64 EchoInt64(Int64 arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回可空 64 位有符号整数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public Int64? EchoNullableInt64(Int64? arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回 8 位无符号整数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public Byte EchoByte(Byte arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回可空 8 位无符号整数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public Byte? EchoNullableByte(Byte? arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回 16 位无符号整数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public UInt16 EchoUInt16(UInt16 arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回可空 16 位无符号整数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public UInt16? EchoNullableUInt16(UInt16? arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回 32 位无符号整数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public UInt32 EchoUInt32(UInt32 arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回可空 32 位无符号整数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public UInt32? EchoNullableUInt32(UInt32? arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回 64 位无符号整数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public UInt64 EchoUInt64(UInt64 arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回可空 64 位无符号整数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public UInt64? EchoNullableUInt64(UInt64? arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回单精度浮点数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public Single EchoSingle(Single arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回可空单精度浮点数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public Single? EchoNullableSingle(Single? arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回双精度浮点数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public Double EchoDouble(Double arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回可空双精度浮点数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public Double? EchoNullableDouble(Double? arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回Unicode字符
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public Char EchoChar(Char arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回可空Unicode字符
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public Char? EchoNullableChar(Char? arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回时间类型
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public DateTime EchoDateTime(DateTime arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回可空时间类型
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public DateTime? EchoNullableDateTime(DateTime? arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回十进制数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public Decimal EchoDecimal(Decimal arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回可空十进制数
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public Decimal? EchoNullableDecimal(Decimal? arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 返回字符串
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public String EchoString(String arg0)
        {
            return arg0;
        }
        /// <summary>
        /// 转为小写
        /// </summary>
        /// <param name=”arg0″>参数</param>
        /// <returns></returns>
        public String LowercaseMethod(String arg0)
        {
            String result = String.Empty;
            if (arg0 != null)
            {
                result = arg0.ToLower();
            }
            MessageBox.Show("BindingTestAv8Handler : " + result);
            return result;
        }
        #endregion 方法
    }
}

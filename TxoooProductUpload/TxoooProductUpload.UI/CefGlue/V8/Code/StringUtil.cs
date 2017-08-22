using System.Globalization;
using System.Text;
using System.Threading;


namespace TxoooProductUpload.UI.CefGlue
{
    /// <summary>
    /// 字符串辅助处理类
    /// </summary>
    public class StringUtil
    {
        #region 方法

        /// <summary>
        /// 首字母大写，其他小写
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string ToTitleCase(string str)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo text = cultureInfo.TextInfo;
            return text.ToTitleCase(text.ToLower(str));
        }

        /// <summary>
        /// 首字母大写，其他不变
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string UppercaseFirst(string str)
        {
            if (str == string.Empty)
            {
                return str;
            }

            return char.ToUpper(str[0]) + str.Substring(1);
        }

        /// <summary>
        /// 首字母小写，其他不变
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string LowercaseFirst(string str)
        {
            if (str == string.Empty)
            {
                return str;
            }

            return char.ToLower(str[0]) + str.Substring(1);
        }

        #endregion 方法

        #region 历史方法

        ///// <summary>
        ///// 连接字符串，中间中空格符号间隔
        ///// </summary>
        ///// <param name="firstStr">第一个字符串</param>
        ///// <param name="secondStr">第二个字符串</param>
        ///// <returns></returns>
        //public static string JoinWithBlank(string firstStr, string secondStr)
        //{
        //    return firstStr + " " + secondStr;
        //}

        ///// <summary>
        ///// 用Native关键字修饰
        ///// </summary>
        ///// <param name="str">字符串</param>
        ///// <returns></returns>
        //public static string ToNative(string str)
        //{
        //    return JoinWithBlank(ConstJsKeyword.Native, str);
        //}

        ///// <summary>
        ///// 获得对象的JavaScript头部信息脚本
        ///// </summary>
        ///// <param name="objName">对象名称</param>
        ///// <returns></returns>
        //public static string GetJavascriptHeader(string objName)
        //{
        //    return ConstJsKeyword.Function + " " + objName + "() {} " + ConstJsKeyword.If + " (!" + objName + ") " + objName + " = {}; (" + ConstJsKeyword.Function + "() {";
        //}

        ///// <summary>
        ///// 获得对象的JavaScript属性脚本
        ///// </summary>
        ///// <param name="objName">对象名称</param>
        ///// <param name="jsPropertyName">JS对应的属性名称</param>
        ///// <param name="propertyName">类对应的属性名称</param>
        ///// <returns></returns>
        //public static string GetJavascriptProperty(string objName, string jsPropertyName, string propertyName)
        //{
        //    var jsCode = new StringBuilder();

        //    jsCode.AppendLine(objName + "." + ConstJsKeyword.DefineGetter + "('" + jsPropertyName + "', " + ConstJsKeyword.Function + "() { " + ConstJsKeyword.Native + " " + ConstJsKeyword.Function + " " + ConstJsKeyword.Get + propertyName + "(); " + ConstJsKeyword.Return + " " + ConstJsKeyword.Get + propertyName + "(); });");
        //    jsCode.Append(objName + "." + ConstJsKeyword.DefineSetter + "('" + jsPropertyName + "', " + ConstJsKeyword.Function + "(" + ConstJsKeyword.CustomParameter + ConstJsKeyword.Zero + ") { " + ConstJsKeyword.Native + " " + ConstJsKeyword.Function + " " + ConstJsKeyword.Set + propertyName + "(" + ConstJsKeyword.CustomParameter + ConstJsKeyword.Zero + "); " + ConstJsKeyword.Set + propertyName + "(" + ConstJsKeyword.CustomParameter + ConstJsKeyword.Zero + "); });");

        //    return jsCode.ToString();
        //}

        ///// <summary>
        ///// 获得对象的JavaScript函数脚本
        ///// </summary>
        ///// <param name="objName">对象名称</param>
        ///// <param name="jsMethodName">JS对应的方法名称</param>
        ///// <param name="methodName">类对应的方法名称</param>
        ///// <param name="arguments">参数数组</param>
        ///// <param name="isReturnValue">是否需要返回值</param>
        ///// <returns></returns>
        //public static string GetJavascriptMethod(string objName, string jsMethodName, string methodName, string arguments, bool isReturnValue)
        //{
        //    string returnValue = isReturnValue ? ConstJsKeyword.Return + " " : "";

        //    return objName + "." + jsMethodName + " = " + ConstJsKeyword.Function + "(" + arguments + ") { " + ConstJsKeyword.Native + " " + ConstJsKeyword.Function + " " + methodName + "(" + arguments + "); " + returnValue + methodName + "(" + arguments + "); };";
        //}

        ///// <summary>
        ///// 获得对象的JavaScript页脚信息脚本
        ///// </summary>
        ///// <param name="objName">对象名称</param>
        ///// <returns></returns>
        //public static string GetJavascriptFooter(string objName)
        //{
        //    return "})();";
        //}

        #endregion 历史方法
    }
}

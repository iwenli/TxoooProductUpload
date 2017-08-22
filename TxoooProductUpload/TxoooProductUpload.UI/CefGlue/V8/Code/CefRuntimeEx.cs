using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TxoooProductUpload.UI.CefGlue
{
    /// <summary>
    /// 自定义的CEF运行库类
    /// </summary>
    public class CefRuntimeEx
    {
        #region 声明常量变量

        /// <summary>
        /// 对象键值对集合
        /// </summary>
        private static Dictionary<string, object> objects = new Dictionary<string, object>();

        #endregion 声明常量变量

        #region 构造函数

        /// <summary>
        /// 自定义构造函数
        /// </summary>
        public CefRuntimeEx()
        {
            objects = new Dictionary<string, object>();
        }

        #endregion 构造函数

        #region 方法

        /// <summary>
        /// 获得对象键值对集合
        /// </summary>
        public static Dictionary<string, object> GetObjects()
        {
            return objects;
        }

        /// <summary>
        /// 直接注册JS对象
        /// </summary>
        /// <param name="name">对象名称</param>
        /// <param name="objectToBind">需要绑定的对象</param>
        /// <returns></returns>
        public static bool RegisterJsObject(string name, object objectToBind)
        {
            objects[name] = objectToBind;

            return true;
        }

        #endregion 方法

        #region 历史方法

        ///// <summary>
        ///// 直接注册JS对象
        ///// </summary>
        ///// <param name="name">对象名称</param>
        ///// <param name="objectToBind">需要绑定的对象</param>
        ///// <returns></returns>
        //public static bool RegisterJsObjectEx(string name, object objectToBind)
        //{
        //    var bindingHandler = new BindingHandler();
        //    string javascriptCode = GetJavascriptFull(name, objectToBind, bindingHandler);

        //    return CefRuntime.RegisterExtension(name + "ExtensionName", javascriptCode, bindingHandler);
        //}

        ///// <summary>
        ///// 获得对象的JS脚本代码
        ///// 注意：这里仅返回JS脚本代码，后面注册需要调用 CefRuntime.RegisterExtension() 方法实现
        ///// </summary>
        ///// <param name="name">对象名称</param>
        ///// <param name="objectToBind">需要绑定的对象</param>
        ///// <param name="bindingHandler"></param>
        ///// <returns></returns>
        //public static string GetJavascriptFull(string name, object objectToBind, BindingHandler bindingHandler)
        //{
        //    objects[name] = objectToBind;

        //    string javascriptCode = bindingHandler.CreateJavascriptFull(name, objectToBind);

        //    return javascriptCode;
        //}

        #endregion 历史方法
    }
}

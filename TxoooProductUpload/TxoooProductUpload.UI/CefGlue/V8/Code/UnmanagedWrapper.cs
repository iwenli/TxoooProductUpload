using System.Collections.Generic;
using System.Reflection;
using Xilium.CefGlue;

namespace TxoooProductUpload.UI.CefGlue
{
    /// <summary>
    /// 用户数据非托管封装类
    /// </summary>
    public class UnmanagedWrapper : CefUserData
    {
        #region 声明常量变量

        /// <summary>
        /// 方法映射集合
        /// </summary>
        public Dictionary<string, string> MethodMap;

        /// <summary>
        /// 对象
        /// </summary>
        public object Obj;

        /// <summary>
        /// 属性集合
        /// </summary>
        public Dictionary<string, PropertyInfo> Properties;

        /// <summary>
        /// 属性映射集合
        /// </summary>
        public Dictionary<string, string> PropertyMap;

        #endregion 声明常量变量

        #region 构造函数

        /// <summary>
        /// 自定义构造函数
        /// </summary>
        /// <param name="obj">对象</param>
        public UnmanagedWrapper(object obj)
        {
            Obj = obj;
            MethodMap = new Dictionary<string, string>();
            PropertyMap = new Dictionary<string, string>();
        }

        #endregion 构造函数

        #region 方法

        /// <summary>
        /// 获得对象
        /// </summary>
        /// <returns></returns>
        public object GetObject()
        {
            return Obj;
        }

        /// <summary>
        /// 增加方法映射
        /// </summary>
        /// <param name="from">来源</param>
        /// <param name="to">目标</param>
        public void AddMethodMapping(string from, string to)
        {
            MethodMap.Add(to, from);
        }

        /// <summary>
        /// 获得方法映射值
        /// </summary>
        /// <param name="from">来源</param>
        /// <returns></returns>
        public string GetMethodMapping(string from)
        {
            string value;

            if (MethodMap.TryGetValue(from, out value))
            {
                return value;
            }

            return null;
        }

        /// <summary>
        /// 增加属性映射
        /// </summary>
        /// <param name="from">来源</param>
        /// <param name="to">目标</param>
        public void AddPropertyMapping(string from, string to)
        {
            PropertyMap.Add(to, from);
        }

        /// <summary>
        /// 获得属性映射值
        /// </summary>
        /// <param name="from">来源</param>
        public string GetPropertyMapping(string from)
        {
            string value;

            if (PropertyMap.TryGetValue(from, out value))
            {
                return value;
            }

            return null;
        }

        #endregion 方法
    }
}

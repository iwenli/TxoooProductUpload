using System;
using System.Reflection;
using Xilium.CefGlue;

namespace TxoooProductUpload.UI.CefGlue
{
    /// <summary>
    /// 属性访问器对象
    /// </summary>
    public class PropertyAccessor : CefV8Accessor
    {
        #region 方法

        /// <summary>
        /// 取值
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="obj">对象</param>
        /// <param name="returnValue">返回值</param>
        /// <param name="exception">返回异常信息</param>
        /// <returns></returns>
        protected override bool Get(string name, CefV8Value obj, out CefV8Value returnValue, out string exception)
        {
            var unmanagedWrapper = (UnmanagedWrapper)(obj.GetUserData());
            string clrName = name;
            clrName = unmanagedWrapper.GetPropertyMapping(clrName);
            PropertyInfo property;

            if (unmanagedWrapper.Properties.TryGetValue(clrName, out property))
            {
                object wrappedObject = unmanagedWrapper.GetObject();

                if (wrappedObject == null)
                {
                    exception = "Binding's CLR Object is null.";
                    returnValue = null;
                    return true;
                }

                try
                {
                    object clrValue = property.GetValue(wrappedObject, null);

                    returnValue = TypeUtil.ConvertToCef(clrValue, typeof(Nullable));
                    exception = null;
                    return true;
                }
                catch (Exception e)
                {
                    exception = e.Message;
                    returnValue = null;
                    return true;
                }
            }
            returnValue = null;
            exception = null;
            return false;
        }

        /// <summary>
        /// 赋值
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="obj">对象</param>
        /// <param name="value">值</param>
        /// <param name="exception">返回异常信息</param>
        /// <returns></returns>
        protected override bool Set(string name, CefV8Value obj, CefV8Value value, out string exception)
        {
            var unmanagedWrapper = (UnmanagedWrapper)(obj.GetUserData());
            string clrName = name;
            PropertyInfo property;

            if (unmanagedWrapper.Properties.TryGetValue(clrName, out property))
            {
                object wrappedObject = unmanagedWrapper.GetObject();

                if (wrappedObject == null)
                {
                    exception = "Binding's CLR Object is null.";
                    return true;
                }

                object clrValue = TypeUtil.ConvertFromCef(value);
                property.SetValue(wrappedObject, clrValue, null);

                exception = null;
                return true;
            }

            exception = null;
            return false;
        }

        #endregion 方法
    }
}

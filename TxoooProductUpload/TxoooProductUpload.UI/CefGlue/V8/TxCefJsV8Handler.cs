using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xilium.CefGlue;
using System.Reflection;

namespace TxoooProductUpload.UI.CefGlue
{
    public class TxCefJsV8Handler : CefV8Handler
    {
        #region 声明常量变量

        Object JsObject = null;

        #endregion 声明常量变量

        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public TxCefJsV8Handler(Object obj)
        {
            JsObject = obj;
        }
        #endregion 构造函数

        #region 事件
        /// <summary>
        /// 网页脚本与后台程序交互方法
        /// 提示一：如果 returnValue = null; 则会导致网页前端出现错误：Cannot read property ’constructor’ of undefined
        /// 提示二：还存在其他的可能，导致导致网页前端出现错误：Cannot read property ’constructor’ of undefined
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="obj">对象</param>
        /// <param name="arguments">参数</param>
        /// <param name="returnValue">返回值</param>
        /// <param name="exception">返回异常信息</param>
        /// <returns></returns>
        protected override bool Execute(string name, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception)
        {
            string result = string.Empty;
            Object retObj = null;
            Type t = JsObject.GetType();
            MethodInfo mi = t.GetMethod(name);
            if (mi != null)
            {
                if (arguments.Length > 0)
                {
                    Object[] param = new Object[arguments.Length];
                    CefV8Value value = null;
                    for (int i = 0, j = arguments.Length; i < j; i++)
                    {
                        value = arguments[i];
                        if (value.IsString)
                        {
                            param[i] = value.GetStringValue();
                        }
                        else if (value.IsInt)
                        {
                            param[i] = value.GetIntValue();
                        }
                        else if (value.IsDouble)
                        {
                            param[i] = value.GetIntValue();
                        }
                        else if (value.IsDouble)
                        {
                            param[i] = value.GetDoubleValue();
                            System.Windows.Forms.MessageBox.Show(param[i].ToString());
                        }
                        else if (value.IsArray)
                        {
                            int len = value.GetArrayLength();
                            Object[] p2 = new Object[len];
                            for (int k = 0; k < len; k++)
                            {
                                CefV8Value va = value.GetValue(k);
                                if (va.IsString)
                                {
                                    p2[k] = va.GetStringValue();
                                }
                                else if (va.IsInt)
                                {
                                    p2[k] = va.GetIntValue();
                                }
                                else if (va.IsDouble)
                                {
                                    p2[k] = va.GetDoubleValue();
                                }
                            }
                            param[i] = p2;
                        }
                        else if (value.IsBool)
                        {
                            param[i] = value.GetBoolValue();
                        }
                        else if (value.IsNull || value.IsUndefined)
                        {
                            param[i] = null;
                        }
                    }
                    retObj = mi.Invoke(JsObject, param);
                }
                else
                {
                    retObj = mi.Invoke(JsObject, null);
                }
            }
            if (retObj != null)
            {
                result = retObj.ToString();
            }
            returnValue = CefV8Value.CreateString(result);
            exception = null;
            return true;
        }
        #endregion 事件
    }
}

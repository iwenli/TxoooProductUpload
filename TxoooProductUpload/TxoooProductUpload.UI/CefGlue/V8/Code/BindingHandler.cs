using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xilium.CefGlue;
using System.Reflection;


namespace TxoooProductUpload.UI.CefGlue
{
    /// <summary>
    /// 绑定处理器对象
    /// </summary>
    public class BindingHandler : CefV8Handler
    {
        #region 声明常量变量

        /// <summary>
        /// 是否检查特殊名称，特殊名称就是：系统自动生成的属性、方法
        /// </summary>
        private static bool isCheckedSpecialName;

        #endregion 声明常量变量

        #region 历史声明委托

        ///// <summary>
        ///// 委托回调
        ///// </summary>
        //public V8HandlerDelegate CallBack { get; set; }

        #endregion 历史声明委托

        #region 事件

        /// <summary>
        /// 网页脚本与后台程序交互方法
        /// 提示一：如果 returnValue = null; 则会导致网页前端出现错误：Cannot read property 'constructor' of undefined
        /// 提示二：还存在其他的可能，导致导致网页前端出现错误：Cannot read property 'constructor' of undefined
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="obj">对象</param>
        /// <param name="arguments">参数</param>
        /// <param name="returnValue">返回值</param>
        /// <param name="exception">返回异常信息</param>
        /// <returns></returns>
        protected override bool Execute(string name, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception)
        {
            returnValue = CefV8Value.CreateNull();
            exception = null;

            var unmanagedWrapper = (UnmanagedWrapper)(obj.GetUserData());
            object self = unmanagedWrapper.GetObject();

            if (self == null)
            {
                exception = "Binding's CLR Object is null.";
                return true;
            }

            Type type = self.GetType();

            MethodInfo[] methodInfos = type.GetMethods();

            foreach (MethodInfo methodInfo in methodInfos)
            {
                bool flag = false;

                ParameterInfo[] parameterInfos = methodInfo.GetParameters();

                string methodName = StringUtil.LowercaseFirst(methodInfo.Name); //通过新方法注册的，首字母变小写了，所以要纠正为首字母小写


                if (methodName == name && parameterInfos.Length <= arguments.Length)
                {
                    if (parameterInfos.Length == 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        for (int parameterIndex = 0; parameterIndex < parameterInfos.Length; parameterIndex++)
                        {
                            ParameterInfo parameterInfo = parameterInfos[parameterIndex];
                            CefV8Value argument = arguments[parameterIndex];

                            if (Equals(argument, parameterInfo.ParameterType))
                            {
                                flag = true;
                            }
                        }
                    }

                    if (flag)
                    {
                        //如果有回调函数传参
                        CefV8Value callBack = null;
                        if (parameterInfos.Length < arguments.Length)
                        {
                            callBack = arguments[arguments.Length - 1];
                            Array.Resize(ref arguments, parameterInfos.Length);
                        }
                        var cb = TypeUtil.ConvertFromCef(callBack);

                        object[] parameterObjects = GetParameterObjects(parameterInfos, arguments);
                        try
                        {
                            object objResult = methodInfo.Invoke(self, parameterObjects);
                            returnValue = TypeUtil.ConvertToCef(objResult, methodInfo.ReturnType);

                            var msg = CefProcessMessage.Create("ExecuteJavaScript");
                            var argument = msg.Arguments;
                            argument.SetString(0, string.Format("{0}('{1}');", cb, objResult.ToString().Replace("\r\n","")));
                            //App.MainForm.cref.Form1.CefFrame.Browser.SendProcessMessage(CefProcessId.Browser, msg);
                        }
                        catch (Exception ex)
                        {
                            exception = ex.Message;
                        }
                        break;
                    }
                }
            }

            //MethodInfo methodInfo = t.GetMethods().FirstOrDefault(x => (x.Name == name && (x.GetParameters().Length == 0 || arguments.Length == 0)) || 
            //    x.Name == name && (x.GetParameters().Length > 0 &&
            //    x.GetParameters().Length == arguments.Length &&
            //    x.GetParameters().Any(m => arguments.Any(k => x.GetParameters().ToList().IndexOf(m) == arguments.ToList().IndexOf(k) && k.GetType() == m.ParameterType))));            

            return true;
        }

        #endregion 事件

        #region 方法

        /// <summary>
        /// 绑定数据并注册对象
        /// 说明：已经过滤特殊名称，即不含系统自动生成的属性、方法
        /// </summary>
        /// <param name="name">对象名称</param>
        /// <param name="obj">需要绑定的对象</param>
        /// <param name="window">用于注册的V8 JS引擎对象，类似于整个程序的窗口句柄</param>
        public static void Bind(string name, object obj, CefV8Value window)
        {
            var unmanagedWrapper = new UnmanagedWrapper(obj);

            var propertyAccessor = new PropertyAccessor();
            CefV8Value javascriptWrapper = CefV8Value.CreateObject(propertyAccessor);
            javascriptWrapper.SetUserData(unmanagedWrapper);

            var handler = new BindingHandler();

            unmanagedWrapper.Properties = GetProperties(obj.GetType());
            CreateJavascriptProperties(handler, javascriptWrapper, unmanagedWrapper.Properties);

            HashSet<string> methodNames = GetMethodNames(obj.GetType());
            CreateJavascriptMethods(handler, javascriptWrapper, methodNames);

            window.SetValue(name, javascriptWrapper, CefV8PropertyAttribute.None);
        }

        /// <summary>
        /// 绑定数据并注册对象
        /// 提示一：可自定义设置是否过滤特殊名称，即可自定义是否需要包含系统自动生成的属性、方法
        /// 提示二：如果containsSpecialName等于false，则会把系统自动生成的属性、方法也反射出来
        /// 提示三：例如类有这么一个属性：public int MyProperty { get; set; }，则系统会自动生成get_MyProperty()与set_MyProperty()方法，通过这两个方法，可以进行获取、赋值操作
        /// </summary>
        /// <param name="name">对象名称</param>
        /// <param name="obj">需要绑定的对象</param>
        /// <param name="window">用于注册的V8 JS引擎对象</param>
        /// <param name="containsSpecialName">是否包含特殊名称，例如：系统自动生成的方法</param>
        public static void Bind(string name, object obj, CefV8Value window, bool containsSpecialName)
        {
            isCheckedSpecialName = containsSpecialName;

            var unmanagedWrapper = new UnmanagedWrapper(obj);

            var propertyAccessor = new PropertyAccessor();
            CefV8Value javascriptWrapper = CefV8Value.CreateObject(propertyAccessor);
            javascriptWrapper.SetUserData(unmanagedWrapper);

            var handler = new BindingHandler();

            unmanagedWrapper.Properties = GetProperties(obj.GetType());
            CreateJavascriptProperties(handler, javascriptWrapper, unmanagedWrapper.Properties);

            HashSet<string> methodNames = GetMethodNames(obj.GetType());
            CreateJavascriptMethods(handler, javascriptWrapper, methodNames);

            window.SetValue(name, javascriptWrapper, CefV8PropertyAttribute.None);
        }

        /// <summary>
        /// 创建JavaScript属性
        /// </summary>
        /// <param name="handler">处理程序</param>
        /// <param name="javascriptObject">经过V8 JS引擎处理后的对象</param>
        /// <param name="properties">属性键值对集合</param>
        public static void CreateJavascriptProperties(CefV8Handler handler, CefV8Value javascriptObject, Dictionary<String, PropertyInfo> properties)
        {
            var unmanagedWrapper = (UnmanagedWrapper)(javascriptObject.GetUserData());

            foreach (string propertyName in properties.Keys)
            {
                string jsPropertyName = StringUtil.LowercaseFirst(propertyName);
                unmanagedWrapper.AddPropertyMapping(propertyName, jsPropertyName);

                string nameStr = jsPropertyName;

                var propertyAttribute = CefV8PropertyAttribute.None;

                if (properties[propertyName].GetSetMethod() == null)
                {
                    propertyAttribute = CefV8PropertyAttribute.ReadOnly;
                }

                javascriptObject.SetValue(nameStr, CefV8AccessControl.Default, propertyAttribute);
            }
        }

        /// <summary>
        /// 创建JavaScript方法
        /// </summary>
        /// <param name="handler">处理程序</param>
        /// <param name="javascriptObject">经过V8 JS引擎处理后的对象</param>
        /// <param name="methodNames">方法键值对集合</param>
        public static void CreateJavascriptMethods(CefV8Handler handler, CefV8Value javascriptObject, IEnumerable<String> methodNames)
        {
            var unmanagedWrapper = (UnmanagedWrapper)(javascriptObject.GetUserData());

            foreach (string methodName in methodNames)
            {
                string jsMethodName = StringUtil.LowercaseFirst(methodName);
                unmanagedWrapper.AddMethodMapping(methodName, jsMethodName);

                string nameStr = jsMethodName;
                javascriptObject.SetValue(nameStr, CefV8Value.CreateFunction(nameStr, handler), CefV8PropertyAttribute.None);
            }
        }

        /// <summary>
        /// 获得所有属性键值对集合
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static Dictionary<String, PropertyInfo> GetProperties(Type type)
        {
            PropertyInfo[] properties = type.GetProperties();
            var result = new Dictionary<String, PropertyInfo>();

            foreach (PropertyInfo property in properties)
            {
                if (isCheckedSpecialName)
                {
                    if (property.IsSpecialName) continue;
                }

                result[property.Name] = property;
            }

            return result;
        }

        /// <summary>
        /// 获得所有方法键值对集合
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static HashSet<String> GetMethodNames(Type type)
        {
            MethodInfo[] methods = type.GetMethods();
            var result = new HashSet<String>();

            foreach (MethodInfo method in methods)
            {
                if (isCheckedSpecialName)
                {
                    if (method.IsSpecialName) continue;
                }

                result.Add(method.Name);
            }

            return result;
        }

        /// <summary>
        /// 获得所有参数对象
        /// JavaScript 数据类型：undefined、boolean、string、number、object、function
        /// 提示一：JS数据类型中的number，对应的是C#中的int、double类型，所以定义参数时，尽可能使用这两种类型
        /// 提示二：对于复杂的数据需求，请尽可能使用string类型操作
        /// 提示三：尽量不要使用重载，如果参数类型比较接近，则经过JS处理后的数据类型，就会找不到原来的真实数据类型，请把方法改名
        /// </summary>
        /// <param name="parameterInfos">通过反射得到的参数数据信息</param>
        /// <param name="arguments">经过V8 JS引擎处理后的对象，本质上是JS数据类型</param>
        public object[] GetParameterObjects(ParameterInfo[] parameterInfos, CefV8Value[] arguments)
        {
            if (parameterInfos == null || arguments == null)
            {
                throw new Exception("parameterInfos or arguments can not be null");
            }

            if (parameterInfos.Length != arguments.Length)
            {
                throw new Exception("parameterInfos.Length != arguments.Length");
            }

            if (parameterInfos.Length == arguments.Length && parameterInfos.Length == 0)
            {
                return null;
            }

            var objects = new object[parameterInfos.Length];

            for (int index = 0; index < parameterInfos.Length; index++)
            {
                ParameterInfo parameterInfo = parameterInfos[index];
                CefV8Value argument = arguments[index];

                if (Equals(argument, parameterInfo.ParameterType))
                {
                    objects[index] = TypeUtil.ConvertFromCef(argument);
                    //objects[index] = GetDynamicValue(argument, parameterInfo.ParameterType);
                }
                else
                {
                    throw new Exception("parameterInfo.ParameterType != argument.GetType()");
                }
            }

            return objects;
        }

        /// <summary>
        /// 判断两种数据类型是否相同
        /// JavaScript 数据类型：undefined、boolean、string、number、object、function
        /// 提示一：JS数据类型中的number，对应的是C#中的int、double类型，所以定义参数时，尽可能使用这两种类型
        /// 提示二：对于复杂的数据需求，请尽可能使用string类型操作
        /// 提示三：尽量不要使用重载，如果参数类型比较接近，则经过JS处理后的数据类型，就会找不到原来的真实数据类型，请把方法改名
        /// </summary>
        /// <param name="cefV8Value">经过V8 JS引擎处理后的对象，本质上是JS数据类型</param>
        /// <param name="parameterType">通过反射得到的参数数据类型</param>
        /// <returns></returns>
        public bool Equals(CefV8Value cefV8Value, Type parameterType)
        {
            bool flag = false;

            if (cefV8Value.IsBool)
            {
                flag = (parameterType == typeof(bool) || parameterType == typeof(bool?) ||
                        parameterType == typeof(Boolean) || parameterType == typeof(Boolean?));
            }
            if (cefV8Value.IsDate)
            {
                if (flag == false)
                {
                    flag = (parameterType == typeof(DateTime) || parameterType == typeof(DateTime?));
                }
            }
            if (cefV8Value.IsDouble)
            {
                if (flag == false)
                {
                    flag = (parameterType == typeof(double) || parameterType == typeof(double?) ||
                            parameterType == typeof(Double) || parameterType == typeof(Double?));
                }
            }
            if (cefV8Value.IsInt)
            {
                if (flag == false)
                {
                    flag = (parameterType == typeof(int) || parameterType == typeof(int?) ||
                            parameterType == typeof(Int32) || parameterType == typeof(Int32?));
                }
            }
            if (cefV8Value.IsString)
            {
                if (flag == false)
                {
                    flag = (parameterType == typeof(string) || parameterType == typeof(String));
                }
            }
            if (cefV8Value.IsUInt)
            {
                if (flag == false)
                {
                    flag = (parameterType == typeof(uint) || parameterType == typeof(uint?) ||
                            parameterType == typeof(UInt32) || parameterType == typeof(UInt32?));
                }
            }
            if (cefV8Value.IsNull)
            {
                if (flag == false)
                {
                    flag = (parameterType == typeof(void));
                }
            }

            return flag;
        }

        #endregion 方法

        #region 历史方法

        ///// <summary>
        ///// 获得动态类型值
        ///// JavaScript 数据类型：undefined、boolean、string、number、object、function
        ///// 提示一：JS数据类型中的number，对应的是C#中的int、double类型，所以定义参数时，尽可能使用这两种类型
        ///// 提示二：对于复杂的数据需求，请尽可能使用string类型操作
        ///// 提示三：尽量不要使用重载，如果参数类型比较接近，则经过JS处理后的数据类型，就会找不到原来的真实数据类型，请把方法改名
        ///// </summary>
        ///// <param name="cefV8Value">经过V8 JS引擎处理后的对象，本质上是JS数据类型</param>
        ///// <param name="parameterType">通过反射得到的参数数据类型</param>
        ///// <returns></returns>
        //public dynamic GetDynamicValue(CefV8Value cefV8Value, Type parameterType)
        //{
        //    dynamic value = null;

        //    if (cefV8Value.IsBool &&
        //        (parameterType == typeof (bool) || parameterType == typeof (bool?) ||
        //         parameterType == typeof (Boolean) || parameterType == typeof (Boolean?)))
        //    {
        //        value = cefV8Value.GetBoolValue();
        //    }
        //    if (cefV8Value.IsDate &&
        //        (parameterType == typeof (DateTime) || parameterType == typeof (DateTime?)))
        //    {
        //        value = cefV8Value.GetDateValue();
        //    }
        //    if (cefV8Value.IsDouble &&
        //        (parameterType == typeof (double) || parameterType == typeof (double?) ||
        //         parameterType == typeof (Double) || parameterType == typeof (Double?)))
        //    {
        //        value = cefV8Value.GetDoubleValue();
        //    }
        //    if (cefV8Value.IsInt &&
        //        (parameterType == typeof (int) || parameterType == typeof (int?) ||
        //         parameterType == typeof (Int32) || parameterType == typeof (Int32?)))
        //    {
        //        value = cefV8Value.GetIntValue();
        //    }
        //    if (cefV8Value.IsString &&
        //        (parameterType == typeof (string) || parameterType == typeof (String)))
        //    {
        //        value = cefV8Value.GetStringValue();
        //    }
        //    if (cefV8Value.IsUInt &&
        //        (parameterType == typeof (uint) || parameterType == typeof (uint?) ||
        //         parameterType == typeof (UInt32) || parameterType == typeof (UInt32?)))
        //    {
        //        value = cefV8Value.GetUIntValue();
        //    }
        //    if (cefV8Value.IsNull &&
        //        (parameterType == typeof (void)))
        //    {
        //        value = null;
        //    }

        //    return value;
        //}

        ///// <summary>
        ///// 获得CEFV8类型值
        ///// JavaScript 数据类型：undefined、boolean、string、number、object、function
        ///// 注意：JS数据类型中的number，对应的是C#中的int、double类型，所以定义参数时，尽可能使用这两种类型
        ///// </summary>
        ///// <param name="obj">对象，本质上是反射调用方法后的返回值</param>
        ///// <param name="parameterType">通过反射得到的参数数据类型</param>
        ///// <returns></returns>
        //public CefV8Value GetCefV8Value(object obj, Type parameterType)
        //{
        //    CefV8Value value = CefV8Value.CreateNull();

        //    if (parameterType == typeof (bool) || parameterType == typeof (bool?))
        //    {
        //        value = CefV8Value.CreateBool((bool) obj);
        //    }
        //    if (parameterType == typeof (Boolean) || parameterType == typeof (Boolean?))
        //    {
        //        value = CefV8Value.CreateBool((Boolean) obj);
        //    }
        //    if (parameterType == typeof (DateTime) || parameterType == typeof (DateTime?))
        //    {
        //        value = CefV8Value.CreateDate((DateTime) obj);
        //    }
        //    if (parameterType == typeof (double) || parameterType == typeof (double?))
        //    {
        //        value = CefV8Value.CreateDouble((double) obj);
        //    }
        //    if (parameterType == typeof (Double) || parameterType == typeof (Double?))
        //    {
        //        value = CefV8Value.CreateDouble((Double) obj);
        //    }
        //    if (parameterType == typeof (int) || parameterType == typeof (int?))
        //    {
        //        value = CefV8Value.CreateInt((int) obj);
        //    }
        //    if (parameterType == typeof (Int32) || parameterType == typeof (Int32?))
        //    {
        //        value = CefV8Value.CreateInt((Int32) obj);
        //    }
        //    if (parameterType == typeof (string))
        //    {
        //        value = CefV8Value.CreateString((string) obj);
        //    }
        //    if (parameterType == typeof (String))
        //    {
        //        value = CefV8Value.CreateString((String) obj);
        //    }
        //    if (parameterType == typeof (uint) || parameterType == typeof (uint?))
        //    {
        //        value = CefV8Value.CreateUInt((uint) obj);
        //    }
        //    if (parameterType == typeof (UInt32) || parameterType == typeof (UInt32?))
        //    {
        //        value = CefV8Value.CreateUInt((UInt32) obj);
        //    }

        //    return value;
        //}

        ///// <summary>
        ///// 获得动态类型值集合（一个值，可能同时属于多种数据类型，返回全部符合条件的集合）
        ///// JavaScript 数据类型：undefined、boolean、string、number、object、function
        ///// 提示一：JS数据类型中的number，对应的是C#中的int、double类型，所以定义参数时，尽可能使用这两种类型
        ///// 提示二：对于复杂的数据需求，请尽可能使用string类型操作
        ///// 提示三：尽量不要使用重载，如果参数类型比较接近，则经过JS处理后的数据类型，就会找不到原来的真实数据类型，请把方法改名
        ///// </summary>
        ///// <param name="cefV8Value">经过V8 JS引擎处理后的对象，本质上是JS数据类型</param>
        ///// <returns></returns>
        //public List<dynamic> GetValues(CefV8Value cefV8Value)
        //{
        //    var values = new List<dynamic>();

        //    if (cefV8Value.IsBool)
        //    {
        //        values.Add(cefV8Value.GetBoolValue());
        //    }
        //    if (cefV8Value.IsDate)
        //    {
        //        values.Add(cefV8Value.GetDateValue());
        //    }
        //    if (cefV8Value.IsDouble)
        //    {
        //        values.Add(cefV8Value.GetDoubleValue());
        //    }
        //    if (cefV8Value.IsInt)
        //    {
        //        values.Add(cefV8Value.GetIntValue());
        //    }
        //    if (cefV8Value.IsString)
        //    {
        //        values.Add(cefV8Value.GetStringValue());
        //    }
        //    if (cefV8Value.IsUInt)
        //    {
        //        values.Add(cefV8Value.GetUIntValue());
        //    }

        //    return values;
        //}

        ///// <summary>
        ///// 获得方法名称集合
        ///// 注意：返回的结果，已经过滤系统自动生成属性
        ///// </summary>
        ///// <param name="propertyInfos">属性元数据信息</param>
        ///// <returns></returns>
        //public HashSet<string> GetPropertyNames(PropertyInfo[] propertyInfos)
        //{
        //    var result = new HashSet<string>();

        //    foreach (PropertyInfo propertyInfo in propertyInfos)
        //    {
        //        if (isCheckedSpecialName)
        //        {
        //            if (propertyInfo.IsSpecialName) continue;
        //        }

        //        result.Add(propertyInfo.Name);
        //    }

        //    return result;
        //}

        ///// <summary>
        ///// 获得方法名称集合
        ///// 注意：返回的结果，已经过滤系统自动生成方法
        ///// </summary>
        ///// <param name="methodInfos">方法元数据信息</param>
        ///// <returns></returns>
        //public HashSet<string> GetMethodNames(MethodInfo[] methodInfos)
        //{
        //    var result = new HashSet<string>();

        //    foreach (MethodInfo methodInfo in methodInfos)
        //    {
        //        if (isCheckedSpecialName)
        //        {
        //            if (methodInfo.IsSpecialName) continue;
        //        }

        //        result.Add(methodInfo.Name);
        //    }

        //    return result;
        //}

        ///// <summary>
        ///// 获得对象的JavaScript头部信息脚本
        ///// </summary>
        ///// <param name="objName">对象名称</param>
        //public string GetJavascriptHeader(string objName)
        //{
        //    return StringUtil.GetJavascriptHeader(objName);
        //}

        ///// <summary>
        ///// 获得对象的JavaScript方法脚本
        ///// </summary>
        ///// <param name="objName">对象名称</param>
        ///// <param name="propertyInfo">属性元数据信息</param>
        //public string GetJavascriptProperty(string objName, PropertyInfo propertyInfo)
        //{
        //    string propertyName = propertyInfo.Name;
        //    string jsPropertyName = StringUtil.LowercaseFirst(propertyName);

        //    return StringUtil.GetJavascriptProperty(objName, jsPropertyName, propertyName);
        //}

        ///// <summary>
        ///// 获得对象的JavaScript方法脚本
        ///// </summary>
        ///// <param name="objName">对象名称</param>
        ///// <param name="methodInfo">方法元数据信息</param>
        //public string GetJavascriptMethod(string objName, MethodInfo methodInfo)
        //{
        //    string methodName = methodInfo.Name;
        //    ParameterInfo[] parameterInfos = methodInfo.GetParameters();
        //    var arguments = new StringBuilder();

        //    if (parameterInfos.Length > 0)
        //    {
        //        for (int index = 0; index < parameterInfos.Length; index++)
        //        {
        //            arguments.Append(ConstJsKeyword.CustomParameter + index + ",");
        //        }

        //        if (arguments.ToString().EndsWith(","))
        //        {
        //            arguments.Remove(arguments.Length - 1, 1);
        //        }
        //    }

        //    bool isReturnValue = methodInfo.ReturnType != typeof (void);
        //    string jsMethodName = StringUtil.LowercaseFirst(methodName);

        //    return StringUtil.GetJavascriptMethod(objName, jsMethodName, methodName, arguments.ToString(), isReturnValue);
        //}

        ///// <summary>
        ///// 获得对象的JavaScript页脚信息脚本
        ///// </summary>
        ///// <param name="objName">对象名称</param>
        //public string GetJavascriptFooter(string objName)
        //{
        //    return StringUtil.GetJavascriptFooter(objName);
        //}

        ///// <summary>
        ///// 创建完整的对象JavaScript脚本
        ///// 注意：已经过滤系统自动生成的属性与方法
        ///// </summary>
        ///// <param name="objName">对象名称</param>
        ///// <param name="propertyInfos">属性元数据信息</param>
        ///// <param name="methodInfos">方法元数据信息</param>
        //public string CreateJavascriptFull(string objName, PropertyInfo[] propertyInfos, MethodInfo[] methodInfos)
        //{
        //    var jsCode = new StringBuilder();

        //    jsCode.AppendLine(GetJavascriptHeader(objName));

        //    foreach (PropertyInfo propertyInfo in propertyInfos)
        //    {
        //        if (isCheckedSpecialName)
        //        {
        //            if (propertyInfo.IsSpecialName) continue;
        //        }

        //        jsCode.AppendLine(GetJavascriptProperty(objName, propertyInfo));
        //    }

        //    foreach (MethodInfo methodInfo in methodInfos)
        //    {
        //        if (isCheckedSpecialName)
        //        {
        //            if (methodInfo.IsSpecialName) continue;
        //        }

        //        jsCode.AppendLine(GetJavascriptMethod(objName, methodInfo));
        //    }

        //    jsCode.AppendLine(GetJavascriptFooter(objName));

        //    return jsCode.ToString();
        //}

        ///// <summary>
        ///// 创建完整的对象JavaScript脚本
        ///// 注意：已经过滤系统自动生成的属性与方法
        ///// </summary>
        ///// <param name="objName">对象名称</param>
        ///// <param name="obj">对象</param>
        //public string CreateJavascriptFull(string objName, object obj)
        //{
        //    Type t = obj.GetType();
        //    MethodInfo[] methodInfos = t.GetMethods();
        //    PropertyInfo[] propertyInfos = t.GetProperties();

        //    var jsCode = new StringBuilder();

        //    jsCode.AppendLine(GetJavascriptHeader(objName));

        //    foreach (PropertyInfo propertyInfo in propertyInfos)
        //    {
        //        if (isCheckedSpecialName)
        //        {
        //            if (propertyInfo.IsSpecialName) continue;
        //        }

        //        jsCode.AppendLine(GetJavascriptProperty(objName, propertyInfo));
        //    }

        //    foreach (MethodInfo methodInfo in methodInfos)
        //    {
        //        if (isCheckedSpecialName)
        //        {
        //            if (methodInfo.IsSpecialName) continue;
        //        }

        //        jsCode.AppendLine(GetJavascriptMethod(objName, methodInfo));
        //    }

        //    jsCode.AppendLine(GetJavascriptFooter(objName));

        //    return jsCode.ToString();
        //}

        #endregion 历史方法
    }
}

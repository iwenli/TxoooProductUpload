using System;
using System.Collections.Generic;
using System.Reflection;
using Xilium.CefGlue;

namespace TxoooProductUpload.UI.CefGlue
{
    /// <summary>
    /// 类型辅助处理类
    /// </summary>
    public class TypeUtil
    {
        #region 方法

        /// <summary>
        /// 把对象转为CEFV8类型值
        /// JavaScript 数据类型：undefined、boolean、string、number、object、function
        /// 注意：JS数据类型中的number，对应的是C#中的int、double类型，所以定义参数时，尽可能使用这两种类型
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="type">经过V8 JS引擎处理后的对象，本质上是JS数据类型</param>
        /// <returns></returns>
        public static CefV8Value ConvertToCef(object obj, Type type)
        {
            if (type == typeof(void))
            {
                return CefV8Value.CreateUndefined();
            }
            if (obj == null)
            {
                return CefV8Value.CreateNull();
            }

            if (type == typeof(Nullable))
            {
                type = obj.GetType();
            }

            Type underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType != null) type = underlyingType;

            if (type == typeof(Boolean))
            {
                return CefV8Value.CreateBool(Convert.ToBoolean(obj));
            }
            if (type == typeof(Int32))
            {
                return CefV8Value.CreateInt(Convert.ToInt32(obj));
            }
            if (type == typeof(String))
            {
                return CefV8Value.CreateString(Convert.ToString(obj));
            }
            if (type == typeof(Double))
            {
                return CefV8Value.CreateDouble(Convert.ToDouble(obj));
            }
            if (type == typeof(Decimal))
            {
                return CefV8Value.CreateDouble(Convert.ToDouble(obj));
            }
            if (type == typeof(SByte))
            {
                return CefV8Value.CreateInt(Convert.ToInt32(obj));
            }
            if (type == typeof(Int16))
            {
                return CefV8Value.CreateInt(Convert.ToInt32(obj));
            }
            if (type == typeof(Int64))
            {
                return CefV8Value.CreateDouble(Convert.ToDouble(obj));
            }
            if (type == typeof(Byte))
            {
                return CefV8Value.CreateInt(Convert.ToInt32(obj));
            }
            if (type == typeof(UInt16))
            {
                return CefV8Value.CreateInt(Convert.ToInt32(obj));
            }
            if (type == typeof(UInt32))
            {
                return CefV8Value.CreateDouble(Convert.ToDouble(obj));
            }
            if (type == typeof(UInt64))
            {
                return CefV8Value.CreateDouble(Convert.ToDouble(obj));
            }
            if (type == typeof(Single))
            {
                return CefV8Value.CreateDouble(Convert.ToDouble(obj));
            }
            if (type == typeof(Char))
            {
                return CefV8Value.CreateInt(Convert.ToInt32(obj));
            }
            if (type.IsArray)
            {
                var managedArray = (Array)obj;
                CefV8Value cefArray = CefV8Value.CreateArray(managedArray.Length);

                for (int i = 0; i < managedArray.Length; i++)
                {
                    object arrObj = managedArray.GetValue(i);

                    if (arrObj != null)
                    {
                        CefV8Value cefObj = ConvertToCef(arrObj, arrObj.GetType());

                        cefArray.SetValue(i, cefObj);
                    }
                    else
                    {
                        cefArray.SetValue(i, CefV8Value.CreateNull());
                    }
                }

                return cefArray;
            }
            if (type.IsValueType && !type.IsPrimitive && !type.IsEnum)
            {
                FieldInfo[] fields = type.GetFields();
                CefV8Value cefArray = CefV8Value.CreateArray(fields.Length);

                foreach (FieldInfo file in fields)
                {
                    String fieldName = file.Name;

                    string strFieldName = Convert.ToString(fieldName);

                    Object fieldVal = file.GetValue(obj);

                    if (fieldVal != null)
                    {
                        CefV8Value cefVal = ConvertToCef(fieldVal, fieldVal.GetType());

                        cefArray.SetValue(strFieldName, cefVal, CefV8PropertyAttribute.None);
                    }
                    else
                    {
                        cefArray.SetValue(strFieldName, CefV8Value.CreateNull(), CefV8PropertyAttribute.None);
                    }
                }

                return cefArray;
            }

            throw new Exception(String.Format("Cannot convert '{0}' object from CLR to CEF.", type.FullName));
        }

        /// <summary>
        /// 把CEFV8类型值转为对象
        /// JavaScript 数据类型：undefined、boolean、string、number、object、function
        /// 提示一：JS数据类型中的number，对应的是C#中的int、double类型，所以定义参数时，尽可能使用这两种类型
        /// 提示二：对于复杂的数据需求，请尽可能使用string类型操作
        /// 提示三：尽量不要使用重载，如果参数类型比较接近，则经过JS处理后的数据类型，就会找不到原来的真实数据类型，请把方法改名
        /// </summary>
        /// <param name="obj">经过V8 JS引擎处理后的对象，本质上是JS数据类型</param>
        /// <returns></returns>
        public static Object ConvertFromCef(CefV8Value obj)
        {
            if (obj == null)
            {
                return null;
            }

            if (obj.IsNull || obj.IsUndefined)
            {
                return null;
            }

            if (obj.IsBool)
            {
                return obj.GetBoolValue();
            }
            if (obj.IsInt)
            {
                return obj.GetIntValue();
            }
            if (obj.IsDouble)
            {
                return obj.GetDoubleValue();
            }
            if (obj.IsString)
            {
                return obj.GetStringValue();
            }

            if (obj.IsArray)
            {
                int arrLength = obj.GetArrayLength();

                if (arrLength > 0)
                {
                    string[] keys = obj.GetKeys();
                    if (keys.Length > 0)
                    {
                        var result = new Dictionary<String, Object>();

                        for (int i = 0; i < arrLength; i++)
                        {
                            string pKey = keys[i];
                            String pKeyStr = pKey;

                            if ((obj.HasValue(keys[i])) && (!pKeyStr.StartsWith("__")))
                            {
                                CefV8Value data = obj.GetValue(keys[i]);
                                if (data != null)
                                {
                                    Object pData = ConvertFromCef(data);

                                    result.Add(pKeyStr, pData);
                                }
                            }
                        }

                        return result;
                    }
                }

                return null;
            }

            if (obj.IsObject)
            {
                string[] keys = obj.GetKeys();
                if (keys.Length > 0)
                {
                    int objLength = keys.Length;
                    if (objLength > 0)
                    {
                        var result = new Dictionary<String, Object>();

                        for (int i = 0; i < objLength; i++)
                        {
                            string pKey = keys[i];
                            String pKeyStr = pKey;

                            if ((obj.HasValue(keys[i])) && (!pKeyStr.StartsWith("__")))
                            {
                                CefV8Value data = obj.GetValue(keys[i]);
                                if (data != null)
                                {
                                    Object pData = ConvertFromCef(data);

                                    result.Add(pKeyStr, pData);
                                }
                            }
                        }

                        return result;
                    }
                }

                return null;
            }

            throw new Exception("Cannot convert object from Cef to CLR.");
        }

        #endregion 方法
    }
}

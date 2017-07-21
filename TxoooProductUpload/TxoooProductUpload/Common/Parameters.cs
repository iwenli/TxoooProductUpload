using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Common
{
    /// <summary>
    /// 参数
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// 
        /// </summary>
        public Parameters()
        {
            this.Items = new List<KeyValuePair<string, string>>(10);
        }

        public Parameters(string query)
        {
            this.Items = new List<KeyValuePair<string, string>>(10);
            var nv = System.Web.HttpUtility.ParseQueryString(query);
            foreach (string key in nv.Keys)
            {
                this.Add(key, nv[key]);
            }
        }

        public string this[string key]
        {
            get { return this.Items.SingleOrDefault((kv) => { return kv.Key == key; }).Value; }
            set
            {

                this.Items.RemoveAll((kv) => { return kv.Key == key; });
                this.Items.Add(new KeyValuePair<string, string>(key, value));
            }
        }

        /// <summary>
        /// 参数
        /// </summary>
        public List<KeyValuePair<string, string>> Items
        {
            get;
            private set;
        }
        /// <summary>
        /// 清空参数
        /// </summary>
        /// <returns></returns>
        public void Clear()
        {
            this.Items.Clear();
        }

        /// <summary>
        /// 排序
        /// </summary>
        public void Sort()
        {
            this.Items.Sort(new Comparison<KeyValuePair<string, string>>((x1, x2) =>
            {
                if (x1.Key == x2.Key)
                {
                    return string.Compare(x1.Value, x2.Value);
                }
                else
                {
                    return string.Compare(x1.Key, x2.Key);
                }
            }));
        }

        /// <summary>
        /// 添加查询参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, object value)
        {
            this.Add(key, (value == null ? string.Empty : value.ToString()));
        }
        /// <summary>
        /// 添加查询参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, string value)
        {
            this.Items.Add(new KeyValuePair<string, string>(key, value));
        }
        /// <summary>
        /// 批量添加集合数据
        /// </summary>
        /// <param name="collection"></param>
        public void AddRange(IEnumerable<KeyValuePair<string, string>> collection)
        {
            if (collection == null) return;
            this.Items.AddRange(collection);
        }

        /// <summary>
        /// 构造查询参数字符串,字符格式如: name1=value1&amp;name2=value2
        /// </summary>
        /// <param name="encodeValue">是否对值进行编码</param>
        /// <returns></returns>
        public string BuildQueryString(bool encodeValue)
        {
            StringBuilder buffer = new StringBuilder();
            foreach (var p in this.Items)
            {
                if (buffer.Length != 0) buffer.Append("&");
                buffer.AppendFormat("{0}={1}", encodeValue ? Uri.EscapeDataString(p.Key) : p.Key, encodeValue ? Uri.EscapeDataString(p.Value) : p.Value);
            }
            return buffer.ToString();
        }

        /// <summary>
        /// 构造字符串,字符串格式如: name1="value1", name2="value2"
        /// </summary>
        /// <param name="encodeValue"></param>
        /// <returns></returns>
        public string BuildString(bool encodeValue)
        {
            StringBuilder buffer = new StringBuilder();
            foreach (var p in this.Items)
            {
                if (buffer.Length != 0) buffer.Append(", ");
                buffer.AppendFormat("{0}=\"{1}\"", encodeValue ? Uri.EscapeDataString(p.Key) : p.Key, encodeValue ? Uri.EscapeDataString(p.Value) : p.Value);
            }
            return buffer.ToString();
        }
    }
}

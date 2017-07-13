using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.Entities
{
    /// <summary>
    /// Combobox键值对
    /// </summary>
    public class ComboboxItem
    {
        /// <summary>
        /// 显示的文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}

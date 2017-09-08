using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload
{
    /// <summary>
    /// 异常基类
    /// </summary>
    public class WlException : Exception
    {
        public WlException() : base() { }
        public WlException(string msg) : base(msg) { }
        public WlException(string msg,Exception innerException) : base(msg, innerException) { }
    }
}

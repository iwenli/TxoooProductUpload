using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TxoooProductUpload.Service.Entities.Web
{
    class LoginAsyncResult
    {
        public string success { get; set; }
        public string msg { get; set; }

        /// <summary>
        /// 获得登录是否成功
        /// </summary>
        public bool IsSuceess { get { return success == "true"; } }
    }
}

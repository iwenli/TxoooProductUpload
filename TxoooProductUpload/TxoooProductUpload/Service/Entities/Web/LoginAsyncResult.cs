using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TxoooProductUpload.Service.Entities.Web
{
    public class LoginAsyncResult
    {
        public bool success { get; set; }
        public string msg { get; set; }

        public int errcode { get; set; }
        public long mchid { get; set; }
        public long userid { get; set; }
        public string token { get; set; }

        /// <summary>
        /// 获得登录是否成功
        /// </summary>
        public bool IsSuceess { get { return success ; } }
    }
}

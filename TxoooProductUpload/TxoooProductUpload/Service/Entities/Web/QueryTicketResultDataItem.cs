using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.Entities.Web
{
    class QueryTicketResultDataItem
    {
        /// <summary>
        /// 提交密钥
        /// </summary>
        public string SecretStr { get; private set; }
        /// <summary>
        /// 提交密钥
        /// </summary>
        public string ButtonTextInfo { get; private set; }

        /// <summary>
        /// 车次信息
        /// </summary>
        public QueryTicketResultDataInfo QueryLeftNewDTO { get; private set; }

    }
}

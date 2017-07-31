using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Common;

namespace TxoooProductUpload.Service.ImageDownload
{
    /// <summary>
    /// 来源列表
    /// </summary>
    class SourceTask
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 分页页面地址
        /// </summary>
        public string PageFormat { set; get; }

        /// <summary>
        /// 图片详情列表正则，做Matches匹配（组2是页面描述  组1是详情url）
        /// </summary>
        public string PageListPattern { set; get; }
        /// <summary>
        /// 下一页正则，做IsMatch匹配
        /// </summary>
        public string NextPagePattern { set; get; }

        /// <summary>
        /// 图片列表正则，做Matches匹配（组1是url  组2是图片说明，可没有 ）
        /// </summary>
        public string ImagePattern { set; get; }

        string _domain = "";
        /// <summary>
        /// 站点域名
        /// </summary>
        public string Domain
        {
            set { _domain = value; }
            get
            {
                return Url.GetDomainName();
            }
        }
    }
}

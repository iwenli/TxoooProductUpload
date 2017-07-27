using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.Common;
using TxoooProductUpload.Service;

namespace TxoooProductUpload.UI.ImageDownload
{
    /// <summary>
    /// 抓取头像
    /// </summary>
    partial class Crawler : FormBase
    {
        public Crawler(ServiceContext serviceContext)
        {
            _context = serviceContext;
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        void Init() {
            this.Text = "图片管理  " + ConstParams.APP_NAME;
        }
    }
}

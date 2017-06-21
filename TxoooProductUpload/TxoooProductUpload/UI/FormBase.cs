using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TxoooProductUpload.UI
{
    using Service;
    using System.Windows.Forms;

    /// <summary>
    /// 抽象窗口基类
    /// </summary>
    class FormBase : Form
    {
        /// <summary>
        /// 获得当前的上下文
        /// </summary>
        public ServiceContext ServiceContext { get; private set; }

        protected FormBase(ServiceContext serviceContext)
        {
            ServiceContext = serviceContext;
        }

        /// <summary>
        /// 无效构造函数
        /// </summary>
        public FormBase()
        {

        }

    }
}

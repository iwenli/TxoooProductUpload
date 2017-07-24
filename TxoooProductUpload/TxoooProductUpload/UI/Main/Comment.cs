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

namespace TxoooProductUpload.UI.Main
{
    partial class Comment : FormBase
    {
        public Comment(ServiceContext context) : base(context)
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            this.txtUrl.SetHintText("在这里输入要添加评价的创业赚钱商品链接");
            this.btnGetProductInfo.Click += (s, e) =>
            {
                SM("哎呀你逗我呢，链接都不输");
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.UI.Service
{
    class ProductService : ServiceBase
    {
        public ProductService()
        {
            MsgTemplate = "[商品消息]{0}";
        }


        internal async Task Msg()
        {
            for (int i = 0; i < 50; i++)
            {
                await Task.Delay(1000);
                InfoMessage(MsgTemplate, "正常消息");
                if (i % 5 == 0)
                {
                    WarnMessage(MsgTemplate, "警告消息");
                }
                if (i % 3 == 0)
                {
                    ErrorMessage(MsgTemplate, "错误信息");
                }
                if (i % 7 == 0)
                {
                    FatalMessage(MsgTemplate, "致命消息");
                }
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.UI.Service;

namespace TxoooProductUpload.UI
{
    public partial class Msgtest : BaseForm
    {
        ProductService productService = new ProductService();
        UserService loginService = new UserService();

        public Msgtest()
        {
            InitializeComponent();

            SendMessageHandler = productService;
            LogControl = richTextBox1;
            SendMessageHandler.OnSendMessage += Event_OnSendMessage;
            loginService.OnSendMessage += Event_OnSendMessage;

            btnOK.Click += async (s, e) =>
            {
                btnOK.Enabled = false;
                await productService.Run(50);
                //var task = Task.Run(() => { productService.Run(); });
                //Task.WaitAll(task);
                btnOK.Enabled = true;
            };
            //Task.Run(async () =>
            //{
            //    await loginService.Msg();
            //    for (int i = 0; i < 5; i++)
            //    {
            //        AppendLog("i=" + i.ToString());
            //    }
            //});

            //Task.Run(async () =>
            //{
            //    await productService.Msg();
            //    for (int j = 0; j < 5; j++)
            //    {
            //        AppendLog("j=" + j.ToString());
            //    }
            //});

        }
    }
}

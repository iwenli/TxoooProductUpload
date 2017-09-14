using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TxoooProductUpload.UI.Forms
{
    public partial class LoadingForm : BaseForm
    {
        public LoadingForm(string loadMessage) : this()
        {
            LoadMessage.Text = loadMessage;
        }
        public LoadingForm()
        {
            InitializeComponent();
            LogControl = logTxt;
        }
    }
}

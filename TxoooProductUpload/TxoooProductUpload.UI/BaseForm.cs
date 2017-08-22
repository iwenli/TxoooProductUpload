using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TxoooProductUpload.UI
{
    using CCWin;
    using Iwenli;

    public partial class BaseForm : CCSkinMain
    {
        public BaseForm()
        {
            InitializeComponent();
            this.XTheme = new Skin_Mac() { };
        }
    }
}

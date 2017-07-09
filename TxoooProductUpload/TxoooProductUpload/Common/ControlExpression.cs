using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TxoooProductUpload.Common
{
    public static class ControlExpression
    {
        #region HintText

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg,
       int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public static void SetHintText(this Control control, string text)
        {
            SendMessage(control.Handle, 0X1501, 0, text);
        }
        #endregion
    }
}

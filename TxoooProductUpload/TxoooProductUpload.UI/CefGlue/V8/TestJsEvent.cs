using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TxoooProductUpload.UI.CefGlue
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class TestJsEvent
    {
        public Object MyParam { get; set; }

        public Object GetMyParam()
        {
            ///System.Windows.Forms.MessageBox.Show("dd");
            if (MyParam.GetType().IsArray)
            {
                String s = "[";
                Object[] o = (Object[])MyParam;
                for (int i = 0; i < o.Length; i++)
                {
                    s += "'" + o[i].ToString() + "'";
                    if (i < (o.Length - 1))
                    {
                        s += ",";
                    }
                }
                s += "]";
                return s;
            }
            return MyParam;
        }

        public void openMyPc(String dir)
        {
            if (dir == null)
            {// 打开我的电脑
                dir = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
            }
            Process.Start("explorer.exe", dir);
        }

    }

}

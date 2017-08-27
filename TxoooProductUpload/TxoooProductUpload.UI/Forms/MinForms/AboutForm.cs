using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.UI.Common.Const;

namespace TxoooProductUpload.UI.Forms.MinForms
{
    partial class AboutForm : BaseForm
    {
        [DllImport("Wave.dll")]
        public static extern int E_WaveInit(IntPtr hwnd, string bmpStr);//初始化对象
        [DllImport("Wave.dll")]
        public static extern int E_AutoEffects(int type, int type1, int type2, int type3);//效果类型
        [DllImport("Wave.dll")]
        public static extern int E_WaveDropStone(int x, int y, int dx, int zl);//仍石头
        [DllImport("Wave.dll")]
        public static extern void E_WaveFree();//释放对象

        Random r = new Random();//置随机数种子

        public AboutForm()
        {
            InitializeComponent();
            Text = String.Format("关于 {0} {1}", AppInfo.AssemblyTitle, AppInfo.AssemblyVersion);
            labelCompanyName.Text = AppInfo.AssemblyCompany + AppInfo.AssemblyCopyright;
            Load += AboutForm_Load;
            sp.MouseMove += AboutForm_MouseMove;
            FormClosing += AboutForm_FormClosing;
        }

        private void AboutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            E_WaveFree();
        }

        private void AboutForm_MouseMove(object sender, MouseEventArgs e)
        {
            E_WaveDropStone(e.X, e.Y, r.Next(0, 5), r.Next(300, 800));
        }

        void AboutForm_Load(object sender, EventArgs e)
        {
            E_WaveInit(sp.Handle, Path.Combine(Environment.CurrentDirectory, "Skin", "copyright_bg2.bmp"));
            E_AutoEffects(2, 0, 0, 0);
            E_AutoEffects(1, r.Next(3, 25), r.Next(0, 5), r.Next(50, 500));
            E_WaveDropStone(1, 1, r.Next(0, 5), r.Next(300, 800));
            btnOK.Click += (s1, e1) => { Close(); };
        }
    }
}

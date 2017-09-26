using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using CCWin.Win32;
using CCWin.Win32.Const;
using TxoooProductUpload.Service.Entities;
using Iwenli.Text;

namespace TxoooProductUpload.UI
{
    public partial class InformationFrm : CCSkinMain
    {
        public InformationFrm(LoginInfo login, IpInfo ip) : this()
        {
            Text = login.DisplayName;
            pnlHeadImg.BackgroundImage = App.Context.UserService.GetHeadPic(login.UserName.AESDecrypt());
            if (ip == null)
            {
                ip = new IpInfo()
                {
                    Ip = "127.0.0.1",
                    Address = "本地",
                    Type = "未知"
                };
            }
            lblMsg.Text = string.Format("您好：{0}{1}当前登录IP:{2}{3}登录地点:{4}{5} {6}", login.MchInfo.NickName,
               Environment.NewLine, ip.Ip, Environment.NewLine, ip.Address, Environment.NewLine, ip.Type);
            lblState.Text = string.Format("上次：{0}", login.LastLoginTime.ToString("MM月dd日 HH:mm:ss"));

        }
        public InformationFrm()
        {
            InitializeComponent();
        }

        //窗口加载时
        private void FrmInformation_Load(object sender, EventArgs e)
        {
            //初始化窗口出现位置
            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            this.PointToScreen(p);
            this.Location = p;
            NativeMethods.AnimateWindow(this.Handle, 130, AW.AW_SLIDE + AW.AW_VER_NEGATIVE);//开始窗体动画
        }


        //倒计时5秒关闭弹出窗
        private void timShow_Tick(object sender, EventArgs e)
        {
            //鼠标不在窗体内时
            if (!this.Bounds.Contains(Cursor.Position))
            {
                this.Close();
            }
        }
    }
}

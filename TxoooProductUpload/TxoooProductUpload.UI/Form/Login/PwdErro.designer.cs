/********************************************************************
 * *
 * * 使本项目源码或本项目生成的DLL前请仔细阅读以下协议内容，如果你同意以下协议才能使用本项目所有的功能，
 * * 否则如果你违反了以下协议，有可能陷入法律纠纷和赔偿，作者保留追究法律责任的权利。
 * *
 * * 1、你可以在开发的软件产品中使用和修改本项目的源码和DLL，但是请保留所有相关的版权信息。
 * * 2、不能将本项目源码与作者的其他项目整合作为一个单独的软件售卖给他人使用。
 * * 3、不能传播本项目的源码和DLL，包括上传到网上、拷贝给他人等方式。
 * * 4、以上协议暂时定制，由于还不完善，作者保留以后修改协议的权利。
 * *
 * * Copyright (C) 2013-? cskin Corporation All rights reserved.
 * * 网站：CSkin界面库 http://www.cskin.net 
 * * 论坛：http://bbs.cskin.net
 * * 作者： 乔克斯 QQ：345015918 .Net项目技术组群：306485590
 * * 请保留以上版权信息，否则作者将保留追究法律责任。
 * *
 * * 创建时间：2015-01-28
 * * 说明：PwdErro.Designer.cs
 * *
********************************************************************/

namespace TxoooProductUpload.UI
{
    partial class PwdErro
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PwdErro));
            this.btnFindPwd = new CCWin.SkinControl.SkinButton();
            this.skinPictureBox1 = new CCWin.SkinControl.SkinPictureBox();
            this.lkFindPwd = new System.Windows.Forms.LinkLabel();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel7 = new CCWin.SkinControl.SkinLabel();
            this.btnQx = new CCWin.SkinControl.SkinButton();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFindPwd
            // 
            this.btnFindPwd.BackColor = System.Drawing.Color.Transparent;
            this.btnFindPwd.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.btnFindPwd.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnFindPwd.DownBack = ((System.Drawing.Image)(resources.GetObject("btnFindPwd.DownBack")));
            this.btnFindPwd.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnFindPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFindPwd.Location = new System.Drawing.Point(166, 159);
            this.btnFindPwd.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnFindPwd.MouseBack")));
            this.btnFindPwd.Name = "btnFindPwd";
            this.btnFindPwd.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnFindPwd.NormlBack")));
            this.btnFindPwd.Palace = true;
            this.btnFindPwd.Size = new System.Drawing.Size(83, 25);
            this.btnFindPwd.TabIndex = 25;
            this.btnFindPwd.Tag = "";
            this.btnFindPwd.Text = "找回密码";
            this.btnFindPwd.UseVisualStyleBackColor = false;
            this.btnFindPwd.Click += new System.EventHandler(this.findPwd_Click);
            // 
            // skinPictureBox1
            // 
            this.skinPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("skinPictureBox1.Image")));
            this.skinPictureBox1.Location = new System.Drawing.Point(23, 51);
            this.skinPictureBox1.Name = "skinPictureBox1";
            this.skinPictureBox1.Size = new System.Drawing.Size(36, 36);
            this.skinPictureBox1.TabIndex = 26;
            this.skinPictureBox1.TabStop = false;
            // 
            // lkFindPwd
            // 
            this.lkFindPwd.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(111)))), ((int)(((byte)(234)))));
            this.lkFindPwd.AutoSize = true;
            this.lkFindPwd.BackColor = System.Drawing.Color.Transparent;
            this.lkFindPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lkFindPwd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lkFindPwd.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(133)))), ((int)(((byte)(227)))));
            this.lkFindPwd.Location = new System.Drawing.Point(285, 85);
            this.lkFindPwd.Name = "lkFindPwd";
            this.lkFindPwd.Size = new System.Drawing.Size(56, 17);
            this.lkFindPwd.TabIndex = 28;
            this.lkFindPwd.TabStop = true;
            this.lkFindPwd.Tag = "";
            this.lkFindPwd.Text = "找回密码";
            this.lkFindPwd.Click += new System.EventHandler(this.findPwd_Click);
            // 
            // skinLabel5
            // 
            this.skinLabel5.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.skinLabel5.Location = new System.Drawing.Point(77, 85);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(272, 17);
            this.skinLabel5.TabIndex = 29;
            this.skinLabel5.Text = "如果您的密码丢失或遗忘，可访问这里            。";
            // 
            // skinLabel7
            // 
            this.skinLabel7.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel7.AutoSize = true;
            this.skinLabel7.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel7.BorderColor = System.Drawing.Color.White;
            this.skinLabel7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel7.Location = new System.Drawing.Point(77, 51);
            this.skinLabel7.Name = "skinLabel7";
            this.skinLabel7.Size = new System.Drawing.Size(248, 17);
            this.skinLabel7.TabIndex = 27;
            this.skinLabel7.Text = "您输入的账号或密码错误，您要找回密码吗？";
            // 
            // btnQx
            // 
            this.btnQx.BackColor = System.Drawing.Color.Transparent;
            this.btnQx.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.btnQx.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnQx.DownBack = ((System.Drawing.Image)(resources.GetObject("btnQx.DownBack")));
            this.btnQx.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnQx.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQx.Location = new System.Drawing.Point(252, 159);
            this.btnQx.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnQx.MouseBack")));
            this.btnQx.Name = "btnQx";
            this.btnQx.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnQx.NormlBack")));
            this.btnQx.Palace = true;
            this.btnQx.Size = new System.Drawing.Size(83, 25);
            this.btnQx.TabIndex = 25;
            this.btnQx.Text = "取消";
            this.btnQx.UseVisualStyleBackColor = false;
            this.btnQx.Click += new System.EventHandler(this.btnQx_Click);
            // 
            // PwdErro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lkFindPwd);
            this.Controls.Add(this.skinLabel5);
            this.Controls.Add(this.skinLabel7);
            this.Controls.Add(this.skinPictureBox1);
            this.Controls.Add(this.btnQx);
            this.Controls.Add(this.btnFindPwd);
            this.DoubleBuffered = true;
            this.Name = "PwdErro";
            this.Size = new System.Drawing.Size(363, 235);
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinButton btnFindPwd;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox1;
        private System.Windows.Forms.LinkLabel lkFindPwd;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private CCWin.SkinControl.SkinLabel skinLabel7;
        private CCWin.SkinControl.SkinButton btnQx;
    }
}

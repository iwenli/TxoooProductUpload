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
    partial class OriginalImage : FormBase
    {
        public OriginalImage()
        {
            InitializeComponent();
            _context = new Service.ServiceContext();
            pic_Loading.Visible = true;
        }

        public OriginalImage(Image img):this()
        {
            pictureBox1.Image = img;
            this.Width = img.Width;
            this.Height = img.Height;

            if (img.Width > 800 && img.Height > 600)
            {
                this.Width = 800;
                this.Height = 600;
            }
            pic_Loading.Visible = false;
        }
        public OriginalImage(string imgUr) : this()
        {
            Image img = _context.ImageService.GetImageByUrl(imgUr);
            pictureBox1.Image = img;
            this.Width = img.Width;
            this.Height = img.Height;

            if (img.Width > 800 && img.Height > 600)
            {
                this.Width = 800;
                this.Height = 600;
            }
            pic_Loading.Visible = false;
        }

        #region MyRegion
        //private Image m_img = null;

        //private EventHandler evtHandler = null;
        ////重载的当前winform的OnPaint方法，当界面被重绘时去显示当前gif显示某一帧

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    if (m_img != null)
        //    {
        //        //获得当前gif动画下一步要渲染的帧。
        //        UpdateImage();
        //        //将获得的当前gif动画需要渲染的帧显示在界面上的某个位置。
        //        e.Graphics.DrawImage(m_img, new Rectangle(145, 140, m_img.Width, m_img.Height));
        //    }
        //}

        ////实现Load方法

        //void OriginalImage_Load(object sender, EventArgs e)
        //{
        //    //为委托关联一个处理方法
        //    evtHandler = new EventHandler(OnImageAnimate);
        //    //获取要加载的gif动画文件
        //    m_img = Image.FromFile(Application.StartupPath + "\\loading.gif");
        //    //调用开始动画方法
        //    BeginAnimate();
        //}

        ////开始动画方法
        //private void BeginAnimate()
        //{
        //    if (m_img != null)
        //    {
        //        //当gif动画每隔一定时间后，都会变换一帧，那么就会触发一事件，该方法就是将当前image每变换一帧时，都会调用当前这个委托所关联的方法。
        //         ImageAnimator.Animate(m_img, evtHandler);
        //    }

        //}

        ////委托所关联的方法
        //private void OnImageAnimate(Object sender, EventArgs e)
        //{
        //    //该方法中，只是使得当前这个winfor重绘，然后去调用该winform的OnPaint（）方法进行重绘)
        //    this.Invalidate();
        //}

        ////获得当前gif动画的下一步需要渲染的帧，当下一步任何对当前gif动画的操作都是对该帧进行操作)
        //private void UpdateImage()
        //{
        //    ImageAnimator.UpdateFrames(m_img);
        //}

        ////关闭显示动画，该方法可以在winform关闭时，或者某个按钮的触发事件中进行调用，以停止渲染当前gif动画。
        //private void StopAnimate()
        //{
        //    m_img = null;
        //    ImageAnimator.StopAnimate(m_img, evtHandler);
        //} 
        #endregion
    }
}

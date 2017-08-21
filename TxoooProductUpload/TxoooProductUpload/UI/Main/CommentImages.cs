using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TxoooProductUpload.UI.Main
{
    partial class CommentImages : FormBase
    {
        /// <summary>
        /// 更新图片委托
        /// </summary>
        public event EventHandler UpdateImage;
        /// <summary>
        ///  引发 <see cref="OnUpdateImage" /> 事件
        /// </summary>
        protected virtual void OnUpdateImage()
        {
            UpdateImage(ImageList, EventArgs.Empty);
        }
        /// <summary>
        /// 要展示的图片
        /// </summary>
        public List<string> ImageList { set; get; }

        int _maxRrviewImgCount = 6;//评价图片最多6个

        public CommentImages()
        {
            InitializeComponent();
            _context = new Service.ServiceContext();
            CommentImages_Load();
        }

        void CommentImages_Load()
        {
            if (ImageList == null)
            {
                ImageList = new List<string>();
            }
            ShowImage();
            lv.MouseClick += Lv_MouseClick;
            cmsShow.Click += Cms_Click;
            cmsDel.Click += Cms_Click;
            btnSave.Click += Btn_Click;
            btnCancel.Click += Btn_Click;
            btnAdd.Click += Btn_Click;
        }

        /// <summary>
        /// 功能按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Btn_Click(object sender, EventArgs e)
        {
            var obj = sender as Button;
            switch (obj.Tag.ToString())
            {
                case "Add":
                    this.openFileDialog1.Filter = "允许格式(*.JPG;*.GIF;*.PNG;*.BMP)|*.JPG;*.JPEG;*.GIF;*.PNG;*.BMP";//|所有文件(*.*)|*.* "(*.*)|*.*";
                    this.openFileDialog1.Title = "选择图片";
                    if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (openFileDialog1.FileNames.Length + ImageList.Count > _maxRrviewImgCount)
                        {
                            SM(string.Format("最多上可以上传{0}张图片！", _maxRrviewImgCount - ImageList.Count));
                            return;
                        }

                        //先上传
                        foreach (string img in openFileDialog1.FileNames)
                        {
                            Image image = Image.FromFile(img);
                            var url = await _context.ImageService.UploadImg(image);
                            if (!ImageList.Contains(url))
                            {
                                ImageList.Add(url);
                            }
                        }
                        //重新显示
                        ShowImage();
                    }
                    break;
                case "Save":
                    OnUpdateImage(); Close();
                    break;
                case "Cancel":
                    Close();
                    break;
            }
        }

        /// <summary>
        /// 菜单事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Cms_Click(object sender, EventArgs e)
        {
            var obj = sender as ToolStripMenuItem;
            if (lv.SelectedItems.Count != 1) return;
            switch (obj.Tag.ToString())
            {
                case "del":
                    ImageList.Remove(lv.SelectedItems[0].Name);
                    lv.RemoveSelectedItems();
                    break;
                case "show":
                    new OriginalImage(lv.SelectedItems[0].Name).ShowDialog(this);
                    break;
            }
        }

        /// <summary>
        /// 菜单显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Lv_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lv.SelectedItems.Count == 1)
            {
                ListViewItem xy = lv.GetItemAt(e.X, e.Y);
                if (xy != null)
                {
                    Point point = this.PointToClient(lv.PointToScreen(new Point(e.X, e.Y)));
                    cms.Show(this, point);
                }
            }
        }

        /// <summary>
        /// 显示图片
        /// </summary>
        void ShowImage()
        {
            Task.Run(() =>
            {
                Action action = () =>
                {
                    il.Images.Clear();
                    lv.Items.Clear();
                    for (int i = 0; i < ImageList.Count; i++)
                    {
                        il.Images.Add(ImageList[i], _context.ImageService.GetImageByUrl(ImageList[i]));
                        lv.Items.Add(ImageList[i], "", i);
                    }
                };
                if (InvokeRequired)
                {
                    Invoke(action);
                }
            });
        }
    }
}

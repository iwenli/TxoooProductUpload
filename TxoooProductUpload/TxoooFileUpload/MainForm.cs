using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.Service;

namespace TxoooFileUpload
{
    public partial class MainForm : Form
    {
        #region 字段
        string _txoooFileUrl = string.Empty;
        ImageService _service = new ServiceContext().ImageService;
        #endregion

        public MainForm()
        {
            InitializeComponent();
            //this.AllowDrop = true;
            Load += MainForm_Load;
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            BtnEvent();
            //DragEnter += MainForm_DragEnter;
            //DragDrop += MainForm_DragDrop;
        }

        //private void MainForm_DragDrop(object sender, DragEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// 拖到上面的文件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void MainForm_DragEnter(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(DataFormats.FileDrop))
        //    {
        //        var file = ((string[])e.Data.GetData(DataFormats.FileDrop))?[0];
        //        if (file != null)
        //        {
        //            var image = Image.FromFile(file);
        //            if (image != null)
        //            {
        //                showAndUploadImage(image);
        //            }
        //        }
        //    }
        //}

        void BtnEvent()
        {
            btnClose.Click += (_s, _e) => { Close(); };
            btnSelect.Click += (_s, _e) =>
            {
                var file = GetImageFiles()?[0];
                if (file != null)
                {
                    var image = Image.FromFile(file);
                    if (image != null)
                    {
                        showAndUploadImage(image);
                    }
                }
            };
            btnUpload.Click += (_s, _e) =>
            {
                if (!string.IsNullOrWhiteSpace(txtFrom.Text))
                {
                    try
                    {
                        showAndUploadImage(txtFrom.Text);
                    }
                    catch (Exception ex)
                    {
                        txtResult.Text = "异常：" + ex.Message;
                    }

                }
            };
        }

        #region 全局键盘
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.V))
            {
                var data = System.Windows.Forms.Clipboard.GetDataObject();
                var bmap = (Image)(data.GetData(typeof(System.Drawing.Bitmap)));
                if (bmap != null)
                {
                    showAndUploadImage(bmap);
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        async void showAndUploadImage(Image image)
        {
            picBoxImage.Image = image;
            try
            {
                _txoooFileUrl = await _service.UploadImgAsync(image);
                if (!string.IsNullOrWhiteSpace(_txoooFileUrl) && _txoooFileUrl != "error")
                {
                    Clipboard.SetDataObject(_txoooFileUrl);
                    txtResult.Text = "上传成功（已经自动复制到剪切板）：" + _txoooFileUrl;
                    txtResult.SelectAll();
                }

            }
            catch (Exception ex)
            {
                txtResult.Text = "上传失败：" + ex.Message;
            }
        }

        void showAndUploadImage(string url)
        {
            try
            {
                var image = _service.GetImageByUrl(url);
                if (image != null)
                {
                    picBoxImage.Image = image;

                    _txoooFileUrl = _service.UploadImg(url);
                    if (!string.IsNullOrWhiteSpace(_txoooFileUrl) && _txoooFileUrl != "error")
                    {
                        Clipboard.SetDataObject(_txoooFileUrl);
                        txtResult.Text = "上传成功（已经自动复制到剪切板）：" + _txoooFileUrl;
                        txtResult.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                txtResult.Text = "上传失败：" + ex.Message;
            }
        }

        string[] GetImageFiles(int maxImageCounts = 1)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择文件";
            openFileDialog.Filter = "JPG图片|*.jpg|BMP图片|*.bmp|Gif图片|*.gif|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.Multiselect = maxImageCounts > 1;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    return openFileDialog.FileNames;
                }
                catch (Exception ex)
                {
                    txtResult.Text = "选择文件异常：" + ex.Message;
                }
            }
            return null;
        }
    }
}

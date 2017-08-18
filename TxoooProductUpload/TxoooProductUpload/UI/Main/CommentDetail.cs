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
using TxoooProductUpload.Service.Entities.Commnet;

namespace TxoooProductUpload.UI.Main
{
    partial class CommentDetail : FormBase
    {
        /// <summary>
        /// 继续提交数据 委托
        /// </summary>
        public event EventHandler IsUploadData;

        /// <summary>
        /// 引发 <see cref="IsUploadData" /> 事件
        /// </summary>
        protected virtual void OnIsUploadData()
        {
            var handler = IsUploadData;
            if (handler != null)
                handler(bs.DataSource, EventArgs.Empty);
        }

        public CommentDetail(ReviewDataSoruce ds)
        {
            InitializeComponent();
            bs.DataSource = ds;
            this.Load += CommentDetail_Load;
            _context = new Service.ServiceContext();

        }


        void CommentDetail_Load(object sender, EventArgs e)
        {
            dgvComments.RowStateChanged += DgvComments_RowStateChanged;
            dgvComments.DataError += DgvComments_DataError;
            cmsDel.Click += CmsDel_Click;
            FormClosing += CommentDetail_FormClosing;
            tsSave.Click += TsSave_Click;
            ShowHeadImage();
        }

        /// <summary>
        /// 不处理此异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvComments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TsSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }
        /// <summary>
        /// 关闭窗体 处罚回调事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommentDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.Yes)
            {
                DialogResult = SMYN("保存更改数据并提交？");
            }
            if (DialogResult == DialogResult.Yes)
            {
                OnIsUploadData();
            }
        }

        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CmsDel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvComments.SelectedRows)
            {
                dgvComments.Rows.Remove(item);
            }
        }

        /// <summary>
        /// 行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DgvComments_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        /// <summary>
        /// 显示头像
        /// </summary>
        void ShowHeadImage()
        {
            Task.Run(() =>
            {
                for (int i = 0; i < dgvComments.Rows.Count; i++)
                {
                    //下面两个方式都可以
                    try
                    {
                        string url = dgvComments.Rows[i].Cells["HeadImageUrl"].Value.ToString();
                        dgvComments.Rows[i].Cells["HeadImage"].Value = _context.ImageService.GetImageByUrl(url);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            });
        }

    }
}

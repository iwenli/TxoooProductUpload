using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.Common;
using TxoooProductUpload.Common.Extended;
using TxoooProductUpload.Service;
using TxoooProductUpload.Service.Entities.Commnet;

namespace TxoooProductUpload.UI.Main
{
    partial class Comment : FormBase
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        private int LVM_SETICONSPACING = 0x1035;
        Regex _urlReg = new Regex(@"7518.cn/shop.html\?id=(\d{5})");
        string _userHeadPic = ConstParams.DEFAULT_HEAD_PIC;
        int _maxRrviewImgCount = 6;//评价图片最多6个
        bool _isUploadReviewImg = true;
        List<string> _reviewImgPathList = new List<string>();
        ReviewInfo _reviewInfo = null;
        ProductInfo _productInfo = null;

        public Comment(ServiceContext context) : base(context)
        {
            InitializeComponent();
            AppendLog(txtLog, "评价页面初始化[开始]...");
            InitPage1();
            InitPage2();
            AppendLog(txtLog, "评价页面初始化[完毕]...");
        }

        /// <summary>
        /// 初始化tagPage1
        /// </summary>
        void InitPage1()
        {
            this.txtUrl.SetHintText("在这里输入要添加评价的创业赚钱商品链接");
            this.txtLog.Focus();
            //复制天猫脚本
            this.btnTmall.Click += (s, e) =>
            {
                try
                {
                    Clipboard.SetText(ConstParams.PRODUCT_COMMENT_TMALL);
                    SM("复制脚本成功");
                }
                catch (Exception ex)
                {
                    AppendLogError(txtLog, "[异常]" + ex.Message);
                }
            };
            //解析商品事件
            this.btnGetProductInfo.Click += async (s, e) =>
            {
                var url = txtUrl.Text.Trim();
                #region 验证URL
                if (string.IsNullOrEmpty(url))
                {
                    SM("哎呀你逗我呢，没连接你给谁评价去O(∩_∩)O~");
                    return;
                }
                if (!_urlReg.IsMatch(url))
                {
                    SM("仔细瞅瞅，商品链接不对吧!");
                    return;
                }
                #endregion
                #region 验证商品
                try
                {
                    var productId = Convert.ToInt64(_urlReg.Match(url).Groups[1].Value);
                    AppendLogWarning(txtLog, "开始验证商品信息...");
                    _productInfo = await _context.ProductService.GetProductInfo(productId);
                    if (_productInfo != null)
                    {
                        AppendLogWarning(txtLog, "商品验证通过，信息如下：");
                        AppendLog(txtLog, "商品{0}品名：{1}", _productInfo.product[0].product_id
                            , _productInfo.product[0].product_name);
                        AppendLog(txtLog, "共识别出{0}个SKU,提交评价会随机匹配SKU作为购买规格评价使用！请知悉...", _productInfo.property.Count);
                        for (int i = 0; i < _productInfo.property.Count; i++)
                        {
                            AppendLog(txtLog, "第{0}个SKU={1}", i + 1, _productInfo.property[i].json_info);
                        }
                        //绑定到page2属性combobox上
                        cbProperty.DataSource = _productInfo.property;
                        //启用
                        tcReviews.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    AppendLogError(txtLog, "[异常]" + ex.Message);
                }
                #endregion
            };
            //解析json评价并上传
            this.btnAddComments.Click += async (s, e) =>
            {
                var json = txtJson.Text.Trim();
                #region 验证URL
                if (string.IsNullOrEmpty(json))
                {
                    SM("干嘛呢，输入评价数据啊！");
                    return;
                }
                #endregion
                #region 提交评价 批量
                try
                {
                    var reviewList = JsonConvert.DeserializeObject<List<ReviewInfo>>(json);
                    AppendLog(txtLog, "共识别出{0}条评价...", reviewList.Count);
                    if (reviewList.Count > 0)
                    {
                        if (SMYN(string.Format("共解析评价{0}条，是否开始上传?", reviewList.Count)) == DialogResult.Yes)
                        {
                            var random = new Random();
                            for (int i = 0; i < reviewList.Count; i++)
                            {
                                reviewList[i].ProductId = _productInfo.product[0].product_id;
                                reviewList[i].AddUserId = _context.Session.Token.userid;
                                reviewList[i].PropertyName = _productInfo.property[random.Next(0, _productInfo.property.Count)]
                                .json_info;
                                //循环处理评价图片
                                if (_isUploadReviewImg && !string.IsNullOrEmpty(reviewList[i].ReviewImgs))
                                {
                                    var imgList = reviewList[i].ReviewImgs.Split(',');
                                    var updateImglist = new List<string>();
                                    for (int j = 0; j < imgList.Length; j++)
                                    {
                                        AppendLog(txtLog, "开始处理第[{0}]个评价的第[{1}]张图片...", i + 1, j + 1);
                                        updateImglist.Add(await _context.CommonService.UploadImg(imgList[j], 4));
                                        AppendLog(txtLog, "第[{0}]个评价的第[{1}]张图片处理完成...", i + 1, j + 1);
                                    }
                                    reviewList[i].ReviewImgs = string.Join(",", updateImglist);
                                }
                                else
                                {
                                    reviewList[i].ReviewImgs = "";
                                }
                            }
                            await SubmintReview(reviewList);
                        }
                    }
                }
                catch (Exception ex)
                {
                    AppendLogError(txtLog, "[异常]" + ex.Message);
                }
                #endregion
            };
            //url输入框点击事件  主要用来自动粘贴
            this.txtUrl.Click += (s, e) =>
            {
                if (string.IsNullOrEmpty((s as TextBox).Text))
                {
                    string getTxt = Clipboard.GetText();
                    if (_urlReg.IsMatch(getTxt))
                    {
                        (s as TextBox).Text = getTxt;
                    }
                }
                else
                {
                    (s as TextBox).SelectAll();
                }
            };

            //是否上传图片
            this.cbIsUploadReviewImg.Click += (s, e) =>
            {
                _isUploadReviewImg = cbIsUploadReviewImg.Checked;
            };
        }
        /// <summary>
        /// 初始化tagPage2
        /// </summary>
        void InitPage2()
        {
            SendMessage(this.lvReviewImage.Handle, LVM_SETICONSPACING, 0, 0x10000 * 40 + 52);//70是行距，60是列距，
            ResetPage2();
            BingPage2Event();
        }

        /// <summary>
        /// 绑定事件
        /// </summary>
        void BingPage2Event()
        {
            //上传头像
            pbHead.Click += async (s, e) =>
            {
                OpenFileDialog ofdImgHead = new OpenFileDialog();   //显示选择文件对话框 
                ofdImgHead.Title = "创业赚钱-商家工具";
                ofdImgHead.Filter = "图片文件(*.jpg,*.png,*.gif,*.bmp,*.jpeg)|*.jpg;*.png;*.gif;*.bmp;*jpeg";
                ofdImgHead.FilterIndex = 2;
                ofdImgHead.RestoreDirectory = true;
                if (ofdImgHead.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image headPic = Image.FromFile(ofdImgHead.FileName).Thumbnail();
                        _userHeadPic = await _context.CommonService.UploadImg(headPic);
                        pbHead.Image = headPic;
                        AppendLogWarning(txtLog, "头像更换[成功]...");
                    }
                    catch (Exception ex)
                    {
                        AppendLogWarning(txtLog, "头像更换[失败]...");
                        Image headPic = Image.FromStream(new MemoryStream(await _context.CommonService.GetImageStreamByImgUrl(_userHeadPic)));
                        AppendLogWarning(txtLog, "[异常发生在]:", ex);
                    }
                }
            };
            //url更换头像
            btnUpdateHeadPic.Click += async (s, e) =>
            {
                string url = txtUpdateHeadPicUrl.Text.Trim();
                //if (!url.IsUrl())
                //{
                //    SM("图片地址没有啊亲...");
                //    return;
                //}
                try
                {
                    var wc = new WebClient();
                    var imageB = wc.DownloadData(url);
                    //var imageB = await _context.CommonService.GetImageStreamByImgUrl(url);
                    var headPic = Image.FromStream(new MemoryStream(imageB)).Thumbnail();
                    _userHeadPic = await _context.CommonService.UploadImg(headPic);
                    pbHead.Image = headPic;
                    AppendLogWarning(txtLog, "头像更换[成功]...");
                    txtUpdateHeadPicUrl.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    AppendLogWarning(txtLog, "头像更换[失败]...");
                    Image headPic = Image.FromStream(new MemoryStream(await _context.CommonService.GetImageStreamByImgUrl(_userHeadPic)));
                    AppendLogWarning(txtLog, "[异常发生在]:", ex);
                }
            };

            //添加评价图片
            pbAddReviewImage.Click += (s, e) =>
            {
                OpenFileDialog ofdReviewImage = new OpenFileDialog();   //显示选择文件对话框
                ofdReviewImage.Multiselect = true;
                ofdReviewImage.Title = "创业赚钱-商家工具";
                ofdReviewImage.Filter = "图片文件(*.jpg,*.png,*.gif,*.bmp,*.jpeg)|*.jpg;*.png;*.gif;*.bmp;*jpeg";
                ofdReviewImage.FilterIndex = 1;
                ofdReviewImage.RestoreDirectory = true;
                if (ofdReviewImage.ShowDialog() == DialogResult.OK)
                {
                    //先判断
                    if (ofdReviewImage.FileNames.Where(m => _reviewImgPathList.Contains(m)).Count() > 0)
                    {
                        SM("不要拿重复的图片来搪塞好不啦~~~");
                        return;
                    }
                    if (ofdReviewImage.FileNames.Length + _reviewImgPathList.Count > _maxRrviewImgCount)
                    {
                        SM(string.Format("最多上可以上传{0}张图片！", _maxRrviewImgCount - _reviewImgPathList.Count));
                        return;
                    }
                    ilReviewImage.Images.Clear();
                    lvReviewImage.Items.Clear();

                    _reviewImgPathList.AddRange(ofdReviewImage.FileNames);
                    //刷新Listview
                    for (int i = 0; i < _reviewImgPathList.Count; i++)
                    {
                        ilReviewImage.Images.Add(_reviewImgPathList[i], Image.FromFile(_reviewImgPathList[i]));
                        lvReviewImage.Items.Add(_reviewImgPathList[i], "", i);
                    }
                    if (_reviewImgPathList.Count == _maxRrviewImgCount)
                    {
                        pbAddReviewImage.Enabled = false;
                    }
                }
            };

            //删除评价图片菜单
            lvReviewImage.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Right && this.lvReviewImage.SelectedItems.Count == 1)
                {
                    ListViewItem xy = lvReviewImage.GetItemAt(e.X, e.Y);
                    if (xy != null)
                    {
                        Point point = this.PointToClient(lvReviewImage.PointToScreen(new Point(e.X, e.Y)));
                        this.cmsReviewImage.Show(this, point);
                    }
                }
            };
            //删除图片事件
            tsmDelReviewImage.Click += (s, e) =>
            {
                //AppendLog(txtLog, "删除的图片是：{0}", );
                _reviewImgPathList.Remove(lvReviewImage.SelectedItems[0].Name);
                lvReviewImage.RemoveSelectedItems();

                if (!pbAddReviewImage.Enabled)
                {
                    pbAddReviewImage.Enabled = true;
                }
            };
            //评价内容
            txtReviewContent.TextChanged += (s, e) =>
            {
                if (txtReviewContent.Text.Trim().Length == 0)
                {
                    btnAddReviewOne.Enabled = false;
                    return;
                }
                if (!btnAddReviewOne.Enabled)
                {
                    btnAddReviewOne.Enabled = true;
                }
            };
            //提交评价按钮事件
            btnAddReviewOne.Click += async (s, e) =>
             {
                 try
                 {
                     if (txtNickName.Text.Trim().IsNullOrEmpty())
                     {
                         SM("昵称不能为空哦");
                         return;
                     }
                     btnAddReviewOne.Enabled = false;
                     //拉取信息
                     _reviewInfo = new ReviewInfo()
                     {
                         ProductId = _productInfo.product[0].product_id,
                         PropertyName = cbProperty.Text,
                         NickName = txtNickName.Text.Substring(0, 1) + "***" + txtNickName.Text.Substring(txtNickName.Text.Length - 1, 1),
                         LikeCount = (int)nudLikeCount.Value,
                         ProductReview = (int)nudProductScore.Value,
                         ExpressReview = (int)nudExpressScore.Value,
                         AddTime = dtpAddTime.Value.ToString("yyyy-MM-dd"),
                         MchReplyContent = txtMchReplyContent.Text.Trim(),
                         ReviewContent = txtReviewContent.Text.Trim(),
                         HeadPic = _userHeadPic,
                         AddUserId = _context.Session.Token.userid
                     };
                     var reviewImageUrls = new List<string>();
                     //上传评价图片
                     for (int i = 0; i < _reviewImgPathList.Count; i++)
                     {
                         reviewImageUrls.Add(await _context.CommonService.UploadImg(Image.FromFile(_reviewImgPathList[i])));
                     }
                     _reviewInfo.ReviewImgs = string.Join(",", reviewImageUrls);

                     var reviewParam = new List<ReviewInfo>();
                     reviewParam.Add(_reviewInfo);
                     if (await SubmintReview(reviewParam))
                     {
                         ResetPage2();
                         return;
                     }
                 }
                 catch (Exception ex)
                 {
                     AppendLogError(txtLog, "[异常]：", ex.Message);
                     return;
                 }
                 btnAddReviewOne.Enabled = true;
             };
        }

        /// <summary>
        /// 提交评价
        /// </summary>
        /// <param name="reviews"></param>
        /// <returns></returns>
        async Task<bool> SubmintReview(List<ReviewInfo> reviews)
        {
            if (reviews == null)
            {
                SM("评价内容咋是空的尼？");
                return false;
            }
            AppendLogWarning(txtLog, "开始上传评价...");
            try
            {
                var isSuccess = await _context.ProductService.AddProductCommnet(JsonConvert.SerializeObject(reviews));
                if (isSuccess)
                {
                    AppendLogWarning(txtLog, "上传成功...");
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("上传评价异常：" + ex.Message);
            }
            AppendLogWarning(txtLog, "上传失败...");
            return false;
        }

        /// <summary>
        /// 重置页面状态
        /// </summary>
        async void ResetPage2()
        {
            txtNickName.SetHintText("评价显示的名称");
            txtMchReplyContent.SetHintText("请输入商家回复，可为空");
            txtUpdateHeadPicUrl.SetHintText("请输入图像的URL");
            _reviewImgPathList.Clear();
            _reviewInfo = null;
            txtNickName.Text = txtMchReplyContent.Text = txtReviewContent.Text = txtUpdateHeadPicUrl.Text = string.Empty;
            nudLikeCount.Value = 0;
            nudProductScore.Value = nudExpressScore.Value = 5;
            ilReviewImage.Images.Clear();
            lvReviewImage.Items.Clear();
            _userHeadPic = ConstParams.DEFAULT_HEAD_PIC;
            pbHead.Image = Image.FromStream(new MemoryStream(await _context.CommonService.GetImageStreamByImgUrl(_userHeadPic)));
            dtpAddTime.MaxDate = DateTime.Now.AddSeconds(1);
            dtpAddTime.Value = DateTime.Now;
            btnAddReviewOne.Enabled = !(pbAddReviewImage.Enabled = true);
        }
    }
}

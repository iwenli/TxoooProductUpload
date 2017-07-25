using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxoooProductUpload.Common;
using TxoooProductUpload.Service;
using TxoooProductUpload.Service.Entities.Commnet;

namespace TxoooProductUpload.UI.Main
{
    partial class Comment : FormBase
    {
        Regex _urlReg = new Regex(@"7518.cn/shop.html\?id=(\d{5})");
        ProductInfo _productInfo = null;

        public Comment(ServiceContext context) : base(context)
        {
            InitializeComponent();
            AppendLog(txtLog, "评价页面初始化[开始]...");
            Init();
            AppendLog(txtLog, "评价页面初始化[完毕]...");
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            this.txtUrl.SetHintText("在这里输入要添加评价的创业赚钱商品链接");
            this.txtJson.Focus();
            this.btnAddComments.Enabled = false;
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
                        this.btnAddComments.Enabled = true;
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
                this.btnAddComments.Enabled = false;
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
                                reviewList[i].PropertyName = _productInfo.property[random.Next(0, _productInfo.property.Count - 1)]
                                .json_info;
                                //循环处理评价图片
                                if (!string.IsNullOrEmpty(reviewList[i].ReviewImgs))
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
                            }
                            AppendLogWarning(txtLog, "开始上传评价...");
                            if (await _context.ProductService.AddProductCommnet(JsonConvert.SerializeObject(reviewList)))
                            {
                                AppendLogWarning(txtLog, "上传成功...");
                            }
                            else
                            {
                                AppendLogWarning(txtLog, "上传失败...");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    AppendLogError(txtLog, "[异常]" + ex.Message);
                }
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
        }
    }
}

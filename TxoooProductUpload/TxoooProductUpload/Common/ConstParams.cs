using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Common
{
    /// <summary>
    /// 常量
    /// </summary>
    class ConstParams
    {
        /// <summary>
        /// 天猫评价抓取脚本
        /// </summary>
        public const string PRODUCT_COMMENT_TMALL = @"if (typeof getTmallReview != 'function') {
    getTmallReview = function () {
        var reviewModelList = [];
        var reviewContionar = document.getElementById('s-review');
        var reviewItem = reviewContionar.childNodes[0].childNodes[1].childNodes;
        for (var i = 0; i < reviewItem.length; i++) {
            var reviewModel = { NickName: '', AddTime: Date(), ReviewContent: '', MchReplyContent: '', ReviewImgs: '' };
            reviewModel.NickName = reviewItem[i].querySelector('.nike').innerText; //昵称
            reviewModel.AddTime = reviewItem[i].querySelector('time').innerText; //评价时间
            reviewModel.ReviewContent = reviewItem[i].querySelector('blockquote').innerText; //评价内容
            var mchReplyContent = reviewItem[i].querySelector('.reply');
            if (mchReplyContent) {
                reviewModel.MchReplyContent = mchReplyContent.innerText.replace('掌柜回复:', ''); //商家回复
            }
            var reviewImgs = reviewItem[i].querySelector('.pics');
            if (reviewImgs) {
                var imgUrls = [];
                reviewImgs.querySelectorAll('img').forEach(function (i) {
                    imgUrls.push(i.src.replace('_100x100q75.jpg', ''));
                });
                reviewModel.ReviewImgs = imgUrls.join(); //评价图片
            }
            reviewModelList.push(reviewModel);
        }
        return reviewModelList;
    }
}
if (typeof Reviews == 'undefined') {
    var Reviews = {};
}
Reviews = getTmallReview();
alert('抓取成功' + Reviews.length + '条评价')
console.log(JSON.stringify(Reviews));";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.Entities.Commnet
{
    /// <summary>
    /// 评论
    /// </summary>
    class ReviewInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public long ProductId { set; get; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { set; get; }
        /// <summary>
        /// 评价时间
        /// </summary>
        public string AddTime { set; get; }
        /// <summary>
        /// 评价内容
        /// </summary>
        public string ReviewContent { set; get; }
        /// <summary>
        /// 商家回复内容
        /// </summary>
        public string MchReplyContent { set; get; }
        /// <summary>
        /// 评价图片,多个图片之间逗号分隔
        /// </summary>
        public string ReviewImgs { set; get; }
        string _headPic = "https://img.txooo.com/2016/04/18/43dddcd3fff51e5418c33dbeef55c001.png";
        /// <summary>
        /// 评论头像
        /// </summary>
        public string HeadPic { set { _headPic = value; } get { return _headPic; } }
        /// <summary>
        /// 购买属性
        /// </summary>
        public string PropertyName { set; get; }

        int _productReview = 5;
        /// <summary>
        /// 商品打分
        /// </summary>
        public int ProductReview { set { _productReview = value; } get { return _productReview; } }

        int _expressReview = 5;
        /// <summary>
        /// 快递打分
        /// </summary>
        public int ExpressReview { set { _productReview = value; } get { return _expressReview; } }

        /// <summary>
        /// 添加的用户ID，只能是商户添加，而且必须是登陆的商户
        /// </summary>
        public long AddUserId { set; get; }
    }
}

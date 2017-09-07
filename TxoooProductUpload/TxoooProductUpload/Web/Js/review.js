if (typeof Date.prototype.format != 'function') {
    Date.prototype.format = function (fmt) {
        var o = {
            'M+': this.getMonth() + 1,                 //月份 
            'd+': this.getDate(),                    //日 
            'h+': this.getHours(),                   //小时 
            'm+': this.getMinutes(),                 //分 
            's+': this.getSeconds(),                 //秒 
            'q+': Math.floor((this.getMonth() + 3) / 3), //季度 
            'S': this.getMilliseconds()             //毫秒 
        };
        if (/(y+)/.test(fmt)) {
            fmt = fmt.replace(RegExp.$1, (this.getFullYear() + '').substr(4 - RegExp.$1.length));
        }
        for (var k in o) {
            if (new RegExp('(' + k + ')').test(fmt)) {
                fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (('00' + o[k]).substr(('' + o[k]).length)));
            }
        }
        return fmt;
    };
}
if (typeof getTmallReview != 'function') {
    getTmallReview = function () {
        var reviewModelList = [], reviewContionar, reviewItem;
        var nickNameClass = '.nick';
        reviewContionar = document.getElementById('s-review');
        if (reviewContionar == null) {
            reviewContionar = document.getElementById('J_CommentsWrapper');
            reviewItem = reviewContionar.childNodes[3].childNodes;
        } else {
            reviewItem = reviewContionar.childNodes[0].childNodes[1].childNodes;
            nickNameClass = '.nike';
        }
        for (var i = 0; i < reviewItem.length; i++) {
            if (reviewItem[i].nodeName == 'LI' && reviewItem[i].classList.contains('item')) {
                var reviewModel = { NickName: '', AddTime: Date(), ReviewContent: '', MchReplyContent: '', ReviewImgs: '' };
                reviewModel.NickName = reviewItem[i].querySelector(nickNameClass).innerText; //昵称
                reviewModel.AddTime = reviewItem[i].querySelector('time').innerText; //评价时间
                reviewModel.ReviewContent = reviewItem[i].querySelector('blockquote').innerText; //评价内容
                var mchReplyContent = reviewItem[i].querySelector('.reply');
                if (mchReplyContent) {
                    reviewModel.MchReplyContent = mchReplyContent.innerText.replace('掌柜回复:', ''); //商家回复
                }
                if (!isLegitimate(reviewModel.ReviewContent) || !isLegitimate(reviewModel.MchReplyContent)) { continue; }
                var reviewImgs = reviewItem[i].querySelector('.pics');
                if (reviewImgs) {
                    var imgUrls = [];
                    var rawImgs = reviewImgs.querySelectorAll('img');
                    for (j = 0; j < rawImgs.length; j++) {
                        var imgSrc = rawImgs[j].src;
                        if (imgSrc.indexOf('_.webp') > -1) {
                            imgSrc = imgSrc.replace(/_110x100[\s\S]*_.webp/, '');
                        } else {
                            imgSrc = imgSrc.replace('_100x100q75.jpg', '');
                        }
                        if (imgSrc.indexOf('http') != 0) {
                            imgSrc = 'https://' + imgSrc;
                        }
                        imgUrls.push(imgSrc);
                    }
                    reviewModel.ReviewImgs = imgUrls.join(); //评价图片
                }
                reviewModelList.push(reviewModel);
            }
        }
        return reviewModelList;
    };
}
if (typeof getJdReview != 'function') {
    getJdReview = function () {
        var reviewModelList = [];
        var reviewContionar = document.getElementById('comment-0');
        var reviewItem = reviewContionar.childNodes;
        for (var i = 0; i < reviewItem.length; i++) {
            if (reviewItem[i].nodeName == 'DIV' && reviewItem[i].classList.contains('comment-item')) {
                var reviewModel = { NickName: '', HeadPic: '', AddTime: Date(), ReviewContent: '', MchReplyContent: '', ReviewImgs: '' };
                reviewModel.NickName = reviewItem[i].querySelector('.avatar').alt; //昵称
                reviewModel.HeadPic = reviewItem[i].querySelector('.avatar').src; //头像
                reviewModel.AddTime = reviewItem[i].querySelector('.order-info').childNodes[3].innerText; //评价时间
                if (!/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2})$/.test(reviewModel.AddTime)) {
                    reviewModel.AddTime = new Date().format('yyyy-MM-dd hh:mm');
                }
                reviewModel.ReviewContent = reviewItem[i].querySelector('.comment-con').innerText; //评价内容
                reviewModel.ProductReview =
                    reviewModel.ExpressReview = reviewItem[i].querySelector('.comment-star').outerHTML.match(/star([1-5])/)[1]; //商品和快递评分
                //商家回复
                var mchReplyContent = reviewItem[i].querySelector('.recomment');
                if (mchReplyContent) {
                    var replyContent = reviewContionar.childNodes[1].querySelector('.recomment').innerText;
                    if (replyContent && replyContent.length > 0 && replyContent.indexOf('回复：')) {
                        reviewModel.MchReplyContent = replyContent.substr(replyContent.indexOf('回复：') + 3);
                    }
                }
                if (!isLegitimate(reviewModel.ReviewContent) || !isLegitimate(reviewModel.MchReplyContent)) { continue; }
                var mchReplyContent = '';//京东没有商家回复
                var reviewImgs = reviewItem[i].querySelector('.pic-list');
                if (reviewImgs) {
                    var imgUrls = [];
                    var rawImgs = reviewImgs.querySelectorAll('img');
                    for (j = 0; j < rawImgs.length; j++) {
                        imgUrls.push(rawImgs[j].src.replace('n0/s48x48', 'n12/s800x800'));
                    }
                    reviewModel.ReviewImgs = imgUrls.join(); //评价图片
                }
                reviewModelList.push(reviewModel);
            }
        }
        return reviewModelList;
    };
}
if (typeof get1688Review != 'function') {
    get1688Review = function () {
        var reviewModelList = [];
        var reviewContionar = document.getElementById('m-detail-offer-remark-list');
        var reviewItem = reviewContionar.childNodes[1].childNodes[1].childNodes;
        for (var i = 0; i < reviewItem.length; i++) {
            if (reviewItem[i].nodeName == 'DIV' && reviewItem[i].classList.contains('remark-item')) {
                var reviewModel = { NickName: '', AddTime: Date(), ReviewContent: '', MchReplyContent: '', ReviewImgs: '' };
                reviewModel.NickName = reviewItem[i].querySelector('.member').innerText; //昵称
                reviewModel.AddTime = reviewItem[i].querySelector('.date').childNodes[1].innerText; //评价时间
                reviewModel.ReviewContent = reviewItem[i].querySelector('.bd').innerText; //评价内容
                if (!isLegitimate(reviewModel.ReviewContent)) { continue; }
                //reviewModel.ProductReview =
                //    reviewModel.ExpressReview = reviewItem[i].querySelector('.member-star').outerHTML.match(/star([1-5])/)[1]; //商品和快递评分
                //1688没有商家回复 和 赛图
                reviewModelList.push(reviewModel);
            }
        }
        return reviewModelList;
    };
}
if (typeof getTaobaoReview != 'function') {
    getTaobaoReview = function () {
        var reviewModelList = [];
        var reviewContionar = document.getElementsByClassName('rates_content')[0];
        var reviewItem = reviewContionar.childNodes[0].childNodes[0].childNodes[0].childNodes;
        for (var i = 0; i < reviewItem.length; i++) {
            var reviewModel = { NickName: '', AddTime: Date(), ReviewContent: '', MchReplyContent: '', ReviewImgs: '' };
            reviewModel.NickName = reviewItem[i].querySelector('.rates_header_nick').innerText; //昵称
            reviewModel.AddTime = reviewItem[i].querySelector('.lib-rates-feedbackDate').innerText; //评价时间
            reviewModel.ReviewContent = reviewItem[i].querySelector('.lib-rates-content').innerText; //评价内容
            if (!isLegitimate(reviewModel.ReviewContent)) { continue; }
            reviewModel.HeadPic = reviewItem[0].querySelector('.rates_header_img img').src.replace('_40x40.jpg', ''); //头像
            var mchReplyContent = reviewItem[i].querySelector('.reply');
            if (mchReplyContent) {
                reviewModel.MchReplyContent = mchReplyContent.innerText.replace('掌柜回复:', ''); //商家回复
            }
            var reviewImgs = reviewItem[i].querySelector('.lib-rates-feexPic');
            if (reviewImgs) {
                var imgUrls = [];
                var rawImgs = reviewImgs.querySelectorAll('img');
                for (j = 0; j < rawImgs.length; j++) {
                    if (rawImgs[j].src.indexOf('http') < 0) {
                        imgUrls.push('https:' + rawImgs[j].src);
                    }
                    else {
                        imgUrls.push(rawImgs[j].src);
                    }
                }
                reviewModel.ReviewImgs = imgUrls.join(); //评价图片
            }
            reviewModelList.push(reviewModel);
        }
        return reviewModelList;
    };
}
if (typeof isLegitimate == 'undefined') {
    isLegitimate = function (str) {
        return /天猫|京东|阿里|淘宝/gi.test(str) == false;
    }
}
if (typeof getReview == 'undefined') {
    getReview = function () {
        var host = location.host;
        if (host.indexOf('detail.m.tmall') > -1) {
            return getTmallReview();
        }
        else if (host == 'item.jd.com') {
            return getJdReview();
        }
        else if (host == 'm.1688.com') {
            return get1688Review();
        }
        else if (host == 'h5.m.taobao.com') {
            return getTaobaoReview();
        }
    }
}
if (typeof Reviews == 'undefined') {
    var Reviews = {};
}
Reviews = getReview();
console.clear();
console.log('抓取成功' + Reviews.length + '条评价');
document.write(JSON.stringify(Reviews));
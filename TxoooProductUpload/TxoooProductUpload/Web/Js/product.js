//淘宝搜索
var productArray = [], container, item;
container = document.getElementById('mainsrp-itemlist');
reviewItem = container.childNodes[3].childNodes;
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
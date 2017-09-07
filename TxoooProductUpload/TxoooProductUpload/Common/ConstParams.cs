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
        #region Const
        /// <summary>
        /// 软件名称
        /// </summary>
        public const string APP_NAME = @"创业赚钱-商家工具";
        /// <summary>
        /// 作者
        /// </summary>
        public const string APP_AUTHOR = @"iwenli";

        /// <summary>
        /// 默认头像
        /// </summary>
        public const string DEFAULT_HEAD_PIC = @"https://img.txooo.com/2016/04/18/43dddcd3fff51e5418c33dbeef55c001.png";

        /// <summary>
        /// 评价抓取脚本
        /// </summary>
        public const string PRODUCT_COMMENT = @"eval(function(p,a,c,k,e,r){e=function(c){return(c<a?'':e(parseInt(c/a)))+((c=c%a)>35?String.fromCharCode(c+29):c.toString(36))};if(!''.replace(/^/,String)){while(c--)r[e(c)]=k[c]||e(c);k=[function(e){return r[e]}];e=function(){return'\\w+'};c=1};while(c--)if(k[c])p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c]);return p}('7(x F.1s.W!=\'n\'){F.1s.W=n(a){6 o={\'M+\':C.1r()+1,\'d+\':C.2f(),\'h+\':C.29(),\'m+\':C.28(),\'s+\':C.24(),\'q+\':1F.1A((C.1r()+3)/3),\'S\':C.1x()};7(/(y+)/.Q(a)){a=a.z(N.$1,(C.1w()+\'\').1a(4-N.$1.r))}A(6 k 1O o){7(1e N(\'(\'+k+\')\').Q(a)){a=a.z(N.$1,(N.$1.r==1)?(o[k]):((\'1z\'+o[k]).1a((\'\'+o[k]).r)))}}u a}}7(x 12!=\'n\'){12=n(){6 a=[],J,t;6 b=\'.1y\';J=L.V(\'s-1v\');7(J==1u){J=L.V(\'20\');t=J.9[3].9}I{t=J.9[0].9[1].9;b=\'.1Y\'}A(6 i=0;i<t.r;i++){7(t[i].11==\'1T\'&&t[i].13.14(\'R\')){6 c={E:\'\',v:F(),p:\'\',w:\'\',G:\'\'};c.E=t[i].8(b).l;c.v=t[i].8(\'1B\').l;c.p=t[i].8(\'1R\').l;6 d=t[i].8(\'.1k\');7(d){c.w=d.l.z(\'掌柜回复:\',\'\')}7(!D(c.p)||!D(c.w)){U}6 e=t[i].8(\'.2r\');7(e){6 f=[];6 g=e.16(\'P\');A(j=0;j<g.r;j++){6 h=g[j].H;7(h.K(\'1f.1g\')>-1){h=h.z(/2i[\\s\\S]*1f.1g/,\'\')}I{h=h.z(\'2q.1h\',\'\')}7(h.K(\'1i\')!=0){h=\'1j://\'+h}f.B(h)}c.G=f.15()}a.B(c)}}u a}}7(x 10!=\'n\'){10=n(){6 a=[];6 b=L.V(\'T-0\');6 c=b.9;A(6 i=0;i<c.r;i++){7(c[i].11==\'1l\'&&c[i].13.14(\'T-R\')){6 d={E:\'\',X:\'\',v:F(),p:\'\',w:\'\',G:\'\'};d.E=c[i].8(\'.1m\').1C;d.X=c[i].8(\'.1m\').H;d.v=c[i].8(\'.1D-1E\').9[3].l;7(!/^(\\d{1,4})(-|\\/)(\\d{1,2})\\2(\\d{1,2}) (\\d{1,2}):(\\d{1,2})$/.Q(d.v)){d.v=1e F().W(\'1G-1H-1I 1J:1K\')}d.p=c[i].8(\'.T-1L\').l;d.1M=d.1N=c[i].8(\'.T-1n\').1P.1Q(/1n([1-5])/)[1];6 e=c[i].8(\'.1d\');7(e){6 f=b.9[1].8(\'.1d\').l;7(f&&f.r>0&&f.K(\'回复：\')){d.w=f.1a(f.K(\'回复：\')+3)}}7(!D(d.p)||!D(d.w)){U}6 e=\'\';6 g=c[i].8(\'.1S-1o\');7(g){6 h=[];6 k=g.16(\'P\');A(j=0;j<k.r;j++){h.B(k[j].H.z(\'1U/1V\',\'1W/1X\'))}d.G=h.15()}a.B(d)}}u a}}7(x 1c!=\'n\'){1c=n(){6 a=[];6 b=L.V(\'m-1p-1Z-1q-1o\');6 c=b.9[1].9[1].9;A(6 i=0;i<c.r;i++){7(c[i].11==\'1l\'&&c[i].13.14(\'1q-R\')){6 d={E:\'\',v:F(),p:\'\',w:\'\',G:\'\'};d.E=c[i].8(\'.21\').l;d.v=c[i].8(\'.22\').9[1].l;d.p=c[i].8(\'.23\').l;7(!D(d.p)){U}a.B(d)}}u a}}7(x 1b!=\'n\'){1b=n(){6 a=[];6 b=L.25(\'26\')[0];6 c=b.9[0].9[0].9[0].9;A(6 i=0;i<c.r;i++){6 d={E:\'\',v:F(),p:\'\',w:\'\',G:\'\'};d.E=c[i].8(\'.27\').l;d.v=c[i].8(\'.19-17-2a\').l;d.p=c[i].8(\'.19-17-2b\').l;7(!D(d.p)){U}d.X=c[0].8(\'.2c P\').H.z(\'2d.1h\',\'\');6 e=c[i].8(\'.1k\');7(e){d.w=e.l.z(\'掌柜回复:\',\'\')}6 f=c[i].8(\'.19-17-2e\');7(f){6 g=[];6 h=f.16(\'P\');A(j=0;j<h.r;j++){7(h[j].H.K(\'1i\')<0){g.B(\'1j:\'+h[j].H)}I{g.B(h[j].H)}}d.G=g.15()}a.B(d)}u a}}7(x D==\'Z\'){D=n(a){u/天猫|京东|阿里|淘宝/2g.Q(a)==2h}}7(x 18==\'Z\'){18=n(){6 a=2j.2k;7(a.K(\'1p.m.2l\')>-1){u 12()}I 7(a==\'R.2m.Y\'){u 10()}I 7(a==\'m.2n.Y\'){u 1c()}I 7(a==\'2o.m.2p.Y\'){u 1b()}}}7(x O==\'Z\'){6 O={}}O=18();1t.2s();1t.2t(\'抓取成功\'+O.r+\'条评价\');L.2u(2v.2w(O));',62,157,'||||||var|if|querySelector|childNodes||||||||||||innerText||function||ReviewContent||length||reviewItem|return|AddTime|MchReplyContent|typeof||replace|for|push|this|isLegitimate|NickName|Date|ReviewImgs|src|else|reviewContionar|indexOf|document||RegExp|Reviews|img|test|item||comment|continue|getElementById|format|HeadPic|com|undefined|getJdReview|nodeName|getTmallReview|classList|contains|join|querySelectorAll|rates|getReview|lib|substr|getTaobaoReview|get1688Review|recomment|new|_|webp|jpg|http|https|reply|DIV|avatar|star|list|detail|remark|getMonth|prototype|console|null|review|getFullYear|getMilliseconds|nick|00|floor|time|alt|order|info|Math|yyyy|MM|dd|hh|mm|con|ProductReview|ExpressReview|in|outerHTML|match|blockquote|pic|LI|n0|s48x48|n12|s800x800|nike|offer|J_CommentsWrapper|member|date|bd|getSeconds|getElementsByClassName|rates_content|rates_header_nick|getMinutes|getHours|feedbackDate|content|rates_header_img|_40x40|feexPic|getDate|gi|false|_110x100|location|host|tmall|jd|1688|h5|taobao|_100x100q75|pics|clear|log|write|JSON|stringify'.split('|'),0,{}))";
        #endregion

        #region 属性

        /// <summary>
        /// 版本号
        /// </summary>
        public static string Version { get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); } }
        #endregion
    }
}

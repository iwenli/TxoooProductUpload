using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Common
{
    /// <summary>
    /// 常量
    /// </summary>
    public class ConstParams
    {
        #region Const
        ///// <summary>
        ///// 软件名称
        ///// </summary>
        //public const string AssemblyTitle = @"创业赚钱-商家工具";
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
        public const string PRODUCT_COMMENT = @"eval(function(p,a,c,k,e,r){e=function(c){return(c<a?'':e(parseInt(c/a)))+((c=c%a)>35?String.fromCharCode(c+29):c.toString(36))};if(!''.replace(/^/,String)){while(c--)r[e(c)]=k[c]||e(c);k=[function(e){return r[e]}];e=function(){return'\\w+'};c=1};while(c--)if(k[c])p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c]);return p}('7(B F.1i.12!=\'p\'){F.1i.12=p(a){6 o={\'M+\':u.1g()+1,\'d+\':u.2f(),\'h+\':u.2e(),\'m+\':u.29(),\'s+\':u.25(),\'q+\':24.1W((u.1g()+3)/3),\'S\':u.1S()};7(/(y+)/.U(a)){a=a.E(I.$1,(u.1N()+\'\').T(4-I.$1.n))}w(6 k 1M o){7(1h I(\'(\'+k+\')\').U(a)){a=a.E(I.$1,(I.$1.n==1)?(o[k]):((\'1H\'+o[k]).T((\'\'+o[k]).n)))}}t a}}7(B Q!=\'p\'){Q=p(){6 a=[];6 b=G.15(\'s-1F\');6 c=b.l[0].l[1].l;w(6 i=0;i<c.n;i++){7(c[i].W==\'1C\'&&c[i].Y.11(\'J\')){6 d={z:\'\',r:F(),x:\'\',A:\'\',D:\'\'};d.z=c[i].8(\'.1t\').9;d.r=c[i].8(\'1p\').9;d.x=c[i].8(\'1o\').9;6 e=c[i].8(\'.1b\');7(e){d.A=e.9.E(\'掌柜回复:\',\'\')}6 f=c[i].8(\'.1Q\');7(f){6 g=[];6 h=f.10(\'K\');w(j=0;j<h.n;j++){g.v(h[j].C.E(\'1n.1j\',\'\'))}d.D=g.16()}a.v(d)}}t a}}7(B 17!=\'p\'){17=p(){6 a=[];6 b=G.15(\'O-0\');6 c=b.l;w(6 i=0;i<c.n;i++){7(c[i].W==\'1c\'&&c[i].Y.11(\'O-J\')){6 d={z:\'\',P:\'\',r:F(),x:\'\',A:\'\',D:\'\'};d.z=c[i].8(\'.18\').1q;d.P=c[i].8(\'.18\').C;d.r=c[i].8(\'.1r-1s\').l[3].9;7(!/^(\\d{1,4})(-|\\/)(\\d{1,2})\\2(\\d{1,2}) (\\d{1,2}):(\\d{1,2})$/.U(d.r)){d.r=1h F().12(\'1u-1v-1w 1x:1y\')}d.x=c[i].8(\'.O-1z\').9;d.1A=d.1B=c[i].8(\'.O-19\').1D.1E(/19([1-5])/)[1];6 e=c[i].8(\'.1f\');7(e){6 f=b.l[1].8(\'.1f\').9;7(f&&f.n>0&&f.14(\'回复：\')){d.A=f.T(f.14(\'回复：\')+3)}}6 e=\'\';6 g=c[i].8(\'.1G-1k\');7(g){6 h=[];6 k=g.10(\'K\');w(j=0;j<k.n;j++){h.v(k[j].C.E(\'1I/1J\',\'1K/1L\'))}d.D=h.16()}a.v(d)}}t a}}7(B R!=\'p\'){R=p(){6 a=[];6 b=G.15(\'m-1l-1O-1d-1k\');6 c=b.l[1].l[1].l;w(6 i=0;i<c.n;i++){7(c[i].W==\'1c\'&&c[i].Y.11(\'1d-J\')){6 d={z:\'\',r:F(),x:\'\',A:\'\',D:\'\'};d.z=c[i].8(\'.1P\').9;d.r=c[i].8(\'.1m\').l[1].9;d.x=c[i].8(\'.1R\').9;a.v(d)}}t a}}7(B V!=\'p\'){V=p(){6 a=[];6 b=G.1T(\'1U\')[0];6 c=b.l[0].l[0].l[0].l;w(6 i=0;i<c.n;i++){6 d={z:\'\',r:F(),x:\'\',A:\'\',D:\'\'};d.z=c[i].8(\'.1V\').9;d.r=c[i].8(\'.X-Z-1X\').9;d.x=c[i].8(\'.X-Z-1Y\').9;d.P=c[0].8(\'.1Z K\').C.E(\'20.1j\',\'\');6 e=c[i].8(\'.1b\');7(e){d.A=e.9.E(\'掌柜回复:\',\'\')}6 f=c[i].8(\'.X-Z-21\');7(f){6 g=[];6 h=f.10(\'K\');w(j=0;j<h.n;j++){7(h[j].C.14(\'22\')<0){g.v(\'23:\'+h[j].C)}L{g.v(h[j].C)}}d.D=g.16()}a.v(d)}t a}}7(B 13==\'1e\'){13=p(){6 a=26.27;7(a==\'1l.m.28.N\'){t Q()}L 7(a==\'J.2a.N\'){t 17()}L 7(a==\'m.2b.N\'){t R()}L 7(a==\'2c.m.2d.N\'){t V()}}}7(B H==\'1e\'){6 H={}}H=13();1a.2g();1a.2h(\'抓取成功\'+H.n+\'条评价\');G.2i(2j.2k(H));',62,145,'||||||var|if|querySelector|innerText||||||||||||childNodes||length||function||AddTime||return|this|push|for|ReviewContent||NickName|MchReplyContent|typeof|src|ReviewImgs|replace|Date|document|Reviews|RegExp|item|img|else||com|comment|HeadPic|getTmallReview|get1688Review||substr|test|getTaobaoReview|nodeName|lib|classList|rates|querySelectorAll|contains|format|getReview|indexOf|getElementById|join|getJdReview|avatar|star|console|reply|DIV|remark|undefined|recomment|getMonth|new|prototype|jpg|list|detail|date|_100x100q75|blockquote|time|alt|order|info|nike|yyyy|MM|dd|hh|mm|con|ProductReview|ExpressReview|LI|outerHTML|match|review|pic|00|n0|s48x48|n12|s800x800|in|getFullYear|offer|member|pics|bd|getMilliseconds|getElementsByClassName|rates_content|rates_header_nick|floor|feedbackDate|content|rates_header_img|_40x40|feexPic|http|https|Math|getSeconds|location|host|tmall|getMinutes|jd|1688|h5|taobao|getHours|getDate|clear|log|write|JSON|stringify'.split('|'),0,{}))";
        #endregion


        #region 程序集特性访问器
        /// <summary>
        /// 标题
        /// </summary>
        public static  string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }
        /// <summary>
        /// 版本
        /// </summary>
        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public static string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }
        /// <summary>
        /// 版权
        /// </summary>
        public static string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        /// <summary>
        /// 公司
        /// </summary>
        public static string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}

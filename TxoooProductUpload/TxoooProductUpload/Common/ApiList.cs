using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Service.Entities.Web;

namespace TxoooProductUpload.Common
{
    /// <summary>
    /// 创业赚钱接口
    /// </summary>
    class ApiList
    {
        #region 基础
        private static bool _isTest = false;
        private static bool _isHttps = true;
        private static LoginAsyncResult _token = new LoginAsyncResult();

        /// <summary>
        /// App Token
        /// </summary>
        public static LoginAsyncResult Token
        {
            set
            {
                _token = value;
            }
            get { return _token; }
        }

        /// <summary>
        /// 是否测试环境
        /// </summary>
        public static bool IsTest
        {
            set
            {
                _isTest = value;
            }
            get { return _isTest; }
        }
        /// <summary>
        /// 是否ssl
        /// </summary>
        public static bool IsHttps
        {
            set
            {
                _isHttps = value;
            }
            get { return _isHttps; }
        }
        /// <summary>
        /// 当前app-api的Host
        /// </summary>
        public static string HostApp
        {
            get
            {
                return
                    (_isHttps ? @"https://" : @"http://") +
                    (_isTest ? @"apimchtest.7518.cn/" : @"api.7518.cn/");
            }
        }

        /// <summary>
        /// 当前mch-api的Host
        /// </summary>
        public static string HostMch
        {
            get
            {
                return
                    (_isHttps ? @"https://" : @"http://") +
                    (_isTest ? @"testmch.7518.cn/" : @"mch.7518.cn/");
            }
        }

        /// <summary>
        /// 当前web-api的Host
        /// </summary>
        public static string HostWeb
        {
            get
            {
                return
                    (_isHttps ? @"https://" : @"http://") +
                    (_isTest ? @"11.t.7518.cn/" : @"11.u.7518.cn/");
            }
        }
        /// <summary>
        /// app Token字符串
        /// </summary>
        public static string AppToken
        {
            get
            {
                return string.Format(@"?userid={0}&token={1}", _token.userid, _token.token);
            }
        }
        #endregion

        /// <summary>
        /// 登陆
        /// </summary>
        public static string Login
        {
            get
            {
                return HostApp + @"App/MchInfo.mch/Login";
            }
        }
        /// <summary>
        /// 商户Web登陆
        /// </summary>
        public static string MchWebLogin
        {
            get
            {
                return HostMch + @"Txooo/Sales/Mch/Passport/Ajax/MchAjax.ajax/LoginV2";
            }
        }
        /// <summary>
        /// 获取商户信息
        /// </summary>
        public static string GetMchStateInfo
        {
            get
            {
                return HostApp + @"App/Account.mch/GetMchStateInfo";
            }
        }

        /// <summary>
        /// 获取地域信息
        /// </summary>
        public static string GetArea
        {
            get
            {
                return HostApp + @"App/Product.mch/GetArea";
            }
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        public static string UpdateImgFile
        {
            get
            {
                return HostApp + @"App/Helper.api/UpdateImgFile";
            }
        }

        /// <summary>
        /// 获取商品分类
        /// </summary>
        public static string GetProductClassByParentIdV3
        {
            get
            {
                return HostWeb + @"Txooo/SalesV2/Shop/Ajax/ShopOpenAjax.ajax/GetProductClassByParentIdV3";
            }
        }

        /// <summary>
        /// 获取商品全部分类
        /// </summary>
        public static string GetAllProductClassV2
        {
            get
            {
                return HostMch + @"Txooo/Sales/Mch/Product/Ajax/ProductAjax.ajax/GetAllProductClassV2";
            }
        }

        /// <summary>
        /// 上传商品
        /// </summary>
        public static string AddProduct4
        {
            get
            {
                return HostApp + @"App/Product.mch/AddProduct4" + AppToken;
            }
        }

        /// <summary>
        /// 获取商品信息
        /// </summary>
        public static string GetProductInfo
        {
            get
            {
                return HostApp + @"App/ShopV2.api/getproductshop" + AppToken;
            }
        }

        /// <summary>
        /// 添加评价
        /// </summary>
        public static string AddProductCommnet
        {
            get
            {
                return HostApp + @"App/ShopV3.api/AddProductCommnet" + AppToken;
            }
        }

    }
}

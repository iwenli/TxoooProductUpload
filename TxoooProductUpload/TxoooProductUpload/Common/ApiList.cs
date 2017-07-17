using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// 当前api的Host
        /// </summary>
        public static string Host
        {
            get
            {
                return
                    (_isHttps ? @"https://" : @"http://") +
                    (_isTest ? @"apimchtest.7518.cn/" : @"api.7518.cn/");
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
                return Host + @"App/MchInfo.mch/Login";
            }
        }

        /// <summary>
        /// 获取商户信息
        /// </summary>
        public static string GetMchStateInfo
        {
            get
            {
                return Host + @"App/Account.mch/GetMchStateInfo";
            }
        }

        /// <summary>
        /// 获取地域信息
        /// </summary>
        public static string GetArea
        {
            get
            {
                return Host + @"App/Product.mch/GetArea";
            }
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        public static string UpdateImgFile
        {
            get
            {
                return Host + @"App/Helper.api/UpdateImgFile";
            }
        }

        /// <summary>
        /// 获取商品分类
        /// </summary>
        public static string GetProductClassByParentIdV3
        {
            get
            {
                // return Host + @"App/Helper.api/UpdateImgFile";
                return (_isHttps ? @"https://" : @"http://") + @"0.t.7518.cn/Txooo/SalesV2/Shop/Ajax/ShopOpenAjax.ajax/GetProductClassByParentIdV3";
            }
        }
    }
}

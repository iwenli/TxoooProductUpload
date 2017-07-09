﻿using System;
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
        public bool IsTest
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
        public bool IsHttps
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
                    (_isTest ? @"apitest.7518.cn/" : @"api.7518.cn/");
            }
        }
        #endregion

        /// <summary>
        /// 登陆
        /// </summary>
        public static string Login = Host + @"App/MchInfo.mch/Login"; 

        /// <summary>
        /// 获取商户信息
        /// </summary>
        public static string GetMchStateInfo = Host + @"App/Account.mch/GetMchStateInfo";

        ///// <summary>
        ///// 获取地域信息
        ///// </summary>
        //public static string GetArea = Host + @"App/Product.mch/GetArea";

        /// <summary>
        /// 上传图片
        /// </summary>
        public static string UpdateImgFile = Host + @"App/Helper.api/UpdateImgFile";
    }
}

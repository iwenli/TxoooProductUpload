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
    public class ApiList
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
                    (_isTest ? @"apitest.7518.cn/" : @"api.7518.cn/");
            }
        }

        /// <summary>
        /// 当前app-api的Host
        /// </summary>
        public static string MchHostApp
        {
            get
            {
                return
                    (_isHttps ? @"https://" : @"http://") +
                    (_isTest ? @"apimchtest.7518.cn/" : @"apimch.7518.cn/");
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
                return MchHostApp + @"App/MchInfo.mch/Login";
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
                return MchHostApp + @"App/Account.mch/GetMchStateInfo";
            }
        }

        /// <summary>
        /// 获取地域信息
        /// </summary>
        public static string GetArea
        {
            get
            {
                return MchHostApp + @"App/Product.mch/GetArea";
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
                return MchHostApp + @"App/Product.mch/AddProduct4" + AppToken;
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

        #region 商品来源
        /// <summary>
        /// 保存商品来源和商品信息
        /// 参数：data 商品信息json
        /// </summary>
        public static string InsertProductsSource
        {
            get
            {
                return MchHostApp + @"App/CrawlProduct.mch/InsertProductsSource" + AppToken;
            }
        }
        /// <summary>
        /// 增量获取商品来源和商品信息
        /// 参数：id 集合中最大的id
        /// 
        /// </summary>
        public static string GetProductsSourceList
        {
            get
            {
                return MchHostApp + @"App/CrawlProduct.mch/GetProductsSourceList" + AppToken;
            }
        }
        #endregion

        #region 商品上下架编辑等操作
        /// <summary>
        /// 获取商品列表
        /// </summary>
        public static string GetProductListForCrawl
        {
            get
            {
                return MchHostApp + @"App/Product.mch/GetProductListForCrawl" + AppToken;
            }
        }
        /// <summary>
        /// 获取商品各个状态产品数量
        /// </summary>
        public static string GetProductStateCount
        {
            get
            {
                return MchHostApp + @"App/Product.mch/GetProductStateCount" + AppToken;
            }
        }
        /// <summary>
        /// 获取商品基本信息
        /// </summary>
        public static string GetProductInfoForMch
        {
            get
            {
                return MchHostApp + @"App/Product.mch/GetProductInfo" + AppToken;
            }
        }
        /// <summary>
        /// 删除商品
        /// 参数：product_id
        /// </summary>
        public static string DelProduct
        {
            get
            {
                return MchHostApp + @"App/Product.mch/DelProduct" + AppToken;
            }
        }
        /// <summary>
        /// 商品上下架
        /// 参数：
        /// product_ids  逗号分隔
        /// is_show：1商家  0下架
        /// </summary>
        public static string UpProducts
        {
            get
            {
                return MchHostApp + @"App/Product.mch/UpProducts" + AppToken;
            }
        }
        #endregion
    }
}

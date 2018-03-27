using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Service.Entities.Web;

namespace TxoooProductUpload.Common
{
    /// <summary>
    /// 服务器接口
    /// </summary>
    public class ApiList
    {
        #region 基础
        private static string _domain = @".7518.cn/";
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
        /// 域名
        /// </summary>
        public static string Domain
        {
            set
            {
                _domain = "." + value + "/";
            }
            get { return _domain; }
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
                    (_isHttps ? @"https://" : @"http://")
                    + (_isTest ? @"apitest" : @"api")
                    + _domain;
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
                    (_isHttps ? @"https://" : @"http://")
                    + (_isTest ? @"apimchtest" : @"apimch")
                    + _domain;
            }
        }

        /// <summary>
        /// 当前mch-api的Host
        /// </summary>
        public static string HostMch
        {
            get
            {
                //兼容域名testmch.7518.cn || mchtest.93390.cn
                return
                    (_isHttps ? @"https://" : @"http://")
                    + (_isTest ? _domain.IndexOf("7518") > 0 ? @"testmch" : @"mchtest" : @"mch")
                    + _domain;
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
                    (_isHttps ? @"https://" : @"http://")
                    + (_isTest ? @"11.t" : @"11.u")
                    + _domain;
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
        /// </summary>
        public static string GetProductsSourceList
        {
            get
            {
                return MchHostApp + @"App/CrawlProduct.mch/GetProductsSourceList" + AppToken;
            }
        }

        /// <summary>
        /// 增量获取商品来源和商品信息
        /// 参数：pid txooo商品id
        ///     : sourceId 来源id
        ///     : sourcrType 来源类型 天猫1 淘宝2 阿里巴巴3 京东4
        /// </summary>
        public static string GetProductsSource
        {
            get
            {
                return MchHostApp + @"App/CrawlProduct.mch/GetProductsSource" + AppToken;
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

        #region 注册相关

        #region 个人注册
        /// <summary>
        /// 根据手机号获取推广码
        /// 参数：
        ///     mobile：手机号
        /// 返回值：
        ///     {"success":true,"msg":"207732"}
        /// </summary>
        public static string GetShareCodeByTxId
        {
            get
            {
                return HostApp + @"App/Passport.api/GetShareCodeByTxId";
            }
        }

        /// <summary>
        /// 验证用户名
        /// 参数：
        ///     regName：用户名（手机号）
        /// 返回值：
        ///     {"success":true,"msg":"用户名可用"}
        /// </summary>
        public static string CheckUserName
        {
            get
            {
                return HostApp + @"App/Passport.api/CheckUserName";
            }
        }

        /// <summary>
        /// 发送验证码
        /// 参数：
        ///     mobile
        /// 返回值：
        ///     {"success":true,"msg":"337A633874387541737150536E645A3939447979687942786C346F3245734F434836554E5870344150766D546F72627636506E5838715339734B423156514E67"}
        /// </summary>
        public static string SendMobile
        {
            get
            {
                return HostApp + @"App/Passport.api/SendMobile";
            }
        }

        /// <summary>
        /// 校验验证码
        /// 参数：
        ///     mobilecode
        /// </summary>
        public static string CheckMobileCode
        {
            get
            {
                return HostApp + @"App/Passport.api/CheckMobileCode";
            }
        }

        /// <summary>
        /// 注册，Post
        /// 参数：
        ///     zyl:zyl
        ///     mobilecode:code
        ///     mobile_verify:msg
        ///     Password:
        ///     sharecode：207732|110166
        ///     source：1                //用户来源（1个人推广，2产品推广）
        ///     source_channel：5        //来源渠道（0浏览器，1微信，2QQ，3微博，4App）  5pc
        ///     app_type：pc-winform
        ///     app_useragent: {"model":"pc","display":"1.0.2","systemName":"windows","product":"Microsoft ","release":"10","fingerprint":"252D2903-9F0B-42D2-BFC8-B9108B759672","channel":"local","device":"高额返利设备"}
        /// </summary>
        public static string Regist
        {
            get
            {
                return HostApp + @"App/Passport.api/RegistV3ForZyl";
            }
        }
        #endregion

        #region 入驻商家
        /// <summary>
        /// 入驻信息检测
        /// 返回值：
        ///     申请状态 0未提交申请 1待审核 2审核通过 3审核不通过
        /// </summary>
        public static string CheckMchApply
        {
            get
            {
                return HostApp + @"App/StoreV2.api/CheckMchApply" + AppToken;
            }
        }
        /// <summary>
        /// 上传资质图片	POST
        /// 参数：
        ///     type：字段类型
        ///     img：base64图片
        /// type类型:
        ///     identiy_pro_img:身份证正面
        ///     identiy_con_img:身份证反面
        ///     business_license_img:营业执照
        ///     service_license_img:服务许可证
        ///     operator_license_img:法人授权书
        ///     bank_pro_img:银行卡正面
        ///     bank_con_img:银行卡反面
        /// </summary>
        public static string UploadApplyImg
        {
            get
            {
                return HostApp + @"App/StoreV2.api/UploadApplyImg" + AppToken;
            }
        }
        /// <summary>
        /// 设置商户入驻第一步
        /// 参数：
        ///     operator_name：法人名称
        ///     identiy_code：身份证号
        ///     bank_name:银行名称
        ///     bank_name_open:开户行地址名称
        ///     bank_code:银行卡号
        ///     mch_class:商户类型
        ///     bank_account_type：银行账户类型（1个人，2企业）
        ///     bank_com_name:开户企业名称
        /// </summary>
        public static string SetMchApply
        {
            get
            {
                return HostApp + @"App/StoreV2.api/SetMchApply" + AppToken;
            }
        }
        /// <summary>
        /// 设置商户入驻第二步
        /// 参数：
        ///     com_name：店铺名称
        ///     region_code：地域代码
        ///     region_name：省市区名称
        ///     region_details：详细地区
        ///     lat：纬度坐标
        ///     lng：经度坐标
        ///     range_number：经营范围米数
        ///     business_time：经营时间
        ///     business_phone：联系电话
        ///     store_img：门头照
        ///     other_img：内部照片
        ///     mch_other_img：荣誉照片
        ///     store_type：店铺招商类型
        ///     store_type_name：店铺招商类型名称
        ///     agent_id：代理id
        /// </summary>
        public static string SetMchApplyClass
        {
            get
            {
                return HostApp + @"App/StoreV2.api/SetMchApplyClass" + AppToken;
            }
        }
        #endregion

        #endregion
    }
}

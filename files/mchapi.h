# 商户API

#ifndef APIMacro_h
#define APIMacro_h

//权限验证
#define Account_GetUserAppFunc @"/App/Account.mch/GetUserAppFunc"

//登录激活找回密码等
#define MchInfo_SendVerificationCode   @"/App/MchInfo.mch/SendVerificationCode"
#define MchInfo_JudgmentVerificationCode  @"/App/MchInfo.mch/JudgmentVerificationCode"
#define MchInfo_UpdateUserPassword     @"/App/MchInfo.mch/UpdateUserPassword"
#define MchInfo_UpdateUserPaymentPassword @"/App/MchInfo.mch/UpdateUserPaymentPassword"
#define MchInfo_SalesUpdatePw          @"/App/MchInfo.mch/SalesUpdatePw"
#define MchInfo_Uploadpic              @"/App/mchinfo.mch/uploadpic"
#define MchInfo_FindPwdSendMobileCode  @"/App/MchInfo.mch/FindPwdSendMobileCode"
#define MchInfo_FindPwdValidate        @"/App/MchInfo.mch/FindPwdValidate"
#define MchInfo_FindPwd                @"/App/MchInfo.mch/FindPwd"
#define MchInfo_Login                  @"/App/MchInfo.mch/Login"
#define MchInfo_GetBrands              @"/App/MchInfo.mch/GetBrands"
#define MchInfo_SelectBrand            @"/App/MchInfo.mch/SelectBrand"
#define MchInfo_PostInfo               @"/App/MchInfo.mch/PostInfo"
#define MchInfo_GetMchStore            @"/App/mchinfo.mch/GetMchStore"

//意见反馈
#define MchInfo_AddImgFeedBack         @"/App/MchInfo.mch/AddImgFeedBack"
// 用户协议接口
#define Helper_MchService                     @"/mchapp/Helper/mch_sevice.html"

//订单详情
//新版发货接口
#define OrderV3_SendProduct            @"/App/OrderV3.mch/SendProduct"
#define MchInfo_SetRefundState         @"/App/MchInfo.mch/SetRefundState"
//最终申请平台接入
#define OrderV2_OrderApplyKfRefund     @"/App/OrderV2.mch/OrderApplyKfRefund"

#define MchInfo_SetOrderStateV2        @"/App/MchInfo.mch/SetOrderStateV2"
#define MchInfo_GetOrderInfoById       @"/App/MchInfo.mch/GetOrderInfoById"
#define MchInfo_GetOrderWasteList      @"/App/MchInfo.mch/GetOrderWasteList"
#define MchInfo_GetOrderRefundWaste    @"/App/MchInfo.mch/GetOrderRefundWaste"
#define MchInfo_EditRemark             @"/App/MchInfo.mch/EditRemark"
//获取默认的收货地址
#define MchAddress_GetMchAddressDefault @"/App/MchAddress.mch/GetMchAddressDefault"

//获取退货原因列表数据
#define OrderV3_GetRefundContentList    @"/App/OrderV3.mch/GetRefundContentList"

//新版取消订单借口
#define OrderV3_CancelOrder             @"/App/OrderV3.mch/CancelOrder"

#define MchInfo_ConfirmRefundState     @"/App/MchInfo.mch/ConfirmRefundState"
#define MchInfo_WriteWebViewCookieV2   @"/App/MchInfo.mch/WriteWebViewCookieV2"
#define MchInfo_GetRandomProductShareContent @"/App/MchInfo.mch/GetRandomProductShareContent"
#define MchInfo_GetPic                 @"/App/mchinfo.mch/GetPic"

#define Account_GetMchStateInfo        @"/App/Account.mch/GetMchStateInfo"
#define Account_GetMchInfo             @"/App/Account.mch/GetMchInfo"
#define Account_GetTemplateProductById @"/App/IndexTemplate.mch/GetTemplateProductById"
#define Account_UpdateMchRegion        @"/App/Account.mch/UpdateMchRegion"
#define Account_SetTemplateClose       @"/App/IndexTemplate.mch/SetTemplateClose"
#define Account_GetMchTemplateState    @"/App/MchAd.mch/GetMchTemplateState"
#define Account_SetTemplateProduct     @"/App/IndexTemplate.mch/SetTemplateProduct"
#define Account_SetMchLogo             @"/App/Account.mch/SetMchLogo"
#define Account_GetMchAdimgList        @"/App/MchAd.mch/GetMchAdimgList"
#define Account_SetMchAdimg            @"/App/MchAd.mch/SetMchAdimg"
#define Account_SetMchAdClose          @"/App/MchAd.mch/SetMchAdClose"
#define Account_GetTemplateIndexByMch  @"/App/IndexTemplate.mch/GetTemplateIndexByMch"
#define Account_SetTemplateOpenById    @"/App/IndexTemplate.mch/SetTemplateOpenById"
//员工
#define Account_GetRbacUserByMch       @"/App/Employee.mch/GetRbacUserByMch"
#define Account_AddEmployee            @"/App/Employee.mch/AddEmployee"
#define Account_DelEmplyee             @"/App/Employee.mch/DelEmplyee"
#define Account_GetFuncList            @"/App/Employee.mch/GetFuncList"
#define Account_SetEmployeeFunc        @"/App/Employee.mch/SetEmployeeFunc"
#define Account_GetEmployeeInfo        @"/App/Employee.mch/GetEmployeeInfo"
//管理
#define Account_GetMchStoreInfo        @"/App/Account.mch/GetMchStoreInfo"
#define Account_SetMchMenuContent      @"/App/MchMenu.mch/SetMchMenuContent"
#define Account_SetMchMenu             @"/App/MchMenu.mch/SetMchMenu"
#define Account_DelMchMenu             @"/App/MchMenu.mch/DelMchMenu"
#define Account_GetMenuList            @"/App/MchMenu.mch/GetMenuList"
#define Account_DelMchBrand            @"/App/MchBrand.mch/DelMchBrand"
#define Account_SetMchBrand            @"/App/MchBrand.mch/SetMchBrand"
#define Account_GetMchBrandList        @"/App/MchBrand.mch/GetMchBrandList"
#define Account_DelMchShare            @"/App/MchShare.mch/DelMchShare"
#define Account_SetMchShare            @"/App/MchShare.mch/SetMchShare"
#define Account_GetMchShareList        @"/App/MchShare.mch/GetMchShareList"
#define Account_GetMenuContentPrivew   @"/App/MchMenu.mch/GetMenuContentPrivew"
#define Account_GetMenuContent         @"/App/MchMenu.mch/GetMenuContent"
#define Account_OpenMchMenu            @"/App/MchMenu.mch/OpenMchMenu"
#define Account_GetMchNewsList         @"/App/MchNew.mch/GetMchNewsList"
#define Account_SetMchNews             @"/App/MchNew.mch/SetMchNews"
#define Account_GetMchNewsInfo         @"/App/MchNew.mch/GetMchNewsInfo"
#define Account_DelMchNews             @"/App/MchNew.mch/DelMchNews"
//#define Account_SetMchNewsShow         @"/App/MchNew.mch/SetMchNewsShow"
#define Account_SetMchNewsShow         @"/App/MchNew.mch/SetNewsShow"
#define Account_SetMchNewsState        @"/App/MchNew.mch/SetMchNewsState"

#define Member_Area                    @"/App/Member.api/Area"

#define MchBrandSpread_GetMchBrandSpreadList @"/App/MchBrandSpread.mch/GetMchBrandSpreadList"
#define MchBrandSpread_GetSparedBrandInfo @"/App/MchBrandSpread.mch/GetSparedBrandInfo"
//地址管理
#define Account_GetMchAddressList      @"/App/MchAddress.mch/GetMchAddressList"
#define Account_SetMainAddress         @"/App/MchAddress.mch/SetMainAddress"
#define Account_DeleteMch              @"/App/MchAddress.mch/DeleteMch"
#define Account_AddMchAddress          @"/App/MchAddress.mch/AddMchAddress"
//门店管理
#define Account_GetMchApply1           @"/App/MchApply.mch/GetMchApply1"
#define Account_GetMchApply            @"/App/MchApply.mch/GetMchApply2"
#define Account_SetMchApply            @"/App/MchApply.mch/SetMchApply2"
#define Account_GetApplyPic            @"/App/MchApply.mch/GetApplyPic"
#define Account_CheckMchApply          @"/App/MchApply.mch/CheckMchApply"
#define Account_UploadApplyImg         @"/App/MchApply.mch/UploadApplyImg"
#define Account_SetMchApply1           @"/App/MchApply.mch/SetMchApply1"
#define Account_SetAgentId             @"/App/Account.mch/SetAgentId"

//售卖状态
#define Account_GetMchProductShowState @"/App/Account.mch/GetMchProductShowState"
#define Account_SetMchProductShowState @"/App/Account.mch/SetMchProductShowState"
//Message
#define News_SelectMemberIndexCount    @"/App/News.mch/GetMchNoReadMsg"
#define News_GetSystemList             @"/App/News.mch/GetSystemList"
#define News_GetMchLiuyanList          @"/App/News.mch/GetMchLiuyanList"
#define News_SetMchLiuyanCollect       @"/App/News.mch/SetMchLiuyanCollect"
#define News_DelMchLiuyan              @"/App/News.mch/DelMchLiuyan"
#define News_SetMchLiuyanRead          @"/App/News.mch/SetMchLiuyanRead"
#define News_GetSysMsgList             @"/App/News.Api/GetSysMsgList"
#define News_UpdateSystemIsOpen        @"/App/News.mch/UpdateSystemIsOpen"
#define News_GetSysMsgIndexList        @"/App/News.mch/GetSysMsgIndexList"
#define News_GetNotice                 @"/App/News.mch/GetNotice"
#define News_DelSysMsg                 @"/App/News.mch/DelSysMsg"

//Order
#define Shop_CheckOrderKfApply         @"/App/ShopV2.api/CheckOrderKfApply"
#define Shop_OrderApplyKf              @"/App/ShopV2.api/OrderApplyKf"
#define Shop_ApplyRefund               @"/app/shop.api/ApplyRefund"
//新版订单列表
#define Order_GetOrderList             @"/App/OrderV3.mch/GetOrderList"

//搜索结果数据
#define OrderV3_SearchOrder            @"/App/OrderV3.mch/SearchOrder"

//根据券号获得虚拟订单信息
#define OrderV3_GetOrderByCode         @"/App/OrderV3.mch/GetOrderByCode"

//使用虚拟券号
#define OrderV3_UseOrderByCode         @"/App/OrderV3.mch/UseOrderByCode"

//新版退货和交易关闭列表
#define OrderV3_GetOrderRefundList     @"/App/OrderV3.mch/GetOrderRefundList"


//新版订单详情数据
#define OrderV3_GetOrderDetailsInfo    @"/App/OrderV3.mch/GetOrderDetailsInfo"

//获得虚拟订单列表
#define Orders_GetOrderVirtualList     @"/App/OrderV3.mch/GetOrderVirtualList"

#define Orders_GetTodayPayMoney        @"/App/Orders.mch/GetTodayPayMoney"
#define Orders_OrderListCount          @"/App/Orders.mch/OrderListCount"

//新的获取订单数量的借口
#define OrderV3_GetOrderStateCount     @"/App/OrderV3.mch/GetOrderStateCount"
//验证界面
#define Orders_UseVerifyCodeUseStateV2  @"/App/Orders.mch/UseVerifyCodeUseStateV2"
#define Orders_GetConsumeValidateByCode @"/App/Orders.mch/GetConsumeValidateByCode"
//验证列表 V1.0接口已废弃
//#define  CHECKLISTURL                  @"/App/MchInfo.mch/GetValidateList"
//Goods

#define Product_GetMchProductClass     @"/App/ProductClass.mch/GetMchProductClass"
#define Product_DelMchProductClass     @"/App/ProductClass.mch/DelMchProductClass"
#define Product_AddMchProductClass     @"/App/ProductClass.mch/AddMchProductClass"
#define Product_DelMchProductClassMap  @"/App/ProductClass.mch/DelMchProductClassMap"
#define Product_AddMchProductClassMap  @"/App/ProductClass.mch/AddMchProductClassMap"

#define Product_ApplyProductClass      @"/App/Product.mch/ApplyProductClass"
#define Product_GetProductStateCount   @"/App/Product.mch/GetProductStateCount"
#define Product_GetProductInfo         @"/App/Product.mch/GetProductInfo"
#define Product_GetProductShare        @"/App/Product.mch/GetProductShare"
#define Product_GetProductProperty     @"/App/Product.mch/GetProductProperty"
#define Product_GetProductShareImg     @"/App/Product.mch/GetProductShareImg"
#define Product_GetProductList2        @"/App/Product.mch/GetProductList2"
#define Product_GetArea                @"/App/Product.mch/GetArea"
#define Product_ModifyProductCheck     @"/App/Product.mch/ModifyProductCheck"
#define Product_ModifyProductShow      @"/App/Product.mch/ModifyProductShow"

//删除商品
#define Product_DelProduct             @"/App/Product.mch/DelProduct"
#define Product_DelShareContent        @"/App/Product.mch/DelShareContent"
#define Product_GetProductClass        @"/App/Product.mch/GetProductClass"
#define Product_GetProductClassV2      @"/App/Product.mch/GetProductClassV2"
#define Product_GetProductClassById    @"/App/Product.mch/GetProductClassById"
#define Product_UpdateImgFile          @"/App/Product.mch/UpdateImgFile"
//添加
#define Product_AddProduct             @"/App/Product.mch/AddProduct4"
#define Product_ModifyShareContent     @"/App/Product.mch/ModifyShareContent"
#define Product_DelShareContent        @"/App/Product.mch/DelShareContent"
//结算(4个废弃)
#define Orders_GetOrderSettlementList  @"/App/Orders.mch/GetOrderSettlementList"
#define Orders_GetStatementDetail      @"/App/Orders.mch/GetStatementDetail"
#define Orders_OrderSettlementCount    @"/App/Orders.mch/OrderSettlementCount"
#define Orders_GetStatementList        @"/App/Orders.mch/GetStatementList"

#define Helper_UpdateImgFile           @"/App/Helper.api/UpdateImgFile"

//BBS
#define BBS_GetBBSList                 @"/app/BBS.mch/GetBBSList"
#define BBS_GetBBSLikeList             @"/app/BBS.mch/GetBBSLikeList"
#define BBS_GetUserBBSList             @"/app/BBS.mch/GetUserBBSList"
#define BBS_ReportUserBBS              @"/app/BBS.mch/ReportUserBBS"
#define BBS_GetBBSDetailsList          @"/app/BBS.mch/GetBBSDetailsList"
#define BBS_AddBBSContent              @"/app/BBS.mch/AddBBSContent"
#define BBS_DelUserBBS                 @"/app/BBS.mch/DelUserBBS"
#define BBS_SetUserBBSLike             @"/app/BBS.mch/SetUserBBSLike"
#define BBS_GetBBSDetails              @"/app/BBS.mch/GetBBSDetails"
#define Reward_GetRewardInfo           @"/app/Reward.mch/GetRewardInfo"
#define Reward_SetRewardState          @"/app/Reward.mch/SetRewardState"
#define Reward_IsOpen                  @"/app/Reward.mch/IsOpen"
#define Settlement_Index               @"/mchapp/Settlement/index.html"
#define Helper_Index                   @"/mchapp/helper/index.html"
#define Mchapp_Reviews                 @"/mchapp/Reviews_1.html"
#define Mchapp_Notice                  @"/mchapp/notice.html"

#endif /* APIMacro_h */

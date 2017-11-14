# 个人API

//api
#define MAINURL                    @".7518.cn"
#define LOGINURL                   @".7518.cn/App/Passport.Api/LoginV2"
#define THIRDLOGINURL              @".7518.cn/App/Passport.Api/WxLogin"
#define SENDCODEURL                @".7518.cn/App/Passport.Api/SendMobile?mobile=%@"
#define GETPAYCODEURL              @".7518.cn/App/Member.Api/SendOldMobileCode?userid=%@&token=%@"
#define CHECKPAYCODEURL            @".7518.cn/App/Member.Api/CheckMobileCode?userid=%@&token=%@&mobilecode=%@&mobile_verify=%@"
#define UPDATEPAYPWDURL            @".7518.cn/App/Member.Api/SubSalesPayPwd?userid=%@&token=%@&repwd=%@"
#define REGISTERURL                @".7518.cn/App/Passport.Api/RegistV2"
#define FINDPWDURL                 @".7518.cn/App/Passport.Api/FindPwd"
#define CHECKUSERURL               @".7518.cn/App/Passport.Api/CheckUserName?regName=%@"
#define CHECKSHARECODEURL          @".7518.cn/App/Passport.Api/CheckUserShareCode?share_code=%@"
#define USERINFOURL                @".7518.cn/App/Member.Api/GetUserInfo"
#define USERSHAREINFOURL           @".7518.cn/App/Member.Api/GetUserShareNum"
#define USERSHAREURL               @".7518.cn/App/Member.Api/GetUserShareList"
#define GETSHARECODEURL            @".7518.cn/App/Member.Api/GetUserShareCodeList"
#define SETSHARECODEURL            @".7518.cn/App/Member.Api/SetShareCode?share_code=%@"
#define BINDCODEURL                @".7518.cn/App/Member.Api/SendCodeMobile?userid=%@&token=%@&mobile=%@"
#define BINDURL                    @".7518.cn/App/Passport.Api/BindV2"
#define UPDATEPWDURL               @".7518.cn/App/Member.Api/SalesUpdatePw?userid=%@&token=%@"

#define BIND_GetVoiceValidateCode  @".7518.cn/App/helper.Api/GetVoiceValidateCode"
#define USERSAFE_SendOldVoiceCode  @".7518.cn/App/Member.api/SendOldVoiceCode"

#define FINDPWD_ValidateMobileCode @".7518.cn/App/Passport.Api/ValidateMobileCode"
#define FINDPWD_GetUserInfoByPhone @".7518.cn/App/Passport.Api/GetUserInfoByPhone"
#define FINDPWD_FindPwd            @".7518.cn/App/Passport.Api/FindPwd"

#define CHECK_GetShareCodeByTxId   @".7518.cn/App/Passport.Api/GetShareCodeByTxId"
#define CHECK_GetDefaultreferrer   @".7518.cn/App/Passport.Api/GetDefaultreferrer"
#define CHECKVERSION_CheckAppVersion @".7518.cn/App/Passport.Api/CheckAppVersion"

#define COOKIE_GetCookie           @".7518.cn/App/passport.Api/WriteWebViewCookieV2"
#define REGIST_RegistV2End         @".7518.cn/App/Passport.Api/RegistV2End"

/我的获取订单围堵消息
#define Member_SelectMemberIndexCountV3    @".7518.cn/App/Member.Api/SelectMemberIndexCountV3"



#define MINE_SelectMemberIndexCount        @".7518.cn/App/Member.Api/SelectMemberIndexCountV2"
#define MINE_GetUserInfo                   @".7518.cn/App/Member.Api/GetUserInfo"
#define MINE_AttendMe                      @".7518.cn/App/Member.Api/SalesAttendMe"
#define MINE_Suggestion                    @".7518.cn/App/Helper.Api/AddFeedBackForApp"
#define PERSONDETAIL_GetUserMchId          @".7518.cn/App/Member.api/GetUserMchId"

#define SelectMchType_GetMchApplyClassDb   @".7518.cn/app/StoreV2.api/GetMchApplyClassDb"
#define SelectMchType_SetMchApplyClass     @".7518.cn/app/StoreV2.api/SetMchApplyClass"
#define QualityMessage_GetPic              @".7518.cn/app/StoreV2.api/GetApplyPic"
#define SelectMchType_GetMchApplyClassDb   @".7518.cn/app/StoreV2.api/GetMchApplyClassDb"
#define SelectMchType_SetMchApplyClass     @".7518.cn/app/StoreV2.api/SetMchApplyClass"
#define QualityMessage_GetPic              @".7518.cn/app/StoreV2.api/GetApplyPic"
#define QualityMessage_GetMchApplyDb       @".7518.cn/app/StoreV2.api/GetMchApplyDb"
#define QualityMessage_GetMchApplyDb       @".7518.cn/app/StoreV2.api/GetMchApplyDb"
#define SelectMchType_GetMchApplyClassDb   @".7518.cn/app/StoreV2.api/GetMchApplyClassDb"
#define QualityMessage_GetPic              @".7518.cn/app/StoreV2.api/GetApplyPic"
#define  MchActiVCUrl                      @".7518.cn/app/StoreV2.api/UploadApplyImg"
#define QualityMessage_SetMchApply         @".7518.cn/app/StoreV2.api/SetMchApply"
#define QualityMessage_GetMchApplyDb       @".7518.cn/app/StoreV2.api/GetMchApplyDb"
#define QualityMessage_GetPic              @".7518.cn/app/StoreV2.api/GetApplyPic"
#define  MchActiVCUrl                      @".7518.cn/app/StoreV2.api/UploadApplyImg"
#define QualityMessage_SetMchApply         @".7518.cn/app/StoreV2.api/SetMchApply"
#define QualityMessage_GetMchApplyDb       @".7518.cn/app/StoreV2.api/GetMchApplyDb"
#define QualityMessage_GetPic              @".7518.cn/app/StoreV2.api/GetApplyPic"
#define QualityMessage_GetMchApplyDb       @".7518.cn/app/StoreV2.api/GetMchApplyDb"
#define SelectMchType_GetMchApplyClassDb   @".7518.cn/app/StoreV2.api/GetMchApplyClassDb"
#define SelectMchType_SetMchApplyClass     @".7518.cn/app/StoreV2.api/SetMchApplyClass"


#define MEMBERV2_UpdateAttention           @".7518.cn/app/MemberV2.api/UpdateAttention"
#define MEMBERV2_UpdateUserBase            @".7518.cn/app/MemberV2.api/UpdateUserBase"
#define MEMBERV2_GetMchInfo                @".7518.cn/app/MemberV2.api/GetMchInfo"
#define MEMBERV2_InitHomePageData          @".7518.cn/app/MemberV2.api/InitHomePageData"
#define MEMBERV2_GetNewsListBy             @".7518.cn/app/MemberV2.api/GetNewsListBy"
#define ADDRESS_GetSalesAddress            @".7518.cn/App/Member.api/GetSalesAddress"

// 我的资产明细
#define UserInfo_GetAccountWasteV3        @".7518.cn/App/Moneyv2.api/GetAccountWasteV3"
#define UserInfo_GetWasteTypeList         @".7518.cn/App/Moneyv2.api/GetWasteTypeList"
#define UserInfo_GetCodeMoneyDetailList   @".7518.cn/App/Moneyv2.api/GetCodeMoneyDetailList"

//获取地址列表的数据
#define MemberV2_GetSalesAddressListByUserId   @".7518.cn/app/MemberV2.api/GetSalesAddressListByUserId"

#define ADDRESS_DelteAddress               @".7518.cn/App/Member.api/DelteAddress"
//删除一条地址
#define MemberV2_DeleteAddress             @".7518.cn/app/MemberV2.api/DeleteAddress"

#define ADDRESS_EditAddressIsMain          @".7518.cn/App/Member.api/EditAddressIsMain"
//设置默认选中地址
#define MemberV2_SetMainAddress            @".7518.cn/app/MemberV2.api/SetMainAddress"
//获取一条地址数据
#define MemberV2_GetSalesAddressById       @".7518.cn/app/MemberV2.api/GetSalesAddressById"

#define Member_EditAddress                 @".7518.cn/App/Member.api/EditAddress"
//新增地址
#define MemberV2_InsertAddress             @".7518.cn/app/MemberV2.api/InsertAddress"
//修改收货地址
#define MemberV2_UpdateAddress             @".7518.cn/app/MemberV2.api/UpdateAddress"

#define SHARE_MakeQrImg                    @".7518.cn/Txooo/SalesV2/Ajax/WebGraphics.ajax/MakeQrImg"
#define POST_GetContentFromLink            @".7518.cn/App/Quan.api/GetContentFromLink"
#define POST_AddPost                       @".7518.cn/App/Quan.api/AddPost"
#define MODIFYNEWPHONE_SetBindMobile       @".7518.cn/App/Member.Api/SetBindMobile"
#define MODIFYNEWPHONE_SendNewMobileCode   @".7518.cn/App/Member.Api/SendNewMobileCode"
#define MODIFYAREACODE_SetUserAddress      @".7518.cn/App/Member.api/SetUserAddress"
#define MODIFYNEWBINDPHONE_CheckMobileCode @".7518.cn/App/Member.Api/CheckMobileCode"

//

//修改绑定手机号码 往原手机号发送验证码
#define MemberV3_SendOldMobileCode         @".7518.cn/App/MemberV3.api/SendOldMobileCode"
//验证原手机号码是否正确
#define MemberV3_CheckMobileCode           @".7518.cn/App/MemberV3.api/CheckMobileCode"
//往新手机号发送验证码
#define MemberV3_SendNewMobileCode         @".7518.cn/App/MemberV3.api/SendNewMobileCode"
//验证新手机号并绑定新手机号
#define MemberV3_SetBindMobile             @".7518.cn/App/MemberV3.api/SetBindMobile"


#define MemberV3_SendMobileCode            @".7518.cn/App/MemberV3.api/SendMobileCode"
#define MemberV3_SetSecurityPhoneByThird   @".7518.cn/App/MemberV3.api/SetSecurityPhoneByThird"


#define MODIFYNEWBINDPHONE_SendOldMobileCode @".7518.cn/App/Member.Api/SendOldMobileCode"
#define MODIFYNICKNAME_UpdateNikeName   @".7518.cn/App/Member.Api/UpdateNikeName"
#define MODIFYUSERWORD_SetUserWord      @".7518.cn/App/Member.api/SetUserWord"
#define HTML_member_bank                @".7518.cn/member/bank.html"
#define Member_SetUserHeadPic           @".7518.cn/App/Member.Api/SetUserHeadPic"
#define Member_SetUserSex               @".7518.cn/App/Member.api/SetUserSex"
#define MINE_GetRecommendProducts       @".7518.cn/App/Member.Api/GetRecommendProducts"

#define GetWebNavigation                @".7518.cn/app/shopv2.api/GetWebNavigation"
#define GetWebNavigationHistory         @".7518.cn/app/shopv2.api/GetWebNavigationBrowse"
#define SetNavColletNav                 @".7518.cn/app/shopv2.api/SetUserCollectNav"
#define EmptyNavCollectNav              @".7518.cn/app/shopv2.api/EmptyUserCollect"
#define EmptyUserBrowseNav              @".7518.cn/app/shopv2.api/EmptyUserBrowseNav"
#define SetWebNavigationBrowse          @".7518.cn/app/shopv2.api/SetWebNavigationBrowse"
#define MCHSETTLE_CheckMchApply         @".7518.cn/app/StoreV2.api/CheckMchApply"
#define MCHCHAT_GetProductInfoByIdV3    @".7518.cn/app/shop.api/GetProductInfoByIdV3"
#define MINE_ChangeLoginUser            @".7518.cn/App/Passport.Api/ChangeLoginUser"
#define UpdateImgFile                   @".7518.cn/App/Helper.api/UpdateImgFile"
#define DelUserBrowseNav                @".7518.cn/app/shopv2.api/DelUserBrowseNav"

#define  MemberV2_UpdateUserCard        @".7518.cn/app/MemberV2.api/UpdateUserCard"
#define  MemberV2_InitEditPageData      @".7518.cn/app/MemberV2.api/InitEditPageData"
#define  MemberV2_UpdateUserEducation   @".7518.cn/app/MemberV2.api/UpdateUserEducation"
#define  MemberV2_GetTagListByTypeId    @".7518.cn/app/MemberV2.api/GetTagListByTypeId"
#define  MemberV2_InsertTagClass        @".7518.cn/app/MemberV2.api/InsertTagClass"
#define  MemberV2_UpdateUserTag         @".7518.cn/app/MemberV2.api/UpdateUserTag"
#define  MemberV2_UpdateUserCompanyAddress @".7518.cn/app/MemberV2.api/UpdateUserCompanyAddress"
#define  MemberV2_GetProhibitWordList      @".7518.cn/app/MemberV2.api/GetProhibitWordList"

#define  MemberV2_DeleteUserTag            @".7518.cn/app/MemberV2.api/DeleteUserTag"

//修改个人信息
#define  MemberV2_UpdateUserBase            @".7518.cn/app/MemberV2.api/UpdateUserBase"

//获取3级联地址
#define  MemberV2_GetArea                   @".7518.cn/app/MemberV2.api/GetArea"


//html
#define MINE_MyteamRank            @".7518.cn/rank/myteamrank.html"
#define MINE_MemberInfo            @".7518.cn/member/info.html"
#define MINE_Money                 @".7518.cn/money/index.html"
#define MINE_Attend                @".7518.cn/Member/attend.html"
#define MINE_Task                  @".7518.cn/task/index.html"
#define MINE_News                  @".7518.cn/news/index.html"
#define MINE_Store                 @".7518.cn/store/index.html"
#define Mine_CashList              @".7518.cn/money/cashList.html"
#define Mine_ApplyList             @".7518.cn/store/list.html"
#define Mine_ShareInfo             @".7518.cn/Share/info.html"
#define PAY_SUCCESS                @".7518.cn/shop/paysccess.html"
#define PROFIEL_RealPointsOfBonus  @".7518.cn/money_2/bonus.html"
#define PROFILE_Cash               @".7518.cn/money/cash.html"
#define Helper_Index               @".7518.cn/Helper/index.html"
#define Helper_UserService         @".7518.cn/Helper/user_sevice.html"

#define Quan_Usernewspreview       @".7518.cn/quan/usernewspreview.html"

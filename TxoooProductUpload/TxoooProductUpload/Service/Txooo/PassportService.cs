/*----------------------------------------------------------------
 *  Copyright (C) 2017 天下商机（txooo.com）版权所有
 * 
 *  文 件 名：PassportService
 *  所属项目：
 *  创建用户：张玉龙(HouWeiya)
 *  创建时间：2018/1/20 15:29:21
 *  
 *  功能描述：
 *          1、
 *          2、 
 * 
 *  修改标识：  
 *  修改描述：
 *  待 完 善：
 *          1、 
----------------------------------------------------------------*/

using FSLib.Network.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Common;
using TxoooProductUpload.Network;
using TxoooProductUpload.Service.Entities;
using TxoooProductUpload.Service.Entities.Web;

namespace TxoooProductUpload.Service.Txooo
{
    /// <summary>
    /// txooo用户通行证相关
    /// </summary>
    public class PassportService
    {
        //网络操作
        NetClient NetClient = new NetClient();

        /// <summary>
        /// 根据手机号获取推广码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public async Task<long> GetShareCodeByTxId(long mobile)
        {
            var stCtx = NetClient.Create<WebResponseResult>(HttpMethod.Get, ApiList.GetShareCodeByTxId,
               data: new { mobile = mobile });

            await stCtx.SendAsync();
            if (!stCtx.IsValid())
            {
                throw new Exception("手机号获取推广码请求失败！");
            }
            if (!stCtx.Result.success)
            {
                throw new Exception(stCtx.Result.GetErrorMessage());

            }
            return Convert.ToInt64(stCtx.Result.msg);
        }

        /// <summary>
        /// 验证手机号是否可用
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public async Task<bool> CheckUserName(long mobile)
        {
            var stCtx = NetClient.Create<WebResponseResult>(HttpMethod.Get, ApiList.CheckUserName,
               data: new { regName = mobile });

            await stCtx.SendAsync();
            if (!stCtx.IsValid())
            {
                throw new Exception(ApiList.CheckUserName + "请求失败！");
            }
            return stCtx.Result.success;
        }

        /// <summary>
        /// 验证手机号是否可用
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public async Task<string> SendMobile(long mobile)
        {
            var stCtx = NetClient.Create<WebResponseResult>(HttpMethod.Get, ApiList.SendMobile,
               data: new { mobile = mobile });

            await stCtx.SendAsync();
            if (!stCtx.IsValid())
            {
                throw new Exception(ApiList.SendMobile + "请求失败！");
            }
            if (!stCtx.Result.success)
            {
                throw new Exception(stCtx.Result.GetErrorMessage());
            }
            return stCtx.Result.msg;
        }

        /// <summary>
        /// 验证手机号是否可用
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
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<long> Regist(object data)
        {
            var stCtx = NetClient.Create<RegistResult>(HttpMethod.Get, ApiList.Regist,
               data: data);

            await stCtx.SendAsync();
            if (!stCtx.IsValid())
            {
                throw new Exception(ApiList.Regist + "请求失败！");
            }
            if (!stCtx.Result.success)
            {
                throw new Exception(stCtx.Result.msg);
            }
            return stCtx.Result.user_id;
        }
    }
}

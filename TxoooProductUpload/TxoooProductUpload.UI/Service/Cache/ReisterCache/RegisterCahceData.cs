/*----------------------------------------------------------------
 *  Copyright (C) 2017 天下商机（txooo.com）版权所有
 * 
 *  文 件 名：RegisterCahceData
 *  所属项目：
 *  创建用户：张玉龙(HouWeiya)
 *  创建时间：2018/1/22 8:47:17
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.UI.Service.Entities;

namespace TxoooProductUpload.UI.Service.Cache.ReisterCache
{
    /// <summary>
    /// 批量注册缓存
    /// </summary>
    public class RegisterCahceData
    {
        /// <summary>
        /// 等待检测集合
        /// </summary>
        public Queue<RegisterInfo> WaitCheckQueue { get; set; }
        /// <summary>
        /// 可以注册的集合
        /// </summary>
        public Queue<RegisterInfo> CanUseQueue { get; set; }
        /// <summary>
        /// 等待注册的集合
        /// </summary>
        public Queue<RegisterInfo> WaitRegisterQueue { set; get; }
        /// <summary>
        /// 注册成功的集合
        /// </summary>
        public List<RegisterInfo> SuccessList { set; get; }

        public RegisterCahceData()
        {
            WaitCheckQueue = new Queue<RegisterInfo>();
            CanUseQueue = new Queue<RegisterInfo>();
            WaitRegisterQueue = new Queue<RegisterInfo>();
            SuccessList = new List<RegisterInfo>();
        }
    }
}

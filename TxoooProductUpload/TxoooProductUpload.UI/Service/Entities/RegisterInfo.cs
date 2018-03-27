/*----------------------------------------------------------------
 *  Copyright (C) 2017 天下商机（txooo.com）版权所有
 * 
 *  文 件 名：RegisterInfo
 *  所属项目：
 *  创建用户：张玉龙(HouWeiya)
 *  创建时间：2018/1/22 8:50:22
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

namespace TxoooProductUpload.UI.Service.Entities
{
    /// <summary>
    /// 用户注册缓存
    /// </summary>
    public class RegisterInfo
    {
        /// <summary>
        /// 注册手机号
        /// </summary>
        public long Mobile { set; get; }
        /// <summary>
        /// 初始密码
        /// </summary>
        public string PassWord { set; get; }
        /// <summary>
        /// 用户id
        /// </summary>
        public long UserId { set; get; }

        /// <summary>
        /// 级别
        /// </summary>
        public int Level { set; get; }
        /// <summary>
        /// 直属上级
        /// </summary>
        public long ParentUserId { set; get; }

        /// <summary>
        /// 请求的数据
        /// </summary>
        public object SendData { set; get; }
    }
}

/*----------------------------------------------------------------
 *  Copyright (C) 2017 天下商机（txooo.com）版权所有
 * 
 *  文 件 名：RegistResult
 *  所属项目：
 *  创建用户：张玉龙(HouWeiya)
 *  创建时间：2018/1/20 15:45:05
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
using TxoooProductUpload.Service.Entities.Web;

namespace TxoooProductUpload.Service.Entities
{
    /// <summary>
    /// 用户注册ResponseResult
    /// </summary>
    class RegistResult : WebResponseResult
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public long user_id { get; private set; }
    }
}

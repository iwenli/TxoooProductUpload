/*----------------------------------------------------------------
 *  Copyright (C) 2017 天下商机（txooo.com）版权所有
 * 
 *  文 件 名：MchCache
 *  所属项目：
 *  创建用户：张玉龙(HouWeiya)
 *  创建时间：2017/11/8 9:48:03
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

namespace TxoooProductUpload.Common
{
    /// <summary>
    /// 商户相关缓存
    /// </summary>
    public static class MchCache
    {
        static List<MchType> _mchTypeList = new List<MchType>();

        /// <summary>
        /// 商家类型
        /// </summary>
        public static List<MchType> MchTypeList
        {
            get
            {
                if (_mchTypeList.Count == 0)
                {
                    _mchTypeList.Clear();
                    _mchTypeList.Add(new MchType() { Id = 3, Name = "招商类" });
                    _mchTypeList.Add(new MchType() { Id = 4, Name = "门店类" });
                    _mchTypeList.Add(new MchType() { Id = 5, Name = "产品类" });
                    _mchTypeList.Add(new MchType() { Id = 7, Name = "微商类" });
                    //_mchTypeList.Add(new MchType() { Id = 9, Name = "高额返利类" });
                }
                return _mchTypeList;
            }
        }

        /// <summary>
        /// 商家类型
        /// </summary>
        public class MchType
        {
            /// <summary>
            /// 商家类型id
            /// </summary>
            public int Id { set; get; }
            /// <summary>
            /// 商家类型名称
            /// </summary>
            public string Name { set; get; }
        }
    }
}

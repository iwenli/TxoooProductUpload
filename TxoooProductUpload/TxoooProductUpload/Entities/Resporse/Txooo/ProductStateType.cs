using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Entities.Resporse.Txooo
{
    /// <summary>
    /// Txooo商品状态
    /// </summary>
    public enum ProductStateType
    {
        /// <summary>
        /// 资料不全
        /// </summary>
        InformationIncomplete = -1,
        /// <summary>
        /// 未提交审核
        /// </summary>
        NotSubmit,
        /// <summary>
        /// 等待审核
        /// </summary>
        WaitCheck,
        /// <summary>
        /// 审核中
        /// </summary>
        Checking,
        /// <summary>
        /// 审核通过
        /// </summary>
        CheckIn,
        /// <summary>
        /// 审核不通过
        /// </summary>
        CheckOut,
        /// <summary>
        /// 售卖中
        /// </summary>
        InSale,
        /// <summary>
        /// 等待上架
        /// </summary>
        WaitShelves
    }
}

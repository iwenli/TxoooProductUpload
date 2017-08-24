using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Service.Entities;

namespace TxoooProductUpload.UI.Service.Entities
{
    /// <summary>
    /// 登陆用户记录
    /// </summary>
    [Serializable]
    class LoginListInfo
    {
        List<LoginInfo> _list = new List<LoginInfo>();

        /// <summary>
        /// 初始化一个 LoginListInfo 实例
        /// </summary>
        public LoginListInfo()
        {

        }

        /// <summary>
        /// 最后登陆的用户信息
        /// </summary>
        public LoginInfo LastLoginInfo
        {
            get
            {
                return _list.FirstOrDefault();
            }
        }

        /// <summary>
        /// 所有登陆过的用户信息
        /// </summary>
        public List<LoginInfo> List
        {
            get
            {
                return _list;
            }
        }

        /// <summary>
        /// 查看指定账户是否存在，若存在返回索引  否则返回-1
        /// </summary>
        /// <param name="userName">账户</param>
        /// <returns>存在则返回索引位置  否则返回-1</returns>
        public int IsExists(string userName)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                if (this._list[i].UserName.Equals(userName))
                {
                    return i;
                }
            }
            return -1;

        }
    }
}

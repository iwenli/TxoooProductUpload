using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.UI.Common
{
    /// <summary>
    /// 工具方法
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// 打开网址
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static  bool OpenUrl(string url)
        {
            //new PhoneBorwser(url).ShowDialog();
            try
            {
                Process.Start(url);
                return true;
            }
            catch (Exception ex)
            {
                Iwenli.LogHelper.GetLogger("Utils").Error(ex.Message, ex);
                return false;
            }
        }
    }
}

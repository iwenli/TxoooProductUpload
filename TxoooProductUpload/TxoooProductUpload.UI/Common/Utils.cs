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
    public class Utils
    {
        static Random _random = new Random();

        /// <summary>
        /// 打开网址
        /// </summary>
        /// <param name="url">网址</param>
        /// <param name="isH5">时候手机端页面</param>
        /// <returns></returns>
        public static bool OpenUrl(string url, bool isH5 = false)
        {
            try
            {
                if (isH5)
                {
                    new PhoneBorwser(url).ShowDialog();
                }
                else
                {
                    Process.Start(url);
                }

                return true;
            }
            catch (Exception ex)
            {
                Iwenli.LogHelper.GetLogger("Utils").Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 获取随机数据
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int RandomInt(int minValue = 1000, int maxValue = 5000)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}

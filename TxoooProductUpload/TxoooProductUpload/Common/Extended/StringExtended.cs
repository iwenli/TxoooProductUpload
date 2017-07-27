using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TxoooProductUpload.Common
{
    public static class StringExtended
    {
        /// <summary>
        /// 将Unicode字符串转为对于的string
        /// </summary>
        /// <param name="unicodeStr"></param>
        /// <returns></returns>
        public static string UnicodeToString(this string str)
        {
            string StrGb = "";
            int i = 0;
            MatchCollection mc = Regex.Matches(str, @"\\u([\w]{2})([\w]{2})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            byte[] bts = new byte[2];
            if (mc.Count != 0)
            {
                foreach (Match m in mc)
                {
                    bts[0] = (byte)int.Parse(m.Groups[2].Value, System.Globalization.NumberStyles.HexNumber);
                    bts[1] = (byte)int.Parse(m.Groups[1].Value, System.Globalization.NumberStyles.HexNumber);
                    string r = Encoding.Unicode.GetString(bts);//Unicode转为汉字  
                    i++;
                    if (i == 1)
                    {
                        StrGb = str.Replace(m.Groups[0].Value, r);
                    }
                    else
                    {
                        StrGb = StrGb.Replace(m.Groups[0].Value, r);
                    }
                }
                return StrGb;
            }
            else
            {
                return str;
            }
        }

        /// <summary>
        /// 是否为网址
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsUrl(this string obj)
        {
            // "^http[s]?:\\/\\/([\\w-]+\\.)+[\\w-]+([\\w-./?%&=]*)?$"
            return Check(obj, @"^(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)|(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&%_\./-~-]*)?$");
        }
        /// <summary>
        /// 检查数据是否匹配
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="reg"></param>
        /// <returns></returns>
        static bool Check(string obj, string reg)
        {
            return Regex.IsMatch(obj,
                reg, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TxoooProductUpload.Common
{
    public static class StringExpression
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
    }
}

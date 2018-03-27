using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Common;

namespace TxoooProductUpload.UI.Common
{
    /// <summary>
    /// 软件设置相关
    /// </summary>
    public class AppSetting
    {

        static int _maxThreadCount = 0;
        /// <summary>
        ///  任务最大线程数
        /// </summary>
        public static int MaxThreadCount
        {
            set
            {
                _maxThreadCount = value;
                AppConfig.ModifyItem("MaxThreadCount", _maxThreadCount.ToString());
            }
            get
            {
                if (_maxThreadCount == 0)
                {
                    _maxThreadCount = Convert.ToInt32(AppConfig.GetItem("MaxThreadCount") ?? "5");
                }
                return _maxThreadCount;
            }
        }

        static int _randomMaxValue = 0;
        /// <summary>
        /// 任务间隔随机数上限（毫秒）
        /// </summary>
        public static int RandomMaxValue
        {
            set
            {
                _randomMaxValue = value;
                AppConfig.ModifyItem("RandomMaxValue", _randomMaxValue.ToString());
            }
            get
            {
                if (_randomMaxValue == 0)
                {
                    _randomMaxValue = Convert.ToInt32(AppConfig.GetItem("RandomMaxValue") ?? "5000");
                }
                return _randomMaxValue;
            }
        }

        static int _randomMinValue = 0;
        /// <summary>
        /// 任务间隔随机数下限（毫秒）
        /// </summary>
        public static int RandomMinValue
        {
            set
            {
                _randomMinValue = value;
                AppConfig.ModifyItem("RandomMinValue", _randomMinValue.ToString());
            }
            get
            {
                if (_randomMinValue == 0)
                {
                    _randomMinValue = Convert.ToInt32(AppConfig.GetItem("RandomMinValue") ?? "1000");
                }
                return _randomMinValue;
            }
        }

        static Dictionary<string, string> _hosts = null;
        /// <summary>
        /// 支持的域名配置
        /// </summary>
        public static Dictionary<string, string> Hosts
        {
            get
            {
                if (_hosts == null)
                {
                    _hosts = new Dictionary<string, string>();
                    var _hostStr = AppConfig.GetItem("Hosts") ?? null;
                    if (_hostStr != null)
                    {
                        var _hostArr = _hostStr.Split(',');
                        foreach (var host in _hostArr)
                        {
                            var _arr = host.Split('|');
                            if (_arr.Length == 2)
                            {
                                _hosts.Add(_arr[0], _arr[1]);
                            }
                        }
                    }
                }
                return _hosts;
            }
        }
    }
}

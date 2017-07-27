using System;
using System.Configuration;

namespace TxoooProductUpload.Common
{
    /// <summary>
    /// app.config 操作类
    /// </summary>
    static class AppConfig
    {
        /// <summary>
        /// 是否记住密码
        /// </summary>
        public static bool IsRemember
        {
            set
            {
                AppConfig.ModifyItem("remember", value.ToString()); ;
            }
            get { return Convert.ToBoolean(AppConfig.GetItem("remember")); }
        }

        #region 方法
        /// <summary>
        /// 添加配置文件的项，键为keyName，值为keyValue  
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="keyValue"></param>
        public static void AddItem(string keyName, string keyValue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add(keyName, keyValue);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        /// <summary>
        /// 判断配置文件中是否存在键为keyName的项  
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static bool ExistItem(string keyName)
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == keyName)
                {
                    //存在  
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 返回配置文件中键为keyName的项的值  
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string GetItem(string keyName)
        {
            return ConfigurationManager.AppSettings[keyName];
        }
        /// <summary>
        /// 修改配置文件中键为keyName的项的值  
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="newKeyValue"></param>
        public static void ModifyItem(string keyName, string newKeyValue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[keyName].Value = newKeyValue;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 删除配置文件键为keyName的项  
        /// </summary>
        /// <param name="keyName"></param>
        public static void RemoveItem(string keyName)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(keyName);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        #endregion

    }
}

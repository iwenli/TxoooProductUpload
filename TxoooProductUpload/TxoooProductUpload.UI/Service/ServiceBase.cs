using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.UI.Handler;

namespace TxoooProductUpload.UI.Service
{
    /// <summary>
    /// UI通用的服务基类
    /// </summary>
    abstract class ServiceBase : SendMessageHandler
    {
        /// <summary>
        /// 服务层上下文
        /// </summary>
        public TxoooProductUpload.Service.ServiceContext BaseContent { private set; get; }

        #region 构造函数
        public ServiceBase(TxoooProductUpload.Service.ServiceContext baseContent)
        {
            BaseContent = baseContent;
        } 
        #endregion

        /// <summary>
        /// 获取相对于data目录下的子目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetCachePath(string subDirectoryName = "")
        {
            var path = Path.Combine(Environment.CurrentDirectory, "data");
            if (!string.IsNullOrEmpty(path))
            {
                path = Path.Combine(path, subDirectoryName);
            }
            return path;
        }

        /// <summary>
        /// 消息模板
        /// </summary>
        public string MsgTemplate { set; get; }


        #region 消息委托
        /// <summary>
        /// 错误消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        public virtual Task ErrorMessage(string msg, params object[] args)
        {
            return Task.Run(() =>
            {
                if (args == null || args.Length == 0)
                {
                    SendMessage(new SendMessageEventArgs(msg, MessageType.ERROR));
                }
                else
                {
                    SendMessage(new SendMessageEventArgs(string.Format(msg, args), MessageType.ERROR));
                }
            });
        }
        /// <summary>
        /// 正常消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        public virtual Task InfoMessage(string msg, params object[] args)
        {
            return Task.Run(() =>
            {
                if (args == null || args.Length == 0)
                {
                    SendMessage(new SendMessageEventArgs(msg, MessageType.INFO));
                }
                else
                {
                    SendMessage(new SendMessageEventArgs(string.Format(msg, args), MessageType.INFO));
                }
            });
        }
        /// <summary>
        /// 警告消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        public virtual Task WarnMessage(string msg, params object[] args)
        {
            return Task.Run(() =>
            {

                if (args == null || args.Length == 0)
                {
                    SendMessage(new SendMessageEventArgs(msg, MessageType.WARN));
                }
                else
                {
                    SendMessage(new SendMessageEventArgs(string.Format(msg, args), MessageType.WARN));
                }
            });
        }
        /// <summary>
        /// 致命消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        public virtual Task FatalMessage(string msg, params object[] args)
        {
            return Task.Run(() =>
            {

                if (args == null || args.Length == 0)
                {
                    SendMessage(new SendMessageEventArgs(msg, MessageType.FATAL));
                }
                else
                {
                    SendMessage(new SendMessageEventArgs(string.Format(msg, args), MessageType.FATAL));
                }
            });
        }
        #endregion
    }
}

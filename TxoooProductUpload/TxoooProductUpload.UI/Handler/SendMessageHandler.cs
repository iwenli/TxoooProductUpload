using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.UI.Handler
{
    /// <summary>
    /// 消息处理委托
    /// </summary>
    public class SendMessageHandler
    {
        /// <summary>
        /// 有新消息前发生
        /// </summary>
        public event EventHandler<SendMessageEventArgs> OnSendMessage;

        /// <summary>
        /// 引发 <see cref="OnSendMessage" /> 事件
        /// </summary>
        protected virtual void SendMessage(SendMessageEventArgs args)
        {
            OnSendMessage?.Invoke(args.Message, args);
        }
    }

    /// <summary>
    /// 包含消息事件数据
    /// </summary>
    public class SendMessageEventArgs : EventArgs
    {
        public MessageType Type { set; get; }
        public string Message { set; get; }

        /// <summary>
        /// 初始化一个 SendMessageEventArgs 实例
        /// </summary>
        public SendMessageEventArgs() { }
        /// <summary>
        ///  初始化一个 SendMessageEventArgs 实例
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="type">消息类型</param>
        public SendMessageEventArgs(string msg, MessageType type)
        {
            Message = msg;
            Type = type;
        }
    }

    /// <summary>
    /// 消息类型
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// 正常
        /// </summary>
        INFO,
        /// <summary>
        /// 警告
        /// </summary>
        WARN,
        /// <summary>
        /// 错误
        /// </summary>
        ERROR,
        /// <summary>
        /// 致命
        /// </summary>
        FATAL
    }

}

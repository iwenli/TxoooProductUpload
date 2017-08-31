using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Entities.Product
{
    /// <summary>
    /// 商品来源相关信息
    /// </summary>
    public class ProductSource
    {
        /// <summary>
        /// 商品来源名称
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetSourceName(SourceType type)
        {
            switch (type)
            {
                case SourceType.Tamll:
                    return "天猫商城";
                case SourceType.Taobao:
                    return "淘宝";
                case SourceType.Alibaba:
                    return "阿里巴巴";
                case SourceType.Jingdong:
                    return "京东商城";

            }
            return "创业赚钱";
        }

        /// <summary>
        /// 商品来源Url规则
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetFormatUrl(SourceType type)
        {
            switch (type)
            {
                case SourceType.Tamll:
                    return "https://detail.tmall.com/item.htm?id={0}";
                case SourceType.Taobao:
                    return "https://item.taobao.com/item.htm?id={0}";
                case SourceType.Alibaba:
                    return "https://detail.1688.com/offer/{0}.html";
                case SourceType.Jingdong:
                    return "https://item.jd.com/{0}.html";

            }
            return "http://0.u.7518.cn/shop.html?id={0}";
        }

        /// <summary>
        /// 商品来源H5Url规则
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetFormatH5Url(SourceType type)
        {
            switch (type)
            {
                case SourceType.Tamll:
                    return "https://detail.m.tmall.com/item.htm?id={0}";
                case SourceType.Taobao:
                    return "http://h5.m.taobao.com/awp/core/detail.htm?id={0}";
                case SourceType.Alibaba:
                    return "https://m.1688.com/offer/{0}.html";
                case SourceType.Jingdong:
                    return "https://item.m.jd.com/product/{0}.html";

            }
            return "http://0.u.7518.cn/shop.html?id={0}";
        }
    }

    /// <summary>
    /// 商品来源类型
    /// </summary>
    public enum SourceType
    {
        /// <summary>
        /// 创业赚钱
        /// </summary>
        Txooo,
        /// <summary>
        /// 天猫商城
        /// </summary>
        Tamll,
        /// <summary>
        /// 淘宝
        /// </summary>
        Taobao,
        /// <summary>
        /// 阿里巴巴
        /// </summary>
        Alibaba,
        /// <summary>
        /// 京东商城
        /// </summary>
        Jingdong
    }
}

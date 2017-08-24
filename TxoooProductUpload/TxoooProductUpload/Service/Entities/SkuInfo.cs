using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Service.Entities
{
    #region JD
    /// <summary>
    /// 1688SKU解析
    /// </summary>
    public class SkuJdInfo
    {
        /// <summary>
        /// SKU列表
        /// </summary>
        public List<ColorSize> colorSize { set; get; }
        /// <summary>
        /// 类别,颜色|尺码
        /// </summary>
        public ColorSizeTitle colorSizeTitle { set; get; }
    }
    /// <summary>
    /// SKU详情
    /// </summary>
    public class ColorSize
    {
        public string color { set; get; }
        public string image { set; get; }
        public string size { set; get; }
        public string skuId { set; get; }
    }
    /// <summary>
    /// SKU标题
    /// </summary>
    public class ColorSizeTitle
    {
        public string colorName { set; get; }
        public string sizeName { set; get; }
    }
    #endregion

    #region 1688
    /// <summary>
    /// 1688SKU解析
    /// </summary>
    public class Sku1688Info
    {
        /// <summary>
        /// 单位
        /// </summary>
        public string unit { set; get; }
        /// <summary>
        /// 类别,颜色|尺码
        /// </summary>
        public Sku1688Item[] value { set; get; }
        /// <summary>
        /// 类别,颜色|尺码
        /// </summary>
        public string prop { set; get; }
    }

    public class Sku1688Item
    {
        /// <summary>
        /// 属性图像URL
        /// </summary>
        public string image { set; get; }
        /// <summary>
        /// 属性值
        /// </summary>
        public string name { set; get; }
    }
    #endregion

    #region TMALL
    /// <summary>
    /// TmallSKU解析
    /// </summary>
    public class SkuTmallInfo
    {
        /// <summary>
        /// sku map id
        /// </summary>
        public string id { set; get; }
        /// <summary>
        /// 该类别下SKU列表
        /// </summary>
        public SkuTmallItem[] values { set; get; }
        /// <summary>
        /// 类别,颜色|尺码
        /// </summary>
        public string text { set; get; }
    }
    /// <summary>
    /// SKU详情
    /// </summary>
    public class SkuTmallItem
    {
        public string id { set; get; }
        public string text { set; get; }
        public string image { set; get; }
    }
    #endregion
}

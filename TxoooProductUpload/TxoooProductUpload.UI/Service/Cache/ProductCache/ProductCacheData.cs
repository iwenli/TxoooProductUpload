using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Entities.Product;

namespace TxoooProductUpload.UI.Service.Cache.ProductCache
{
    /// <summary>
    /// 商品抓取缓存数据
    /// </summary>
    public class ProductCacheData
    {
        /// <summary>
        /// 等待处理的商品集合
        /// </summary>
        public List<ProductSourceInfo> WaitProcessList { get; set; }
        /// <summary>
        /// 处理失败的集合
        /// </summary>
        public List<ProductSourceInfo> ProcessFailList { get; set; }

        /// <summary>
        /// 等待上传图片的商品集合
        /// </summary>
        public List<ProductSourceInfo> WaitUploadImageList { set; get; }

        /// <summary>
        /// 上传图片失败的商品集合
        /// </summary>
        public List<ProductSourceInfo> UploadImageFailList { set; get; }

        /// <summary>
        /// 等待上传的商品集合
        /// </summary>
        public List<ProductSourceInfo> WaitUploadList { set; get; }

        /// <summary>
        /// 上传失败的商品集合
        /// </summary>
        public List<ProductSourceInfo> UploadFailList { set; get; }

        /// <summary>
        /// 上传成功的商品集合
        /// </summary>
        public List<ProductSourceInfo> UploadSuccessList { set; get; }

        public ProductCacheData()
        {
            WaitProcessList = new List<ProductSourceInfo>();
            ProcessFailList = new List<ProductSourceInfo>();
            WaitUploadImageList = new List<ProductSourceInfo>();
            UploadImageFailList = new List<ProductSourceInfo>();
            WaitUploadList = new List<ProductSourceInfo>();
            UploadFailList = new List<ProductSourceInfo>();
            UploadSuccessList = new List<ProductSourceInfo>();
        }
    }
}

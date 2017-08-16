using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TxoooProductUpload.Common.Extended
{
    /// <summary>
    /// 图像扩展
    /// </summary>
    static class ImageExtended
    {
        #region 缩略图
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static Image Thumbnail(this Image originalImage, int width = 100, int height = 100, string mode = "Cut")
        {
            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW":  //指定高宽缩放（可能变形）                
                    break;
                case "W":   //指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H":   //指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut": //指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight), new System.Drawing.Rectangle(x, y, ow, oh), System.Drawing.GraphicsUnit.Pixel);

            return bitmap;
            //try
            //{
            //    //以jpg格式保存缩略图
            //    bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            //}
            //catch (System.Exception e)
            //{
            //    throw e;
            //}
            //finally
            //{
            //    originalImage.Dispose();
            //    bitmap.Dispose();
            //    g.Dispose();
            //}
        }
        #endregion

        #region 图片后缀扩展

        #region 通过Image对象获取
        private static Dictionary<String, ImageFormat> _imageFormats;
        /// <summary>
        /// 获取 所有支持的图片格式字典
        /// </summary>
        public static Dictionary<String, ImageFormat> ImageFormats
        {
            get
            {
                return _imageFormats ?? (_imageFormats = GetImageFormats());
            }
        }

        /// <summary>
        /// 获取所有图片格式
        /// </summary>
        /// <returns></returns>
        private static Dictionary<String, ImageFormat> GetImageFormats()
        {
            var dic = new Dictionary<String, ImageFormat>();
            var properties = typeof(ImageFormat).GetProperties(BindingFlags.Static | BindingFlags.Public);
            foreach (var property in properties)
            {
                var format = property.GetValue(null, null) as ImageFormat;
                if (format == null) continue;
                dic.Add(("." + property.Name).ToUpper(), format);
            }
            return dic;
        }
        /// <summary>
        /// 根据图像获取图像的扩展名
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static String GetExtension(this Image image)
        {
            foreach (var pair in ImageFormats)
            {
                if (pair.Value.Guid == image.RawFormat.Guid)
                {
                    return pair.Key;
                }
            }
            throw new BadImageFormatException();
        }
        #endregion

        #region 通过文件头bytes获取

        private static SortedDictionary<int, ImageType> _bytesImageFormats;

        private static readonly string ErrType = ImageType.None.ToString();
        private static SortedDictionary<int, ImageType> InitImageTag()
        {
            SortedDictionary<int, ImageType> list = new SortedDictionary<int, ImageType>();

            list.Add((int)ImageType.BMP, ImageType.BMP);
            list.Add((int)ImageType.JPG, ImageType.JPG);
            list.Add((int)ImageType.GIF, ImageType.GIF);
            list.Add((int)ImageType.PCX, ImageType.PCX);
            list.Add((int)ImageType.PNG, ImageType.PNG);
            list.Add((int)ImageType.PSD, ImageType.PSD);
            list.Add((int)ImageType.RAS, ImageType.RAS);
            list.Add((int)ImageType.SGI, ImageType.SGI);
            list.Add((int)ImageType.TIFF, ImageType.TIFF);
            return list;

        }
        /// <summary>
        /// 获取 所有支持的图片格式字典-文件头获取后缀的定义
        /// </summary>
        public static SortedDictionary<int, ImageType> BytesImageFormats
        {
            get
            {
                return _bytesImageFormats ?? (_bytesImageFormats = InitImageTag());
            }

        }
        /// <summary>  
        /// 通过文件头获取图像文件的类型  
        /// </summary>  
        /// <param name="path"></param>  
        /// <returns></returns>  
        public static string GetExtension(this string path)
        {
            return CheckImageType(path);
        }
        /// <summary>  
        /// 通过文件头判断图像文件的类型  
        /// </summary>  
        /// <param name="path"></param>  
        /// <returns></returns>  
        private static string CheckImageType(string path)
        {
            byte[] buf = new byte[2];
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    int i = sr.BaseStream.Read(buf, 0, buf.Length);
                    if (i != buf.Length)
                    {
                        return ImageType.None.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                //Debug.Print(ex.ToString());
                return ImageType.None.ToString();
            }
            return GetExtension(buf);
        }

        /// <summary>  
        /// 通过文件的前两个字节判断图像类型  
        /// </summary>  
        /// <param name="buf">至少2个字节</param>  
        /// <returns></returns>  
        public static string GetExtension(this byte[] buf)
        {
            if (buf == null || buf.Length < 2)
            {
                return ImageType.None.ToString();
            }

            int key = (buf[1] << 8) + buf[0];
            ImageType s;
            if (BytesImageFormats.TryGetValue(key, out s))
            {
                return "." + s.ToString();
            }
            return ImageType.None.ToString();
        }
        #endregion
        #endregion
    }

    /// <summary>  
    /// 图像文件的类型  
    /// </summary>  
    public enum ImageType
    {
        None = 0,
        BMP = 0x4D42,
        JPG = 0xD8FF,
        GIF = 0x4947,
        PCX = 0x050A,
        PNG = 0x5089,
        PSD = 0x4238,
        RAS = 0xA659,
        SGI = 0xDA01,
        TIFF = 0x4949
    }
}

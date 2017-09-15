using Iwenli;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TxoooProductUpload.Entities.Product;
using TxoooProductUpload.Entities.Request;

namespace TxoooProductUpload.UI.Service
{
    class ProductService : ServiceBase
    {
        /// <summary>
        /// 上传商品SKU格式化字符串
        /// </summary>
        string skuFormat = @"&map_id_{0}=0&json_info_{0}={1}&price_{0}={2}&market_price_{0}={2}&remain_inventory_{0}={6}&property_map_img_{0}={3}&radio_num_{0}={4}&is_default_{0}={5}";
        /// <summary>
        /// 详情格式化字符串
        /// </summary>
        string detialFormat = @"<p>{0}</p><img src='{1}' />";

        public ProductService(TxoooProductUpload.Service.ServiceContext baseContent) : base(baseContent)
        {
            MsgTemplate = "[商品消息]{0}";
        }
        /// <summary>
        /// 识别发货地
        /// </summary>
        /// <returns></returns>
        public void DiscernLcation(ProductSourceInfo product)
        {
            var p = product;
            if (!product.Location.IsNullOrEmpty())
            {
                var area = BaseContent.CacheContext.Data.AreaList.Where(
                m => m.region_name.Contains(p.Location.Substring(p.Location.Length - 2))).FirstOrDefault();
                if (area != null)
                {
                    product.RegionName = area.region_name;
                    product.RegionCode = area.region_code;
                }
            }
        }

        ///// <summary>
        ///// 上传商品图片到Txooo服务器 并返回商品集合 并行
        ///// </summary>
        ///// <param name="productList"></param>
        ///// <returns></returns>
        //public async Task<List<ProductSourceInfo>> UploadProductImageSync(List<ProductSourceInfo> productList)
        //{
        //    List<ProductSourceInfo> list = new List<ProductSourceInfo>();
        //    await Task.Delay(10);
        //    Parallel.For(0, productList.Count, async (index) =>
        //    {
        //        var product = productList[index];
        //        try
        //        {
        //            foreach (var url in product.ThumImgList)
        //            {
        //                product.TxoooThumImgList.Add(await BaseContent.ImageService.UploadImgAsync(url, 1));
        //            }
        //            foreach (var url in product.DetailImgList)
        //            {
        //                product.TxoooDetailImgList.Add(await BaseContent.ImageService.UploadImgAsync(url, 2));
        //            }
        //            foreach (var sku in product.SkuList)
        //            {
        //                //如果没有抓到详情图片  则用主图图片
        //                if (sku.Image.IsNullOrEmpty())
        //                {
        //                    sku.TxoooImage = product.TxoooThumImgList[0];
        //                }
        //                else
        //                {
        //                    sku.TxoooImage = await BaseContent.ImageService.UploadImgAsync(sku.Image, 3);
        //                }
        //            }
        //            list.Add(product);
        //        }
        //        catch (Exception ex)
        //        {
        //            Iwenli.LogHelper.LogError(this, "上传{0}商品{1}图片执行异常：{2}".FormatWith(product.SourceName, product.Id, ex.Message));
        //        }
        //    });
        //    return list;
        //}


        #region 上传商品
        /// <summary>
        /// 上传商品
        /// </summary>
        /// <param name="productList"></param>
        /// <returns></returns>
        public async Task UploadProduct(ProductSourceInfo product)
        {
            #region 验证
            if (product.TxoooThumImgList.Count == 0)
            {
                string formatMsg = "{0}商品 {1} 主图为空，跳过上传.";
                new Exception(formatMsg.FormatWith(product.SourceName, product.Id));
                //await ErrorMessage(formatMsg, product.SourceName, product.Id);
            }
            if (product.SkuList.Count == 0)
            {
                string formatMsg = "{0}商品 {1} SKU为空，跳过上传.";
                new Exception(formatMsg.FormatWith(product.SourceName, product.Id));
                //await ErrorMessage(formatMsg, product.SourceName, product.Id);
            }
            if (!product.IsVirtual && !product.IsFreePostage && product.Postage == 0)
            {
                string formatMsg = "{0}商品 {1} 不是虚拟商品 并且不包邮 但是邮费为0，跳过上传.";
                new Exception(formatMsg.FormatWith(product.SourceName, product.Id));
                //await ErrorMessage(formatMsg, product.SourceName, product.Id);
            }
            #endregion

            ProductRequest productRequest = new ProductRequest();
            #region 转换对象为上传参数对象
            #region 主图
            if (product.TxoooThumImgList.Count > 5)
            {
                productRequest.ThumImages = product.TxoooThumImgList.Take(5).Join(",");
            }
            else
            {
                productRequest.ThumImages = product.TxoooThumImgList.Join(",");
            }
            #endregion

            #region SKu
            StringBuilder skuJson = new StringBuilder();
            for (int i = 0; i < product.SkuList.Count; i++)
            {
                productRequest.SkuJsons.AppendFormat(skuFormat, i, product.SkuList[i].Name,
                    product.SkuList[i].Price * (1 + product.PremiumRatio), product.SkuList[i].TxoooImage, product.SettlementRatio * 100,
                    (i == 1).ToString().ToLower(), product.SkuList[i].Quantity);
            }
            #endregion

            #region 描述
            for (int i = 0; i < product.TxoooDetailImgList.Count; i++)
            {
                productRequest.Details.AppendFormat(detialFormat, string.Empty, product.TxoooDetailImgList[i]);
            }
            #endregion

            #region 基本参数
            productRequest.ClassId = product.ClassId;
            productRequest.ProductName = product.ProductName;
            productRequest.RegionCode = product.RegionCode;
            productRequest.RegionName = product.RegionName;
            productRequest.NewOld = product.IsNew ? 1 : 2;
            productRequest.IsVirtual = product.IsVirtual;

            productRequest.IsFreePostage = product.IsFreePostage;
            productRequest.Refund = product.IsRefund;
            productRequest.Postage = product.Postage;
            productRequest.Append = product.Append;
            productRequest.Limit = product.Limit;
            productRequest.TypeService = product.ClassType;
            productRequest.Brand = product.Brand.Trim();
            productRequest.Shares = product.SubTitle;
            #endregion 
            #endregion
            await Task.Delay(1000);
            var result = await BaseContent.ProductService.UploadProduct(productRequest);
            if (result.success)
            {
                product.Id = Convert.ToInt32(result.msg);
            }
            else
            {
                string formatMsg = "{0}商品 {1} 上传失败,服务器结果：{2}";
                new Exception(formatMsg.FormatWith(product.SourceName, product.Id, result.msg));
            }
        }

        #endregion


        #region  上传商品图片到Txooo服务器 并返回商品
        /// <summary>
        /// 上传商品图片到Txooo服务器 并返回商品
        /// </summary>
        /// <param name="productList"></param>
        /// <returns></returns>
        public async Task UploadProductImage(ProductSourceInfo product)
        {
            foreach (var url in product.ThumImgList)
            {
                try
                {
                    await Task.Delay(100);
                    product.TxoooThumImgList.Add(BaseContent.ImageService.UploadImg(url));
                }
                catch (Exception ex)
                {
                    new Exception("上传{0}商品{1} 主图 {2} 执行异常：{3}".FormatWith(product.SourceName, product.Id, url, ex.Message), ex);
                }
            }
            foreach (var url in product.DetailImgList)
            {
                try
                {
                    await Task.Delay(100);
                    product.TxoooDetailImgList.Add(BaseContent.ImageService.UploadImg(url));
                }
                catch (Exception ex)
                {
                    new Exception("上传{0}商品{1} 详情图 {2} 执行异常：{3}".FormatWith(product.SourceName, product.Id, url, ex.Message), ex);
                }

            }
            //这里使用缓存变量  缓存sku图片字典
            Dictionary<string, string> skuImageDic = new Dictionary<string, string>();
            foreach (var sku in product.SkuList)
            {
                //如果没有抓到详情图片  则用主图图片
                if (sku.Image.IsNullOrEmpty())
                {
                    sku.TxoooImage = product.TxoooThumImgList[0];
                }
                else
                {
                    try
                    {
                        if (!new Regex("img.txooo.com").IsMatch(sku.TxoooImage))
                        {
                            if (skuImageDic.ContainsKey(sku.Image))
                            {
                                sku.TxoooImage = skuImageDic[sku.Image];
                            }
                            else
                            {
                                await Task.Delay(100);
                                sku.TxoooImage = BaseContent.ImageService.UploadImg(sku.Image);
                                skuImageDic.Add(sku.Image, sku.TxoooImage);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        new Exception("上传{0}商品{1} SKU图 {2} 执行异常：{3}".FormatWith(product.SourceName, product.Id, sku.Image, ex.Message), ex);
                    }
                }
            }
        }
        #endregion

        #region 测试代码
        private static object o = new object();
        /*定义 Queue*/
        private static Queue<Product> _Products { get; set; }

        private static ConcurrentQueue<Product> _ConcurrentQueue { set; get; }
        private static ConcurrentBag<Product> _ConcurrenProducts { get; set; }

        internal async Task Msg()
        {
            for (int i = 0; i < 50; i++)
            {
                await InfoMessage(MsgTemplate, "正常消息");
                if (i % 5 == 0)
                {
                    await WarnMessage(MsgTemplate, "警告消息");
                }
                if (i % 3 == 0)
                {
                    await ErrorMessage(MsgTemplate, "错误信息");
                }
                if (i % 7 == 0)
                {
                    await FatalMessage(MsgTemplate, "致命消息");
                }
            }
        }

        public async Task Run(int count)
        {
            _Products = new Queue<Product>();
            Stopwatch swTask = new Stopwatch();//用于统计时间消耗的
            swTask.Start();

            ///*创建任务 t1  t1 执行 数据集合添加操作*/
            //Task t1 = Task.Factory.StartNew(() =>
            //{

            //});
            ///*创建任务 t2  t2 执行 数据集合添加操作*/
            //Task t2 = Task.Factory.StartNew(() =>
            //{

            //});
            ///*创建任务 t3  t3 执行 数据集合添加操作*/
            //Task t3 = Task.Factory.StartNew(() =>
            //{
            //    AddProducts(3);
            //});
            Parallel.For(0, count, async (i) =>
            {
                await AddProducts(i);
            });
            //for (int i = 0; i < count; i++)
            //{
            //    await 
            //}

            //await AddProducts(2);
            //await AddProducts(3);
            //await t3;

            //Task.WaitAll(t1, t2, t3);

            swTask.Stop();
            await WarnMessage(MsgTemplate, "List<Product> 当前数据量为：" + _Products.Count);
            await WarnMessage(MsgTemplate, "List<Product> 执行时间为：" + swTask.ElapsedMilliseconds);

            await Task.Delay(5000);
            _ConcurrenProducts = new ConcurrentBag<Product>();
            Stopwatch swTask1 = new Stopwatch();
            swTask1.Start();

            /*创建任务 tk1  tk1 执行 数据集合添加操作*/
            Task tk1 = Task.Factory.StartNew(() =>
            {
                AddConcurrenProducts();
            });
            /*创建任务 tk2  tk2 执行 数据集合添加操作*/
            Task tk2 = Task.Factory.StartNew(() =>
            {
                AddConcurrenProducts();
            });
            /*创建任务 tk3  tk3 执行 数据集合添加操作*/
            Task tk3 = Task.Factory.StartNew(() =>
            {
                AddConcurrenProducts();
            });

            Task.WaitAll(tk1, tk2, tk3);
            swTask1.Stop();

            await WarnMessage(MsgTemplate, "ConcurrentBag<Product> 当前数据量为：" + _ConcurrenProducts.Count);
            await WarnMessage(MsgTemplate, "ConcurrentBag<Product> 执行时间为：" + swTask1.ElapsedMilliseconds);
        }

        /*执行集合数据添加操作*/
        async Task AddProducts(int index)
        {
            Parallel.For(0, 30, async (i) =>
             {
                 Product product = new Product();
                 product.Name = "name" + i;
                 product.Category = "Category" + i;
                 product.SellPrice = i;
                 lock (o)
                 {
                     _Products.Enqueue(product);
                 }
                 await InfoMessage(MsgTemplate, string.Format("线程{0} 第{1}商品添加成功", index, i));
             });

        }
        /*执行集合数据添加操作*/
        void AddConcurrenProducts()
        {
            Parallel.For(0, 30, (i) =>
            {
                Product product = new Product();
                product.Name = "name" + i;
                product.Category = "Category" + i;
                product.SellPrice = i;
                _ConcurrenProducts.Add(product);
                // InfoMessage(MsgTemplate, string.Format("第{0}商品添加成功", i));
            });

        }
        class Product
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public int SellPrice { get; set; }
        }
        #endregion
    }

}

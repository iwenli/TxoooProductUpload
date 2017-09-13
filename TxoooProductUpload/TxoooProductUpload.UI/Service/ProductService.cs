using Iwenli;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TxoooProductUpload.Entities.Product;

namespace TxoooProductUpload.UI.Service
{
    class ProductService : ServiceBase
    {
        public ProductService(TxoooProductUpload.Service.ServiceContext baseContent) : base(baseContent)
        {
            MsgTemplate = "[商品消息]{0}";
        }
        /// <summary>
        /// 识别发货地
        /// </summary>
        /// <returns></returns>
        public void DiscernLcation(ref ProductSourceInfo product)
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

        /// <summary>
        /// 上传商品图片到Txooo服务器 并返回商品
        /// </summary>
        /// <param name="productList"></param>
        /// <returns></returns>
        public void UploadProductImage(ProductSourceInfo product)
        {
            foreach (var url in product.ThumImgList)
            {
                try
                {
                    product.TxoooThumImgList.Add(BaseContent.ImageService.UploadImg(url));
                }
                catch (Exception ex)
                {
                    new Exception("上传{0}商品{1}主图{2}执行异常：{3}".FormatWith(product.SourceName, product.Id, url, ex.Message), ex);
                }
            }
            foreach (var url in product.DetailImgList)
            {
                try
                {
                    product.TxoooDetailImgList.Add(BaseContent.ImageService.UploadImg(url));
                }
                catch (Exception ex)
                {
                    new Exception("上传{0}商品{1}详情图{2}执行异常：{3}".FormatWith(product.SourceName, product.Id, url, ex.Message), ex);
                }

            }
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
                        sku.TxoooImage = BaseContent.ImageService.UploadImg(sku.Image);
                    }
                    catch (Exception ex)
                    {
                        new Exception("上传{0}商品{1}详情图{2}执行异常：{3}".FormatWith(product.SourceName, product.Id, sku.Image, ex.Message), ex);
                    }

                }
            }
        }

        #region 测试代码
        //private static object o = new object();
        ///*定义 Queue*/
        //private static Queue<Product> _Products { get; set; }

        //private static ConcurrentQueue<Product> _ConcurrentQueue { set; get; }
        //private static ConcurrentBag<Product> _ConcurrenProducts { get; set; }

        //internal async Task Msg()
        //{
        //    for (int i = 0; i < 50; i++)
        //    {
        //        await InfoMessage(MsgTemplate, "正常消息");
        //        if (i % 5 == 0)
        //        {
        //            await WarnMessage(MsgTemplate, "警告消息");
        //        }
        //        if (i % 3 == 0)
        //        {
        //            await ErrorMessage(MsgTemplate, "错误信息");
        //        }
        //        if (i % 7 == 0)
        //        {
        //            await FatalMessage(MsgTemplate, "致命消息");
        //        }
        //    }
        //}

        //public async Task Run(int count)
        //{
        //    _Products = new Queue<Product>();
        //    Stopwatch swTask = new Stopwatch();//用于统计时间消耗的
        //    swTask.Start();

        //    ///*创建任务 t1  t1 执行 数据集合添加操作*/
        //    //Task t1 = Task.Factory.StartNew(() =>
        //    //{

        //    //});
        //    ///*创建任务 t2  t2 执行 数据集合添加操作*/
        //    //Task t2 = Task.Factory.StartNew(() =>
        //    //{

        //    //});
        //    ///*创建任务 t3  t3 执行 数据集合添加操作*/
        //    //Task t3 = Task.Factory.StartNew(() =>
        //    //{
        //    //    AddProducts(3);
        //    //});
        //    Parallel.For(0, count, async (i) =>
        //    {
        //        await AddProducts(i);
        //    });
        //    //for (int i = 0; i < count; i++)
        //    //{
        //    //    await 
        //    //}

        //    //await AddProducts(2);
        //    //await AddProducts(3);
        //    //await t3;

        //    //Task.WaitAll(t1, t2, t3);

        //    swTask.Stop();
        //    await WarnMessage(MsgTemplate, "List<Product> 当前数据量为：" + _Products.Count);
        //    await WarnMessage(MsgTemplate, "List<Product> 执行时间为：" + swTask.ElapsedMilliseconds);

        //    await Task.Delay(5000);
        //    _ConcurrenProducts = new ConcurrentBag<Product>();
        //    Stopwatch swTask1 = new Stopwatch();
        //    swTask1.Start();

        //    /*创建任务 tk1  tk1 执行 数据集合添加操作*/
        //    Task tk1 = Task.Factory.StartNew(() =>
        //    {
        //        AddConcurrenProducts();
        //    });
        //    /*创建任务 tk2  tk2 执行 数据集合添加操作*/
        //    Task tk2 = Task.Factory.StartNew(() =>
        //    {
        //        AddConcurrenProducts();
        //    });
        //    /*创建任务 tk3  tk3 执行 数据集合添加操作*/
        //    Task tk3 = Task.Factory.StartNew(() =>
        //    {
        //        AddConcurrenProducts();
        //    });

        //    Task.WaitAll(tk1, tk2, tk3);
        //    swTask1.Stop();

        //    await WarnMessage(MsgTemplate, "ConcurrentBag<Product> 当前数据量为：" + _ConcurrenProducts.Count);
        //    await WarnMessage(MsgTemplate, "ConcurrentBag<Product> 执行时间为：" + swTask1.ElapsedMilliseconds);
        //}

        ///*执行集合数据添加操作*/
        //async Task AddProducts(int index)
        //{
        //    Parallel.For(0, 30, async (i) =>
        //     {
        //         Product product = new Product();
        //         product.Name = "name" + i;
        //         product.Category = "Category" + i;
        //         product.SellPrice = i;
        //         lock (o)
        //         {
        //             _Products.Enqueue(product);
        //         }
        //         await InfoMessage(MsgTemplate, string.Format("线程{0} 第{1}商品添加成功", index, i));
        //     });

        //}
        ///*执行集合数据添加操作*/
        //void AddConcurrenProducts()
        //{
        //    Parallel.For(0, 30, (i) =>
        //    {
        //        Product product = new Product();
        //        product.Name = "name" + i;
        //        product.Category = "Category" + i;
        //        product.SellPrice = i;
        //        _ConcurrenProducts.Add(product);
        //        // InfoMessage(MsgTemplate, string.Format("第{0}商品添加成功", i));
        //    });

        //}
        //class Product
        //{
        //    public string Name { get; set; }
        //    public string Category { get; set; }
        //    public int SellPrice { get; set; }
        //} 
        #endregion
    }

}

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TxoooProductUpload.UI.Service
{
    class ProductService : ServiceBase
    {
        private static object o = new object();
        /*定义 Queue*/
        private static Queue<Product> _Products { get; set; }

        private static ConcurrentQueue<Product> _ConcurrentQueue { set; get; }
        private static ConcurrentBag<Product> _ConcurrenProducts { get; set; }


        public ProductService()
        {
            MsgTemplate = "[商品消息]{0}";
        }

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
            for (int i = 0; i < count; i++)
            {
                await AddProducts(i);
            }
           
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
    }

}

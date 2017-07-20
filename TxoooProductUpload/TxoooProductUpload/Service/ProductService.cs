using FSLib.Network.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Common;
using TxoooProductUpload.Service.Entities;
using TxoooProductUpload.Service.Entities.Web;

namespace TxoooProductUpload.Service
{
    /// <summary>
    /// 商品相关数据服务
    /// </summary>
    class ProductService : ServiceBase
    {
        public ProductService(ServiceContext context) : base(context)
        {
        }


        /// <summary>
        /// 上传商品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<WebResponseResult<string>> UploadProduct(ProductResult product)
        {

            var data = new {
                is_default_0 = true,
                is_virtual = 0,
                json_info_0 = "均码",
                new_old = 1,
                price_0 = 100,
                product_brand = "品牌",
                product_details = "<p></p><img src=\"https://img.txooo.com/2017/06/19/a4f258eb654da2f08df81eadf902578c.jpg\"/><p></p><img src=\"https://img.txooo.com/2017/04/10/ab5cfed05a4b4002e5a792a91fcb479f.jpg\"/><p></p><img src=\"https://img.txooo.com/2017/06/20/a466f3629713e6db28de65488898f65f.jpg\"/><p></p><img src=\"https://img.txooo.com/2017/06/20/702a3caf04e8ce5e52b37bc1152d8ed3.jpg\"/>",
                product_details_type = 0,
                product_id = 21683,
                product_imgs = "https://img.txooo.com/2017/06/19/c48e78c819d71acf6d8fafeb75008325.jpg,https://img.txooo.com/2017/06/19/e7cfb47ad20b5ea1aa3a3f85f41d08cd.jpg,https://img.txooo.com/2017/06/19/d00ec1764153c8cb514d00b91e66cb58.jpg,https://img.txooo.com/2017/06/19/4810b68a1c880c753d12e6964bd3bdaf.jpg",
                product_ispostage = true,
                product_name = "龙哥测试接口上传",
                product_postage = "",
                product_type = 619,
                product_type_service = 1,
                property_map_img_0 = "https://img.txooo.com/2017/06/19/aca8612f1889e34ddc0c757bdf8f9bae.jpg",
                radio_num_0 = 10,
                refund = 1,
                region_code = 110000,
                region_name = "北京市",
                remain_inventory_0 = 80,
                share_content_0 = "分享码",
                share_id_0 = 0,
                submit_product = 1
            };
            var stCtx = ServiceContext.Session.NetClient
               .Create<WebResponseResult<string>>(HttpMethod.Post, ApiList.AddProduct4 + string.Format("?userid={0}&token={1}",
               ServiceContext.Session.Token.userid, ServiceContext.Session.Token.token), data: data);
            
            await stCtx.SendAsync();
            if (!stCtx.IsValid())
            {
                new Exception("ProductService.UploadProduct未能提交请求");
            }
            return stCtx.Result;
        }
    }
}

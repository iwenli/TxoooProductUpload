using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxoooProductUpload.Common;
using TxoooProductUpload.Entities.Product;

namespace TxoooProductUpload.Entities.Request
{
    /// <summary>
    /// 提交商品
    /// </summary>
    public class ProductRequest
    { 
        /// <summary>
        /// 初始化一个 ProductRequest 实例
        /// </summary>
        public ProductRequest()
        {
            SkuJsons = new StringBuilder();
            Details = new StringBuilder();
        }
        #region api相关

        /// <summary>
        /// 商品id
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { set; get; }

        /// <summary>
        /// 商品新旧，新品1，二手2
        /// </summary>
        public int NewOld { set; get; }

        /// <summary>
        /// 商品主图,逗号分隔
        /// </summary>
        public string ThumImages { set; get; }

        /// <summary>
        /// 商品品牌
        /// </summary>
        public string Brand { set; get; }

        /// <summary>
        /// 发货地代码（直辖市id：2,3,10,23）
        /// </summary>
        public long RegionCode { set; get; }

        /// <summary>
        /// 发货地名称
        /// </summary>
        public string RegionName { set; get; }

        /// <summary>
        /// 是否虚拟商品1是，0否
        /// </summary>
        public bool IsVirtual { set; get; }

        /// <summary>
        /// 是否包邮（True包邮，Flase不包邮）
        /// </summary>
        public bool IsFreePostage { set; get; }

        /// <summary>
        /// 邮费金额
        /// </summary>
        public double Postage { set; get; }
        /// <summary>
        /// 每增加一件增加的邮费
        /// </summary>
        public double Append { set; get; }
        /// <summary>
        /// 满足包邮的件数
        /// </summary>
        public int Limit { set; get; }

        /// <summary>
        /// 支持七天无理由1支持，0不支持
        /// </summary>
        public bool Refund { set; get; }

        /// <summary>
        /// 商品类别id
        /// </summary>
        public long ClassId { set; get; }

        /// <summary>
        /// 商品详情
        /// </summary>
        public StringBuilder Details { set; get; }


        int _submint = 1;
        /// <summary>
        /// 提交或保存商品（1提交，0保存）  默认为1
        /// </summary>
        public int Submit
        {
            set { _submint = value; }
            get
            {
                return _submint;
            }
        }

        int _detailsType = 0;
        /// <summary>
        /// 详情类型（0手机，1pc）
        /// </summary>
        public int DetailsType
        {
            set { _detailsType = value; }
            get
            {
                return _detailsType;
            }
        }

        /// <summary>
        /// 商品分类类型 （1产品，2服务）
        /// </summary>
        public int TypeService { set; get; }

        /// <summary>
        /// 商品sku json
        /// </summary>
        public StringBuilder SkuJsons { set; get; }

        /// <summary>
        /// 推广语集合,多个通过|分隔
        /// </summary>
        public string Shares { set; get; }

        /// <summary>
        /// 搜索关键词 空格分隔
        /// </summary>
        public string SearchKeyWord { set; get; }
        #endregion

        /// <summary>
        /// 生成商品上传信息
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Parameters parameters = new Parameters();
            parameters.Add("product_id", Id);
            parameters.Add("new_old", NewOld);
            parameters.Add("product_details_type", DetailsType);
            parameters.Add("product_name", ProductName);
            parameters.Add("product_type", ClassId);
            parameters.Add("product_type_service", TypeService);
            parameters.Add("region_code", RegionCode);
            parameters.Add("region_name", RegionName);
            parameters.Add("submit_product", Submit);
            parameters.Add("is_virtual", Convert.ToInt16(IsVirtual));
            parameters.Add("product_ispostage", IsFreePostage.ToString().ToLower());
            parameters.Add("refund", Convert.ToInt16(Refund));
            parameters.Add("product_imgs", ThumImages);
            parameters.Add("product_details", Details.ToString());
            parameters.Add("product_brand", Brand??"");//品牌
            parameters.Add("search_key_word", SearchKeyWord ?? "");//搜索关键词

            if (!IsFreePostage)   //如果不包邮设置邮费
            {
                parameters.Add("product_postage", "{" + string.Format("\"postage\":\"{0}\",\"append\":\"{1}\",\"limit\":\"{2}\"", Postage, Append, Limit) + "}");
            }
            #region 推广语
            //if (!Shares.IsNullOrEmpty())
            //{
            //    var shareList = Shares.Split('|');
            //    for (int i = 0; i < shareList.Length; i++)
            //    {
            //        parameters.Add("share_id_" + i, 0);
            //        parameters.Add("share_content_" + i, shareList[i]);
            //    }
            //}
            #endregion
            return parameters.BuildQueryString(false) + SkuJsons.ToString();
        }
    }
}

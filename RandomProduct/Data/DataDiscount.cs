using RandomProduct.Models.Data;
using System;
using System.Collections.Generic;

namespace RandomProduct.Data
{
    public static class DataDiscount
    {
        public static List<DiscountData> DiscountDatas = new List<DiscountData>();

        static DataDiscount()
        {
            FillDiscount("RP-25D-SITB", "Buy 2 or more Bags of Pogs and get 50% off each bag (excluding the first one)", 2, new DiscountResult(50, "RP-25D-SITB"));
            FillDiscount("RP-1TB-EITB", "Buy a Large bowl of Trifle and get a free Paper Mask.", 2, new DiscountResult(100, "RP-RPM-FITB"));
            FillDiscount("RP-5NS-DITB", "Buy 100 or more Shurikens and get 30% off whole basket.", 100, new DiscountResult(30, ""));
        }

        private static void FillDiscount(string productId, string discountName, int discountCondition, DiscountResult discountResult)
        {
            // * Notes: 
            //  productId - discount for what product,
            //  discountCondition - e.x. Buy "2" or more.... or Buy "100" or more... and ect...
            //  discountResult - discountResult.Percents - discount by percents, discountResult.ProductId - discount for what product, (discountResult.ProductId == Empty - for whole basket)
            if ((discountCondition == 0 || discountCondition < 1) || (discountResult.Percents == 0 || discountResult.Percents < 1))
            {
                throw new Exception();
            }

            DiscountDatas.Add(new DiscountData(productId, discountName, discountCondition, discountResult));
        }
    }
}

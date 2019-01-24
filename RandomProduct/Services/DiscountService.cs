using RandomProduct.Data;
using RandomProduct.Models;
using RandomProduct.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomProduct.Services
{
    public abstract class DiscountService
    {
        public virtual Dictionary<string, double> CheckDiscounts(List<Product> products)
        {
            Dictionary<string, double> dic = new Dictionary<string, double>();

            foreach (DiscountData item in DataDiscount.DiscountDatas)
            {
                IEnumerable<Product> productsWithDiscount = products.Where(x => x.ProductId == item.ProductId);

                if (productsWithDiscount.Any() && productsWithDiscount.Count() >= item.DiscountCondition)
                {
                    double result = 0;

                    foreach (Product product in productsWithDiscount)
                    {
                        result = Math.Abs(product.Cost * item.DiscountResult.Percents);
                    }

                    dic.Add(productsWithDiscount.FirstOrDefault().ProductId, result);
                }
            }

            return dic;
        }
    }
}

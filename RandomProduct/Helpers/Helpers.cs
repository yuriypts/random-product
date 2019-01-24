using RandomProduct.Models.ExtendsModels;
using System;
using System.Collections.Generic;

namespace RandomProduct.Helpers
{
    public static class Helpers
    {
        public static void ShowProductInMarket(List<ProductResponseModel> products)
        {
            foreach (var item in products)
            {
                Console.WriteLine("id - {0}, name - {1}, count - {2}, cost - {3}", item.ProductId, item.ProductName, item.CountProducts, item.ProductCost);
            }
        }
    }
}

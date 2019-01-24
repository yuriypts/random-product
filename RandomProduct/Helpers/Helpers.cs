using RandomProduct.Models.ExtendsModels;
using System;
using System.Collections.Generic;

namespace RandomProduct.Helpers
{
    public static class Helpers
    {
        public static void ShowProductsInMarket(List<ProductResponseModel> products)
        {
            foreach (var item in products)
            {
                Console.WriteLine("Id - {0}, Name - {1}, Count - {2}, Cost - {3}", item.ProductId, item.ProductName, item.CountProducts, item.ProductCost);
            }
        }
    }
}

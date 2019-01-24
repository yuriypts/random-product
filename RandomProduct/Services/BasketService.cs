using RandomProduct.Interfaces;
using RandomProduct.Models;
using RandomProduct.Models.ExtendsModels;
using System.Collections.Generic;
using System.Linq;

namespace RandomProduct.Services
{
    public class BasketService : IBasketService
    {
        public List<Product> Products = new List<Product>();

        public void AddProductToBasket(Product product)
        {
            Products.Add(product);
        }
        public void RemoveProductToBasket(Product product)
        {
            Products.Remove(product);
        }
        public List<ProductResponseModel> ListProducts()
        {
            var distinctList = Products.Select(x => new { x.ProductId, x.Name, CountProducts = Products.Count(y => y.ProductId == x.ProductId), x.Cost }).Distinct();
            return distinctList.Select(x => new ProductResponseModel { ProductId = x.ProductId, ProductName = x.Name, CountProducts = x.CountProducts, ProductCost = x.Cost }).ToList();
        }

        public List<Product> ListWholeProducts()
        {
            return Products;
        }
    }
}

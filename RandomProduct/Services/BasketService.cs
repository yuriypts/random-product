using RandomProduct.Interfaces;
using RandomProduct.Models;
using System.Collections.Generic;

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
        public List<Product> ListProducts()
        {
            return Products;
        }
    }
}

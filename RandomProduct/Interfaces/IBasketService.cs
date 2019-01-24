using RandomProduct.Models;
using System.Collections.Generic;

namespace RandomProduct.Interfaces
{
    public interface IBasketService
    {
        void AddProductToBasket(Product product);
        void RemoveProductToBasket(Product product);
        List<Product> ListProducts();
    }
}

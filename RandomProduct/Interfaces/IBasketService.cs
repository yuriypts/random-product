using RandomProduct.Models;
using RandomProduct.Models.ExtendsModels;
using System.Collections.Generic;

namespace RandomProduct.Interfaces
{
    public interface IBasketService
    {
        void AddProductToBasket(Product product);
        void RemoveProductFromBasket(Product product);
        List<ProductResponseModel> ListProducts();
        List<Product> ListWholeProducts();
        Product GetProduct(string productId);
        Product GetProductByName(string productName);
        List<Product> GetProductsByName(string productName);
    }
}

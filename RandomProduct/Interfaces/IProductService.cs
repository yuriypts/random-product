using RandomProduct.Models;
using RandomProduct.Models.ExtendsModels;
using System.Collections.Generic;

namespace RandomProduct.Interfaces
{
    public interface IProductService
    {
        void FillProducts(List<Product> products);
        List<ProductResponseModel> GetProducts();
        List<Product> GetWholeProducts();
        Product GetProduct(string id);
        void RemoveProduct(Product product);
    }
}

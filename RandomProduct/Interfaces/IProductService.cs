using RandomProduct.Models;
using System.Collections.Generic;

namespace RandomProduct.Interfaces
{
    public interface IProductService
    {
        void FillProducts(List<Product> products);
        List<Product> GetProducts();
        Product GetProduct(string id);
    }
}

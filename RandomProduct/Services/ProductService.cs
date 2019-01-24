using RandomProduct.Interfaces;
using RandomProduct.Models;
using RandomProduct.Models.ExtendsModels;
using System.Collections.Generic;
using System.Linq;

namespace RandomProduct.Services
{
    public class ProductService : IProductService
    {
        List<Product> Products { get; set; }

        public void FillProducts(List<Product> products)
        {
            Products = new List<Product>();

            foreach (Product product in products)
            {
                Products.Add(product);
            }
        }

        public List<ProductResponseModel> GetProducts()
        {
            var distinctList = Products.Select(x => new { x.ProductId, x.Name, CountProducts = Products.Count(y => y.ProductId == x.ProductId), x.Cost }).Distinct();
            return distinctList.Select(x => new ProductResponseModel { ProductId = x.ProductId, ProductName = x.Name, CountProducts = x.CountProducts, ProductCost = x.Cost }).ToList();
        }

        public List<Product> GetWholeProducts()
        {
            return Products;
        }

        public Product GetProduct(string id)
        {
            return Products.FirstOrDefault(x => x.ProductId == id);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}

using RandomProduct.Interfaces;
using RandomProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public List<Product> GetProducts()
        {
            return Products;
        }

        public Product GetProduct(string id)
        {
            return Products.FirstOrDefault(x => x.Id == id);
        }
    }
}

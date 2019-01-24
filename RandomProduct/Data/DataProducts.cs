using RandomProduct.Models;
using System;
using System.Collections.Generic;

namespace RandomProduct.Data
{
    public static class DataProducts
    {
        public static List<Product> Products = new List<Product>
            {
                new Product("RP-5NS-DITB", "Shurikens", new Random().Next(100, 200), 8.95),
                new Product("RP-25D-SITB", "Bag of Pogs", 25, 5.31),
                new Product("RP-1TB-EITB", "Large bowl of Trifle", 1, 2.75),
                new Product("RP-RPM-FITB", "Paper Mask", new Random().Next(0, 100), 0.30),
            };
    }
}

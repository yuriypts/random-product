using RandomProduct.Models;
using System;
using System.Collections.Generic;

namespace RandomProduct.Data
{
    public static class DataProducts
    {
        public static List<Product> Products = new List<Product>();

        private static int shurikensCount = new Random().Next(100, 200);
        private static int bagOfPogsCount = 25;
        private static int largeBowlOfTrifleCount = 1;
        private static int paperMaskCount = new Random().Next(0, 100);

        static DataProducts()
        {
            FillProduct("RP-5NS-DITB", "Shurikens", shurikensCount, 8.95);
            FillProduct("RP-25D-SITB", "Bag of Pogs", bagOfPogsCount, 5.31);
            FillProduct("RP-1TB-EITB", "Large bowl of Trifle", largeBowlOfTrifleCount, 2.75);
            FillProduct("RP-RPM-FITB", "Paper Mask", paperMaskCount, 0.30);
        }

        private static void FillProduct(string productId, string productName, int productCount, double productCost)
        {
            for (int item = 0; item < productCount; item++)
            {
                Products.Add(new Product(item, productId, productName, productCost));
            }
        }
    }
}

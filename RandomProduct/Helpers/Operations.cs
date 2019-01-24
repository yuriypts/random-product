using RandomProduct.Data;
using RandomProduct.Enums;
using RandomProduct.Interfaces;
using RandomProduct.Models;
using RandomProduct.Models.ExtendsModels;
using RandomProduct.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomProduct.Helpers
{
    public static class Operations
    {
        private readonly static IProductService productService;
        private readonly static IBasketService basketService;

        static Operations()
        {
            productService = new ProductService();
            basketService = new BasketService();

            productService.FillProducts(DataProducts.Products);
        }

        public static void OpenGeneralOperations()
        {
            Console.WriteLine($"Choose operation (please enter the number):\n " +
                $"{(int)GeneralOperationsEnum.ListProducts} - Get list of Products\n " +
                $"{(int)GeneralOperationsEnum.ByProduct} - By the Product\n " +
                $"{(int)GeneralOperationsEnum.OpenBasket} - Open my Basket\n " +
                $"{(int)GeneralOperationsEnum.CloseProgram} - Close Program");

            string value = Console.ReadLine();

            int operationNumber;
            int.TryParse(value, out operationNumber);

            switch (operationNumber)
            {
                case (int)GeneralOperationsEnum.ListProducts:
                    Helpers.ShowProductInMarket(productService.GetProducts());

                    break;

                case (int)GeneralOperationsEnum.ByProduct:
                    Helpers.ShowProductInMarket(productService.GetProducts());

                    Console.WriteLine("Choose the product (please enter Id product)");
                    string productId = Console.ReadLine();

                    Product product = productService.GetProduct(productId);

                    if (product != null)
                        basketService.AddProductToBasket(product);
                    else
                        Console.WriteLine("Product was not found please try again");

                    break;

                case (int)GeneralOperationsEnum.OpenBasket:
                    List<Product> productsInBasket = basketService.ListProducts();

                    foreach (var item in productsInBasket.Distinct())
                    {
                        Console.WriteLine("\nName - {0},\n Count - {1},\n Sub-total-item - {2}", item.Name, productsInBasket.Count(x => x.Id == item.Id), productsInBasket.Where(x => x.Id == item.Id).Sum(x => x.Cost));
                    }

                    Console.WriteLine("Sub-total of the basket - {0}", productsInBasket.Sum(x => x.Cost));
                    Console.WriteLine("Discount - empty");
                    Console.WriteLine("Grant Total Price - with discount");

                    break;

                case (int)GeneralOperationsEnum.CloseProgram:
                    return;

                default:
                    Console.WriteLine("Provide operation is incorrect, please try again");

                    break;
            }

            Console.WriteLine(new string('-', 80));
            OpenGeneralOperations();
        }
    }
}

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
                $"{(int)GeneralOperationsEnum.CloseProgram} - Close Program\n" +
                $"{(int)GeneralOperationsEnum.Discounts} - Get All Discounts\n");

            string value = Console.ReadLine();

            int operationNumber;
            int.TryParse(value, out operationNumber);

            switch (operationNumber)
            {
                case (int)GeneralOperationsEnum.ListProducts:
                    Helpers.ShowProductsInMarket(productService.GetProducts());

                    break;

                case (int)GeneralOperationsEnum.ByProduct:
                    Helpers.ShowProductsInMarket(productService.GetProducts());

                    Console.WriteLine("Choose the product (please enter Id product)");
                    string productId = Console.ReadLine();

                    Product product = productService.GetProduct(productId);

                    if (product != null)
                    {
                        productService.RemoveProduct(product);
                        basketService.AddProductToBasket(product);
                    }
                    else
                        Console.WriteLine("Product was not found please try again");

                    break;

                case (int)GeneralOperationsEnum.OpenBasket:
                    List<ProductResponseModel> productsInBasket = basketService.ListProducts();
                    List<Product> wholeProductsInBasket = basketService.ListWholeProducts();

                    if (wholeProductsInBasket.Any())
                    {
                        foreach (var item in productsInBasket)
                        {
                            Console.WriteLine("\nName - {0},\n Count - {1},\n Sub-total-item - {2}", item.ProductName, item.CountProducts, wholeProductsInBasket.Where(x => x.ProductId == item.ProductId).Sum(x => x.Cost));
                        }

                        Console.WriteLine("Sub-total of the basket - {0}", wholeProductsInBasket.Sum(x => x.Cost));
                        Console.WriteLine("Discount - empty");
                        Console.WriteLine("Grant Total Price - with discount");
                    }
                    else
                    {
                        Console.WriteLine("Basket is empty");
                    }

                    break;

                case (int)GeneralOperationsEnum.CloseProgram:
                    return;

                case (int)GeneralOperationsEnum.Discounts:
                    foreach (var item in DataDiscount.DiscountDatas)
                    {
                        Console.WriteLine(item.Name);
                    }

                    break;

                default:
                    Console.WriteLine("Provide operation is incorrect, please try again");

                    break;
            }

            Console.WriteLine(new string('-', 80));
            OpenGeneralOperations();
        }
    }
}

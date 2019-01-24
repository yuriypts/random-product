using RandomProduct.Data;
using RandomProduct.Enums;
using RandomProduct.Interfaces;
using RandomProduct.Models;
using RandomProduct.Models.Data;
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
                        BasketService basketServiceUpCast = basketService as BasketService;
                        Dictionary<string, double> discounts = basketServiceUpCast.CheckDiscounts(wholeProductsInBasket);
                        double basketSum = wholeProductsInBasket.Sum(x => x.Cost);

                        foreach (var item in productsInBasket)
                        {
                            Console.WriteLine("\nName - {0},\n Count - {1},\n Sub-total-item - {2}", item.ProductName, item.CountProducts, wholeProductsInBasket.Where(x => x.ProductId == item.ProductId).Sum(x => x.Cost));
                            Console.WriteLine("Any discount applicable - {0}", discounts.FirstOrDefault(x => x.Key == item.ProductId).Value);
                        }

                        Console.WriteLine("Sub-total of the basket - {0}", basketSum);
                        Console.WriteLine("Grant Total Price - {0}", Math.Abs(basketSum - discounts.Values.Sum()));

                        Console.WriteLine(new string('-', 80));
                        OpenBasketOperations();
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

        public static void OpenBasketOperations()
        {
            Console.WriteLine($"Choose operation (please enter the number):\n " +
                $"{(int)BasketOperationsEnum.RemoveProduct} - Remove product one at time from\n" +
                $"{(int)BasketOperationsEnum.RemoveProductsAsAWhole} - Remove products as a whole from basket\n" +
                $"{(int)BasketOperationsEnum.GoToMainMenu} - Go to main menu");

            string value = Console.ReadLine();

            int operationNumber;
            int.TryParse(value, out operationNumber);

            switch (operationNumber)
            {
                case (int)BasketOperationsEnum.RemoveProduct:
                    Console.WriteLine("Plese provide the name product");
                    string nameProduct = Console.ReadLine();

                    Product product = basketService.GetProductByName(nameProduct);

                    if (product != null)
                    {
                        basketService.RemoveProductFromBasket(product);
                        productService.AddProduct(product);
                    }
                    else
                    {
                        Console.WriteLine("Provided name is incorrect, please try again");
                    }

                    Console.WriteLine(new string('-', 80));
                    OpenGeneralOperations();

                    break;

                case (int)BasketOperationsEnum.RemoveProductsAsAWhole:
                    Console.WriteLine("Plese provide the name product");
                    string nameProductAll = Console.ReadLine();

                    List<Product> productAll = basketService.GetProductsByName(nameProductAll);

                    if (productAll != null)
                    {
                        foreach (var item in productAll)
                        {
                            basketService.RemoveProductFromBasket(item);
                            productService.AddProduct(item);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Provided name is incorrect, please try again");
                    }

                    Console.WriteLine(new string('-', 80));
                    OpenGeneralOperations();

                    break;

                case (int)BasketOperationsEnum.GoToMainMenu:
                    Console.WriteLine(new string('-', 80));
                    OpenGeneralOperations();

                    break;

                default:
                    Console.WriteLine("Provide operation is incorrect, please try again");

                    break;
            }

            Console.WriteLine(new string('-', 80));
            OpenBasketOperations();
        }
    }
}

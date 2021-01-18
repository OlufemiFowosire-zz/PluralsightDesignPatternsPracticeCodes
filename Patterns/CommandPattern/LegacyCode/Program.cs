using LegacyCode.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var shoppingCartRepository = new ShoppingCartRepository();
            var productsRepository = new ProductRepository();

            var product = productsRepository.FindBy("SM7B");

            shoppingCartRepository.Add(product);
            shoppingCartRepository.IncreaseQuantity(product.ArticleId);
            shoppingCartRepository.IncreaseQuantity(product.ArticleId);
            shoppingCartRepository.IncreaseQuantity(product.ArticleId);
            shoppingCartRepository.IncreaseQuantity(product.ArticleId);

            PrintCart(shoppingCartRepository);

            Console.ReadLine();
        }

        static void PrintCart(ShoppingCartRepository shoppingCartRepository)
        {
            var total = 0.0;
            var display = new StringBuilder();
            foreach (var item in shoppingCartRepository.items.ToList())
            {
                total += item.Value.Product.amount * item.Value.Quantity;
                display.AppendLine((string.Format("{0} {1:C0} X {2} = {3:C0}",
                    item.Key,
                    item.Value.Product.amount,
                    item.Value.Quantity,
                    item.Value.Product.amount * item.Value.Quantity
                    )));
            }
            display.AppendLine(string.Format("Total price:\t{0:C0}", total));
            Console.WriteLine(display.ToString());
        }
    }
}

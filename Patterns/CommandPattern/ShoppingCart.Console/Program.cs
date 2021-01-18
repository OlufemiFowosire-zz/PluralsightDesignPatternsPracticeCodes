using System.Linq;
using System.Text;
using ShoppingCart.Business.Commands;
using ShoppingCart.Business.Repositories;
using static ShoppingCart.Business.Commands.ChangeQuantityCommand;

namespace ShoppingCart.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var shoppingCartRepository = new ShoppingCartRepository();
            var productRepository = new ProductRepository();

            var product = productRepository.FindBy("SM7B");

            var addToCart = new AddToCartCommand(shoppingCartRepository, productRepository, product);
            var changeQuantity = new ChangeQuantityCommand(Operation.Increase, shoppingCartRepository, productRepository, product);
            var manager = new CommandManager();

            manager.Invoke(addToCart);
            manager.Invoke(changeQuantity);
            manager.Invoke(changeQuantity);
            manager.Invoke(changeQuantity);
            manager.Invoke(changeQuantity);
            manager.Undo();
            manager.Redo();

            //shoppingCartRepository.Add(product);
            //shoppingCartRepository.IncreaseQuantity(product.ArticleId);
            //shoppingCartRepository.IncreaseQuantity(product.ArticleId);
            //shoppingCartRepository.IncreaseQuantity(product.ArticleId);
            //shoppingCartRepository.IncreaseQuantity(product.ArticleId);

            PrintCart(shoppingCartRepository);

            System.Console.ReadLine();
        }

        static void PrintCart(ShoppingCartRepository shoppingCartRepository)
        {
            //var total = 0.0;
            var display = new StringBuilder();
            shoppingCartRepository.items.ToList().ForEach(
                item =>
                {
                    display.AppendLine((string.Format("{0} {1:C0} X {2} = {3:C0}",
                    item.Key,
                    item.Value.Product.Amount,
                    item.Value.Quantity,
                    item.Value.Product.Amount * item.Value.Quantity
                    )));
                }
                );
            //foreach (var item in shoppingCartRepository.items.ToList())
            //{
            //    total += item.Value.Product.amount * item.Value.Quantity;
            //    display.AppendLine((string.Format("{0} {1:C0} X {2} = {3:C0}",
            //        item.Key,
            //        item.Value.Product.amount,
            //        item.Value.Quantity,
            //        item.Value.Product.amount * item.Value.Quantity
            //        )));
            //}
            display.AppendLine(string.Format("Total price:\t{0:C0}", 
                shoppingCartRepository.items.ToList().Sum(item => item.Value.Product.Amount * item.Value.Quantity))
            );
            System.Console.WriteLine(display.ToString());
        }
    }
}

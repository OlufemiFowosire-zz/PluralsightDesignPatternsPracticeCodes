using ShoppingCart.Business.Models;
using ShoppingCart.Business.Repositories;

namespace ShoppingCart.Business.Commands
{
    public class ChangeQuantityCommand : ICommand
    {
        private Operation operation;
        private IShoppingCartRepository shoppingCartRepository;
        private IProductRepository productRepository;
        private Product product;

        public ChangeQuantityCommand(Operation operation,
            IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository,
            Product product)
        {
            this.operation = operation;
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
            this.product = product;
        }
        public bool CanExecute()
        {
            switch (operation)
            {
                case Operation.Increase:
                    return productRepository.GetStockFor(product.ArticleId) > 0;
                case Operation.Decrease:
                    return shoppingCartRepository.Get(product.ArticleId).Quantity > 0;
            }
            return false;
        }

        public void Execute()
        {
            switch (operation)
            {
                case Operation.Increase:
                    shoppingCartRepository.IncreaseQuantity(product.ArticleId);
                    productRepository.DecreaseStockBy(product.ArticleId, 1);
                    break;
                case Operation.Decrease:
                    shoppingCartRepository.DecreaseQuantity(product.ArticleId);
                    productRepository.IncreaseStockBy(product.ArticleId, 1);
                    break;
            }
        }

        public void Undo()
        {
            switch (operation)
            {
                case Operation.Increase:
                    shoppingCartRepository.DecreaseQuantity(product.ArticleId);
                    productRepository.IncreaseStockBy(product.ArticleId, 1);
                    break;
                case Operation.Decrease:
                    shoppingCartRepository.Add(product);
                    productRepository.DecreaseStockBy(product.ArticleId, 1);
                    break;
            }
        }

        public enum Operation
        {
            Increase,
            Decrease
        }
    }
}

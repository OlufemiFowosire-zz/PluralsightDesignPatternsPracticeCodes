using ShoppingCart.Business.Models;
using ShoppingCart.Business.Repositories;
using System;

namespace ShoppingCart.Business.Commands
{
    public class RemoveFromCartCommand : ICommand
    {
        private IShoppingCartRepository shoppingCartRepository;
        private IProductRepository productRepository;
        private Product product;
        private int qty;

        public RemoveFromCartCommand(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository, Product product)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
            this.product = product;
        }

        public bool CanExecute()
        {
            //if (product == null) return false;
            return shoppingCartRepository.Get(product.ArticleId).Quantity > 0;
        }

        public void Execute()
        {
            //if (product == null) return;
            qty = shoppingCartRepository.Get(product.ArticleId).Quantity;
            productRepository.IncreaseStockBy(product.ArticleId, qty);
            shoppingCartRepository.RemoveAll(product.ArticleId);
        }

        public void Undo()
        {
            //if (product == null) return;
            productRepository.DecreaseStockBy(product.ArticleId, qty);
            shoppingCartRepository.Add(product, qty);
        }
    }
}

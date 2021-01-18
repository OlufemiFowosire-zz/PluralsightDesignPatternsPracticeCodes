using ShoppingCart.Business.Models;
using ShoppingCart.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Business.Commands
{
    public class AddToCartCommand : ICommand
    {
        private IShoppingCartRepository shoppingCartRepository;
        private IProductRepository productRepository;
        private Product product;

        public AddToCartCommand(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository, Product product)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
            this.product = product;
        }
        public bool CanExecute()
        {
            return productRepository.GetStockFor(product.ArticleId) > 0;
        }

        public void Execute()
        {
            productRepository.DecreaseStockBy(product.ArticleId, 1);
            shoppingCartRepository.Add(product);
        }

        public void Undo()
        {
            productRepository.IncreaseStockBy(product.ArticleId, 1);
            shoppingCartRepository.DecreaseQuantity(product.ArticleId);
        }
    }
}

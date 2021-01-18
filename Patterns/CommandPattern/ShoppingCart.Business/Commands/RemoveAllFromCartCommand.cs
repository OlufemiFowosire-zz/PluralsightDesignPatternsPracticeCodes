using Microsoft.Extensions.Caching.Memory;
using ShoppingCart.Business.Models;
using ShoppingCart.Business.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Business.Commands
{
    public class RemoveAllFromCartCommand : ICommand
    {
        private IShoppingCartRepository shoppingCart;
        private IProductRepository productRepository;
        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public RemoveAllFromCartCommand(IShoppingCartRepository shoppingCart, IProductRepository productRepository)
        {
            this.shoppingCart = shoppingCart;
            this.productRepository = productRepository;
        }

        public bool CanExecute()
        {
            return shoppingCart.All().Any();
        }

        public void Execute()
        {
            IList<(Product Product, int Quantity)> data = shoppingCart.All().ToList<(Product Product, int Quantity)>();
            _cache.Set<IList<(Product Product, int Quantity)>>(1, data);
            foreach (var item in data)
            {
                productRepository.IncreaseStockBy(item.Product.ArticleId, item.Quantity);
                shoppingCart.RemoveAll(item.Product.ArticleId);
            }
        }

        public void Undo()
        {
            foreach (var item in _cache.Get<IList<(Product Product, int Quantity)>>(1))
            {
                shoppingCart.Add(item.Product, item.Quantity);
                productRepository.DecreaseStockBy(item.Product.ArticleId, item.Quantity);
            }
        }
    }
}

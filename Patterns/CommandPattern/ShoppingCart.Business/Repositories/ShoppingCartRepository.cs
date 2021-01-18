using ShoppingCart.Business.Models;
using System.Collections.Generic;

namespace ShoppingCart.Business.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        public Dictionary<string, (Product Product, int Quantity)> items { get; }

        public ShoppingCartRepository()
        {
            items = new Dictionary<string, (Product Product, int Quantity)>();
        }
        public void Add(Product product, int qty = 1)
        {
            if (items.ContainsKey(product.ArticleId))
                IncreaseQuantity(product.ArticleId);
            else
                items.Add(product.ArticleId, (product, qty));
        }
        public IEnumerable<(Product Product, int Quantity)> All()
        {
            return items.Values;
        }
        public void IncreaseQuantity(string articleId)
        {
            items[articleId] = (items[articleId].Product, items[articleId].Quantity + 1);
        }

        // TODO CHECK
        public void DecreaseQuantity(string articleId)
        {
            if (items[articleId].Quantity == 1)
                RemoveAll(articleId);
            else
                items[articleId] = (items[articleId].Product, items[articleId].Quantity - 1);
        }
        public (Product Product, int Quantity) Get(string articleId)
        {
            if (!items.ContainsKey(articleId))
                return (default, default);
            return items[articleId];
        }
        public void RemoveAll(string articleId)
        {
            items.Remove(articleId);
        }
    }
}

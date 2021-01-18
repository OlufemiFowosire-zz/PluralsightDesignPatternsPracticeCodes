using LegacyCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCode.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        public Dictionary<string, (Product Product, int Quantity)> items { get; }

        public ShoppingCartRepository()
        {
            items = new Dictionary<string, (Product Product, int Quantity)>();
        }
        public void Add(Product product)
        {
            items.Add(product.ArticleId, (product, 1));
        }

        public void IncreaseQuantity(string articleId)
        {
            items[articleId] = (items[articleId].Product, items[articleId].Quantity + 1);
        }
    }
}

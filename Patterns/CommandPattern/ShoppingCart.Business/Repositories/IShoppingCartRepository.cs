using ShoppingCart.Business.Models;
using System.Collections.Generic;

namespace ShoppingCart.Business.Repositories
{
    public interface IShoppingCartRepository
    {
        void Add(Product product, int qty = 1);
        IEnumerable<(Product Product, int Quantity)> All();
        void IncreaseQuantity(string articleId);
        void DecreaseQuantity(string articleId);
        (Product Product, int Quantity) Get(string articleId);
        void RemoveAll(string articleId);
    }
}

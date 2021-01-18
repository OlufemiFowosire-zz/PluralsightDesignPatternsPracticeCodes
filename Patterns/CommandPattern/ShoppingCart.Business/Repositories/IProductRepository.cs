using ShoppingCart.Business.Models;
using System.Collections.Generic;

namespace ShoppingCart.Business.Repositories
{
    public interface IProductRepository
    {
        void DecreaseStockBy(string articleId, int amount);

        void IncreaseStockBy(string articleId, int amount);

        IEnumerable<Product> All();

        int GetStockFor(string articleId);

        Product FindBy(string articleId);
    }
}

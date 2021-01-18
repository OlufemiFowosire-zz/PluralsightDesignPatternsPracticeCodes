using LegacyCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCode.Repositories
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

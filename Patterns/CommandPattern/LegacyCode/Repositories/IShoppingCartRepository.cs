using LegacyCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCode.Repositories
{
    public interface IShoppingCartRepository
    {
        void Add(Product product);
        void IncreaseQuantity(string articleId);
    }
}

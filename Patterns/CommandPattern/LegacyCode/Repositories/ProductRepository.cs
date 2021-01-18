using LegacyCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCode.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private Dictionary<string, (Product Product, int Stock)> products { get; }

        public ProductRepository()
        {
            products = new Dictionary<string, (Product, int)>();

            AddProduct(new Product("EOSR1", "Canon EOS R", 1099), 2);
            AddProduct(new Product("EOS70D", "Canon EOS 70D", 699), 1);
            AddProduct(new Product("ATOMOSNV", "Atomos Ninja V", 799), 0);
            AddProduct(new Product("SM7B", "Shure SM7B", 399), 5);
        }

        public void AddProduct(Product product, int stock)
        {
            products[product.ArticleId] = (product, stock);
        }

        public void DecreaseStockBy(string articleId, int amount)
        {
            if (!products.ContainsKey(articleId)) return;

            products[articleId] = (products[articleId].Product, products[articleId].Stock - amount);
        }

        public void IncreaseStockBy(string articleId, int amount)
        {
            if (!products.ContainsKey(articleId)) return;

            products[articleId] = (products[articleId].Product, products[articleId].Stock + amount);
        }

        public IEnumerable<Product> All()
        {
            return products.Select(x => x.Value.Product);
        }

        public int GetStockFor(string articleId)
        {
            if (!products.ContainsKey(articleId)) return 0;
            return products[articleId].Stock;
        }

        public Product FindBy(string articleId)
        {
            if (!products.ContainsKey(articleId)) return null;
            return products[articleId].Product;
        }
    }
}

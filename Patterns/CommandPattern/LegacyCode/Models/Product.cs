using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCode.Models
{
    public class Product
    {
        public string ArticleId { get; set; }
        private string article { get; set; }
        public int amount { get; set; }

        public Product(string articleId, string articleTopic, int amount)
        {
            ArticleId = articleId;
            this.article = article;
            this.amount = amount;
        }
    }
}

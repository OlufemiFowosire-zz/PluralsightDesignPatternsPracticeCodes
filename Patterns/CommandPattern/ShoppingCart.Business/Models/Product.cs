namespace ShoppingCart.Business.Models
{
    public class Product
    {
        public string ArticleId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public Product(string articleId, string name, int amount)
        {
            ArticleId = articleId;
            Name = name;
            Amount = amount;
        }
    }
}

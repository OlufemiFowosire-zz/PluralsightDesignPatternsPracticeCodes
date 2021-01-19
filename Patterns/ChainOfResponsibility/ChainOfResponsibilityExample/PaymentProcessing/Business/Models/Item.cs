namespace PaymentProcessing.Business.Models
{
    public class Item
    {
        private string id;
        private string name;
        public decimal Price { get; }

        public Item(string id, string name, decimal price)
        {
            this.id = id;
            this.name = name;
            Price = price;
        }
    }
}
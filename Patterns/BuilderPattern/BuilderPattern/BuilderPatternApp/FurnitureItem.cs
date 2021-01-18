namespace BuilderPatternApp
{
    public class FurnitureItem
    {
        public FurnitureItem(string productName, double price, double height, double width, double weight)
        {
            Name = productName;
            Price = price;
            Height = height;
            Width = width;
            Weight = weight;
        }

        public string Name { get; }
        public double Price { get; }
        public double Height { get; }
        public double Width { get; }
        public double Weight { get; }
    }
}

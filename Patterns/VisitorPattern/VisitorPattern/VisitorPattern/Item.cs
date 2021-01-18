using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern
{
    public class Item
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public Item(int id, double price)
        {
            Id = id;
            Price = price;
        }
        public double GetDiscount(double percentage)
        {
            return Math.Round(Price * percentage, 2);
        }
    }

    public class Book : Item, IVisitableElement
    {
        public Book(int id, double price) : base(id, price)
        {
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitBook(this);
        }
    }
    public class Vinyl : Item, IVisitableElement
    {
        public Vinyl(int id, double price) : base(id, price)
        {
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitVinyl(this);
        }
    }
}

using System;
using System.Collections.Generic;

namespace VisitorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IVisitableElement> items = new List<IVisitableElement>
            {
                new Book(12345, 11.99),
                new Book(78910, 22.79),
                new Vinyl(11198, 17.99),
                new Book(63254, 9.79)
            };

            var cart = new ObjectStructure(items);

            var discounVisitor = new DiscountVisitor();
            var salesVisitor = new SalesVisitor();

            cart.ApplyVisitor(discounVisitor);
            cart.ApplyVisitor(salesVisitor);

            discounVisitor.Reset();
            cart.RemoveItem(items[2]);
            cart.ApplyVisitor(discounVisitor);
        }
    }
}

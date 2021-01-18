using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern
{
    public class ObjectStructure
    {
        private readonly List<IVisitableElement> cart;
        public ObjectStructure(List<IVisitableElement> items)
        {
            cart = items;
        }

        public void RemoveItem(IVisitableElement item)
        {
            cart.Remove(item);
        }
        public void ApplyVisitor(IVisitor visitor)
        {
            Console.WriteLine("\n---------- Visitor Breakdown ----------");
            foreach (var item in cart)
            {
                item.Accept(visitor);
            }

            visitor.Print();
        }
    }
}

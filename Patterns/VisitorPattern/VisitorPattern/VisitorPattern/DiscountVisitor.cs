using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern
{
    public class DiscountVisitor : IVisitor
    {
        private double savings;
        public void Print()
        {
            Console.WriteLine($"\nYou saved a total of {savings} on today's order");
        }

        public void VisitBook(Book book)
        {
            var discount = 0.0;
            if (book.Price > 20.00)
            {
                discount = book.GetDiscount(0.10);
                Console.WriteLine($"DISCOUNTED: Book #{book.Id} is now {Math.Round(book.Price - discount, 2)}");
            }
            else
                Console.WriteLine($"FULL PRICE: Book #{book.Id} is {Math.Round(book.Price, 2)}");
            savings += discount;
        }

        public void VisitVinyl(Vinyl vinyl)
        {
            var discount = vinyl.GetDiscount(0.15);
            Console.WriteLine($"SUPER SAVINGS: Vinyl #{vinyl.Id} is now {Math.Round(vinyl.Price - discount, 2)}");

            savings += discount;
        }

        public void Reset()
        {
            savings = 0.0;
        }
    }
}

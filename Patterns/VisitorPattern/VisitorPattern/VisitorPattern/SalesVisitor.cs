using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern
{
    public class SalesVisitor : IVisitor
    {
        private int bookCount;
        private int vinylCount;
        public void Print()
        {
            Console.WriteLine($"Books sold: {bookCount}\nVinyl sold: {vinylCount}");
            Console.WriteLine($"The store sold {bookCount + vinylCount} units today!");
        }

        public void VisitBook(Book book)
        {
            bookCount++;
        }

        public void VisitVinyl(Vinyl vinyl)
        {
            vinylCount++;
        }

    }
}

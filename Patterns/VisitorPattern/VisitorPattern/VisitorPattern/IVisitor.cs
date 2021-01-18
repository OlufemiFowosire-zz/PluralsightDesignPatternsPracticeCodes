using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern
{
    public interface IVisitor
    {
        void VisitBook(Book book);
        void VisitVinyl(Vinyl vinyl);
        void Print();
    }
}

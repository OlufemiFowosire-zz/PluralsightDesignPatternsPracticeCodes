using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern
{
    public interface IVisitableElement
    {
        void Accept(IVisitor visitor);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityApp.Business.Handlers
{
    public interface IHandler<T>
    {
        IHandler<T> SetNext(IHandler<T> next);
        void Handle();
    }
}

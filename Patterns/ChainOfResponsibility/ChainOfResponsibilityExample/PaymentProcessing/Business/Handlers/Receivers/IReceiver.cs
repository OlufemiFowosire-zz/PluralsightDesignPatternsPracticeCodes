using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Business.Handlers.Receivers
{
    public interface IReceiver<T> where T: class
    {
        void Handle(T request);
    }
}

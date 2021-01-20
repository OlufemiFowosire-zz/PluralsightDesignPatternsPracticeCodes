using PaymentProcessing.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Business.PaymentProcessors
{
    public class PaypalPaymentProcessor : PaymentProcessor
    {
        public override void Finalize(Order order, PaymentProvider paymentProvider)
        {
            base.Finalize(order, paymentProvider);
        }
    }
}

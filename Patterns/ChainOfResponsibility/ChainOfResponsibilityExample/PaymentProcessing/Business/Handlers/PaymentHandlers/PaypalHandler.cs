using PaymentProcessing.Business.Models;
using PaymentProcessing.Business.PaymentProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Business.Handlers.PaymentHandlers
{
    public class PaypalHandler : PaymentHandler
    {
        private IPaymentProcessor paymentProcessor= new PaypalPaymentProcessor();

        public override void Handle(Order order)
        {
            if(order.SelectedPayments.Any(payment => payment.PaymentProvider == PaymentProvider.Paypal))
            {
                paymentProcessor.Finalize(order);
            }
            base.Handle(order);
        }
    }
}

using PaymentProcessing.Business.Handlers.Receivers;
using PaymentProcessing.Business.Models;
using PaymentProcessing.Business.PaymentProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Business.Handlers.PaymentHandlers
{
    public class PaypalHandler : IReceiver<Order>
    {
        private PaymentProcessor paymentProcessor= new PaypalPaymentProcessor();

        public void Handle(Order order)
        {
            if (!order.SelectedPayments.Any(payment => payment.PaymentProvider == PaymentProvider.Paypal)) return;
            
            paymentProcessor.Finalize(order, PaymentProvider.Paypal);
        }
    }
}

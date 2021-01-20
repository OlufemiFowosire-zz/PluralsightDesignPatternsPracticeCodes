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
    public class CreditCardHandler : IReceiver<Order>
    {
        private PaymentProcessor paymentProcessor = new CreditCardPaymentProcessor();

        public void Handle(Order order)
        {
            if (!order.SelectedPayments.Any(payment => payment.PaymentProvider == PaymentProvider.CreditCard)) return;
            
            paymentProcessor.Finalize(order, PaymentProvider.CreditCard);
        }
    }
}

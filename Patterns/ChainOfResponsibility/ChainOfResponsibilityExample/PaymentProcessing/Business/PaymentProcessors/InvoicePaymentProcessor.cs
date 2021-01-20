using PaymentProcessing.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Business.PaymentProcessors
{
    public class InvoicePaymentProcessor : PaymentProcessor
    {
        public override void Finalize(Order order, PaymentProvider paymentProvider)
        {
            // TODO: Create an invoice and email it while also ensuring validation of the details

            base.Finalize(order, paymentProvider);
        }
    }
}

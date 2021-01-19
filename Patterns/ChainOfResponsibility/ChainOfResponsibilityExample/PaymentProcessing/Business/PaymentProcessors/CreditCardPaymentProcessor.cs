﻿using PaymentProcessing.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Business.PaymentProcessors
{
    public class CreditCardPaymentProcessor : IPaymentProcessor
    {
        public void Finalize(Order order)
        {
            var payment = order.SelectedPayments
                .FirstOrDefault(payment => payment.PaymentProvider == PaymentProvider.CreditCard);

            if (payment == null) return;

            order.FinalizedPayments.Add(payment);
        }
    }
}

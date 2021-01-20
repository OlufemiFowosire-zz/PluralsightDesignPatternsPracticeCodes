using PaymentProcessing.Business.Models;
using System.Linq;

namespace PaymentProcessing.Business.PaymentProcessors
{
    public abstract class PaymentProcessor
    {
        private decimal amountPaid;
        public virtual void Finalize(Order order, PaymentProvider paymentProvider)
        {
            var payment = order.SelectedPayments.FirstOrDefault(payment => payment.PaymentProvider == paymentProvider);

            if (payment == null) return;

            if (payment.Amount >= order.AmountDue)
            {
                payment.Amount -= order.AmountDue;
                amountPaid = order.AmountDue;
            }
            else
            {
                amountPaid = payment.Amount;
                payment.Amount = 0;
            }
            payment = new Payment { Amount = amountPaid, PaymentProvider = paymentProvider };
            order.FinalizedPayments.Add(payment);
        }
    }
}

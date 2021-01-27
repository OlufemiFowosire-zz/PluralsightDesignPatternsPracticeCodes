using PaymentProcessing.Business.Exceptions;
using PaymentProcessing.Business.Handlers.Receivers;
using PaymentProcessing.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Business.Handlers
{
    public class PaymentHandler
    {
        private IList<IReceiver<Order>> receivers;

        public PaymentHandler(params IReceiver<Order>[] receivers)
        {
            this.receivers = receivers;
        }
        public void Handle(Order order)
        {
            foreach (var receiver in receivers)
            {
                Console.WriteLine($"Running: {receiver.GetType().Name}");
                if (order.AmountDue > 0)
                {
                    receiver.Handle(order);
                }
                else
                {
                    break;
                }
            }
            if(order.AmountDue > 0)
            {
                throw new InsufficientPaymentException("Insufficient balance!");
            }
            else
            {
                // In real-world scenario, You change your shipping status
                // by adding a record in your database to say that the status of the order
                // has now changed so that someone else can take care of that
                order.ShippingStatus = ShippingStatus.ReadyForShippment;
            }
        }

        public void AddProvider(IReceiver<Order> next)
        {
            receivers.Add(next);
        }

        public void ClearProviders()
        {
            receivers.Clear();
        }
    }
}

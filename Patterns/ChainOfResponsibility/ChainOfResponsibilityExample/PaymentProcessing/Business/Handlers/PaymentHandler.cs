using PaymentProcessing.Business.Exceptions;
using PaymentProcessing.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Business.Handlers
{
    public abstract class PaymentHandler : IHandler<Order>
    {
        private IHandler<Order> next;
        public virtual void Handle(Order order)
        {
            Console.WriteLine($"Running: {GetType().Name}");
            if(next == null && order.AmountDue > 0)
            {
                throw new InsufficientPaymentException("Insufficient balance!");
            }
            if(order.AmountDue > 0)
            {
                next.Handle(order);
            }
            else
            {
                // In real-world scenario, You change your shipping status
                // by adding a record in your database to say that the status of the order
                // has now changed so that someone else can take care of that
                order.ShippingStatus = ShippingStatus.ReadyForShippment;
            }
        }

        public IHandler<Order> SetNext(IHandler<Order> next)
        {
            this.next = next;

            return next;
        }
    }
}

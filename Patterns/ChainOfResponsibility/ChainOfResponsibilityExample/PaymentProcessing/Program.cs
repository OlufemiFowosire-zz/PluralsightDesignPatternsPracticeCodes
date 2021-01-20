using PaymentProcessing.Business.Exceptions;
using PaymentProcessing.Business.Handlers.PaymentHandlers;
using PaymentProcessing.Business.Models;
using System;

namespace PaymentProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();
            order.LineItems.Add(new Item("ATOMOSV", "Atomos Ninja V", 499), 2);
            order.LineItems.Add(new Item("EOSR", "Canon EOS R", 1799), 1);

            order.SelectedPayments.Add(new Payment 
            {
                PaymentProvider = PaymentProvider.Paypal,
                Amount = 1000
            });
            order.SelectedPayments.Add(new Payment
            {
                PaymentProvider = PaymentProvider.Invoice,
                Amount = 1797
            });

            
            Console.WriteLine($"Order Total: {order.AmountDue}");
            Console.WriteLine($"Shipping Status: {order.ShippingStatus.GetDescription()}");

            var handler = new PaypalHandler();
            handler.SetNext(new CreditCardHandler())
                   .SetNext(new InvoiceHandler());
            try
            {
                handler.Handle(order);
            }
            catch (InsufficientPaymentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine($"Amount Due: {order.AmountDue}");
                Console.WriteLine($"Shipping Status: {order.ShippingStatus.GetDescription()}");
            }
        }
    }
}

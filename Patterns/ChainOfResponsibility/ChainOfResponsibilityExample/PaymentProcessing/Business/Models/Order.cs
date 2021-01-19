using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Business.Models
{
    public class Order
    {
        public List<Payment> SelectedPayments { get; } = new List<Payment>();
        public List<Payment> FinalizedPayments { get; } = new List<Payment>();
        public Dictionary<Item, int> LineItems { get; } = new Dictionary<Item, int>();
        public decimal AmountDue => LineItems.Sum(item => item.Key.Price * item.Value) - FinalizedPayments.Sum(payment => payment.Amount);
        public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.WaitingForPayment;
    }
}

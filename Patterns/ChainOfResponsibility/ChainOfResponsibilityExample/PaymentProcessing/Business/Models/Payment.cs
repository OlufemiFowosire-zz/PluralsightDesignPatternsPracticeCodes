namespace PaymentProcessing.Business.Models
{
    public class Payment
    {
        public PaymentProvider PaymentProvider { get; internal set; }
        public decimal Amount { get; internal set; }
    }
}
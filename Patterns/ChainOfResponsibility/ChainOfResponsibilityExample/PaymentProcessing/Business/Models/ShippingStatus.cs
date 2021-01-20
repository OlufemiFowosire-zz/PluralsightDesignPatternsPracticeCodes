using System.ComponentModel;

namespace PaymentProcessing.Business.Models
{
    public enum ShippingStatus
    {
        [Description("Waiting for payment")]
        WaitingForPayment,

        [Description("Ready for shipment")]
        ReadyForShippment,

        Shipped
    }
}
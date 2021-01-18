namespace Factory_Pattern_First_Look.Business.Models.Shipping.Factories
{
    public class GlobalExpressShippingProviderFactory : ShippingProviderFactory
    {
        protected override ShippingProvider CreateShippingProvider(string country)
        {
            return new GlobalExpressShippingProvider();
        }
    }
}

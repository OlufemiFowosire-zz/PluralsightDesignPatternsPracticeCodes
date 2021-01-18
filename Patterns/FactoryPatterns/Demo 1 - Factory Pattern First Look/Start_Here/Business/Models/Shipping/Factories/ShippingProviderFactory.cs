namespace Factory_Pattern_First_Look.Business.Models.Shipping.Factories
{
    public abstract class ShippingProviderFactory
    {
        protected abstract ShippingProvider CreateShippingProvider(string country);
        public ShippingProvider GetShippingProvider(string country)
        {
            return CreateShippingProvider(country);
        }
    }
}

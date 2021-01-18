using StrategyPatternFirstLook.Business.Strategies.Invoice;
using StrategyPatternFirstLook.Business.Strategies.SalesTax;
using StrategyPatternFirstLook.Business.Strategies.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternFirstLook.OrderStrategyFactory
{
    public sealed class OrderStrategyFactoryImpl : OrderStrategyFactory
    {
        private readonly Dictionary<int, IInvoiceStrategy> invoiceStrategies;
        private readonly Dictionary<string, ISalesTaxStrategy> salesTaxStrategies;
        private readonly Dictionary<int, IShippingStrategy> shippingStrategies;
        private readonly static OrderStrategyFactory instance = new OrderStrategyFactoryImpl();
        public static OrderStrategyFactory Instance => instance;
        private OrderStrategyFactoryImpl()
        {
            invoiceStrategies = new Dictionary<int, IInvoiceStrategy>
            {
                { 1, new FileInvoiceStrategy()},
                { 2, new EmailInvoiceStrategy()},
                { 3, new PrintOnDemandInvoiceStrategy() }
            };
            salesTaxStrategies = new Dictionary<string, ISalesTaxStrategy> 
            {
                { "sweden", new SwedenSalesTaxStrategy()},
                { "usa", new USASalesTaxStrategy() }
            };
            shippingStrategies = new Dictionary<int, IShippingStrategy>
            {
                { 1, new NipostShippingStrategy() },
                { 2, new DhlShippingStrategy() },
                { 3, new UnitedStatesPostalServiceShippingStrategy() },
                { 4, new FedexShippingStrategy() },
                { 5, new UpsShippingStrategy() }
            };
        }
        public IInvoiceStrategy CreateInvoiceStrategy(int invoiceOption)
        { 
            return invoiceStrategies.ContainsKey(invoiceOption) ? invoiceStrategies[invoiceOption] : new NoInvoiceStrategy();
        }

        public ISalesTaxStrategy CreateSalesTaxStrategy(string destination)
        {
            return salesTaxStrategies.ContainsKey(destination) ? salesTaxStrategies[destination] : new NoSalesTaxStrategy();
        }

        public IShippingStrategy CreateShippingStrategy(int provider)
        {
            return shippingStrategies.ContainsKey(provider) ? shippingStrategies[provider] : new NoShippingStrategy();
        }
    }
}

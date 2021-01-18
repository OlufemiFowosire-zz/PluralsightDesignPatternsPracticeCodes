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
    public interface OrderStrategyFactory
    {
        ISalesTaxStrategy CreateSalesTaxStrategy(string destination);
        IInvoiceStrategy CreateInvoiceStrategy(int invoiceOption);
        IShippingStrategy CreateShippingStrategy(int provider);
    }
}

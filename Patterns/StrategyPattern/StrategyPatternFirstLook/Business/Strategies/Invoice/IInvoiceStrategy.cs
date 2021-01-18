using StrategyPatternFirstLook.Business.Models;

namespace StrategyPatternFirstLook.Business.Strategies.Invoice
{
    public interface IInvoiceStrategy
    {
        bool Generate(Order order);
    }
}

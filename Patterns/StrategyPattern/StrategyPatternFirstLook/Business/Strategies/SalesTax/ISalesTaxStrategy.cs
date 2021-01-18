using StrategyPatternFirstLook.Business.Models;

namespace StrategyPatternFirstLook.Business.Strategies.SalesTax
{
    public interface ISalesTaxStrategy
    {
        decimal GetTax(Order order);
    }
}

using StrategyPatternFirstLook.Business.Models;

namespace StrategyPatternFirstLook.Business.Strategies.Shipping
{
    public interface IShippingStrategy
    {
        void Ship(Order order);
    }
}

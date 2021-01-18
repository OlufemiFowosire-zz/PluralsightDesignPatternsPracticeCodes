using StrategyPatternFirstLook.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternFirstLook.Business.Strategies.Shipping
{
    public class NoShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            
        }
    }
}

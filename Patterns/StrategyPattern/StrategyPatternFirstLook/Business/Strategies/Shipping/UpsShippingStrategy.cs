using StrategyPatternFirstLook.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternFirstLook.Business.Strategies.Shipping
{
    public class UpsShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            using (var client = new HttpClient())
            {
                /// TODO: Implement UPS shipping Integration

                Console.WriteLine("Order is shipped with UPS");
            }
        }
    }
}

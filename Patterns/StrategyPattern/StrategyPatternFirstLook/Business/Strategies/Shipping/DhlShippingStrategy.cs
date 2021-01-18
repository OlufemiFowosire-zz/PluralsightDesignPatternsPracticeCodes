using StrategyPatternFirstLook.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternFirstLook.Business.Strategies.Shipping
{
    public class DhlShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            using (var client = new HttpClient())
            {
                /// TODO: Implement DHL shipping Integration

                Console.WriteLine("Order is shipped with DHL");
            }
        }
    }
}

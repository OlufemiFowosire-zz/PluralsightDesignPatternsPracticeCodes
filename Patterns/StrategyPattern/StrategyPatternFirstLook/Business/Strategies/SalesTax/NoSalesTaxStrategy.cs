using StrategyPatternFirstLook.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternFirstLook.Business.Strategies.SalesTax
{
    public class NoSalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTax(Order order)
        {
            throw new NotImplementedException("Tax Unavailable");
        }
    }
}

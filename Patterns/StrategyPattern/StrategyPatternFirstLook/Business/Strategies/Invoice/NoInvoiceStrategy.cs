using StrategyPatternFirstLook.Business.Models;
using StrategyPatternFirstLook.Business.Strategies.SalesTax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternFirstLook.Business.Strategies.Invoice
{
    public class NoInvoiceStrategy : InvoiceStrategy
    {
        public override bool Generate(Order order)
        {
            return false;
        }
    }
}

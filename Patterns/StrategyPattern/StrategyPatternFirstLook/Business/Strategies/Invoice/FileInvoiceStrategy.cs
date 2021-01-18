using StrategyPatternFirstLook.Business.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternFirstLook.Business.Strategies.Invoice
{
    public class FileInvoiceStrategy : InvoiceStrategy
    {
        public override bool Generate(Order order)
        {
            var success = false;
            using (StreamWriter stream = new StreamWriter($"invoice_{Guid.NewGuid()}.txt"))
            {
                stream.WriteLine(GenerateTextInvoice(order));
                stream.Flush();
                success = true;
            }
            return success;
        }
    }
}

using Newtonsoft.Json;
using StrategyPatternFirstLook.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternFirstLook.Business.Strategies.Invoice
{
    public class PrintOnDemandInvoiceStrategy : IInvoiceStrategy
    {
        public bool Generate(Order order)
        {
            var success = false;
            using (var client = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(order);

                client.BaseAddress = new Uri("https://pluralsight.com");

                client.PostAsync("/print-on-demand", new StringContent(content));
                success = true;
            }
            return success;
        }
    }
}

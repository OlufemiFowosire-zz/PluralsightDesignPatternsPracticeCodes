using StrategyPatternFirstLook.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternFirstLook.Business.Strategies.Invoice
{
    public class EmailInvoiceStrategy : InvoiceStrategy
    {
        public override bool Generate(Order order)
        {
            var body = GenerateTextInvoice(order);
            var success = false;
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                NetworkCredential credentials = new NetworkCredential("olufemifowosire@gmail.com", "NewSeason__123");
                client.Credentials = credentials;
                client.EnableSsl = true;
                MailMessage message = new MailMessage("olufemifowosire@gmail.com", "predestination2004@yahoo.com")
                {
                    Subject = $"Order Invoice: {order.ShippingDetails.Receiver}",
                    Body = body
                };
                client.Send(message);
                success = true;
            }
            return success;
        }
    }
}

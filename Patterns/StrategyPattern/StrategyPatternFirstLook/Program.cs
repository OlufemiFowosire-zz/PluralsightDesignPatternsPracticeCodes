using StrategyPatternFirstLook.Business.Models;
using StrategyPatternFirstLook.Business.Strategies.Invoice;
using StrategyPatternFirstLook.Business.Strategies.SalesTax;
using StrategyPatternFirstLook.Business.Strategies.Shipping;
using StrategyPatternFirstLook.OrderStrategyFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternFirstLook
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Input
            Console.WriteLine("Please select an origin country: ");
            var origin = Console.ReadLine().Trim().ToLowerInvariant();

            Console.WriteLine("Please select a destination country: ");
            var destination = Console.ReadLine().Trim().ToLowerInvariant();

            Console.WriteLine("Choose one of the following shipping providers: ");
            Console.WriteLine("1. NIPOST (Nigerian Postal Service)");
            Console.WriteLine("2. DHL");
            Console.WriteLine("3. USPS");
            Console.WriteLine("4. Fedex");
            Console.WriteLine("5. UPS");
            Console.WriteLine("Select shipping provider: ");
            int provider = Convert.ToInt32(Console.ReadLine().Trim());

            Console.WriteLine("Choose one of the following invoice delivery options: ");
            Console.WriteLine("1. File (download later)");
            Console.WriteLine("2. Email");
            Console.WriteLine("3. Print-on-demand");
            Console.WriteLine("Select invoice delivery option: ");
            var invoiceOption = Convert.ToInt32(Console.ReadLine().Trim());

            #endregion
            var order = new Order()
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = origin,
                    DestinationCountry = destination,
                    DestinationState = "la"
                },
                SalesTaxStrategy = GetSalesTaxStrategyFor(destination),
                InvoiceStrategy = GetInvoiceStrategyFor(invoiceOption),
                ShippingStrategy = GetShippingStrategyFor(provider)
            };

            order.SelectedPayments.Add(
                new Payment()
                {
                    PaymentProvider = PaymentProvider.Invoice,
                    Amount = 0
                }
            );

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m, ItemType.Service), 1);
            string output;
            try
            {
                output = order.GetTax().ToString();
                order.Finalize();
            }
            catch (NotImplementedException ex)
            {
                output = ex.Message;
            }
            
            Console.WriteLine(output);
            Console.ReadKey();
        }
        private static ISalesTaxStrategy GetSalesTaxStrategyFor(string destination)
        {
            return OrderStrategyFactoryImpl.Instance.CreateSalesTaxStrategy(destination);
        }
        private static IShippingStrategy GetShippingStrategyFor(int provider)
        {
            return OrderStrategyFactoryImpl.Instance.CreateShippingStrategy(provider);
        }
        private static IInvoiceStrategy GetInvoiceStrategyFor(int invoiceOption)
        {
            return OrderStrategyFactoryImpl.Instance.CreateInvoiceStrategy(invoiceOption);
        }

        /*#region Sorting Practice
        static void Main(string[] args)
        {
            var orders = new[] {
                new Order()
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "Sweden",
                        DestinationCountry = "Sweden"
                    }
                },
                new Order()
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "Sweden",
                        DestinationCountry = "USA"
                    }
                },
                new Order()
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "Sweden",
                        DestinationCountry = "Nigeria"
                    }
                },
                new Order()
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "Sweden",
                        DestinationCountry = "Singapore"
                    }
                }
            };
            orders[0].LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);
            orders[1].LineItems.Add(new Item("CONSULTING", "Building a website", 10m, ItemType.Service), 1);
            orders[2].LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 1100m, ItemType.Literature), 1);
            orders[3].LineItems.Add(new Item("CONSULTING", "Building a website", 1m, ItemType.Service), 1);
            print(orders);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Sorting...");
            Console.WriteLine();
            Console.WriteLine();

            Array.Sort(orders, new OrderAmountComparer());

            print(orders);

            Console.ReadLine();
        }
        private static void print(Order[] orders) 
        {
            foreach (var order in orders)
            {
                Console.WriteLine($"{order.ShippingDetails.DestinationCountry}     \t{order.TotalPrice}");
            }
        }
        #endregion

        public class OrderAmountComparer : IComparer<Order>
        {
            public int Compare(Order x, Order y)
            {
                return x.TotalPrice.CompareTo(y.TotalPrice);
            }
        }
        public class OrderOriginComparer : IComparer<Order>
        {
            public int Compare(Order x, Order y)
            {
                return x.ShippingDetails.DestinationCountry.CompareTo(y.ShippingDetails.DestinationCountry);
            }
        }*/
    }
}

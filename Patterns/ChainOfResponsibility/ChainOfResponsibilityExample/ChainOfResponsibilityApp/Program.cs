using ChainOfResponsibilityApp.Business;
using ChainOfResponsibilityApp.Business.Models;
using System;
using System.Globalization;

namespace ChainOfResponsibilityApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User("Olufemi Fowosire",
                "870101XXXX",
                new RegionInfo("SE"),
                new DateTimeOffset(1987, 01, 29, 00, 00, 00,
                TimeSpan.FromHours(2)));

            var processor = new UserProcessor();

            var result = processor.Register(user);

            Console.WriteLine(result);
        }
    }
}

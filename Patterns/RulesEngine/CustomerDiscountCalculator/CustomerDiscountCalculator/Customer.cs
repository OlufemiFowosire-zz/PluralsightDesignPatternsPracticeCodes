using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerDiscountCalculator
{
    public class Customer
    {
        public DateTime? DateOfFirstPurchase { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsVeteran { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CustomerDiscountCalculator
{
    public class DiscountRuleEngine
    {
        List<IDiscountRule> rules = new List<IDiscountRule>();
        public DiscountRuleEngine(IEnumerable<IDiscountRule> rules)
        {
            this.rules.AddRange(rules);
        }

        public decimal CalculateDiscountPercentage(Customer customer)
        {
            decimal discount = 0;
            foreach (var rule in rules)
            {
                discount = Math.Max(discount, rule.CalculateDiscount(customer, discount));
            }

            return discount;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerDiscountCalculator
{
    public class DiscountCalculator
    {
        public decimal CalculateDiscountPercentage(Customer customer)
        {
            //var rules = new List<IDiscountRule>();
            //rules.Add(new FirstTimeCustomerRule());
            //rules.Add(new LoyalCustomerRule());
            //rules.Add(new VeteranRule());
            //rules.Add(new SeniorsRule());
            //rules.Add(new BirthdayRule());

            // Important your rules are stateless to use reflection
            var ruleType = typeof(IDiscountRule);

            IEnumerable<IDiscountRule> rules = this.GetType().Assembly.GetTypes()
                .Where(p => ruleType.IsAssignableFrom(p) && !p.IsInterface && p != typeof(BirthdayRule))
                .Select(r => Activator.CreateInstance(r) as IDiscountRule);
            rules = rules.Append(Activator.CreateInstance(typeof(BirthdayRule)) as IDiscountRule);

            var engine = new DiscountRuleEngine(rules);

            return engine.CalculateDiscountPercentage(customer);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class RuleEngine
    {
        private readonly List<RuleBase> rules;
        private RuleEngine(List<RuleBase> rules)
        {
            this.rules = rules;
            //rules = new List<RuleBase>();
            //rules.Add(new BackstagePassesRule());
            //rules.Add(new ConjuredItemRule());
            //rules.Add(new AgedBrieRule());
            //rules.Add(new SulfurasRule());
            //rules.Add(new NormalItemRule());
        }
        
        public void ApplyRule(ItemProxy item)
        {
            foreach (var rule in rules)
            {
                if (rule.IsMatch(item))
                {
                    rule.Update(item);
                    break;
                }
            }
        }

        public class Builder
        {
            private List<RuleBase> builderRules = new List<RuleBase>();
            public Builder()
            {
                this.WithAgedBrieRule()
                    .WithBackstagePassesRule()
                    .WithConjuredItemRule()
                    .WithSulfurasRule();
            }

            private Builder WithAgedBrieRule()
            {
                builderRules.Add(new AgedBrieRule());
                return this;
            }

            private Builder WithSulfurasRule()
            {
                builderRules.Add(new SulfurasRule());
                return this;
            }

            private Builder WithConjuredItemRule()
            {
                builderRules.Add(new ConjuredItemRule());
                return this;
            }

            private Builder WithBackstagePassesRule()
            {
                builderRules.Add(new BackstagePassesRule());
                return this;
            }

            internal RuleEngine Build()
            {
                builderRules.Add(new NormalItemRule());
                return new RuleEngine(builderRules);
            }
        }
    }
}

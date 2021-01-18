using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GildedRose.Console.RuleEngine;

namespace GildedRose.Console
{
    public class GildedRose
    {
        private readonly List<Item> Items;
        public GildedRose(List<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                UpdateQuality(new ItemProxy(Items[i]));
            }
        }
       
        public void UpdateQuality(ItemProxy item)
        {
            var ruleEngine = new Builder().Build();
            ruleEngine.ApplyRule(item);
        }
    }
}

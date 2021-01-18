using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class SulfurasRule : RuleBase
    {
        public override void AdjustQuality(ItemProxy item)
        {
        }

        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        public override void AdjustSellIn(ItemProxy item)
        {
        }
    }
}

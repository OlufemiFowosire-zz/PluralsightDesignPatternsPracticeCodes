using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class BackstagePassesRule : RuleBase
    {
        public override void AdjustQuality(ItemProxy item)
        {
            item.IncrementQuality();
            if (item.SellIn < 11)
                item.IncrementQuality();
            if (item.SellIn < 6)
                item.IncrementQuality();
            if (item.SellIn <= 0)
            {
                item.ResetQuality();
            }
        }

        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }
    }
}

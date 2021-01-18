using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public abstract class RuleBase
    {
        public abstract bool IsMatch(ItemProxy item);
        public void Update(ItemProxy item)
        {
            AdjustQuality(item);
            AdjustSellIn(item);
            if (item.SellIn < 0)
                AdjustQuality(item);
        }

        public abstract void AdjustQuality(ItemProxy item);
        public virtual void AdjustSellIn(ItemProxy item)
        {
            item.DecrementSellIn();
        }
    }
}

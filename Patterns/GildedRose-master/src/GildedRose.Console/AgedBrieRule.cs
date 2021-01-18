using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class AgedBrieRule : RuleBase
    {
        public override void AdjustQuality(ItemProxy item)
        {
            item.IncrementQuality();
        }

        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Aged Brie";
        }
    }
}

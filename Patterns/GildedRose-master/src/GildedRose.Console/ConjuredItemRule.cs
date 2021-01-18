using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class ConjuredItemRule : RuleBase
    {
        public override void AdjustQuality(ItemProxy item)
        {
            item.DecrementQuality();
            item.DecrementQuality();
        }

        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Conjured Mana Cake";
        }
    }
}

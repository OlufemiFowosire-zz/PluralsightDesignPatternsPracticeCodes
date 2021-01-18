using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class ItemProxy
    {
        private Item item;
        public ItemProxy(Item item)
        {
            this.item = item;
        }

        public string Name => item.Name;
        public int SellIn => item.SellIn;
        public int Quality => item.Quality;

        public void IncrementQuality()
        {
            if(item.Quality < 50)
            {
                item.Quality++;
            }
        }
        public void DecrementQuality()
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }
        public void ResetQuality()
        {
            item.Quality = 0;
        }
        public void DecrementSellIn()
        {
            item.SellIn--;
        }
    }
}

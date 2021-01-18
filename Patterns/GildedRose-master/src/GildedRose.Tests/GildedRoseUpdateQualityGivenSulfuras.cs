using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseUpdateQualityGivenSulfuras
    {
        private List<Item> items = new List<Item>();
        private Item item;
        private GildedRose.Console.GildedRose service;
        private const int INITIAL_QUALITY = 80;
        private const int INITIAL_SELL_IN = 0;

        public GildedRoseUpdateQualityGivenSulfuras()
        {
            service = new GildedRose.Console.GildedRose(items);
            item = GetSulfuras();
            items.Add(item);
        }

        private Item GetSulfuras()
        {
            return new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Fact]
        public void DoesNotIncreaseQualityGivenPositiveSellIn()
        {
            service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY, item.Quality);
        }

        [Fact]
        public void DoesNotIncreaseQualityGivenNonPositiveSellIn()
        {
            item.SellIn = -1;
            service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY, item.Quality);
        }

        [Fact]
        public void DoesNotReduceSell()
        {
            service.UpdateQuality();

            Assert.Equal(INITIAL_SELL_IN, item.SellIn);
        }
    }
}

using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseUpdateQualityGivenConjuredItem
    {
        private List<Item> items = new List<Item>();
        private Item item;
        private GildedRose.Console.GildedRose _service;
        private const int INITIAL_QUALITY = 10;
        private const int INITIAL_SELL_IN = 20;

        public GildedRoseUpdateQualityGivenConjuredItem()
        {
            _service = new GildedRose.Console.GildedRose(items);
            item = GetConjuredItem();
            items.Add(item);
        }

        private Item GetConjuredItem()
        {
            return new Item { Name = "Conjured Mana Cake", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Fact]
        public void ReducesConjuredItemQualityBy2GivenPositiveSellIn()
        {
            _service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY - 2, item.Quality);
        }

        [Fact]
        public void ReducesConjuredItemQualityBy4GivenNonPositiveSellIn()
        {
            item.SellIn = 0;
            _service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY - 4, item.Quality);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        public void DoesNotReduceQualityBelowZero(int initialQuality)
        {
            item.Quality = initialQuality;
            _service.UpdateQuality();

            Assert.Equal(0, item.Quality);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        [InlineData(0)]
        public void DoesNotReduceQualityBelowZeroGivenNonPositiveSellIn(int initialQuality)
        {
            item.SellIn = 0;
            item.Quality = initialQuality;
            _service.UpdateQuality();

            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void ReducesConjuredItemSellInBy1()
        {
            _service.UpdateQuality();

            Assert.Equal(INITIAL_SELL_IN - 1, item.SellIn);
        }

        [Fact]
        public void DoesReduceSellInBelowZero()
        {
            item.SellIn = 0;
            _service.UpdateQuality();

            Assert.Equal(-1, item.SellIn);
        }
    }
}

using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseUpdateQualityGivenNormalItem
    {
        private List<Item> items = new List<Item>();
        private Item item;
        private GildedRose.Console.GildedRose _service;
        private const int INITIAL_QUALITY = 10;
        private const int INITIAL_SELL_IN = 20;

        public GildedRoseUpdateQualityGivenNormalItem()
        {
            _service = new GildedRose.Console.GildedRose(items);
            item = GetNormalItem();
            items.Add(item);
        }

        private Item GetNormalItem()
        {
            return new Item { Name = "Normal Item", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Fact]
        public void ReducesNormalItemQualityBy1GivenPositiveSellIn()
        {
            _service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY - 1, item.Quality);
        }

        [Fact]
        public void ReducesNormalItemQualityBy2GivenNonPositiveSellIn()
        {
            item.SellIn = 0;
            _service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY - 2, item.Quality);
        }

        [Fact]
        public void DoesNotReduceQualityBelowZero()
        {
            item.Quality = 0;
            _service.UpdateQuality();

            Assert.Equal(0, item.Quality);
        }

        [Theory]
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
        public void ReducesNormalItemSellInBy1()
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

using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseUpdateQualityGivenAgedBrie
    {
        private List<Item> items = new List<Item>();
        private Item item;
        private GildedRose.Console.GildedRose service;
        private const int INITIAL_QUALITY = 10;
        private const int INITIAL_SELL_IN = 20;

        public GildedRoseUpdateQualityGivenAgedBrie()
        {
            service = new GildedRose.Console.GildedRose(items);
            item = GetAgedBrie();
            items.Add(item);
        }

        private Item GetAgedBrie()
        {
            return new Item { Name = "Aged Brie", Quality = INITIAL_QUALITY, SellIn = INITIAL_SELL_IN };
        }

        [Fact]
        public void IncreasesAgedBrieQualityBy1GivenPositiveSellIn()
        {
            service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY + 1, item.Quality);
        }

        [Fact]
        public void IncreasesAgedBrieQualityBy2GivenNonPositiveSellIn()
        {
            item.SellIn = 0;
            service.UpdateQuality();

            Assert.Equal(INITIAL_QUALITY + 2, item.Quality);
        }

        [Fact]
        public void DoesNotIncreaseQualityBeyond50()
        {
            item.Quality = 50;
            service.UpdateQuality();

            Assert.Equal(50, item.Quality);
        }

        [Theory]
        [InlineData(48)]
        [InlineData(49)]
        [InlineData(50)]
        public void DoesNotIncreaseQualityAbove50GivenNonPositiveSellIn(int initialQuality)
        {
            item.SellIn = 0;
            item.Quality = initialQuality;
            service.UpdateQuality();

            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void ReducesAgedBrieSellInBy1()
        {
            service.UpdateQuality();

            Assert.Equal(INITIAL_SELL_IN - 1, item.SellIn);
        }

        [Fact]
        public void DoesReduceSellInBelowZero()
        {
            item.SellIn = 0;
            service.UpdateQuality();

            Assert.Equal(-1, item.SellIn);
        }
    }
}

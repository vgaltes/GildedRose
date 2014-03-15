using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;
using FluentAssertions;

namespace GildedRose.Tests
{
    [TestFixture]
    public class TestAssemblyTests
    {
        Program program = new Program();

        [Test]
        public void AtTheEndOfEachDayTheSystemLowersSellInByOne()
        {
            var item = CreateItem(sellIn: 20);

            program.UpdateQuality(new List<Item> { item });

            item.SellIn.Should().Be(19);
        }

        [Test]
        public void AtTheEndOfEachDayTheSystemLowersQualityInByOne()
        {
            var item = CreateItem(quality: 20);

            program.UpdateQuality(new List<Item> { item });

            item.Quality.Should().Be(19);
        }

        [Test]
        public void OnceTheSellByDateHasPassedQualityDegradesTwiceAsFast()
        {
            var item = CreateItem(sellIn: 0, quality: 20);

            program.UpdateQuality(new List<Item> { item });

            item.Quality.Should().Be(18);        
        }

        [Test]
        public void TheQualityOfAnItemIsNeverNegative()
        {
            var item = CreateItem(quality: 0);

            program.UpdateQuality(new List<Item> { item });

            item.Quality.Should().Be(0);
        }

        [Test]
        public void AgedBrieIncreasesQualityByOneTheOlderItGets()
        {
            var item = CreateItem(name: "Aged Brie", quality: 20);

            program.UpdateQuality(new List<Item> { item });

            item.Quality.Should().Be(21);
        }

        [Test]
        public void TheQualityOfAnItemIsNeverMoreThan50()
        {
            var item = CreateItem(name: "Aged Brie", quality: 50);

            program.UpdateQuality(new List<Item> { item });

            item.Quality.Should().Be(50);
        }

        [Test]
        public void LegendaryItemsNeverDecreasesSellIn()
        {
            var item = CreateItem(name: "Sulfuras, Hand of Ragnaros", sellIn: 50);

            program.UpdateQuality(new List<Item> { item });

            item.SellIn.Should().Be(50);
        }

        [Test]
        public void LegendaryItemsNeverDecreasesQuality()
        {
            var item = CreateItem(name: "Sulfuras, Hand of Ragnaros", quality: 50);

            program.UpdateQuality(new List<Item> { item });

            item.Quality.Should().Be(50);
        }

        [Test]
        public void BackstagePassesDecreaesQualityByOneIfSellInIsGreaterThan10()
        {
            var item = CreateItem(name: "Backstage Passes", quality: 50, sellIn:11);

            program.UpdateQuality(new List<Item> { item });

            item.Quality.Should().Be(49);
        }

        private Item CreateItem(string name = "Regular item", int quality = 20, int sellIn = 30)
        {
            return new Item { Name = name, Quality = quality, SellIn = sellIn };
        }
    }
}
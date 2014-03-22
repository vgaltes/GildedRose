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
        public void BackstagePassesIncreasesQualityByOneIfSellInIsGreaterThan10()
        {
            var item = CreateItem(name: "Backstage passes to a TAFKAL80ETC concert", quality: 40, sellIn: 11);

            program.UpdateQuality(new List<Item> { item });

            item.Quality.Should().Be(41);
        }

        [Test]
        public void BackstagePassesIncreasesQualityByTwoIfSellInIsBetween6And10()
        {
            var itemTenDaysToSell = CreateItem(name: "Backstage passes to a TAFKAL80ETC concert", quality: 40, sellIn: 10);
            var itemSixDaysToSell = CreateItem(name: "Backstage passes to a TAFKAL80ETC concert", quality: 40, sellIn: 6);

            program.UpdateQuality(new List<Item> { itemTenDaysToSell, itemSixDaysToSell });

            itemTenDaysToSell.Quality.Should().Be(42);
            itemSixDaysToSell.Quality.Should().Be(42);
        }

        [Test]
        public void BackstagePassesIncreasesQualityByThreeIfSellInIsBetween1And5()
        {
            var itemFiveDaysToSell = CreateItem(name: "Backstage passes to a TAFKAL80ETC concert", quality: 40, sellIn: 5);
            var itemOneDayToSell = CreateItem(name: "Backstage passes to a TAFKAL80ETC concert", quality: 40, sellIn: 1);

            program.UpdateQuality(new List<Item> { itemFiveDaysToSell, itemOneDayToSell });

            itemFiveDaysToSell.Quality.Should().Be(43);
            itemOneDayToSell.Quality.Should().Be(43);
        }

        [Test]
        public void BackstagePassesDropsQualityToZeroAfterTheConcert()
        {
            var item = CreateItem(name: "Backstage passes to a TAFKAL80ETC concert", quality: 40, sellIn: 0);

            program.UpdateQuality(new List<Item> { item });

            item.Quality.Should().Be(0);
        }

        private Item CreateItem(string name = "Regular item", int quality = 20, int sellIn = 30)
        {
            return new Item { Name = name, Quality = quality, SellIn = sellIn };
        }
    }
}
using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;
using FluentAssertions;

namespace GildedRose.Tests
{
    [TestFixture]
    public class TestAssemblyTests
    {
        [Test]
        public void AtTheEndOfEachDayTheSystemLowersSellInByOne()
        {
            var item = CreateItem(sellIn: 20);
            var program = new Program();

            program.UpdateQuality(new List<Item> { item });

            item.SellIn.Should().Be(19);
        }

        [Test]
        public void AtTheEndOfEachDayTheSystemLowersQualityInByOne()
        {
            var item = CreateItem(quality: 20);
            var program = new Program();

            program.UpdateQuality(new List<Item> { item });

            item.Quality.Should().Be(19);
        }

        [Test]
        public void OnceTheSellByDateHasPassedQualityDegradesTwiceAsFast()
        {
            var item = CreateItem(sellIn: 0, quality: 20);
            var program = new Program();

            program.UpdateQuality(new List<Item> { item });

            item.Quality.Should().Be(18);
        }

        private Item CreateItem(string name = "Regular item", int quality = 20, int sellIn = 30)
        {
            return new Item { Name = name, Quality = quality, SellIn = sellIn };
        }
    }
}
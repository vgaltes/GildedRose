using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GildedRose.Console.ItemsStrategies;
using NUnit.Framework;
using FluentAssertions;
using GildedRose.Console;

namespace GildedRose.Tests.ItemsStrategies
{
    [TestFixture]
    public class LegendaryItemStrategyTests
    {
        LegendaryItemStrategy legendaryItemStrategy = new LegendaryItemStrategy();

        [Test]
        public void LegendaryItemCanHandleSulfurasItems()
        {
            var item = CreateItem(name: "Sulfuras, Hand of Ragnaros");
            var canHandle = legendaryItemStrategy.CanHandle(item);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void LegendaryItemsNeverDecreasesSellIn()
        {
            var item = CreateItem(name: "Sulfuras, Hand of Ragnaros", sellIn: 40);
            legendaryItemStrategy.UpdateQuality(item);

            item.SellIn.Should().Be(40);
        }

        [Test]
        public void LegendaryItemsNeverDecreasesQuality()
        {
            var item = CreateItem(name: "Sulfuras, Hand of Ragnaros", quality: 40);

            legendaryItemStrategy.UpdateQuality(item);

            item.Quality.Should().Be(40);
        }
        private Item CreateItem(string name = "Regular item", int quality = 20, int sellIn = 30)
        {
            return new Item { Name = name, Quality = quality, SellIn = sellIn };
        }
    }
}

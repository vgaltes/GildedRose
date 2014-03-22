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
            var item = CreateItem();
            var canHandle = legendaryItemStrategy.CanHandle(item);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void LegendaryItemsNeverDecreasesSellIn()
        {
            var item = CreateItem(sellIn: 40);
            legendaryItemStrategy.UpdateQuality(item);

            item.SellIn.Should().Be(40);
        }

        [Test]
        public void LegendaryItemsNeverDecreasesQuality()
        {
            var item = CreateItem(quality: 40);

            legendaryItemStrategy.UpdateQuality(item);

            item.Quality.Should().Be(40);
        }

        [Test]
        public void TheQualityOfAnItemIsNeverMoreThan50()
        {
            var item = CreateItem(quality: 50);

            legendaryItemStrategy.UpdateQuality(item);

            item.Quality.Should().Be(50);
        }

        [Test]
        public void TheQualityOfAnItemIsNeverNegative()
        {
            var item = CreateItem(quality: 0);

            legendaryItemStrategy.UpdateQuality(item);

            item.Quality.Should().Be(0);
        }
        private Item CreateItem(int quality = 20, int sellIn = 30)
        {
            return new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = quality, SellIn = sellIn };
        }
    }
}

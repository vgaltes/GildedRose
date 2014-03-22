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
    public class BackStagePassItemStrategyTests
    {
        BackStagePassItemStrategy backstagePassItemStrategy = new BackStagePassItemStrategy();

        [Test]
        public void BackStagePassItemCanHandleBackStagePassItems()
        {
            var item = CreateItem();
            var canHandle = backstagePassItemStrategy.CanHandle(item);

            canHandle.Should().BeTrue();
        }               

        [Test]
        public void TheQualityOfAnItemIsNeverMoreThan50()
        {
            var item = CreateItem(quality: 50);

            backstagePassItemStrategy.UpdateQuality(item);

            item.Quality.Should().Be(50);
        }

        
        private Item CreateItem(int quality = 20, int sellIn = 30)
        {
            return new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = quality, SellIn = sellIn };
        }
    }
}

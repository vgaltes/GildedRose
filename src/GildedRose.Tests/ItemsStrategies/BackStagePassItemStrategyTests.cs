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

        [Test]
        public void BackstagePassesIncreasesQualityByOneIfSellInIsGreaterThan10()
        {
            var item = CreateItem(quality: 40, sellIn: 11);

            backstagePassItemStrategy.UpdateQuality(item);

            item.Quality.Should().Be(41);
        }

        [Test]
        public void BackstagePassesIncreasesQualityByTwoIfSellInIsBetween6And10()
        {
            var itemTenDaysToSell = CreateItem(quality: 40, sellIn: 10);
            var itemSixDaysToSell = CreateItem(quality: 40, sellIn: 6);

            backstagePassItemStrategy.UpdateQuality(itemTenDaysToSell);
            backstagePassItemStrategy.UpdateQuality(itemSixDaysToSell);

            itemTenDaysToSell.Quality.Should().Be(42);
            itemSixDaysToSell.Quality.Should().Be(42);
        }

        [Test]
        public void BackstagePassesIncreasesQualityByThreeIfSellInIsBetween1And5()
        {
            var itemFiveDaysToSell = CreateItem(quality: 40, sellIn: 5);
            var itemOneDayToSell = CreateItem(quality: 40, sellIn: 1);

            backstagePassItemStrategy.UpdateQuality(itemFiveDaysToSell);
            backstagePassItemStrategy.UpdateQuality(itemOneDayToSell);

            itemFiveDaysToSell.Quality.Should().Be(43);
            itemOneDayToSell.Quality.Should().Be(43);
        }

        [Test]
        public void BackstagePassesDropsQualityToZeroAfterTheConcert()
        {
            var item = CreateItem(quality: 40, sellIn: 0);

            backstagePassItemStrategy.UpdateQuality(item);

            item.Quality.Should().Be(0);
        }

        
        private Item CreateItem(int quality = 20, int sellIn = 30)
        {
            return new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = quality, SellIn = sellIn };
        }
    }
}

using FluentAssertions;
using GildedRose.Console;
using GildedRose.Console.ItemsStrategies;
using NUnit.Framework;

namespace GildedRose.Tests.ItemsStrategies
{
    [TestFixture]
    public class RegularItemStrategyTests
    {
        RegularItemStrategy regularItemStrategy = new RegularItemStrategy();

        [Test]
        public void AtTheEndOfEachDayTheSystemLowersSellInByOne()
        {
            var item = CreateItem(sellIn: 20);

            regularItemStrategy.UpdateQuality(item);

            item.SellIn.Should().Be(19);
        }

        [Test]
        public void AtTheEndOfEachDayTheSystemLowersQualityInByOne()
        {
            var item = CreateItem(quality: 20);

            regularItemStrategy.UpdateQuality(item);

            item.Quality.Should().Be(19);
        }

        [Test]
        public void OnceTheSellByDateHasPassedQualityDegradesTwiceAsFast()
        {
            var item = CreateItem(sellIn: 0, quality: 20);

            regularItemStrategy.UpdateQuality(item);

            item.Quality.Should().Be(18);
        }

        [Test]
        public void TheQualityOfAnItemIsNeverNegative()
        {
            var item = CreateItem(quality: 0);

            regularItemStrategy.UpdateQuality(item);

            item.Quality.Should().Be(0);
        }

        private Item CreateItem(int quality = 20, int sellIn = 30)
        {
            return new Item { Name = "Regular item", Quality = quality, SellIn = sellIn };
        }
    }
}
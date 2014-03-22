using FluentAssertions;
using GildedRose.Console;
using GildedRose.Console.ItemsStrategies;
using NUnit.Framework;

namespace GildedRose.Tests.ItemsStrategies
{
    [TestFixture]
    public class AgedBrieItemStrategyTests
    {
        AgedBrieItemStrategy agedBrieItemStrategy = new AgedBrieItemStrategy();

        [Test]
        public void AgedBrieItemStrategyCanHandleAgedBrieItems()
        {
            var item = CreateItem();
            var canHandle = agedBrieItemStrategy.CanHandle(item);

            canHandle.Should().BeTrue();
        }               

        [Test]
        public void TheQualityOfAnItemIsNeverMoreThan50()
        {
            var item = CreateItem(quality: 50);

            agedBrieItemStrategy.UpdateQuality(item);

            item.Quality.Should().Be(50);
        }

        [Test]
        public void AgedBrieIncreasesQualityByOneTheOlderItGets()
        {
            var item = CreateItem(quality: 20);

            agedBrieItemStrategy.UpdateQuality(item);

            item.Quality.Should().Be(21);
        }
        
        private Item CreateItem(int quality = 20, int sellIn = 30)
        {
            return new Item { Name = "Aged Brie", Quality = quality, SellIn = sellIn };
        }
    }
}

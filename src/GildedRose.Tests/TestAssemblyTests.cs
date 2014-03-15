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
            var item = new Item { Name = "Regular item", Quality = 20, SellIn = 20 };
            var program = new Program();

            program.UpdateQuality(new List<Item> { item });

            item.SellIn.Should().Be(19);            
        }
    }
}
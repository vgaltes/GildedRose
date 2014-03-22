using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;
using FluentAssertions;
using GildedRose.Console.ItemsStrategies;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        List<Item> items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "  ",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          };
        List<GildedRoseItemStrategy> strategies = new List<GildedRoseItemStrategy>
                                {
                                    new LegendaryItemStrategy(),
                                    new BackStagePassItemStrategy(),
                                    new AgedBrieItemStrategy(),
                                    new RegularItemStrategy()
                                };
        Program program = new Program();

        [Test]
        public void GoldenMasterTest()
        {
            program.UpdateQuality(items, strategies);

            items[0].Quality.Should().Be(19);
            items[0].SellIn.Should().Be(9);

            items[1].Quality.Should().Be(1);
            items[1].SellIn.Should().Be(1);

            items[2].Quality.Should().Be(6);
            items[2].SellIn.Should().Be(4);

            items[3].Quality.Should().Be(80);
            items[3].SellIn.Should().Be(0);

            items[4].Quality.Should().Be(19);
            items[4].SellIn.Should().Be(14);

            items[5].Quality.Should().Be(5);
            items[5].SellIn.Should().Be(2);
        }

        private Item CreateItem(string name = "Regular item", int quality = 20, int sellIn = 30)
        {
            return new Item { Name = name, Quality = quality, SellIn = sellIn };
        }
    }
}
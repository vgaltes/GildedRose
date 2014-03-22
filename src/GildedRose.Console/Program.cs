using System.Collections.Generic;
using GildedRose.Console.ItemsStrategies;

namespace GildedRose.Console
{
    public class Program
    {
        IList<Item> items;

        StrategyFactory strategyFactory = new StrategyFactory();

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              items = new List<Item>
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
                                          }
                          };

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality(List<Item> items)
        {
            this.items = items;
            UpdateQuality();
        }

        public void UpdateQuality()
        {
            foreach ( var item in items)
            {
                var strategy = strategyFactory.GetStrategyFor(item);
                strategy.UpdateQuality(item);
            }
        }
    }
}
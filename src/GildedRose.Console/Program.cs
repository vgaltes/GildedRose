using System.Collections.Generic;
using GildedRose.Console.ItemsStrategies;

namespace GildedRose.Console
{
    public class Program
    {
        IList<Item> Items;

        IList<GildedRoseItemStrategy> GildedRoseItemStrategies;

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
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
                                          },
                                GildedRoseItemStrategies = new List<GildedRoseItemStrategy>
                                {
                                    new LegendaryItemStrategy(),
                                    new BackStagePassItemStrategy(),
                                    new AgedBrieItemStrategy(),
                                    new RegularItemStrategy()
                                }
                          };

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality(List<Item> items, List<GildedRoseItemStrategy> strategies)
        {
            this.Items = items;
            this.GildedRoseItemStrategies = strategies;
            UpdateQuality();
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];

                bool handled = false;
                foreach ( var gildedRoseItemStrategy in GildedRoseItemStrategies)
                {   
                    if (!handled && gildedRoseItemStrategy.CanHandle(item))
                    {
                        gildedRoseItemStrategy.UpdateQuality(item);
                        handled = true;
                    }
                }
            }
        }
    }
}

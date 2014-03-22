using System.Collections.Generic;
using GildedRose.Console.ItemsStrategies;

namespace GildedRose.Console
{
    public class Program
    {
        IList<Item> Items;
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
                                          }

                          };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality(List<Item> items)
        {
            this.Items = items;
            UpdateQuality();
        }

        public void UpdateQuality()
        {
            var legendaryItemStrategy = new LegendaryItemStrategy();
            var backStagePassItemStrategy = new BackStagePassItemStrategy();
            var agedBrieItemStrategy = new AgedBrieItemStrategy();
            var regularItemStrategy = new RegularItemStrategy();

            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];

                if (legendaryItemStrategy.CanHandle(item))
                {
                }
                else if (backStagePassItemStrategy.CanHandle(item))
                {
                    backStagePassItemStrategy.UpdateQuality(item);                    
                }
                else if ( agedBrieItemStrategy.CanHandle(item))
                {
                    agedBrieItemStrategy.UpdateQuality(item);
                }
                else if (regularItemStrategy.CanHandle(item))
                {
                    regularItemStrategy.UpdateQuality(item);
                }
            }
        }

        

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}

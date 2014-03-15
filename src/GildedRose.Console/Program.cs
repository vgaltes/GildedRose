﻿using System.Collections.Generic;

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

        private bool IsRegularItem(Item item)
        {
            return item.Name != "Aged Brie" &&
                   item.Name != "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool HasQuality(Item item)
        {
            return item.Quality > 0;
        }

        private bool IsLegendaryItem(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        private bool IsBackStagePassItem(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool IsAgedBrieItem(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private bool SellByDatePassed(Item item)
        {
            return item.SellIn < 0;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];

                if (IsLegendaryItem(item))
                {

                }
                else if (IsRegularItem(item))
                {
                    if (HasQuality(item))
                    {
                        item.Quality = item.Quality - 1;
                    }

                    DecrementSellIn(item);

                    if (SellByDatePassed(item))
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
                else if (IsBackStagePassItem(item))
                {
                    if (IsQualityUnderTheLimit(item))
                    {
                        IncrementQuality(item);

                        if (item.SellIn < 11)
                        {
                            if (IsQualityUnderTheLimit(item))
                            {
                                IncrementQuality(item);
                            }
                        }
                        if (item.SellIn < 6)
                        {
                            if (IsQualityUnderTheLimit(item))
                            {
                                IncrementQuality(item);
                            }
                        }
                    }

                    DecrementSellIn(item);

                    if (SellByDatePassed(item))
                    {
                        item.Quality = 0;
                    }
                }
                else if ( IsAgedBrieItem(item))
                {
                    DecrementSellIn(item);
                    
                    if (IsQualityUnderTheLimit(item))
                    {
                        IncrementQuality(item);

                        if (SellByDatePassed(item))
                        {
                            if (IsQualityUnderTheLimit(item))
                            {
                                IncrementQuality(item);
                            }
                        }
                    }
                }
            }
        }

        private static void IncrementQuality(Item item)
        {
            item.Quality = item.Quality + 1;
        }

        private bool IsQualityUnderTheLimit(Item item)
        {
            return item.Quality < 50;
        }

        private static void DecrementSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}

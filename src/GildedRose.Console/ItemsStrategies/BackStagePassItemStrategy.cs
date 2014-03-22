using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console.ItemsStrategies
{
    public class BackStagePassItemStrategy : GildedRoseItemStrategy
    {
        public bool CanHandle(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        public void UpdateQuality(Item item)
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

        private bool SellByDatePassed(Item item)
        {
            return item.SellIn < 0;
        }
    }
}

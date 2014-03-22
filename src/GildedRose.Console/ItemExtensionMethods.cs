using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public static class ItemExtensionMethods
    {
        public static void DecrementQualityBy(this Item item, int decrement)
        {
            item.Quality -= decrement;
        }

        public static void DecrementSellInBy(this Item item, int decrement)
        {
            item.SellIn -= decrement;
        }

        public static void IncrementQualityBy(this Item item, int increment)
        {
            item.Quality += increment;
        }

        public static bool HasQuality(this Item item)
        {
            return item.Quality > 0;
        }

        public static bool HasSellByDatePassed(this Item item)
        {
            return item.SellIn < 0;
        }

        public static bool HasQualityUnder(this Item item, int qualityLimit)
        {
            return item.Quality < qualityLimit;
        }
    }
}

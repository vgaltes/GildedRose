namespace GildedRose.Console.ItemsStrategies
{
    public class RegularItemStrategy
    {
        public bool CanHandle(Item item)
        {
            return true;
        }

        public void UpdateQuality(Item item)
        {
            if (HasQuality(item))
            {
                DecrementQuality(item);
            }

            DecrementSellIn(item);

            if (SellByDatePassed(item))
            {
                DecrementQuality(item);
            }
        }

        private static void DecrementQuality(Item item)
        {
            item.Quality = item.Quality - 1;
        }
        
        private static void DecrementSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        private bool HasQuality(Item item)
        {
            return item.Quality > 0;
        }

        private bool SellByDatePassed(Item item)
        {
            return item.SellIn < 0;
        }
    }
}

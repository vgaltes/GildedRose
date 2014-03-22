namespace GildedRose.Console.ItemsStrategies
{
    public class AgedBrieItemStrategy : GildedRoseItemStrategy
    {
        public bool CanHandle(Item item)
        {
            return item.Name == "Aged Brie";
        }

        public void UpdateQuality(Item item)
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

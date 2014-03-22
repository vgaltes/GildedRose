namespace GildedRose.Console.ItemsStrategies
{
    public class AgedBrieItemStrategy : GildedRoseItemStrategy
    {
        private const int DEFAULT_SELLIN_DROP = 1;
        private const int QUALITY_LIMIT = 50;
        private const int DEFAULT_QUALITY_RAISE = 1;
        private const string AGED_BRIE_NAME = "Aged Brie";

        public bool CanHandle(Item item)
        {
            return item.Name == AGED_BRIE_NAME;
        }

        public void UpdateQuality(Item item)
        {
            item.DecrementSellInBy(DEFAULT_SELLIN_DROP);

            if (item.HasQualityUnder(QUALITY_LIMIT))
            {
                item.IncrementQualityBy(DEFAULT_QUALITY_RAISE);

                if (item.HasSellByDatePassed())
                {
                    if (item.HasQualityUnder(QUALITY_LIMIT))
                    {
                        item.IncrementQualityBy(DEFAULT_QUALITY_RAISE);
                    }
                }
            }
        }
    }
}

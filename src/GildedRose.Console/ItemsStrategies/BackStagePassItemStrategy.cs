namespace GildedRose.Console.ItemsStrategies
{
    public class BackStagePassItemStrategy : GildedRoseItemStrategy
    {
        private const int DEFAULT_QUALITY_RAISE = 1;
        private const int DOUBLE_QUALITY_RAISE = 2;
        private const int TRIPLE_QUALITY_RAISE = 3;
        private const int QUALITY_LIMIT = 50;
        private const int DEFAULT_SELLIN_DROP = 1;
        private const int NO_QUALITY = 0;
        private const string BACKSTAGE_PASS_NAME = "Backstage passes to a TAFKAL80ETC concert";

        public bool CanHandle(Item item)
        {
            return item.Name == BACKSTAGE_PASS_NAME;
        }

        public void UpdateQuality(Item item)
        {   
            if ( ItemIsWithinTenAndSixDays(item) )
            {
                item.IncrementQualityBy(DOUBLE_QUALITY_RAISE);
            }
            else if ( ItemIsEarlierThanSixDays(item) )
            {
                item.IncrementQualityBy(TRIPLE_QUALITY_RAISE);
            }
            else if (item.HasQualityUnder(QUALITY_LIMIT))
            {
                item.IncrementQualityBy(DEFAULT_QUALITY_RAISE);
            }

            item.DecrementSellInBy(DEFAULT_SELLIN_DROP);

            if (item.HasSellByDatePassed())
            {
                item.Quality = NO_QUALITY;
            }
        }

        private bool ItemIsEarlierThanSixDays(Item item)
        {
            return item.SellIn < 6;
        }

        private bool ItemIsWithinTenAndSixDays(Item item)
        {
            return item.SellIn < 11 && item.SellIn >= 6;
        }
    }
}

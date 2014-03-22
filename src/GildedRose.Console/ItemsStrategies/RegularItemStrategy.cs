using GildedRose.Console;

namespace GildedRose.Console.ItemsStrategies
{
    public class RegularItemStrategy : GildedRoseItemStrategy
    {
        private const int DEFAULT_QUALITY_DROP = 1;
        private const int DEFAULT_SELLIN_DROP = 1;

        public bool CanHandle(Item item)
        {
            return true;
        }

        public void UpdateQuality(Item item)
        {
            if (item.HasQuality())
            {
                item.DecrementQualityBy(DEFAULT_QUALITY_DROP);
            }

            item.DecrementSellInBy(DEFAULT_SELLIN_DROP);

            if (item.HasSellByDatePassed())
            {
                item.DecrementQualityBy(DEFAULT_QUALITY_DROP);
            }
        }
    }
}

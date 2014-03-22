namespace GildedRose.Console.ItemsStrategies
{
    public class LegendaryItemStrategy : GildedRoseItemStrategy
    {
        private const string LEGENDARY_NAME = "Sulfuras, Hand of Ragnaros";

        public bool CanHandle(Item item)
        {
            return item.Name == LEGENDARY_NAME;
        }

        public void UpdateQuality(Item item)
        { }
    }
}
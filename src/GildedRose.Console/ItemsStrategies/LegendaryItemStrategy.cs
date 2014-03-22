namespace GildedRose.Console.ItemsStrategies
{
    public class LegendaryItemStrategy : GildedRoseItemStrategy
    {
        public bool CanHandle(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        public void UpdateQuality(Item item)
        { }
    }
}

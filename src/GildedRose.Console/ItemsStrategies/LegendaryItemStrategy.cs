namespace GildedRose.Console.ItemsStrategies
{
    public class LegendaryItemStrategy
    {
        public bool CanHandle(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        public void UpdateQuality(Item item)
        { }
    }
}

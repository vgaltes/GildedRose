namespace GildedRose.Console.ItemsStrategies
{
    public interface GildedRoseItemStrategy
    {
        bool CanHandle(Item item);

        void UpdateQuality(Item item);
    }
}
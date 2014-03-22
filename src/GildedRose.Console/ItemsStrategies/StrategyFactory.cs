using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console.ItemsStrategies
{
    public class StrategyFactory
    {
        List<GildedRoseItemStrategy> gildedRoseItemStrategies = new List<GildedRoseItemStrategy>
                                {
                                    new LegendaryItemStrategy(),
                                    new BackStagePassItemStrategy(),
                                    new AgedBrieItemStrategy()
                                };

        public GildedRoseItemStrategy GetStrategyFor(Item item)
        {
            foreach ( var strategy in gildedRoseItemStrategies)
            {
                if (strategy.CanHandle(item))
                    return strategy;
            }

            return new RegularItemStrategy();
        }
    }
}

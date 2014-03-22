using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console.ItemsStrategies
{
    internal class LegendaryItemStrategy
    {
        internal bool CanHandle(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
}

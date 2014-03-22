using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console.ItemsStrategies
{
    internal class BackStagePassItemStrategy
    {
        internal bool CanHandle(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }
    }
}

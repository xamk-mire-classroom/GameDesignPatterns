using GameDesignPatterns.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Models.Items
{
    public abstract class Item
    {
        protected Item(string name, ItemRarity rarity)
        {
            Name = name;
            Rarity = rarity;
        }

        public string Name { get; set; }
        public ItemRarity Rarity { get; set; }
    }
}

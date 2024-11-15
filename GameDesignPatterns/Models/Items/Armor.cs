using GameDesignPatterns.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Models.Items
{
    public class Armor : Item
    {
        public Armor(string name, ItemRarity rarity) : base(name, rarity)
        {
        }

        public int Defense { get; set; }
        public int Durability { get; set; }
    }
}

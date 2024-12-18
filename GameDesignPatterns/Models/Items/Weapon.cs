﻿
using GameDesignPatterns.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Models.Items
{
    public class Weapon : Item
    {
        public Weapon(string name, ItemRarity rarity) : base(name, rarity)
        {
        }

        public int Damage { get; set; }
        public WeaponType WeaponType { get; set; }
    }
}

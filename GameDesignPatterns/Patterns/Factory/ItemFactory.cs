using GameDesignPatterns.Enums;
using GameDesignPatterns.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Patterns.Factory
{
    public abstract class ItemFactory
    {
        public abstract Weapon CreateWeapon(string name);
        public abstract Potion CreatePotion(string name);
        public abstract Armor CreateArmor(string name);
    }

    public class CommonItemFactory : ItemFactory
    {
        public override Weapon CreateWeapon(string name)
        {
            return new Weapon
            {
                Name = name,
                Rarity = ItemRarity.Common,
                Damage = 10,
                WeaponType = WeaponType.Melee
            };
        }

        public override Potion CreatePotion(string name)
        {
            return new Potion
            {
                Name = name,
                Rarity = ItemRarity.Common,
                Effect = "Heal",
                Duration = 10
            };
        }

        public override Armor CreateArmor(string name)
        {
            return new Armor
            {
                Name = name,
                Rarity = ItemRarity.Common,
                Defense = 5,
                Durability = 20
            };
        }
    }

    public class MagicalItemFactory : ItemFactory
    {
        public override Weapon CreateWeapon(string name)
        {
            return new Weapon
            {
                Name = name,
                Rarity = ItemRarity.Magical,
                Damage = 15,
                WeaponType = WeaponType.Ranged
            };
        }

        public override Potion CreatePotion(string name)
        {
            return new Potion
            {
                Name = name,
                Rarity = ItemRarity.Magical,
                Effect = "Mana Restore",
                Duration = 15
            };
        }

        public override Armor CreateArmor(string name)
        {
            return new Armor
            {
                Name = name,
                Rarity = ItemRarity.Magical,
                Defense = 10,
                Durability = 30
            };
        }
    }

    public class RareItemFactory : ItemFactory
    {
        public override Weapon CreateWeapon(string name)
        {
            return new Weapon
            {
                Name = name,
                Rarity = ItemRarity.Rare,
                Damage = 20,
                WeaponType = WeaponType.Melee
            };
        }

        public override Potion CreatePotion(string name)
        {
            return new Potion
            {
                Name = name,
                Rarity = ItemRarity.Rare,
                Effect = "Greater Heal",
                Duration = 20
            };
        }

        public override Armor CreateArmor(string name)
        {
            return new Armor
            {
                Name = name,
                Rarity = ItemRarity.Rare,
                Defense = 15,
                Durability = 40
            };
        }
    }

    public class LegendaryItemFactory : ItemFactory
    {
        public override Weapon CreateWeapon(string name)
        {
            return new Weapon
            {
                Name = name,
                Rarity = ItemRarity.Legendary,
                Damage = 30,
                WeaponType = WeaponType.Ranged
            };
        }

        public override Potion CreatePotion(string name)
        {
            return new Potion
            {
                Name = name,
                Rarity = ItemRarity.Legendary,
                Effect = "Godlike Restoration",
                Duration = 30
            };
        }

        public override Armor CreateArmor(string name)
        {
            return new Armor
            {
                Name = name,
                Rarity = ItemRarity.Legendary,
                Defense = 20,
                Durability = 50
            };
        }
    }
}

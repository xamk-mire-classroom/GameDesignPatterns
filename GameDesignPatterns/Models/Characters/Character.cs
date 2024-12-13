using GameDesignPatterns.Models.Items;
using GameDesignPatterns.Patterns;
using GameDesignPatterns.Patterns.Factory;
using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace GameDesignPatterns.Models
    {
        public abstract class Character
        {
            // Properties from your implementation
            public string Name { get; }
            public int Health { get;  set; }
            public int MaxHealth { get; set; }
            public int Mana { get; set; }
            public int Strength { get; set; }
            public int Agility { get; set; }
            public Position CurrentPosition { get; set; } = new Position();
            public Weapon? EquippedWeapon { get; private set; }
            public Armor? EquippedArmor { get; private set; }
            public Potion? EquippedPotion { get; private set; }

        // Inventory to hold all items
        public List<Item> Inventory { get; } = new List<Item>();

        // Strategy and State pattern properties
        public IActionStrategy CurrentActionStrategy { get; set; }
        public ICharacterState CurrentState { get; set; }

            protected Character(string name, int health, int mana, int strength, int agility)
            {
                Name = name;
                Health = health;
                MaxHealth = health;
                Mana = mana;
                Strength = strength;
                Agility = agility;

                // Initialize with default state and strategy
                CurrentState = new IdleState();
                InitializeDefaultStrategy();
            }

       
        public void AddToInventory(Item item)
        {
            Inventory.Add(item);
            Console.WriteLine($"{Name} added {item.Name} ({item.Rarity}) to their inventory.");
        }

        public void DisplayInventory()
        {
            Console.WriteLine($"\n{Name}'s Inventory:");
            if (Inventory.Count == 0)
            {
                Console.WriteLine("The inventory is empty.");
            }
            else
            {
                foreach (var item in Inventory)
                {
                    Console.WriteLine($"- {item.Name} ({item.GetType().Name}) - {item.Rarity}");
                }
            }
        }

        public void UsePotion(Potion potion)
        {
            if (Inventory.Contains(potion))
            {
                Inventory.Remove(potion);
                Console.WriteLine($"{Name} used {potion.Name} and gained the effect: {potion.Effect} for {potion.Duration} seconds.");
                // Apply potion effect logic (e.g., restore health)
            }
            else
            {
                Console.WriteLine($"{potion.Name} is not in {Name}'s inventory.");
            }
        }

        // Equipment methods
        public bool EquipItem(Item item)
        {
            // Check if item is in inventory
            if (!Inventory.Contains(item))
            {
                Console.WriteLine($"{item.Name} is not in {Name}'s inventory.");
                return false;
            }

            switch (item)
            {
                case Weapon weapon:
                    if (EquippedWeapon != null)
                    {
                        // Put currently equipped weapon back in inventory
                        Inventory.Add(EquippedWeapon);
                    }
                    EquippedWeapon = weapon;
                    Inventory.Remove(weapon);
                    Console.WriteLine($"{Name} equipped {weapon.Name} as weapon.");
                    return true;

                case Armor armor:
                    if (EquippedArmor != null)
                    {
                        // Put currently equipped armor back in inventory
                        Inventory.Add(EquippedArmor);
                    }
                    EquippedArmor = armor;
                    Inventory.Remove(armor);
                    Console.WriteLine($"{Name} equipped {armor.Name} as armor.");
                    return true;

                case Potion potion:
                    if (EquippedPotion != null)
                    {
                        // Put currently equipped potion back in inventory
                        Inventory.Add(EquippedPotion);
                    }
                    EquippedPotion = potion;
                    Inventory.Remove(potion);
                    Console.WriteLine($"{Name} equipped {potion.Name} in utility slot.");
                    return true;

                default:
                    Console.WriteLine($"Cannot equip {item.Name} - unknown item type.");
                    return false;
            }
        }

        public bool UnequipItem(string slot)
        {
            switch (slot.ToLower())
            {
                case "weapon":
                    if (EquippedWeapon == null)
                    {
                        Console.WriteLine($"{Name} has no weapon equipped.");
                        return false;
                    }
                    Inventory.Add(EquippedWeapon);
                    Console.WriteLine($"{Name} unequipped {EquippedWeapon.Name}.");
                    EquippedWeapon = null;
                    return true;

                case "armor":
                    if (EquippedArmor == null)
                    {
                        Console.WriteLine($"{Name} has no armor equipped.");
                        return false;
                    }
                    Inventory.Add(EquippedArmor);
                    Console.WriteLine($"{Name} unequipped {EquippedArmor.Name}.");
                    EquippedArmor = null;
                    return true;

                case "potion":
                    if (EquippedPotion == null)
                    {
                        Console.WriteLine($"{Name} has no potion equipped.");
                        return false;
                    }
                    Inventory.Add(EquippedPotion);
                    Console.WriteLine($"{Name} unequipped {EquippedPotion.Name}.");
                    EquippedPotion = null;
                    return true;

                default:
                    Console.WriteLine($"Invalid equipment slot: {slot}");
                    return false;
            }
        }

        public void DisplayEquipment()
        {
            Console.WriteLine($"\n{Name}'s Equipment:");
            Console.WriteLine($"Weapon Slot: {(EquippedWeapon == null ? "Empty" : $"{EquippedWeapon.Name} ({EquippedWeapon.Rarity})")}");
            Console.WriteLine($"Armor Slot: {(EquippedArmor == null ? "Empty" : $"{EquippedArmor.Name} ({EquippedArmor.Rarity})")}");
            Console.WriteLine($"Utility Slot: {(EquippedPotion == null ? "Empty" : $"{EquippedPotion.Name} ({EquippedPotion.Rarity})")}");
        }

        // Method to be implemented by derived classes to set their default strategy
        protected abstract void InitializeDefaultStrategy();

            // Abstract method from your implementation
            public abstract string UseAbility();

        public void SetAction(IActionStrategy actionStrategy)
        {   
            CurrentActionStrategy = actionStrategy;   
        }


        // State pattern methods
        public void ChangeState(ICharacterState newState)
            {
                CurrentState = newState;
                
            }

            public void PerformAction()
            {

            CurrentState.HandleState(this, CurrentActionStrategy);
            
            }

            //Method to move the character
            public void Move(int dx, int dy) 
            {
                CurrentPosition.Move(dx, dy);
            }

           
            
            

        }
    }
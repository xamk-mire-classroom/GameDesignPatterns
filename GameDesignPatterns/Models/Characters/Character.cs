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
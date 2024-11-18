using GameDesignPatterns.Patterns;
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

        // Method to be implemented by derived classes to set their default strategy
        protected abstract void InitializeDefaultStrategy();

        // Abstract method from your implementation
        public abstract string UseAbility();

        // Strategy pattern methods
        public void ChangeActionStrategy(IActionStrategy newStrategy)
        {
            CurrentActionStrategy = newStrategy;
            CurrentActionStrategy.PerformAction(this);
        }

        // State pattern methods
        public void ChangeState(ICharacterState newState)
        {
            CurrentState = newState;
            CurrentState.HandleState(this);
        }

        public void PerformAction()
        {
            CurrentState.HandleState(this);
            CurrentActionStrategy?.PerformAction(this);

        }
    }
}
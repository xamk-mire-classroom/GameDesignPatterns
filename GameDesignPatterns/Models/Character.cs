using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Models
{
    // Factory Method Pattern - Character Creation

    // Abstract Character class
    public abstract class Character
    {
        public string name { get; }
        public int health { get; }
        public int mana { get; }
        public int strength { get; }
        public int agility { get; }

        protected Character(string name, int health, int mana, int strength, int agility)
        {
            this.name = name;
            this.health = health;
            this.mana = mana;
            this.strength = strength;
            this.agility = agility;
        }

        public abstract string UseAbility();
    }
}

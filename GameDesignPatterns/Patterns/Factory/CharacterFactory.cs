using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDesignPatterns.Models;

namespace GameDesignPatterns.Patterns.Factory
{
    // CharacterFactory class
    public class CharacterFactory
    {
        public Character CreateCharacter(string type, string name)
        {
            switch (type.ToLower())
            {
                case "warrior":
                    return new Warrior(name);
                case "mage":
                    return new Mage(name);
                case "archer":
                    return new Archer(name);
                default:
                    throw new ArgumentException($"Invalid character type: {type}");
            }
        }
    }
}

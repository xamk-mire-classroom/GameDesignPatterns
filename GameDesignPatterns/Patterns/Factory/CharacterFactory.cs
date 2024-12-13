using System;
using GameDesignPatterns.Models;
using GameDesignPatterns.Models.Characters;

namespace GameDesignPatterns.Patterns.Factory
{
    public class CharacterFactory
    {
        // Abstract factory interface
        public interface ICharacterFactory
        {
            Character CreateCharacter(string name);
        }

        // Concrete factories for each character type
        public class WarriorFactory : ICharacterFactory
        {
            public Character CreateCharacter(string name)
            {
                return new Warrior(name);
            }
        }

        public class MageFactory : ICharacterFactory
        {
            public Character CreateCharacter(string name)
            {
                return new Mage(name);
            }
        }

        public class ArcherFactory : ICharacterFactory
        {
            public Character CreateCharacter(string name)
            {
                return new Archer(name);
            }
        }

        // Factory provider class
        public class CharacterFactoryProvider
        {
            public static ICharacterFactory GetFactory(string characterType)
            {
                switch (characterType.ToLower())
                {
                    case "warrior":
                        return new WarriorFactory();
                    case "mage":
                        return new MageFactory();
                    case "archer":
                        return new ArcherFactory();
                    default:
                        throw new ArgumentException($"Invalid character type: {characterType}");
                }
            }
        }
    }
    
}
using GameDesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Patterns.Commands
{
    public class HealCommand : ICommand
    {
        private readonly Character _character;
        private readonly int _healAmount;
        private int _actualHealing;

        public HealCommand(Character character, int healAmount = 0)
        {
            _character = character;
            // If no heal amount provided, calculate based on character attributes
            _healAmount = healAmount > 0
                ? healAmount
                : CalculateHealAmount();
        }

        private int CalculateHealAmount()
        {
            // Example healing calculation
            // Could be based on character's mana, strength, or other attributes
            return _character.Mana / 2;
        }

        public void Execute()
        {
            // Calculate actual healing (can't exceed max health)
            _actualHealing = Math.Min(_healAmount, _character.MaxHealth - _character.Health);

            // Heal the character
            _character.Health += _actualHealing;

            Console.WriteLine($"{_character.Name} heals for {_actualHealing} health.");
            Console.WriteLine($"{_character.Name} now has {_character.Health} health.");
        }

        
    }
}

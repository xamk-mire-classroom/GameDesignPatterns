using GameDesignPatterns.Models;
using GameDesignPatterns.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Patterns
{
    public class HealAction : IActionStrategy
    {
        private const int HEAL_AMOUNT = 20;
        private const int MANA_COST = 10;

        public void PerformAction(Character character)
        {
            Console.WriteLine($"{character.Name} performs a Healing Action!");
            if (character.Mana > MANA_COST)
            {
                int healedAmount = Math.Min(HEAL_AMOUNT, character.MaxHealth - character.Health);
                character.Health += healedAmount;
                character.Mana -= MANA_COST;

                Console.WriteLine($"{character.Name} heals for {healedAmount} health. Current health: {character.Health}");
            }
            else
            {
                Console.WriteLine($"{character.Name} does not have enough mana to heal!");
            }
        }
    }
}
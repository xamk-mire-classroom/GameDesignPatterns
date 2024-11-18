using GameDesignPatterns.Models;
using GameDesignPatterns.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Patterns
{
    public class MagicAction : IActionStrategy
    {
        private const int MAGIC_DAMAGE = 30;
        private const int MANA_COST = 15;
        public void PerformAction(Character character)
        {
            Console.WriteLine($"{character.Name} casts a Magic Spell!");
            if (character.Mana >= MANA_COST)
            {
                character.Mana -= MANA_COST;
                Console.WriteLine($"{character.Name} deals {MAGIC_DAMAGE} magic damage!");
            }
            else
            {
                Console.WriteLine($"{character.Name} does not have enough mana to cast spell!");
            }
        }
    }
}
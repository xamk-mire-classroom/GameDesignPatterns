using GameDesignPatterns.Models;
using GameDesignPatterns.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Patterns
{
    public class RangedAction : IActionStrategy
    {
        private const int RANGED_DAMAGE = 35;
        private const int ACCURACY_CHANCE = 80;
        public void PerformAction(Character character)
        {
            Console.WriteLine($"{character.Name} performs a Ranged Attack!");
            Random random = new Random();
            if (random.Next(100) < ACCURACY_CHANCE)
            {
                Console.WriteLine($"{character.Name} hits the target for {RANGED_DAMAGE} damage!");
            }
            else
            {
                Console.WriteLine($"{character.Name}'s ranged attack misses!");
            }
        }
    }
}
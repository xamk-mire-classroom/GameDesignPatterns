using GameDesignPatterns.Models;
using GameDesignPatterns.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Patterns 
{
    public class MeleeAction : IActionStrategy
    {
        private const int MELEE_DAMAGE = 25;
        public void PerformAction(Character character)
        {
            Console.WriteLine($"{character.Name} performs a Melee Attack!");
            Console.WriteLine($"{character.Name} deals {MELEE_DAMAGE} physical damage!");
        }
    }
}
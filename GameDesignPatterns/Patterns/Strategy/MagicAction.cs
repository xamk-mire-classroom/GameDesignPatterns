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
        public void PerformAction(Character character)
        {
            Console.WriteLine($"{character.Name} casts a Magic Spell!");
            // Add magic spell logic here
        }
    }
}
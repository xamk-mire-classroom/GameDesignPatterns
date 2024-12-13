using GameDesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Patterns
{
    public class DefendingState : ICharacterState
    {
        public void HandleState(Character character, IActionStrategy actionStrategy)
        {
            Console.WriteLine($"{character.Name} is defending.");
        }

        public override string ToString()
        {
            return "Defending state";
        }

        
    }
}
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
        private const double DAMAGE_REDUCTION = 0.5;
        public void HandleState(Character character)
        {
            Console.WriteLine($"{character.Name} is in a Defending State.");
            Console.WriteLine($"{character.Name} reduces incoming damage by {DAMAGE_REDUCTION * 100}%");
        }
    }
}

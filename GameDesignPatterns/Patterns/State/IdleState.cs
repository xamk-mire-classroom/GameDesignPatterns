using GameDesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Patterns
{
    public class IdleState : ICharacterState
    {
        public void HandleState(Character character, IActionStrategy actionStrategy)
        {
            Console.WriteLine($"{character.Name} is in an Idle State.");
            actionStrategy.PerformAction(character);
        }

        public override string ToString()
        {
            return "Idle state";
        }
        
    }
}

using GameDesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Patterns
{
    public class ActionState : ICharacterState
    {
        public void HandleState(Character character)
        {
            Console.WriteLine($"{character.Name} is in an Action State.");
            if (character.CurrentActionStrategy != null)
            {
                character.CurrentActionStrategy.PerformAction(character);
            }
            else
            {
                Console.WriteLine($"{character.Name} has no action strategy assigned!");
            }
        }
    }  
}

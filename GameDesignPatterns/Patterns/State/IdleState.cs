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
        public void HandleState(Character character)
        {
            Console.WriteLine($"{character.Name} is in an Idle State.");
            // Passive regeneration or other idle state mechanics
            character.Health = Math.Min(character.Health + 5, character.MaxHealth);
            Console.WriteLine($"{character.Name} passively recovers 5 health. Current Health: {character.Health}");
        }
    }
}

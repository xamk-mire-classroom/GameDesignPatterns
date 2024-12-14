using GameDesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Patterns.Commands
{
    public class DefendCommand : ICommand
    {
        private readonly Character _character;
        

        public DefendCommand(Character character)
        {
            _character = character;
            
        }

        public void Execute()
        {
            // Add actual defense bonus or damage reduction for next enemy turn
            _character.Health += 5; // Temporary HP or defense boost
            Console.WriteLine($"{_character.Name} takes a defensive stance and gains some protection!");
        }
    }
}

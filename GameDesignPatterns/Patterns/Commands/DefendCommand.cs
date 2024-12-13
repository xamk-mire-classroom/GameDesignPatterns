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
            
            // Change to defending state
            _character.ChangeState(new DefendingState());

            Console.WriteLine($"{_character.Name} enters a defensive stance!");
        }
    }
}

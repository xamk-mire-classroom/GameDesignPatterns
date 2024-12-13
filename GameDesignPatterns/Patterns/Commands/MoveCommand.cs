using GameDesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Patterns.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly Character _character;
        private readonly int _dx;
        private readonly int _dy;

        public MoveCommand(Character character, int dx, int dy)
        {
            _character = character;
            _dx = dx;
            _dy = dy;
            
        }

        public void Execute()
        {
            _character.Move(_dx, _dy);
            Console.WriteLine($"{_character.Name} moved to {_character.CurrentPosition}");
        }

      
    }
}

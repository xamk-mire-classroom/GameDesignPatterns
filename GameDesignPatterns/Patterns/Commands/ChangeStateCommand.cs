using GameDesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Patterns.Commands
{
    public class ChangeStateCommand : ICommand
    {
        private readonly Character _character;
        private ICharacterState _characterState;

        public ChangeStateCommand(Character character)
        {
            _character = character;
        }

        public void Execute()
        {
            Console.WriteLine($"Changing character {_character.Name} state");
            Console.WriteLine($"Press '1' for IdleState, '2' for ActionState, '3' for DefendingState. Press '0' to cancel");

            var stateChoice = Console.ReadKey();

            switch (stateChoice.KeyChar)
            {
                case '1':
                    _characterState = new IdleState();
                    break;
                case '2':
                    _characterState = new ActionState();
                    break;
                case '3':
                    _characterState = new DefendingState();
                    break;

                default:
                    return;
            }

            _character.ChangeState(_characterState);

            Console.WriteLine($"{_character.Name} is changing its state to {_characterState}!");
        }
    }
}

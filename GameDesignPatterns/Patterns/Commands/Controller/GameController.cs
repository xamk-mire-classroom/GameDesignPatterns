using GameDesignPatterns.Models;
using GameDesignPatterns.Models.Enemies;
using GameDesignPatterns.Patterns.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;

namespace GameDesignPatterns.Patterns.Command.Controller
{
    public class GameController
    {
        private readonly Character _character;
        private readonly BaseEnemy? _target;
        private readonly Stack<ICommand> _commandHistory;
        private readonly Dictionary<ConsoleKey, ICommand> _commandMap;

        public GameController(Character character, BaseEnemy? target)
        {
            _character = character;
            _target = target;
            _commandHistory = new Stack<ICommand>();
            _commandMap = InitializeCommandMap();
        }

        private Dictionary<ConsoleKey, ICommand> InitializeCommandMap()
        {
            var commands = new Dictionary<ConsoleKey, ICommand>
            {
                
                { ConsoleKey.D, new DefendCommand(_character) },
                { ConsoleKey.H, new HealCommand(_character) },
                {ConsoleKey.M, new ChangeStateCommand(_character) },
                
            };
            // Only add attack command if we have a target
            if (_target != null)
            {
                commands.Add(ConsoleKey.A, new AttackCommand(_character, _target));
            }

            return commands;
        }

        public void HandleInput(ConsoleKey key)
        {
            // Handle movement commands
            if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow ||
                key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow)
            {
                HandleMovement(key);
                return;
            }

            // Handle other commands
            if (_commandMap.TryGetValue(key, out ICommand? command))
            {
                if (command != null)
                {
                    ExecuteCommand(command);
                }
            }
        }

        public void HandleMovement(ConsoleKey key)
        {
            ICommand? moveCommand = key switch
            {
                ConsoleKey.UpArrow => new MoveCommand(_character, 0, 1),
                ConsoleKey.DownArrow => new MoveCommand(_character, 0, -1),
                ConsoleKey.LeftArrow => new MoveCommand(_character,-1, 0),
                ConsoleKey.RightArrow => new MoveCommand(_character, 1,0),
                _ => null
            };

            if (moveCommand != null)
            {
                ExecuteCommand(moveCommand);
            }
        }


        private void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _commandHistory.Push(command);
        }
 
        //Method for command history
        public void UndoLastCommand()
        {
            if (_commandHistory.Count > 0)
            {
                // Pop the last command
                _commandHistory.Pop();
                // Could implement actual undo logic here if needed
                Console.WriteLine("Undoing last command...");
            }
        }

        public void DisplayCommandHistory()
        {
            Console.WriteLine("\nCommand History:");
            foreach (var command in _commandHistory.Reverse())
            {
                Console.WriteLine($"- {command.GetType().Name}");
            }
        }
    }
}

using GameDesignPatterns.Models;
using GameDesignPatterns.Models.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDesignPatterns.Patterns;

namespace GameDesignPatterns.Patterns.Commands
{
    public class AttackCommand : ICommand
    {
        private readonly Character _character;
        private readonly BaseEnemy _target;

        public AttackCommand(Character character,BaseEnemy target)
        {
            _character = character;
            _target = target;
            
        }



        public void Execute()
        {
            Console.WriteLine($"{_character.Name} attacks {_target.Name}");

            // Calculate and deal damage
            int damage = _character.Strength + (_character.EquippedWeapon?.Damage ?? 0);
            _target.Health -= damage;

            Console.WriteLine($"Dealt {damage} damage!");
        }

    }
}
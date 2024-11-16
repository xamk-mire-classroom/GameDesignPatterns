using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDesignPatterns.Patterns;

namespace GameDesignPatterns.Models.Characters
{
    public class Warrior : Character
    {
        public Warrior(string name) : base(name, 100, 20, 15, 8) 
        {
            InitializeDefaultStrategy();
        }

        protected override void InitializeDefaultStrategy()
        {
            CurrentActionStrategy = new MeleeAction();
        }
        public override string UseAbility() => $"{Name} uses Mighty Slash!";
    }
}

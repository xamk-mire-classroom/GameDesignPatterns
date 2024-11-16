using GameDesignPatterns.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Models.Characters
{
    public class Archer : Character
    {
        public Archer(string name) : base(name, 70, 40, 7, 15) 
        {
            InitializeDefaultStrategy();
        }

        protected override void InitializeDefaultStrategy()
        {
            CurrentActionStrategy = new RangedAction();
        }
        public override string UseAbility() => $"{Name} shoots Precise Arrow!";
    }
}

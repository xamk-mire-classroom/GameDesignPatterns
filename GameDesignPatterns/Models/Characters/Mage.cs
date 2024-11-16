using GameDesignPatterns.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameDesignPatterns.Models.Characters
{
    public class Mage : Character
    {
        public Mage(string name) : base(name, 60, 100, 4, 6) 
        {
            InitializeDefaultStrategy();
        }

        protected override void InitializeDefaultStrategy()
        {
            CurrentActionStrategy = new MagicAction();
        }
        public override string UseAbility() => $"{Name} casts Fireball!";
    }
}

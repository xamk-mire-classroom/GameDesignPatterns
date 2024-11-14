using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Models
{
    public class Warrior : Character
    {
        public Warrior(string name) : base(name, 100, 20, 15, 8) { }
        public override string UseAbility() => $"{name} uses Mighty Slash!";
    }
}

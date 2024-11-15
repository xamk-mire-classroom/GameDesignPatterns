using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Models
{
    public class Archer : Character
    {
        public Archer(string name) : base(name, 70, 40, 7, 15) { }
        public override string UseAbility() => $"{name} shoots Precise Arrow!";
    }
}

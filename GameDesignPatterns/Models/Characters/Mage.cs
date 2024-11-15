using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameDesignPatterns.Models
{
    public class Mage : Character
    {
        public Mage(string name) : base(name, 60, 100, 4, 6) { }
        public override string UseAbility() => $"{name} casts Fireball!";
    }
}

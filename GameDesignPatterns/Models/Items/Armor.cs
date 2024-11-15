using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Models.Items
{
    public class Armor : Item
    {
        public int Defense { get; set; }
        public int Durability { get; set; }
    }
}

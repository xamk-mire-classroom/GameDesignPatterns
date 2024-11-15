using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Models.Items
{
    public class Potion : Item
    {
        public string Effect { get; set; }
        public int Duration { get; set; }
    }
}

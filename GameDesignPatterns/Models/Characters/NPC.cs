using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Models
{
    // NPC class
    public class NPC
    {
        public int Id { get; }
        public string Name { get; }
        public string Role { get; }
        public (int, int) Location { get; }
        public string Behavior() { return ""; }

        public NPC(int id, string name, string role, (int, int) location)
        {
            Id = id;
            Name = name;
            Role = role;
            Location = location;
        }
    }
}

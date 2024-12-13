using GameDesignPatterns.Enums;
using GameDesignPatterns.Models.Quests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Models.Locations
{
    public class Location
    {
        public string Name { get; }
        public LocationType Type { get; }
        public Position Position { get; }
        public List<NPC> NPCs { get; } = new List<NPC>();
        public List<IQuest> AvailableQuests { get; } = new List<IQuest>();

        public Location(string name, LocationType type, Position position)
        {
            Name = name;
            Type = type;
            Position = position;
        }

        public void AddNPC(NPC npc)
        {
            NPCs.Add(npc);
        }

        public void AddQuest(IQuest quest)
        {
            AvailableQuests.Add(quest);
        }
    }
}

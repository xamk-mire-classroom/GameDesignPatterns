using GameDesignPatterns.Enums;
using GameDesignPatterns.Models.Quests;
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
        public NPCType Type { get; }
        public Position Position { get; private set; }
        public Dictionary<string, string> Dialogue { get; } = new Dictionary<string, string>();
        public List<IQuest> OfferedQuests { get; } = new List<IQuest>();

        public NPC(int id, string name, NPCType type, Position position)
        {
            Id = id;
            Name = name;
            Type = type;
            Position = position;
            InitializeDefaultDialogue();
        }

        private void InitializeDefaultDialogue()
        {
            switch (Type)
            {
                case NPCType.Villager:
                    Dialogue["greeting"] = "Welcome, traveler!";
                    Dialogue["quest"] = "I might have some work for you...";
                    break;
                case NPCType.Merchant:
                    Dialogue["greeting"] = "Looking to trade?";
                    Dialogue["quest"] = "Help me with my goods, and I'll reward you well.";
                    break;
                case NPCType.Royalty:
                    Dialogue["greeting"] = "Welcome to our realm.";
                    Dialogue["quest"] = "We have an important task that requires your skills.";
                    break;
            }
        }

        public string GetDialogue(string key)
        {
            return Dialogue.TryGetValue(key, out string? dialogue) ? dialogue : "...";
        }

        public void AddQuest(IQuest quest)
        {
            OfferedQuests.Add(quest);
        }
    }
}

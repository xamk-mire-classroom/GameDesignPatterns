using System;
using System.Collections.Generic;
using GameDesignPatterns.Models.Quests;

namespace GameDesignPatterns.Patterns.Factory
{
    public interface IQuestFactory
    {
        IQuest CreateMainQuest(string title, string description, int requiredKills);
        IQuest CreateSideQuest(string title, string description, List<string> objectives);
    }

    public class QuestFactory : IQuestFactory
    {
        public IQuest CreateMainQuest(string title, string description, int requiredKills)
        {
            return new MainQuest(title, description, requiredKills);
        }

        public IQuest CreateSideQuest(string title, string description, List<string> objectives)
        {
            return new SideQuest(title, description, objectives);
        }
    }
}
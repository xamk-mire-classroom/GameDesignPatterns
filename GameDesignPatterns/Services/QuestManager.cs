using System;
using System.Collections.Generic;
using System.Linq;
using GameDesignPatterns.Enums;
using GameDesignPatterns.Models.Quests;
using GameDesignPatterns.Patterns.Factory;

namespace GameDesignPatterns.Services
{
    public interface IQuestManager
    {
        IQuest CreateMainQuest(string title, string description, int requiredKills);
        IQuest CreateSideQuest(string title, string description, List<string> objectives);
        IEnumerable<IQuest> GetActiveQuests();
        IEnumerable<IQuest> GetCompletedQuests();
        void AbandonQuest(string questId);
    }

    public class QuestManager : IQuestManager
    {
        private readonly IQuestFactory _questFactory;
        private List<IQuest> _activeQuests;
        private List<IQuest> _completedQuests;

        public QuestManager(IQuestFactory questFactory)
        {
            _questFactory = questFactory;
            _activeQuests = new List<IQuest>();
            _completedQuests = new List<IQuest>();
        }

        public IQuest CreateMainQuest(string title, string description, int requiredKills)
        {
            var quest = _questFactory.CreateMainQuest(title, description, requiredKills);
            _activeQuests.Add(quest);
            return quest;
        }

        public IQuest CreateSideQuest(string title, string description, List<string> objectives)
        {
            var quest = _questFactory.CreateSideQuest(title, description, objectives);
            _activeQuests.Add(quest);
            return quest;
        }

        public IEnumerable<IQuest> GetActiveQuests()
        {
            return _activeQuests.ToList();
        }

        public IEnumerable<IQuest> GetCompletedQuests()
        {
            return _completedQuests.ToList();
        }

        public void AbandonQuest(string questId)
        {
            var quest = _activeQuests.FirstOrDefault(q => q.QuestId == questId);
            if (quest != null)
            {
                quest.Status = Enums.QuestStatus.Abandoned;
                _activeQuests.Remove(quest);
            }
        }

        // Method to update quest status and move completed quests
        public void UpdateQuestStatus(IQuest quest)
        {
            if (quest.Status == QuestStatus.Completed)
            {
                if (_activeQuests.Contains(quest))
                {
                    _activeQuests.Remove(quest);
                    _completedQuests.Add(quest);
                    
                }
            }
        }
    }
}
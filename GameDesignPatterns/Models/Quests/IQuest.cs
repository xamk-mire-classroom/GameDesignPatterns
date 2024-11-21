using System;
using GameDesignPatterns.Enums;

namespace GameDesignPatterns.Models.Quests
{
    public interface IQuest
    {
        string QuestId { get; }
        string Title { get; }
        string Description { get; }
        QuestStatus Status { get; set; }

        int RewardExperience { get; }
        object Reward { get; }

        void Start();
        void Complete();
        void Fail();
        void UpdateProgress(object progressData);
    }
}
using GameDesignPatterns.Enums;
using GameDesignPatterns.Services;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GameDesignPatterns.Models.Quests
{
    public class MainQuest : BaseQuest
    {
        public int RequiredKills { get; private set; }
        private int _currentKills;
        public int CurrentKills => _currentKills;
        public readonly QuestManager questManager;

        public MainQuest(string title, string description, int requiredKills)
        {
            Title = title;
            Description = description;
            RequiredKills = requiredKills;
            RewardExperience = 500;
            Reward = new { Gold = 250, SpecialItem = "Legendary Sword" };
        }

        public override void UpdateProgress(object progressData)
        {
            // First check if quest is already completed
            if (Status == QuestStatus.Completed)
            {
                return;  // Don't process updates for completed quests
            }

            if (progressData is int kills && Status == QuestStatus.InProgress)
            {
                _currentKills += kills;
                
                if (_currentKills >= RequiredKills)
                {
                    _currentKills = RequiredKills; 
                    Complete();                
                    Console.WriteLine($"Quest '{Title}' completed!");
                    return;
                }

                Console.WriteLine($"Progress: {_currentKills}/{RequiredKills} kills");
            }
        }
        public override void Start()
        {
            Status = QuestStatus.InProgress;
        }
    }
}
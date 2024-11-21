using System;
using System.Collections.Generic;

namespace GameDesignPatterns.Models.Quests
{
    public class MainQuest : BaseQuest
    {
        public int RequiredKills { get; private set; }
        private int _currentKills;

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
            if (progressData is int kills)
            {
                _currentKills += kills;

                if (_currentKills >= RequiredKills)
                {
                    Complete();
                }

                Console.WriteLine($"Progress: {_currentKills}/{RequiredKills} kills");
            }
        }
    }
}
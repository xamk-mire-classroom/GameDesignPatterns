using System;
using GameDesignPatterns.Enums;

namespace GameDesignPatterns.Models.Quests
{
    public abstract class BaseQuest : IQuest
    {
        public string QuestId { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public QuestStatus Status { get; set; }

        public int RewardExperience { get; protected set; }
        public object Reward { get; protected set; }

        protected BaseQuest()
        {
            QuestId = Guid.NewGuid().ToString();
            Status = QuestStatus.NotStarted;
        }

        public virtual void Start()
        {
            if (Status == QuestStatus.NotStarted)
            {
                Status = QuestStatus.InProgress;
                Console.WriteLine($"Quest Started: {Title}");
            }
        }

        public virtual void Complete()
        {
            if (Status == QuestStatus.InProgress)
            {
                Status = QuestStatus.Completed;
                Console.WriteLine($"Quest Completed: {Title}");
            }
        }

        public virtual void Fail()
        {
            Status = QuestStatus.Failed;
            Console.WriteLine($"Quest Failed: {Title}");
        }

        public abstract void UpdateProgress(object progressData);
    }
}
using GameDesignPatterns.Models.Quests;

public class SideQuest : BaseQuest
{
    public List<string> Objectives { get; private set; }
    private int _completedObjectives;

    public SideQuest(string title, string description, List<string> objectives)
    {
        Title = title;
        Description = description;
        Objectives = objectives;
        RewardExperience = 100;
        Reward = new { Gold = 50 };
    }

    public override void UpdateProgress(object progressData)
    {
        if (progressData is string objective)
        {
            if (Objectives.Contains(objective))
            {
                Objectives.Remove(objective);
                _completedObjectives++;

                Console.WriteLine($"Objective Completed: {objective}");

                if (Objectives.Count == 0)
                {
                    Complete();
                }
            }
        }
    }
}
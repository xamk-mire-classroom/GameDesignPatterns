using System;
using System.Collections.Generic;
using GameDesignPatterns.Patterns;
using GameDesignPatterns.Patterns.Factory;
using GameDesignPatterns.Services;

class Program
{
    static void Main(string[] args)
    {
        // Demonstrate Game Design Patterns
        DemonstrateGameSystem();

        // Demonstrate Quest System
        var demo = new QuestSystemDemo();
        demo.RunDemonstration();
    }

    static void DemonstrateGameSystem()
    {
        // Singleton usage
        GameDesignPatterns.Patterns.Singleton.GameWorld gameWorld = GameDesignPatterns.Patterns.Singleton.GameWorld.getInstance();

        // Create a CharacterFactory
        GameDesignPatterns.Patterns.Factory.CharacterFactory characterFactory = new GameDesignPatterns.Patterns.Factory.CharacterFactory();

        // Create characters dynamically based on type input
        var warrior = characterFactory.CreateCharacter("warrior", "Conan");
        var mage = characterFactory.CreateCharacter("mage", "Gandalf");
        var archer = characterFactory.CreateCharacter("archer", "Legolas");

        // Demonstrate character abilities
        Console.WriteLine(warrior.UseAbility());
        Console.WriteLine(mage.UseAbility());
        Console.WriteLine(archer.UseAbility());

        // Dynamic strategy change example
        warrior.ChangeActionStrategy(new HealAction());  // Switch from default to healing

        // Dynamic state change example
        warrior.ChangeState(new ActionState());  // Switch to action state
        warrior.ChangeState(new DefendingState());  // Switch to defending state
    }
}

class QuestSystemDemo
{
    private readonly IQuestManager _questManager;

    public QuestSystemDemo()
    {
        // Dependency Injection - Creating factory and manager
        IQuestFactory questFactory = new QuestFactory();
        _questManager = new QuestManager(questFactory);
    }

    public void RunDemonstration()
    {
        Console.WriteLine("Quest System Demonstration");
        Console.WriteLine("-------------------------");

        // Create a main quest
        var mainQuest = _questManager.CreateMainQuest(
            "Dragon Slayer",
            "Defeat 10 dragons in the mountain region",
            10
        );
        mainQuest.Start();
        Console.WriteLine($"Main Quest Started: {mainQuest.Title}");

        // Simulate quest progress
        mainQuest.UpdateProgress(5);
        Console.WriteLine($"Main Quest Progress: 5/10");
        mainQuest.UpdateProgress(5);
        Console.WriteLine($"Main Quest Status: {mainQuest.Status}");

        // Create a side quest
        var sideQuest = _questManager.CreateSideQuest(
            "Herb Gathering",
            "Collect various herbs in the forest",
            new List<string> { "Red Herb", "Blue Herb", "Green Herb" }
        );
        sideQuest.Start();
        Console.WriteLine($"Side Quest Started: {sideQuest.Title}");

        // Simulate side quest progress
        sideQuest.UpdateProgress("Red Herb");
        sideQuest.UpdateProgress("Blue Herb");
        sideQuest.UpdateProgress("Green Herb");
        Console.WriteLine($"Side Quest Status: {sideQuest.Status}");

        // Display active and completed quests
        Console.WriteLine("\nActive Quests:");
        foreach (var quest in _questManager.GetActiveQuests())
        {
            Console.WriteLine($"- {quest.Title}: {quest.Status}");
        }

        Console.WriteLine("\nCompleted Quests:");
        foreach (var quest in _questManager.GetCompletedQuests())
        {
            Console.WriteLine($"- {quest.Title}: {quest.Status}");
        }
    }
}
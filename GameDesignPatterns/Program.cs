using System;
using System.Collections.Generic;
using GameDesignPatterns.Enums;
using GameDesignPatterns.Patterns;
using GameDesignPatterns.Patterns.Command.Controller;
using GameDesignPatterns.Patterns.Factory;
using GameDesignPatterns.Services;
using GameDesignPatterns.Models.Enemies;
using GameDesignPatterns.Models.Characters;
using GameDesignPatterns.Patterns.Singleton;
using System.ComponentModel.DataAnnotations;
using GameDesignPatterns.Models;
using GameDesignPatterns.Models.Items;

class Program
{
    static void Main(string[] args)
    {
        // Demonstrate Game Design Patterns
        DemonstrateGameSystem();

        //Demonstrate Quest System
        var demo = new QuestSystemDemo();
        demo.RunDemonstration();

        //Demonstrate Game Controller with Command Pattern
        DemonstrateGameController();
    }

    static void DemonstrateGameSystem()
    {
        Console.WriteLine("Welcome to the game world!");
        //Retrieve the singleton instance of gameworld
        GameWorld gameWorld = GameWorld.getInstance();

        //Display the game world map
        Console.WriteLine("\n-- Game world map ---");
        var worldMap = gameWorld.GetWorldMap();
        foreach (var row in worldMap)
        {
            Console.WriteLine(string.Join(" ", row));
        }

        //Display initial game world state
        Console.WriteLine("\n--- Game world state ---");
        Console.WriteLine($"Weather: {gameWorld.GetWeather()}");
        Console.WriteLine($"Time of day: {gameWorld.GetTimeOfDay()}");

        //Display NPCs
        Console.WriteLine("\n--- NPCs in the game world ----");
        foreach (var npc in gameWorld.GetNPCs())
        {
            Console.WriteLine($"NPC: {npc.Name} ({npc.Role}) at location {npc.Location}");
            Console.WriteLine($"{npc.Name}: \"{GetNPCDialogue(npc)}\"");
        }

        static string GetNPCDialogue(NPC npc)
        {
            return npc.Role switch
            {
                "Quest Giver" => "I have an important task for you, brave adventurer!",
                "Trader" => "Would you like to trade some goods?",
                _ => "Hello there, traveler."
            };
        }

        



        // Use the CharacterFactoryProvider to get the correct factory
        var warriorFactory = GameDesignPatterns.Patterns.Factory.CharacterFactory.CharacterFactoryProvider.GetFactory("warrior");
        var mageFactory = GameDesignPatterns.Patterns.Factory.CharacterFactory.CharacterFactoryProvider.GetFactory("mage");
        var archerFactory = GameDesignPatterns.Patterns.Factory.CharacterFactory.CharacterFactoryProvider.GetFactory("archer");

        // Create characters
        var warrior = warriorFactory.CreateCharacter("Conan");
        var mage = mageFactory.CreateCharacter("Gandalf");
        var archer = archerFactory.CreateCharacter("Legolas");

        // Demonstrate character abilities
        Console.WriteLine(warrior.UseAbility());
            Console.WriteLine(mage.UseAbility());
            Console.WriteLine(archer.UseAbility());

            // Dynamic strategy change example
            warrior.SetAction(new HealAction());  // Switch from default to healing

            // Dynamic state change example
            warrior.ChangeState(new ActionState());  // Switch to action state
            warrior.ChangeState(new DefendingState());  // Switch to defending state
        }


        static void DemonstrateGameController()
        {
            Console.WriteLine("\n--- Game Controller Demonstration ---");



            // Use the CharacterFactoryProvider to get the correct factory
            var warriorFactory = GameDesignPatterns.Patterns.Factory.CharacterFactory.CharacterFactoryProvider.GetFactory("warrior");
            var mageFactory = GameDesignPatterns.Patterns.Factory.CharacterFactory.CharacterFactoryProvider.GetFactory("mage");
            var archerFactory = GameDesignPatterns.Patterns.Factory.CharacterFactory.CharacterFactoryProvider.GetFactory("archer");

            // Create characters
            var warrior = warriorFactory.CreateCharacter("Conan");
            var mage = mageFactory.CreateCharacter("Gandalf");
            var archer = archerFactory.CreateCharacter("Legolas");

            // Create an enemy (example: Slime)
            var enemy = new Slime(GameDesignPatterns.Enums.EnemyRank.Normal);

            // Instantiate GameController with one character and one enemy
            var gameController = new GameController(warrior, enemy);

            Console.WriteLine("Game started! Use the following keys to control the player:");
            Console.WriteLine("A - Attack | D - Defend | H - Heal");
            Console.WriteLine("Arrow keys - Move | Q - Quit");
            Console.WriteLine("--------------------------------------------------");

            // Game loop
            bool running = true;
            while (running)
            {
                
                Console.Write("\nEnter a command: ");
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.Q: // Quit the game
                        running = false;
                        Console.WriteLine("Exiting the game...");
                        break;

                    default:
                        gameController.HandleInput(key);
                        break;
                }
            }
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

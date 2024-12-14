using GameDesignPatterns.Enums;
using GameDesignPatterns.Models.Locations;
using GameDesignPatterns.Models;
using GameDesignPatterns.Patterns.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDesignPatterns.Patterns.Factory;
using GameDesignPatterns.Models.Quests;

namespace GameDesignPatterns.Services
{
    public class GameWorldInteraction
    {
        private readonly GameWorld gameWorld;
        private readonly Character player;
        private Location? currentLocation;
        public readonly QuestManager questManager;

        public GameWorldInteraction(Character player, QuestManager questManager)
        {
            this.gameWorld = GameWorld.GetInstance();
            this.player = player;
            this.currentLocation = gameWorld.GetLocation(player.CurrentPosition);
            this.questManager = questManager;
        }

        public bool MoveToLocation(Position newPosition)
        {
            var targetLocation = gameWorld.GetLocation(newPosition);
            if (targetLocation == null)
            {
                Console.WriteLine($"Cannot move to position {newPosition} - no location exists there.");
                Console.WriteLine("Try a different direction!");
                return false;
            }

            player.CurrentPosition = newPosition;
            currentLocation = targetLocation;
            Console.WriteLine($"\nMoved to {currentLocation.Name}!");
            DisplayLocationInfo();
            return true;
        }

        public void DisplayLocationInfo()
        {
            if (currentLocation == null)
            {
                Console.WriteLine("\nPlayer is not in a valid location!");
                return;
            }
            Console.WriteLine($"\nCurrent Location: {currentLocation.Name} ({currentLocation.Type})");
            Console.WriteLine($"Weather: {gameWorld.GetWeather()}, Time: {gameWorld.GetTimeOfDay()}");
            Console.WriteLine("\nNPCs present:");
            foreach (var npc in currentLocation.NPCs)
            {
                Console.WriteLine($"- {npc.Name} ({npc.Type})");
            }
        }

        public void InteractWithNPC(string npcName)
        {
            if (currentLocation == null)
            {
                Console.WriteLine("Cannot interact - player is not in a valid location.");
                return;
            }

            var npc = currentLocation.NPCs.FirstOrDefault(n => n.Name.Equals(npcName, StringComparison.OrdinalIgnoreCase));
            if (npc == null)
            {
                Console.WriteLine($"No NPC named {npcName} found at this location.");
                return;
            }

            Console.WriteLine($"\nInteracting with {npc.Name}");
            Console.WriteLine(npc.GetDialogue("greeting"));

            // Check if NPC has any available quests
            if (!npc.OfferedQuests.Any())
            {
                // Create appropriate quest based on NPC type
                CreateNPCQuest(npc);
            }
            
            if (npc.OfferedQuests.Any())
            {
                // Display and manage available quests
                DisplayAvailableQuests(npc);
                
            }

            //Check for active quests that can be completed
            foreach (var quest in questManager.GetActiveQuests())
            {
                if (quest.Status == QuestStatus.InProgress)
                {
                    if (quest is MainQuest mainQuest && mainQuest.CurrentKills >= mainQuest.RequiredKills)
                    {
                        Console.WriteLine($"\nReady to complete: {quest.Title}");
                        Console.WriteLine("Complete quest? (Y/N)");
                        if (Console.ReadKey(true).Key == ConsoleKey.Y)
                        {
                            quest.Complete();
                        }
                    }
                    // Similar check for SideQuest if needed
                }
            }
        }

        private void CreateNPCQuest(NPC npc)
        {
            IQuest? quest = npc.Type switch
            {
                NPCType.Royalty => questManager.CreateMainQuest(
                    "Royal Command",
                    "Defeat the monsters threatening our realm",
                    5),
                NPCType.Merchant => questManager.CreateSideQuest(
                    "Merchant's Request",
                    "Collect trading goods",
                    new List<string> { "Find rare herbs", "Collect minerals", "Gather wood" }),
                NPCType.Villager => questManager.CreateSideQuest(
                    "Village Aid",
                    "Help the village with various tasks",
                    new List<string> { "Fix the fence", "Clear the garden", "Find lost sheep" }),
                _ => null
            };

            if (quest != null)
            {
                npc.OfferedQuests.Add(quest);
            }
        }

        private void DisplayAvailableQuests(NPC npc)
        {
            Console.WriteLine("\nAvailable Quests:");
            
            foreach (var quest in npc.OfferedQuests)
            {
                Console.WriteLine($"- {quest.Title}: {quest.Description}");
                Console.WriteLine($"  Reward: {quest.RewardExperience} XP");

                if (quest.Status == QuestStatus.NotStarted)
                {
                    Console.WriteLine("Accept this quest? (Y/N)");
                    if (Console.ReadKey(true).Key == ConsoleKey.Y)
                    {
                        quest.Start();
                        Console.WriteLine($"\nAccepted quest: {quest.Title}");
                    }
                }
            }
        }

        public void HandleLocationEvents()
        {
            if (currentLocation == null)
            {
                return;
            }
            // Handle any events that should occur in the current location
            // For example, random encounters, weather changes, or time-based events
            var time = gameWorld.GetTimeOfDay();
            var weather = gameWorld.GetWeather();

            if (currentLocation.Type == LocationType.Dungeon && time == TimeOfDay.Night)
            {
                Console.WriteLine("The dungeon seems more dangerous at night...");
                // Could trigger combat or other events here
            }
        }


        public void HandleInput(ConsoleKey key)
        {
            Position newPosition;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    newPosition = new Position(player.CurrentPosition.X, player.CurrentPosition.Y + 1);
                    Console.WriteLine($"Attempting to move North to position {newPosition}");
                    MoveToLocation(newPosition);
                    break;
                case ConsoleKey.DownArrow:
                    newPosition = new Position(player.CurrentPosition.X, player.CurrentPosition.Y - 1);
                    Console.WriteLine($"Attempting to move South to position {newPosition}");
                    MoveToLocation(newPosition);
                    break;
                case ConsoleKey.LeftArrow:
                    newPosition = new Position(player.CurrentPosition.X - 1, player.CurrentPosition.Y);
                    Console.WriteLine($"Attempting to move West to position {newPosition}");
                    MoveToLocation(newPosition);
                    break;
                case ConsoleKey.RightArrow:
                    newPosition = new Position(player.CurrentPosition.X + 1, player.CurrentPosition.Y);
                    Console.WriteLine($"Attempting to move East to position {newPosition}");
                    MoveToLocation(newPosition);
                    break;
            }
        }
    }
}

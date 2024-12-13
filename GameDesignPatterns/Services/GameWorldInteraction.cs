using GameDesignPatterns.Enums;
using GameDesignPatterns.Models.Locations;
using GameDesignPatterns.Models;
using GameDesignPatterns.Patterns.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Services
{
    public class GameWorldInteraction
    {
        private readonly GameWorld gameWorld;
        private readonly Character player;
        private Location? currentLocation;

        public GameWorldInteraction(Character player)
        {
            this.gameWorld = GameWorld.GetInstance();
            this.player = player;
            this.currentLocation = gameWorld.GetLocation(player.CurrentPosition);
        }

        public bool MoveToLocation(Position newPosition)
        {
            var targetLocation = gameWorld.GetLocation(newPosition);
            if (targetLocation == null)
            {
                Console.WriteLine("Cannot move there - no location exists at that position.");
                return false;
            }

            player.CurrentPosition = newPosition;
            currentLocation = targetLocation;
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

            if (npc.OfferedQuests.Any())
            {
                Console.WriteLine(npc.GetDialogue("quest"));
                DisplayAvailableQuests(npc);
            }
        }

        private void DisplayAvailableQuests(NPC npc)
        {
            Console.WriteLine("\nAvailable Quests:");
            foreach (var quest in npc.OfferedQuests)
            {
                Console.WriteLine($"- {quest.Title}: {quest.Description}");
                Console.WriteLine($"  Reward: {quest.RewardExperience} XP");
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
    }
}

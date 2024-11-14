using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDesignPatterns.Enums;
using GameDesignPatterns.Models;

namespace GameDesignPatterns.Patterns.Singleton
{
    // Singleton Pattern - Game World

    // GameWorld singleton class
    public class GameWorld
    {
        private static GameWorld instance;
        private string[][] worldMap;
        private List<NPC> npcs;
        private Weather weather;
        private TimeOfDay timeOfDay;

        private GameWorld()
        {
            // Initialize world map, NPCs, etc.

            // Initialize world map
            worldMap = new string[][]
            {
        new string[] { "🌳", "🌳", "🏠", "🌳", "⛰" },
        new string[] { "🌳", "🏕", "🛣", "🏕", "🌳" },
        new string[] { "🏰", "🛣", "⛲", "🛣", "🏠" },
        new string[] { "🌳", "🏕", "🛣", "🏕", "🌳" },
        new string[] { "⛰", "🌳", "🏠", "🌳", "🌳" }
            };

            // Initialize NPCs
            npcs = new List<NPC>
    {
        new NPC(1, "Old Sage", "Quest Giver", (2, 2)),
        new NPC(2, "Merchant", "Trader", (0, 2))
    };

            // Initialize weather and time of day
            weather = Weather.Sunny;
            timeOfDay = TimeOfDay.Morning;
        }

        public static GameWorld getInstance()
        {
            if (instance == null)
            {
                instance = new GameWorld();
            }
            return instance;
        }

        // Getter and setter methods for game state
        public string[][] GetWorldMap() { return worldMap; }
        public List<NPC> GetNPCs() { return npcs; }
        public Weather GetWeather() { return weather; }
        public TimeOfDay GetTimeOfDay() { return timeOfDay; }
        public void SetWeather(Weather newWeather) { weather = newWeather; }
        public void SetTimeOfDay(TimeOfDay newTime) { timeOfDay = newTime; }
    }
}

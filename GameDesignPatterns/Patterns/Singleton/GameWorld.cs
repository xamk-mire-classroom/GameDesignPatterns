using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDesignPatterns.Enums;
using GameDesignPatterns.Models;
using GameDesignPatterns.Models.Locations;

namespace GameDesignPatterns.Patterns.Singleton
{
    public class GameWorld
    {
        private static GameWorld? instance;
        private readonly Dictionary<Position, Location> locations = new Dictionary<Position, Location>();
        private Weather weather;
        private TimeOfDay timeOfDay;

        private GameWorld()
        {
            InitializeWorld();
        }

        private void InitializeWorld()
        {

            // Create locations with more spread out coordinates
            CreateLocation("Riverwood Village", LocationType.Village, new Position(0, 0));    // Center
            CreateLocation("Dark Cave", LocationType.Dungeon, new Position(-1, 0));          // West
            CreateLocation("Highcastle Town", LocationType.Town, new Position(1, 0));        // East
            CreateLocation("Forest Camp", LocationType.Village, new Position(0, 1));         // North
            CreateLocation("Lake Settlement", LocationType.Village, new Position(0, -1));    // South

            weather = Weather.Sunny;
            timeOfDay = TimeOfDay.Morning;
        }

        private void CreateLocation(string name, LocationType type, Position position)
        {
            var location = new Location(name, type, position);
            locations[position] = location;

            // Add NPCs based on location type
            switch (type)
            {
                case LocationType.Village:
                    location.AddNPC(new NPC(GetNextNPCId(), "Village Elder", NPCType.Villager, position));
                    location.AddNPC(new NPC(GetNextNPCId(), "Traveling Merchant", NPCType.Merchant, position));
                    break;
                case LocationType.Town:
                    location.AddNPC(new NPC(GetNextNPCId(), "Town Mayor", NPCType.Royalty, position));
                    location.AddNPC(new NPC(GetNextNPCId(), "Shop Owner", NPCType.Merchant, position));
                    break;
                case LocationType.Dungeon:
                    // Dungeons might have special NPCs or none at all
                    break;
            }
        }

        private int npcIdCounter = 0;
        private int GetNextNPCId() => ++npcIdCounter;

        public static GameWorld GetInstance()
        {
            instance ??= new GameWorld();
            return instance;
        }

        public Location? GetLocation(Position position)
        {
            return locations.TryGetValue(position, out var location) ? location : null;
        }

        public IEnumerable<Location> GetAllLocations() => locations.Values;
        public Weather GetWeather() => weather;
        public TimeOfDay GetTimeOfDay() => timeOfDay;
        public void SetWeather(Weather newWeather) => weather = newWeather;
        public void SetTimeOfDay(TimeOfDay newTime) => timeOfDay = newTime;

    }
}
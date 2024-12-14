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
using System.Numerics;
using GameDesignPatterns.Models.Quests;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Game!");
        var player = CharacterCreation();
        var gameWorld = GameWorld.GetInstance();
        var questManager = new QuestManager(new QuestFactory());
        var worldInteraction = new GameWorldInteraction(player, questManager);
        BaseEnemy? currentEnemy = null;
        var gameController = new GameController(player,currentEnemy);

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n=== Game Menu ===");
            Console.WriteLine("1. View Character Info");
            Console.WriteLine("2. Explore World");
            Console.WriteLine("3. View Inventory");
            Console.WriteLine("4. View Equipment");
            Console.WriteLine("5. View Quests");
            Console.WriteLine("6. Save and Exit");
            Console.WriteLine("==================");

            Console.Write("Choose an option (1-6): ");
            var choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (choice)
            {
                case '1':
                    DisplayCharacterInfo(player);
                    break;
                case '2':
                    ExploreWorld(worldInteraction, player);
                    break;
                case '3':
                    ManageInventory(player);
                    break;
                case '4':
                    ManageEquipment(player);
                    break;
                case '5':
                    ManageQuests(questManager);
                    break;
                case '6':
                    running = false;
                    Console.WriteLine("Thanks for playing!");
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }

    static Character CharacterCreation()
    {
        Console.WriteLine("\n=== Character Creation ===");
        Console.WriteLine("Choose your class:");
        Console.WriteLine("1. Warrior (High strength and defense)");
        Console.WriteLine("2. Mage (High mana and magical abilities)");
        Console.WriteLine("3. Archer (High agility and ranged attacks)");

        Character? player = null;
        while (player == null)
        {
            Console.Write("Enter your choice (1-3): ");
            var choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            Console.Write("Enter your character's name: ");
            var name = Console.ReadLine() ?? "Hero";

            var factory = choice switch
            {
                '1' => CharacterFactory.CharacterFactoryProvider.GetFactory("warrior"),
                '2' => CharacterFactory.CharacterFactoryProvider.GetFactory("mage"),
                '3' => CharacterFactory.CharacterFactoryProvider.GetFactory("archer"),
                _ => null
            };

            if (factory != null)
            {
                player = factory.CreateCharacter(name);
                Console.WriteLine($"\nWelcome, {player.Name}!");
            }
            else
            {
                Console.WriteLine("Invalid choice! Please try again.");
            }
        }

        var commonFactory = new CommonItemFactory();
        var rareFactory = new RareItemFactory();
        var magicalFactory = new MagicalItemFactory();

        // Create various items
        var starterSword = commonFactory.CreateWeapon("Rusty Sword");
        var starterBow = commonFactory.CreateWeapon("Old Bow");
        var starterStaff = commonFactory.CreateWeapon("Apprentice Staff");
        var leatherArmor = commonFactory.CreateArmor("Leather Armor");
        var healthPotion = commonFactory.CreatePotion("Minor Health Potion");
        var manaPotion = commonFactory.CreatePotion("Minor Mana Potion");

        // Add basic equipment based on character class
        if (player is Warrior)
        {
            player.AddToInventory(starterSword);
            player.AddToInventory(leatherArmor);
            player.AddToInventory(healthPotion);
        }
        else if (player is Archer)
        {
            player.AddToInventory(starterBow);
            player.AddToInventory(leatherArmor);
            player.AddToInventory(healthPotion);
        }
        else if (player is Mage)
        {
            player.AddToInventory(starterStaff);
            player.AddToInventory(leatherArmor);
            player.AddToInventory(manaPotion);
        }

        // Add some additional items for testing
        var betterWeapon = rareFactory.CreateWeapon("Steel Blade");
        var betterArmor = magicalFactory.CreateArmor("Enchanted Robe");
        var strongPotion = rareFactory.CreatePotion("Greater Health Potion");

        player.AddToInventory(betterWeapon);
        player.AddToInventory(betterArmor);
        player.AddToInventory(strongPotion);

        return player;
    }

    static void DisplayCharacterInfo(Character player)
    {
        Console.WriteLine("\n=== Character Information ===");
        Console.WriteLine($"Name: {player.Name}");
        Console.WriteLine($"Health: {player.Health}/{player.MaxHealth}");
        Console.WriteLine($"Mana: {player.Mana}");
        Console.WriteLine($"Strength: {player.Strength}");
        Console.WriteLine($"Agility: {player.Agility}");
        Console.WriteLine($"Position: {player.CurrentPosition}");
    }

    static void ExploreWorld(GameWorldInteraction worldInteraction, Character player)
    {
        bool exploring = true;
        while (exploring)
        {
            Console.WriteLine("\n=== World Exploration ===");
            Console.WriteLine("1. View Current Location");
            Console.WriteLine("2. Move to New Location");
            Console.WriteLine("3. Interact with NPCs");
            Console.WriteLine("4. Look for Enemies");
            Console.WriteLine("5. Return to Main Menu");

            Console.Write("Choose an option (1-5): ");
            var choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (choice)
            {
                case '1':
                    worldInteraction.DisplayLocationInfo();
                    break;
                case '2':
                    Console.WriteLine("\nAvailable moves:");
                    Console.WriteLine("Use arrow keys to move:");
                    Console.WriteLine("Up - Move North");
                    Console.WriteLine("Down - Move South");
                    Console.WriteLine("Left - Move West");
                    Console.WriteLine("Right - Move East");
                    Console.WriteLine("Press any other key to cancel");

                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow ||
                        key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow)
                    {
                        worldInteraction.HandleInput(key);
                    }
                    break;
                case '3':
                    Console.Write("Enter NPC name to interact with: ");
                    var npcName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(npcName))
                    {
                        worldInteraction.InteractWithNPC(npcName);
                    }
                    break;
                case '4':
                    InitiateCombat(player, worldInteraction);
                    break;
                case '5':
                    exploring = false;
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }

    static void InitiateCombat(Character player, GameWorldInteraction worldInteraction)
    {
        Console.WriteLine("\n=== Combat Initiated ===");

        // Create a random enemy
        var enemy = CreateRandomEnemy();
        Console.WriteLine($"A {enemy.Name} appears!");

        // Create combat controller
        var gameController = new GameController(player, enemy);

        bool inCombat = true;
        while (inCombat)
        {
            // Check for combat end conditions first
            if (enemy.Health <= 0)
            {
                Console.WriteLine($"\nYou defeated the {enemy.Name}!");
                // Update any active main quests
                foreach (var quest in worldInteraction.questManager.GetActiveQuests().ToList())
                {
                    if (quest is MainQuest mainQuest && quest.Status != QuestStatus.Completed)
                    {
                        mainQuest.UpdateProgress(1);
                        if (quest.Status == QuestStatus.Completed)
                        {
                            worldInteraction.questManager.UpdateQuestStatus(quest);
                        }
                    }
                }
                break;
            }
            if (player.Health <= 0)
            {
                Console.WriteLine("\nYou have been defeated! Returning to town...");
                player.Health = player.MaxHealth / 2;  // Revive with half health
                break;  
            }

            Console.WriteLine($"\n{player.Name}'s HP: {player.Health}/{player.MaxHealth}");
            Console.WriteLine($"{enemy.Name}'s HP: {enemy.Health}");
            Console.WriteLine("\nActions:");
            Console.WriteLine("A - Attack");
            Console.WriteLine("D - Defend");
            Console.WriteLine("H - Heal");
            Console.WriteLine("R - Run Away");

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.R)
            {
                Console.WriteLine("You run away from combat!");
                inCombat = false;
                continue;
            }

            gameController.HandleInput(key);

            // Enemy's turn - they deal damage to player
            if (inCombat)
            {
                // Add simple enemy attack logic
                int enemyDamage = enemy.Strength - (player.EquippedArmor?.Defense ?? 0);
                if (enemyDamage > 0)
                {
                    player.Health -= enemyDamage;
                    Console.WriteLine($"{enemy.Name} attacks for {enemyDamage} damage!");
                }
                else
                {
                    Console.WriteLine($"{enemy.Name}'s attack was blocked by your armor!");
                }
            }
        }

        if (player.Health <= 0)
        {
            Console.WriteLine("You have been defeated! Returning to town...");
            player.Health = player.MaxHealth / 2;  // Revive with half health
        }
        else if (enemy.Health <= 0)
        {
            Console.WriteLine($"You defeated the {enemy.Name}!");
            // Could add rewards here
        }
    }

    static BaseEnemy CreateRandomEnemy()
    {
        var random = new Random();
        var enemyType = random.Next(3);  // 0-2
        var rank = random.Next(3) switch
        {
            0 => EnemyRank.Normal,
            1 => EnemyRank.Elite,
            _ => EnemyRank.Boss
        };

        return enemyType switch
        {
            0 => new Slime(rank),
            1 => new Goblin(rank),
            _ => new Dragon(rank)
        };
    }

    static void ManageInventory(Character player)
    {
        Console.WriteLine("\n=== Inventory Management ===");
        player.DisplayInventory();

        // Additional inventory management options could be added here
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);
    }

    static void ManageEquipment(Character player)
    {
        bool managing = true;
        while (managing)
        {
            Console.WriteLine("\n=== Equipment Management ===");
            player.DisplayEquipment();
            Console.WriteLine("\n1. Equip Item");
            Console.WriteLine("2. Unequip Item");
            Console.WriteLine("3. Return to Main Menu");

            Console.Write("Choose an option (1-3): ");
            var choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (choice)
            {
                case '1':
                    player.DisplayInventory();
                    Console.Write("\nEnter item name to equip: ");
                    var itemName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(itemName))
                    {
                        var item = player.Inventory.FirstOrDefault(i =>
                            i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
                        if (item != null)
                        {
                            player.EquipItem(item);
                        }
                        else
                        {
                            Console.WriteLine("Item not found in inventory.");
                        }
                    }
                    break;
                case '2':
                    Console.WriteLine("\nChoose slot to unequip:");
                    Console.WriteLine("1. Weapon");
                    Console.WriteLine("2. Armor");
                    Console.WriteLine("3. Potion");
                    var slotChoice = Console.ReadKey().KeyChar;
                    string slot = slotChoice switch
                    {
                        '1' => "weapon",
                        '2' => "armor",
                        '3' => "potion",
                        _ => ""
                    };
                    if (!string.IsNullOrEmpty(slot))
                    {
                        player.UnequipItem(slot);
                    }
                    break;
                case '3':
                    managing = false;
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }

    static void ManageQuests(QuestManager questManager)
    {
        Console.WriteLine("\n=== Quest Log ===");
        Console.WriteLine("\nActive Quests:");
        foreach (var quest in questManager.GetActiveQuests())
        {
            // Only show InProgress quests here
            if (quest.Status == QuestStatus.InProgress)
            {
                if (quest is MainQuest mainQuest)
                {
                    Console.WriteLine($"- {quest.Title}: {quest.Status}");
                    Console.WriteLine($"  Progress: {mainQuest.CurrentKills}/{mainQuest.RequiredKills} kills");
                }
                else
                {
                    Console.WriteLine($"- {quest.Title}: {quest.Status}");
                }
            }
        }

        Console.WriteLine("\nCompleted Quests:");
        foreach (var quest in questManager.GetCompletedQuests())
        {
            Console.WriteLine($"- {quest.Title}: {quest.Status}");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);
    }
}

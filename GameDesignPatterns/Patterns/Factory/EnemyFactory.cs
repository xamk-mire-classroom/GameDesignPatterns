using GameDesignPatterns.Enums;
using GameDesignPatterns.Models.Enemies;
using System;

namespace GameDesignPatterns.Patterns.Factory
{
    // Abstract factory interface
    public interface IEnemyFactory
    {
        IEnemy CreateEnemy(EnemyRank rank);
    }

    // Concrete factories for each enemy type
    public class SlimeFactory : IEnemyFactory
    {
        public IEnemy CreateEnemy(EnemyRank rank)
        {
            return new Slime(rank);
        }
    }

    public class GoblinFactory : IEnemyFactory
    {
        public IEnemy CreateEnemy(EnemyRank rank)
        {
            return new Goblin(rank);
        }
    }

    public class DragonFactory : IEnemyFactory
    {
        public IEnemy CreateEnemy(EnemyRank rank)
        {
            return new Dragon(rank);
        }
    }

    // Factory provider class
    public class EnemyFactoryProvider
    {
        public static IEnemyFactory GetFactory(string enemyType)
        {
            switch (enemyType.ToLower())
            {
                case "slime":
                    return new SlimeFactory();
                case "goblin":
                    return new GoblinFactory();
                case "dragon":
                    return new DragonFactory();
                default:
                    throw new ArgumentException($"Invalid enemy type: {enemyType}");
            }
        }
    }

    // Optional: Factory registry for dynamic enemy type registration
    public class EnemyFactoryRegistry
    {
        private static readonly Dictionary<string, IEnemyFactory> _factories = new();

        public static void RegisterFactory(string enemyType, IEnemyFactory factory)
        {
            _factories[enemyType.ToLower()] = factory;
        }

        public static IEnemyFactory GetFactory(string enemyType)
        {
            if (_factories.TryGetValue(enemyType.ToLower(), out var factory))
            {
                return factory;
            }
            throw new ArgumentException($"No factory registered for enemy type: {enemyType}");
        }
    }
}
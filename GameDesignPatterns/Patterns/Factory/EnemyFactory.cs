using GameDesignPatterns.Enums;
using GameDesignPatterns.Models.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Patterns.Factory
{
    public class EnemyFactory
    {
        public IEnemy CreateEnemy(string enemyType, EnemyRank rank)
        {
            return enemyType.ToLower() switch
            {
                "slime" => new Slime(rank),
                "goblin" => new Goblin(rank),
                "dragon" => new Dragon(rank),
                _ => throw new ArgumentException("Invalid enemy type")
            };
        }
    }
}

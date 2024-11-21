using GameDesignPatterns.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Models.Enemies
{
    public class Goblin : BaseEnemy
    {
        public Goblin(EnemyRank rank)
        {
            Name = $"{rank} Goblin";
            Rank = rank;
            SetStatsByRank();
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name} attacks with a rusty dagger!");
        }
    }
}

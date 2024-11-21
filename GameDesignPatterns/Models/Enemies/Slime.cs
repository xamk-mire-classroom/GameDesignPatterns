using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDesignPatterns.Enums;

namespace GameDesignPatterns.Models.Enemies
{
    public class Slime : BaseEnemy
    {
        public Slime(EnemyRank rank)
        {
            Name = $"{rank} Slime";
            Rank = rank;
            SetStatsByRank();
        }

        public override void Move()
        {
            Console.WriteLine($"{Name} slithers slowly.");
        }
    }
}
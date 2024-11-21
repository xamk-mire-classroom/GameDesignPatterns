﻿using GameDesignPatterns.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Models.Enemies
{
    public class Dragon : BaseEnemy
    {
        public Dragon(EnemyRank rank)
        {
            Name = $"{rank} Dragon";
            Rank = rank;
            SetStatsByRank();
        }

        public override void Move()
        {
            Console.WriteLine($"{Name} flies majestically.");
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name} breathes devastating fire!");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDesignPatterns.Enums;

namespace GameDesignPatterns.Models.Enemies
{
    public abstract class BaseEnemy : IEnemy
    {
        public string Name { get; protected set; }
        public EnemyRank Rank { get; protected set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }

        public virtual void Move()
        {
            Console.WriteLine($"{Name} is moving.");
        }

        public virtual void Attack()
        {
            Console.WriteLine($"{Name} is attacking.");
        }

        protected void SetStatsByRank()
        {
            switch (Rank)
            {
                case EnemyRank.Normal:
                    Health = 50;
                    Strength = 10;
                    Agility = 5;
                    Mana = 20;
                    break;
                case EnemyRank.Elite:
                    Health = 150;
                    Strength = 25;
                    Agility = 15;
                    Mana = 50;
                    break;
                case EnemyRank.Boss:
                    Health = 500;
                    Strength = 50;
                    Agility = 30;
                    Mana = 100;
                    break;
            }
        }
    }
}

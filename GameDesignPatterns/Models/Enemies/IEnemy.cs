using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameDesignPatterns.Enums;

namespace GameDesignPatterns.Models.Enemies
{
    public interface IEnemy
    {
        string Name { get; }
        EnemyRank Rank { get; }
        int Health { get; set; }
        int Mana { get; set; }
        int Strength { get; set; }
        int Agility { get; set; }

        void Move();
        void Attack();
    }
}

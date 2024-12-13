using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns.Models
{
    public class Position
    {
        public Position(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        //Move in a specific direction
        public void Move(int dx, int dy) 
        {
            X += dx;
            Y += dy;
        }

        //Calculate distance to another position
        public double DistanceTo(Position other) 
        {
            int dx = X - other.X;
            int dy = Y - other.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        //Override to string for easy printing
        public override string ToString() => $"({X} {Y})";

        //Static methods for creation positions
        public static Position operator +(Position a, Position b)=>
            new Position(a.X - b.X, a.Y - b.Y);
    }
}

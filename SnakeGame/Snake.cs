using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake
    {
        public int HeadRowPosition { get; set; } = 12;
        public int HeadColPosition { get; set; } = 3;

        public int TailRowPosition { get; set; } = 12;
        public int TailColPosition { get; set; } = 2;

        public int Size { get; set; } = 2;
        public Direction Direction { get; set; } = Direction.Right;

        public char Shape { get; set; } = '█';
        public char Space { get; set; } = ' ';
    }
    public enum Direction
    {
        Right = 0,
        Left = 1,
        Up = 2,
        Down = 3
    }
}
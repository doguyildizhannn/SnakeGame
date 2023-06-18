using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnakeGame
{
    public class World
    {
        public int RowLength { get; set; } = 27;
        public int ColumnLength { get; set; } = 75;
        public Node[,] SnakeWorld { get; set; }
        public char Shape { get; set; } = '█';
        public char Space { get; set; } = ' ';
        public Node[,] CreateWorld()
        {
            Node[,] Arr = new Node[27, 75];

            for (int i = 0; i < RowLength; i++)
            {
                for (int j = 0; j < ColumnLength; j++)
                {
                    Arr[i, j] = new Node();

                    if (i == 0 || j == 0 || i == RowLength - 1 || j == ColumnLength - 1)
                    {
                        Arr[i, j].Shape = Shape;
                        Arr[i, j].Indicator = "W";
                    }
                    else
                    {
                        Arr[i, j].Shape = Space;
                        Arr[i, j].Indicator = "S";
                    }
                }
            }

            return Arr;
        }

        public Node[,] UpdateWorld(Node[,] World, Snake Snake, Bait Bait)
        {
            World[Snake.HeadRowPosition, Snake.HeadColPosition].Shape = Snake.Shape;
            World[Snake.HeadRowPosition, Snake.HeadColPosition].Indicator = "H";


            World[Snake.TailRowPosition, Snake.TailColPosition].Shape = Snake.Shape;
            World[Snake.TailRowPosition, Snake.TailColPosition].Indicator = "T";


            World[Bait.BaitRowPosition, Bait.BaitColPosition].Shape = Bait.Shape;
            World[Bait.BaitRowPosition, Bait.BaitColPosition].Indicator = "B";


            return World;
        }

        public void DrawWorld(Node[,] World)
        {
            for (int i = 0; i < RowLength; i++)
            {
                for (int j = 0; j < ColumnLength; j++)
                {
                    Console.Write(World[i, j].Shape);
                }
                Console.Write('\n');
            }
        }
    }

    public class Node
    {
        public char Shape { get; set; }
        public String Indicator { get; set; }
        public Direction Direction { get; set; }
    }
}
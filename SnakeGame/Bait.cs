using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Bait
    {
        public int BaitRowPosition { get; set; } = 12;
        public int BaitColPosition { get; set; } = 36;
        public char Shape { get; set; } = '█';
        public char Space { get; set; } = ' ';

        public int RegenerateBaitRowPos(World world)
        {
            Random r = new Random();
            int rInt = r.Next(1, world.RowLength - 2);

            return rInt;
        }

        public int RegenerateBaitColPos(World world)
        {
            Random c = new Random();
            int cInt = c.Next(1, world.ColumnLength - 2);

            return cInt;
        }
    }
}
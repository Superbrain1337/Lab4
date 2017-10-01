using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    public class Entities
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Letter { get; set; }

        public Entities()
        {
            X = 0;
            Y = 0;
            Letter=' ';
        }

        public Entities(int x, int y, char letter, Random rnd, char[,] board)
        {
            this.X = x;
            this.Y = y;
            this.Letter = letter;
        }
    }
}

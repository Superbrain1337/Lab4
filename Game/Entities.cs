using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Entities
    {
        private int x = 0;
        private int y = 0;
        private char letter = ' ';
        private Random rnd = new Random();
        private char[,] board = new char[20, 50];

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public char Letter { get { return letter; } set { letter = value; } }
        public int RandomNumb(int x) => rnd.Next(x);
        public char[,] Board { get { return board; } set { board = value; } }
        
    }
    class PlayerClass : Entities
    {
        private int prevX = 0;
        private int prevY = 0;

        public int PrevX { get; set; }
        public int PrevY { get; set; }

    }
}

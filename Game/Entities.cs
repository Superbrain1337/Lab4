using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //public enum Rutor { Player = 80, Enemie = 69, Wall = 35, Room = 32, Door = 68, Stairs = 83, Key = 75 };
    abstract class Entities
    {
        
        private int x = 0;
        private int y = 0;
        private char letter = ' ';
        private Random rnd = new Random();
        private Entities[,] board = new Entities[20, 50];
        private int numbOfKeys = 0;


        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public char Letter { get { return letter; } set { letter = value; } }
        public int RandomNumb(int x) => rnd.Next(x);
        public Entities[,] Board { get { return board; } set { board = value; } }
        public int NumbOfKeys { get { return numbOfKeys; } set { numbOfKeys = value; } }
        
    }
    class PlayerClass : Entities
    {
        private int prevX = 0;
        private int prevY = 0;

        public int PrevX { get; set; }
        public int PrevY { get; set; }

    }
}

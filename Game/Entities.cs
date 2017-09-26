using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    
    public class Entities
    {
        
        private int x = 0;
        private int y = 0;
        private char letter;
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
        public PlayerClass() : base()
        {

        }

        private int prevX = 0;
        private int prevY = 0;
        private char letter;


        public int PrevX { get { return prevX; } set { prevX = value; } }
        public int PrevY { get { return prevY; } set { prevY = value; } }
        

    }
    class EmptyClass : Entities
    {
        private char letter;

        public new char Letter { get { return letter; } set { letter = ' '; } }
    }
    class WallClass : Entities
    {
        private char letter;

        public new char Letter { get { return letter; } set { letter = '#'; } }
    }
    class DoorClass : Entities
    {

    }
    class KeyClass : Entities
    {

    }
    class BoardClass : Entities
    {
        int x, y;

        public new int X { get { return x; } set { x = 20; } }
        public new int Y { get { return y; } set { y = 50; } }
    }
}

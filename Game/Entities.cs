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
    
    public class EnemyClass : Entities
    {
        public EnemyClass()
        {
            Letter = 'E';
        }

        public EnemyClass(int x, int y, char letter, Random rnd, char[,] board)
        {
            this.X = x;
            this.Y = y;
            this.Letter = letter;
        }
    }

    public class EmptyClass : Entities
    {
        public EmptyClass()
        {
            Letter = ' ';
        }

        public EmptyClass(int x, int y, char letter, Random rnd, char[,] board)
        {
            this.X = x;
            this.Y = y;
            this.Letter = letter;
        }
    }

    public class WallClass : Entities
    {
        public WallClass()
        {
            Letter = '#';
        }

        public WallClass(int x, int y, char letter, Random rnd, char[,] board)
        {
            this.X = x;
            this.Y = y;
            this.Letter = letter;
        }
    }

    public class DoorClass : Entities
    {
        public DoorClass()
        {
            Letter = 'D';
        }

        public DoorClass(int x, int y, char letter, Random rnd, char[,] board)
        {
            this.X = x;
            this.Y = y;
            this.Letter = letter;
        }
    }

    public class KeyClass : Entities
    {
        public KeyClass()
        {
            Letter = 'K';
        }

        public KeyClass(int x, int y, char letter, Random rnd, char[,] board)
        {
            this.X = x;
            this.Y = y;
            this.Letter = letter;
        }
    }

    public class BoardClass : Entities
    {
        public new int exitX { get; set; }
        public new int exitY { get; set; }


        public BoardClass()
        {
            X = 20;
            Y = 50;
            exitX = 2;
            exitY = 2;
        }

        public BoardClass(int x, int y, char letter, Random rnd, char[,] board)
        {
            this.X = x;
            this.Y = y;
            this.Letter = letter;

            this.exitX = exitX;
            this.exitY = exitY;
        }
    }
}

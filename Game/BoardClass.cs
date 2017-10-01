using System;

namespace Game
{
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

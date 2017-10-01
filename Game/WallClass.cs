using System;

namespace Game
{
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
}

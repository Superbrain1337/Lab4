using System;

namespace Game
{
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
}

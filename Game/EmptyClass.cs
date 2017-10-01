using System;

namespace Game
{
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
}

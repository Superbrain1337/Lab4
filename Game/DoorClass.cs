using System;

namespace Game
{
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
}

using System;

namespace Game
{
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
}

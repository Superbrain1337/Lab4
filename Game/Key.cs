using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Key:Entities, ILetter
    {
        public override int X { get; set; }
        public override int Y { get; set; }
        public char Letter { get; set; }
        public int KeyCount { get; set; }

        public Key()
        {
            Letter = 'K';
        }
        public void SpawnKey()
        {
            Y = 2 + Rnd.Next(Board.GetLength(0) - 4);
            X = 5 + Rnd.Next(Board.GetLength(1) - 10);
            while (KeyCount < 1)
            {
                if (Board[Y, X] == Ruta.Empty)
                {
                    Board[Y, X] = Ruta.Key;
                    KeyCount++;
                }
            }
        }

    }
}

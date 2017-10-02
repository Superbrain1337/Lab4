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

        public Key()
        {
            Letter = 'K';
        }
        public void SpawnKey()
        {
            Y = Rnd.Next(Board.GetLength(0));
            X = Rnd.Next(Board.GetLength(1));
            if(Board[Y,X] != Ruta.Wall)
            {
                Board[Y, X] = Ruta.Key;
            }
        }

        public void LookForKey()
        {
            if(Board[Y,X] == Ruta.Key) NumbOfKeys++;
        }

    }
}

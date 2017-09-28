using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Key:Entities
    {
        public Key()
        {
            Letter = 'K';
        }
        public void SpawnKey()
        {
            int y = RandomNumb(Board.GetLength(0));
            int x = RandomNumb(Board.GetLength(1));
            if(Board[y,x] != new Wall())
            {
                Board[y, x] = new Key();
            }
        }

        public void LookForKey()
        {
            if(Board[Y,X] == new Key()) NumbOfKeys++;
        }

    }
}

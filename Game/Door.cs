using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Door:Entities
    {
        
        public void CreateExit(Entities entities)
        {
            int wall = RandomNumb(4);
            int pos;
            if(wall == 0)
            {
                pos = RandomNumb(entities.Board.GetLength(1));
                entities.Board[0, pos] = Rutor.Door;
            }
            else if(wall == 1)
            {
                pos = RandomNumb(entities.Board.GetLength(0));
                entities.Board[pos, entities.Board.GetLength(1)-1] = Rutor.Door;
            }
            else if (wall == 2)
            {
                pos = RandomNumb(entities.Board.GetLength(1));
                entities.Board[entities.Board.GetLength(0)-1, pos] = Rutor.Door;
            }
            else
            {
                pos = RandomNumb(entities.Board.GetLength(0));
                entities.Board[pos, 0] = Rutor.Door;
            }
        }
    }
}

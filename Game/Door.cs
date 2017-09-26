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
                pos = 1 + RandomNumb(entities.Board.GetLength(1) - 2);
                entities.Board[0, pos] = new Door();
            }
            else if(wall == 1)
            {
                pos = 1 + RandomNumb(entities.Board.GetLength(0) - 2);
                entities.Board[pos, entities.Board.GetLength(1)-1] = new Door();
            }
            else if (wall == 2)
            {
                pos = 1 + RandomNumb(entities.Board.GetLength(1) - 2);
                entities.Board[entities.Board.GetLength(0)-1, pos] = new Door();
            }
            else
            {
                pos = 1 + RandomNumb(entities.Board.GetLength(0) - 2);
                entities.Board[pos, 0] = new Door();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Door:Entities
    {
        public Door()
        {
            Letter = 'D';
        }
        
        public void CreateExit()
        {
            int wall = RandomNumb(4);
            int pos;
            if(wall == 0)
            {
                pos = 1 + RandomNumb(Board.GetLength(1) - 2);
                Board[0, pos] = new Door();
            }
            else if(wall == 1)
            {
                pos = 1 + RandomNumb(Board.GetLength(0) - 2);
                Board[pos, Board.GetLength(1)-1] = new Door();
            }
            else if (wall == 2)
            {
                pos = 1 + RandomNumb(Board.GetLength(1) - 2);
                Board[Board.GetLength(0)-1, pos] = new Door();
            }
            else
            {
                pos = 1 + RandomNumb(Board.GetLength(0) - 2);
                Board[pos, 0] = new Door();
            }
        }
    }
}

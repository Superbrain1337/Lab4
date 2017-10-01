using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Door:Entities
    {
        public int Wall { get; set; }
        public int Pos { get; set; }
        public override int X { get; set; }
        public override int Y { get; set; }
        public override char Letter { get; set; }

        public Door()
        {
            Letter = 'D';
        }
        
        public void CreateExit()
        {
            Wall = Rnd.Next(4);
            
            if(Wall == 0)
            {
                Pos = 1 + Rnd.Next(Board.GetLength(1) - 2);
                Board[0, Pos] = Ruta.Door;
            }
            else if(Wall == 1)
            {
                Pos = 1 + Rnd.Next(Board.GetLength(0) - 2);
                Board[Pos, Board.GetLength(1)-1] = Ruta.Door;
            }
            else if (Wall == 2)
            {
                Pos = 1 + Rnd.Next(Board.GetLength(1) - 2);
                Board[Board.GetLength(0)-1, Pos] = Ruta.Door;
            }
            else
            {
                Pos = 1 + Rnd.Next(Board.GetLength(0) - 2);
                Board[Pos, 0] = Ruta.Door;
            }
        }
    }
}

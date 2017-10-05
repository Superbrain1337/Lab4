using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Door:Entities
    {
        public int Wall { get; set; }
        public int Pos { get; set; }

        //variables from Entities
        public override int X { get; set; }
        public override int Y { get; set; }
        
        
        //Creates a Door to leave the room
        public void CreateExit()
        {
            //Randomly decides wich wall to place the exit on
            Wall = Rnd.Next(4);
            
            if(Wall == 0)
            {
                Pos = 1 + Rnd.Next(Board.GetLength(1) - 2);
                Board[0, Pos] = Ruta.Door;
                X = Pos;
                Y = 0;
            }
            else if(Wall == 1)
            {
                Pos = 1 + Rnd.Next(Board.GetLength(0) - 2);
                Board[Pos, Board.GetLength(1)-1] = Ruta.Door;
                X = Board.GetLength(1)-1;
                Y = Pos;
            }
            else if (Wall == 2)
            {
                Pos = 1 + Rnd.Next(Board.GetLength(1) - 2);
                Board[Board.GetLength(0)-1, Pos] = Ruta.Door;
                X = Pos;
                Y = Board.GetLength(0)-1;
            }
            else
            {
                Pos = 1 + Rnd.Next(Board.GetLength(0) - 2);
                Board[Pos, 0] = Ruta.Door;
                X = 0;
                Y = Pos;
            }
        }
    }
}

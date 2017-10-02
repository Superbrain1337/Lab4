using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Wall:Entities, ILetter
    {
        public override int X { get; set; }
        public override int Y { get; set; }

        public char Letter { get; set; }

        public int Pos { get; set; }
        public int End { get; set; }
        public int Start { get; set; }
        public int Lenght { get; set; }
        public int Direction { get; set; }
        public int R { get; set; }
        

        public Wall()
        {
            Letter = '#';
        }

        public void DrawWalls()
        {
            
            R = Rnd.Next(40);
            for (int i = 0; i < R; i++)
            {
                Console.ForegroundColor = (ConsoleColor)(Rnd.Next(15)+1);
                Direction = Rnd.Next(100) % 2;
                Lenght = Board.GetLength(Direction);
                Start = 2 + Rnd.Next(Lenght - 2);
                End = Start + Rnd.Next(Lenght - Start);
                Pos = Rnd.Next(Board.GetLength((Direction+1)%2));
                if (Direction == 1)
                {
                    Y = Pos;
                    for (int j = Start; j < End; j++)
                    {
                        Board[Y, j] = Ruta.Wall;
                        //if (Y + 1 <= lenght && entities.Board[j, Y + 1] != Rutor.Wall ) entities.Board[j, Y + 1] = Rutor.Room;
                        //if (Y - 1 >= 0 && entities.Board[j, Y - 1] != Rutor.Wall ) entities.Board[j, Y - 1] = Rutor.Room;
                        //if (j == end - 1) entities.Board[j + 1, Y] = Rutor.Room;
                    }
                }
                else
                {
                    X = Pos;
                    for (int j = Start; j < End; j++)
                    {
                        Board[j, X] = Ruta.Wall;
                        //if ( X + 1 <= lenght && entities.Board[X + 1, j] != Rutor.Wall) entities.Board[j, X + 1] = Rutor.Room;
                        //if (X - 1 >= 0 && entities.Board[X - 1, j] != Rutor.Wall ) entities.Board[j, X - 1] = Rutor.Room;
                        //if (j == end - 1) entities.Board[X, j + 1] = Rutor.Room;
                    }
                }
            }
        }

        public void CreateRoom()
        {
            //Console.ForegroundColor = (ConsoleColor)(1+Rnd.Next(15));
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (i == Board.GetLowerBound(0) || j == Board.GetLowerBound(1) || i == Board.GetUpperBound(0) || j == Board.GetUpperBound(1))
                    {
                        Board[i, j] = Ruta.Wall;
                    }

                }
            }
            
        }
        
    }
}

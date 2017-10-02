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
                Console.ForegroundColor = ConsoleColor.White;
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
                    }
                }
                else
                {
                    X = Pos;
                    for (int j = Start; j < End; j++)
                    {
                        Board[j, X] = Ruta.Wall;
                    }
                }
            }
        }

        public void CreateRoom()
        {
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

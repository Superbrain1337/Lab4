using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Room:Entities
    {
        private int direction;
        private int lenght;
        private int start;
        private int end;
        private int pos;
        

        public void DrawWalls()
        {
            
            int r = RandomNumb(40);
            for (int i = 0; i < r; i++)
            {
                Console.ForegroundColor = (ConsoleColor)(RandomNumb(15)+1);
                direction = RandomNumb(100) % 2;
                lenght = Board.GetLength(direction);
                start = 2 + RandomNumb(lenght - 2);
                end = start + RandomNumb(lenght - start);
                pos = RandomNumb(Board.GetLength((direction+1)%2));
                if (direction == 1)
                {
                    Y = pos;
                    for (int j = start; j < end; j++)
                    {
                        Board[Y, j] = new Room();
                        //if (Y + 1 <= lenght && entities.Board[j, Y + 1] != Rutor.Wall ) entities.Board[j, Y + 1] = Rutor.Room;
                        //if (Y - 1 >= 0 && entities.Board[j, Y - 1] != Rutor.Wall ) entities.Board[j, Y - 1] = Rutor.Room;
                        //if (j == end - 1) entities.Board[j + 1, Y] = Rutor.Room;
                    }
                }
                else
                {
                    X = pos;
                    for (int j = start; j < end; j++)
                    {
                        Board[j, X] = new Room();
                        //if ( X + 1 <= lenght && entities.Board[X + 1, j] != Rutor.Wall) entities.Board[j, X + 1] = Rutor.Room;
                        //if (X - 1 >= 0 && entities.Board[X - 1, j] != Rutor.Wall ) entities.Board[j, X - 1] = Rutor.Room;
                        //if (j == end - 1) entities.Board[X, j + 1] = Rutor.Room;
                    }
                }
            }
        }

        public void CreateRoom()
        {
            Console.ForegroundColor = (ConsoleColor)RandomNumb(16);
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (i == Board.GetLowerBound(0) || j == Board.GetLowerBound(1) || i == Board.GetUpperBound(0) || j == Board.GetUpperBound(1))
                    {
                        Board[i, j] = new Room();
                    }

                }
            }
            
        }
        
    }
}

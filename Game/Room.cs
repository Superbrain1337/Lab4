using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Room:Entities
    {
        private static Entities entities = new Entities();
        private int direction;
        private int lenght;
        private int start;
        private int end;
        private int pos;

        public int Start { get => start; set => start = value; }
        public int End { get => end; set => end = value; }
        

        public void DrawWalls(Entities entities)
        {
            
            int r = RandomNumb(40);
            for (int i = 0; i < r; i++)
            {
                Console.ForegroundColor = (ConsoleColor)(RandomNumb(15)+1);
                direction = entities.RandomNumb(100) % 2;
                lenght = entities.Board.GetLength(direction);
                start = 2 + RandomNumb(lenght - 2);
                end = start + RandomNumb(lenght - start);
                pos = RandomNumb(entities.Board.GetLength((direction+1)%2));
                if (direction == 1)
                {
                    Y = pos;
                    for (int j = start; j < end; j++)
                    {
                        entities.Board[Y, j] = Rutor.Wall;
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
                        entities.Board[j, X] = Rutor.Wall;
                        //if ( X + 1 <= lenght && entities.Board[X + 1, j] != Rutor.Wall) entities.Board[j, X + 1] = Rutor.Room;
                        //if (X - 1 >= 0 && entities.Board[X - 1, j] != Rutor.Wall ) entities.Board[j, X - 1] = Rutor.Room;
                        //if (j == end - 1) entities.Board[X, j + 1] = Rutor.Room;
                    }
                }
            }
        }

        public void CreateRoom(Entities entities)
        {
            Console.ForegroundColor = (ConsoleColor)RandomNumb(16);
            for (int i = 0; i < entities.Board.GetLength(0); i++)
            {
                for (int j = 0; j < entities.Board.GetLength(1); j++)
                {
                    if (i == entities.Board.GetLowerBound(0) || j == entities.Board.GetLowerBound(1) || i == entities.Board.GetUpperBound(0) || j == entities.Board.GetUpperBound(1))
                    {
                        entities.Board[i, j] = Rutor.Wall;
                    }
                    else
                    {
                        entities.Board[i, j] = Rutor.Room;
                    }

                }
            }
            
        }
        
    }
}

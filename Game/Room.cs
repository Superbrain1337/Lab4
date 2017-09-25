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
            lenght = entities.Board.GetLength(direction);
            int r = RandomNumb(20);
            for (int i = 0; i < r; i++)
            {
                direction = entities.RandomNumb(100) % 2;
                start = RandomNumb(lenght);
                end = start + RandomNumb(lenght - start);
                pos = RandomNumb(entities.Board.GetLength(direction));
                if (direction == 0)
                {
                    Y = pos;
                    for (int j = start; j < end; j++)
                    {
                        entities.Board[Y, j] = Rutor.Wall; ;
                    }
                }
                else
                {
                    X = pos;
                    for (int j = start; j < end; j++)
                    {
                        entities.Board[j, X] = Rutor.Wall;
                    }
                }
            }
        }

        public void CreateRoom(Entities entities)
        {
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

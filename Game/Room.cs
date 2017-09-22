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
        private static int direction = entities.RandomNumb(100) % 2;
        private static int lenght = entities.Board.GetLength(direction);
        private int start;
        private int end;
        private int pos;

        public int Start { get => start; set => start = value; }
        public int End { get => end; set => end = value; }

        public static int GetDirection()
        {
            return direction;
        }

        public void DrawWalls(int start, int end)
        {
            start = RandomNumb(lenght);
            end = start + RandomNumb(lenght - start);
            for (int i = 0; i < RandomNumb(10); i++)
            {
                pos = RandomNumb(entities.Board.GetLength(GetDirection()));
                if (GetDirection() == 0)
                {
                    Y = pos;
                    for (int j = start; j < end; j++)
                    {
                        entities.Board[Y, i] = '#';
                    }
                }
                else
                {
                    X = pos;
                    for (int j = start; j < end; j++)
                    {
                        entities.Board[i, X] = '#';
                    }
                }
            }
            
        }

        public Room()
        {
            for (int i = 0; i < entities.Board.GetLength(0); i++)
            {
                for (int j = 0; j < entities.Board.GetLength(1); j++)
                {
                    if (i == entities.Board.GetLowerBound(0) || j == entities.Board.GetLowerBound(1) || i == entities.Board.GetUpperBound(0) || j == entities.Board.GetUpperBound(1))
                    {
                        entities.Board[i, j] = '#';
                    }
                    else
                    {
                        entities.Board[i, j] = ' ';
                    }

                }
            }
            /*for(int i = 0; i < RandomNumb(10); i++)
            {
                start = RandomNumb(lenght);
                end = start + RandomNumb(lenght - start);
                wall.DrawWall(start, end);
            }
            */
        }
        
    }
}

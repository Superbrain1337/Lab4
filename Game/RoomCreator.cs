using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class RoomCreator
    {
        public static WallClass wall = new WallClass();
        public static Random rnd = new Random();
        public static char[,] CreateOuterWalls(char[,] boardGridOuterWall)
        {
            for (int i = 0; i < boardGridOuterWall.GetLength(0); i++)
            {
                for (int j = 0; j < boardGridOuterWall.GetLength(1); j++)
                {
                    if (i == boardGridOuterWall.GetLowerBound(0) || 
                        j == boardGridOuterWall.GetLowerBound(1) || 
                        i == boardGridOuterWall.GetUpperBound(0) || 
                        j == boardGridOuterWall.GetUpperBound(1))
                    {
                        boardGridOuterWall[i, j] = wall.Letter;
                    }
                }
            }
            CreateInnerWalls(boardGridOuterWall);
            return (boardGridOuterWall);
        }

        public static char[,] CreateInnerWalls(char[,] boardGridInnerWall) 
        {
            int r = rnd.Next(40);
            for (int i = 0; i < r; i++)
            {
                Console.ForegroundColor = (ConsoleColor)(rnd.Next(15) + 1);
                int direction = rnd.Next(100) % 2;
                int lenght = boardGridInnerWall.GetLength(direction);
                int start = 2 + rnd.Next(lenght - 2);
                int end = start + rnd.Next(lenght - start);
                int pos = rnd.Next(boardGridInnerWall.GetLength((direction + 1) % 2));
                if (direction == 1)
                {
                    
                    for (int j = start; j < end; j++)
                    {
                        boardGridInnerWall[pos, j] = wall.Letter;
                        //if (Y + 1 <= lenght && entities.Board[j, Y + 1] != Rutor.Wall ) entities.Board[j, Y + 1] = Rutor.Room;
                        //if (Y - 1 >= 0 && entities.Board[j, Y - 1] != Rutor.Wall ) entities.Board[j, Y - 1] = Rutor.Room;
                        //if (j == end - 1) entities.Board[j + 1, Y] = Rutor.Room;
                    }
                }
                else
                {
                    
                    for (int j = start; j < end; j++)
                    {
                        boardGridInnerWall[j, pos] = wall.Letter;
                        //if ( X + 1 <= lenght && entities.Board[X + 1, j] != Rutor.Wall) entities.Board[j, X + 1] = Rutor.Room;
                        //if (X - 1 >= 0 && entities.Board[X - 1, j] != Rutor.Wall ) entities.Board[j, X - 1] = Rutor.Room;
                        //if (j == end - 1) entities.Board[X, j + 1] = Rutor.Room;
                    }
                }
            }
            return (boardGridInnerWall);
        }
        public void PlaceEnemy()
        {

        }
        public void PlacePlayer()
        {

        }
        public void PlaceDoor()
        {

        }
        public void PlaceKey()
        {

        }
    }
}

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
        public int Lenght { get; set; }
        public int Direction { get; set; }
        public int WallCount { get; set; }
        private int currentWallCount;
        private int drawnWalls;
        

        public Wall()
        {
            Letter = '#';
        }
        
        //Creates a new empty room
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

        public void CreateMaze()
        {
            //Y = 6 + Rnd.Next(Board.GetLength(0)-12);
            //X = 0;
            Board[2, 2] = Ruta.Wall;
            Board[Board.GetLength(0) - 3, 2] = Ruta.Wall;
            Board[2, Board.GetLength(1) - 3] = Ruta.Wall;
            Board[Board.GetLength(0) - 3, Board.GetLength(1) - 3] = Ruta.Wall;
            Direction = 0;
            WallCount = 3;
            drawnWalls = 0;
            
            while(drawnWalls < 100)
            {
                Pos = Rnd.Next(WallCount);
                for (int j = 1; j < Board.GetLength(0) - 1; j++)
                {
                    for (int k = 1; k < Board.GetLength(1) - 1; k++)
                    {
                        if (Board[j, k] == Ruta.Wall)
                        {
                            if (currentWallCount == Pos)
                            {
                                Y = j;
                                X = k;
                            }
                            currentWallCount++;
                        }
                    }
                }

                switch (Direction)
                {
                    case 0:
                        //Lenght = 5 + Rnd.Next(Board.GetLength(1) / 2);
                        if (X < Board.GetLength(1)-2 && X > 1)
                        {
                            while (Board[Y, X + 1] != Ruta.Wall && Board[Y - 1, X + 1] != Ruta.Wall && Board[Y + 1, X + 1] != Ruta.Wall)
                            {
                                Board[Y, X] = Ruta.Wall;
                                X++;
                                WallCount++;
                            }
                            drawnWalls++;
                        }
                        break;
                    case 1:
                        //Lenght = 2 + Rnd.Next(Board.GetLength(0) / 2);
                        if (Y < Board.GetLength(0) - 2 && Y > 1)
                        {
                            while (Board[Y + 1, X] != Ruta.Wall && Board[Y + 1, X + 1] != Ruta.Wall && Board[Y + 1, X - 1] != Ruta.Wall)
                            {
                                Board[Y, X] = Ruta.Wall;
                                Y++;
                                WallCount++;
                            }
                            drawnWalls++;
                        }
                        break;
                    case 2:
                        //Lenght = 5 + Rnd.Next(Board.GetLength(1) / 2);
                        if (X < Board.GetLength(1) - 2 && X > 1)
                        {
                            while (Board[Y, X - 1] != Ruta.Wall && Board[Y - 1, X - 1] != Ruta.Wall && Board[Y + 1, X - 1] != Ruta.Wall)
                            {
                                Board[Y, X] = Ruta.Wall;
                                X--;
                                WallCount++;
                            }
                            drawnWalls++;
                        }
                        break;
                    case 3:
                        //Lenght = 2 + Rnd.Next(Board.GetLength(0) / 2);
                        if (Y < Board.GetLength(0) - 2 && Y > 1)
                        {
                            while (Board[Y - 1, X] != Ruta.Wall && Board[Y - 1, X + 1] != Ruta.Wall && Board[Y + 1, X - 1] != Ruta.Wall)
                            {
                                Board[Y, X] = Ruta.Wall;
                                Y--;
                                WallCount++;
                            }
                            drawnWalls++;
                        }
                        break;
                }
                Direction = Rnd.Next(4);
                currentWallCount = 0;
            }
        }



        /*
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
        */
    }
}

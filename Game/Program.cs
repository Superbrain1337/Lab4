using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace Game
{
    
    public class Program
    {
        public static PlayerClass Player = new PlayerClass();
        public static void Main(string[] args)
        {
            PlayerClass Player = new PlayerClass();
            BoardClass Board = new BoardClass();
            EnemyClass Enemy = new EnemyClass();
            CreateLvl();
            Console.Read();
        }

        public static char[,] CreateLvl()
        {
            BoardClass Board = new BoardClass();
            char[,] boardGrid = new char[Board.X, Board.Y];
            Console.WriteLine(boardGrid[0,0]);
            return (boardGrid);
        }


        public static void Game()
        {
            //Console.WriteLine(Main.Board.X + " " + Board.Y);
            //Door D = new Door();
            //Room.CreateRoom(Board);
            //Room.DrawWalls(Board);
            //D.CreateExit(Board);
            Random rnd = new Random();
            //boardGrid = CreateLvl();
            bool loseGame = false;
            int highscore = 0, playerUsedActions = 0;
            
            Console.CursorVisible = false;

            //Draw.DrawScreen(boardGrid);
            while (!loseGame)
            {
                Player.PlayerMovement();
                playerUsedActions++;

            }
            Draw.DrawGameOver(highscore);
            Console.ReadLine();
        }
        /*public static Entities[,] CreateLvl()
        {
            //creates a grid of empty places
            


            //Setts all Outer walls
            for (int i = 0; i < boardGrid.GetLength(0); i++)
            {
                for (int j = 0; j < boardGrid.GetLength(1); j++)
                {
                    if (i == boardGrid.GetLowerBound(0) || j == boardGrid.GetLowerBound(1) || i == boardGrid.GetUpperBound(0) || j == boardGrid.GetUpperBound(1))
                    {
                        WallClass wall = new WallClass();
                        wall.X = i;
                        wall.Y = j;
                    }


                }
            }
            //Sets
            return (boardGrid);
        }
        */
        
    }
}

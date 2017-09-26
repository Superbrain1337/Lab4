using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace Game
{
    class Program
    {

        public static PlayerClass Player = new PlayerClass();
        //public static Room Room = new Room();
        public static BoardClass Board = new BoardClass();
        public static Entities[,] boardGrid = new EmptyClass[Board.X, Board.Y];

        static void Main(string[] args)
        {
            
            //Door D = new Door();
            //Room.CreateRoom(Board);
            //Room.DrawWalls(Board);
            //D.CreateExit(Board);
            Random rnd = new Random();
            Entities [,] boardGrid = CreateLvl();
            bool loseGame = false;
            
            Player.X = 25;
            Player.Y = 18;

            int highscore = 0, playerUsedActions = 0;
            ConsoleKeyInfo userMovementInput = new ConsoleKeyInfo();
            Console.CursorVisible = false;
            
            Draw.DrawScreen(boardGrid);
            while (!loseGame)
            {
                userMovementInput = Console.ReadKey(true);
                Player.PrevX = Player.X;
                Player.PrevY = Player.Y;
                playerUsedActions++;
                /*
                switch (userMovementInput.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:

                        if (boarGrid[Player.Y - 1, Player.X] != )
                            Player.Y--;
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (boarGrid[Player.Y + 1, Player.X] != Rutor.Wall)
                            Player.Y++;
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (boarGrid[Player.Y, Player.X - 1] != Rutor.Wall)
                            Player.X--;
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (boarGrid[Player.Y, Player.X + 1] != Rutor.Wall)
                            Player.X++;
                        break;
                    default:
                        break;
                }
                if (Player.PrevX != Player.X || Player.PrevY != Player.Y)
                {
                    Draw.Plot(Player.PrevX, Player.PrevY, Rutor.Room);
                    Draw.Plot(Player.X, Player.Y, Rutor.Player);
                }
                */
                if (Player.X == 2 && Player.Y == 2)
                {
                    highscore = 100 - playerUsedActions;
                    loseGame = true;
                }
            }
            Draw.DrawGameOver(highscore);
            Console.ReadLine();
        }
        public static Entities[,] CreateLvl()
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
        
        
    }
}

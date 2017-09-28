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

        public static Player Player = new Player();
        public static Wall Wall = new Wall();
        public static Door Door = new Door();
        public static Entities Board = new Entities();

        static void Main(string[] args)
        {
            Entities B = new Entities();
            Wall.CreateRoom();
            Wall.DrawWalls();
            Door.CreateExit();
            Random rnd = new Random();
            Entities[,] boardGrid = new Entities[20, 50];
            boardGrid = Board.Board;
            bool loseGame = false;
            
            Player.X = 25;
            Player.Y = 18;
            int highscore = 0, playerUsedActions = 0;
            ConsoleKeyInfo userMovementInput = new ConsoleKeyInfo();
            Console.CursorVisible = false;
            boardGrid[Player.Y, Player.X] = new Player();
            Draw.DrawScreen(boardGrid);
            while (!loseGame)
            {
                userMovementInput = Console.ReadKey(true);
                Player.PrevX = Player.X;
                Player.PrevY = Player.Y;
                playerUsedActions++;
                switch (userMovementInput.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:

                        if (boardGrid[Player.Y - 1, Player.X] != new Wall())
                            Player.Y--;
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (boardGrid[Player.Y + 1, Player.X] != new Wall())
                            Player.Y++;
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (boardGrid[Player.Y, Player.X - 1] != new Wall())
                            Player.X--;
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (boardGrid[Player.Y, Player.X + 1] != new Wall())
                            Player.X++;
                        break;
                    default:
                        break;
                }
                if (Player.PrevX != Player.X || Player.PrevY != Player.Y)
                {
                    Draw.Plot(Player.PrevX, Player.PrevY, ' ');
                    Draw.Plot(Player.X, Player.Y, Player.Letter);
                }
                if (Player.X == 2 && Player.Y == 2)
                {
                    highscore = 100 - playerUsedActions;
                    loseGame = true;
                }
            }
            Draw.DrawGameOver(highscore);
            Console.ReadLine();
        }

        
        
    }
}

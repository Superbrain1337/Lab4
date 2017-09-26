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
        
        static void Main(string[] args)
        {
            Room R = new Room();
            Entities B = new Entities();
            Door D = new Door();
            R.CreateRoom(B);
            R.DrawWalls(B);
            D.CreateExit(B);
            Random rnd = new Random();
            Rutor[,] board = new Rutor[20, 50];
            board = B.Board;
            bool loseGame = false;
            int px = 25, py = 18;
            int highscore = 0, playerUsedActions = 0;
            ConsoleKeyInfo userMovementInput = new ConsoleKeyInfo();
            
            const string controls = "P = player, W = Walker, R = Runner, F = Fatty, A = Abommenation";
            
            board[py, px] = Rutor.Player;
            while (!loseGame)
            {
                Draw.DrawScreen(board,controls);
                userMovementInput = Console.ReadKey(false);
                board[py, px] = Rutor.Room;
                playerUsedActions++;
                switch (userMovementInput.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if(board[py - 1,px] != Rutor.Wall)
                            py--;
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (board[py + 1, px] != Rutor.Wall)
                            py++;
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (board[py, px - 1] != Rutor.Wall)
                            px--;
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (board[py, px + 1] != Rutor.Wall)
                            px++;
                        break;
                    default:
                        break;
                }
                board[py, px] = Rutor.Player;
                if(px == 2 && py == 2)
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

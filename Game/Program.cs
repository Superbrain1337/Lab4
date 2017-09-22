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
            Random rnd = new Random();
            bool loseGame = false;
            char[,] board = new char[20, 50];
            int px = 25, py = 18;
            int highscore = 0, playerUsedActions = 0;
            ConsoleKeyInfo userMovementInput = new ConsoleKeyInfo();
            
            const string controls = "P = player, W = Walker, R = Runner, F = Fatty, A = Abommenation";
            for(int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if(i == board.GetLowerBound(0) || j == board.GetLowerBound(1) || i == board.GetUpperBound(0) || j == board.GetUpperBound(1))
                    {
                        board[i, j] = '#';
                    }
                    else
                    {
                        board[i, j] = ' ';
                    }
                    
                }
            }
            board[py, px] = 'P';
            while (!loseGame)
            {
                Draw.DrawScreen(board,controls);
                userMovementInput = Console.ReadKey(false);
                board[py, px] = ' ';
                playerUsedActions++;
                switch (userMovementInput.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if(board[py - 1,px] != '#')
                            py--;
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (board[py + 1, px] != '#')
                            py++;
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (board[py, px - 1] != '#')
                            px--;
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (board[py, px + 1] != '#')
                            px++;
                        break;
                    default:
                        break;
                }
                board[py, px] = 'P';
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

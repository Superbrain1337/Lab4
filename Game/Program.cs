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

        public static void DrawBoard(char[,] array)
        {
            Console.Clear();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i,j]);
                }
                Console.WriteLine("");
            }
        }

        static void Main(string[] args)
        {
            Room R = new Room();
            Entities B = new Entities();
            Random rnd = new Random();
            char[,] board = new char[20, 50];
            board = B.Board;
            bool loseGame = false;
            int px = 25, py = 18;
            
            int highscore = 0, count = 0;
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            
            const string controls = "P = player, W = Walker, R = Runner, F = Fatty, A = Abommenation";
            
            board[py, px] = 'P';
            while (!loseGame)
            {
                DrawBoard(board);
                Console.WriteLine(controls);
                key = Console.ReadKey(false);
                board[py, px] = ' ';
                count++;
                switch (key.Key)
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
                    highscore = 100 - count;
                    loseGame = true;
                }
            }
            Console.WriteLine($"GAME OVER    Highscore: {highscore}p");
            Console.ReadLine();
        }
    }
}

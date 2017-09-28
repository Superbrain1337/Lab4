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
        public static bool loseGame = false;
        public static Random r = new Random();

        public static void Main(string[] args)
        {
            Console.Read();
            Game();
        }

        public char[,] CreateLvl()
        {
            BoardClass Board = new BoardClass();
            char[,] boardGrid = new char[Board.X, Board.Y];
            return (boardGrid);
        }


        public static void Game()
        {
            Random rnd = new Random();

            int highscore = 0, playerUsedActions = 0;
            Console.CursorVisible = false;

            PlayerClass Player = new PlayerClass();
            BoardClass Board = new BoardClass();
            EnemyClass Enemy = new EnemyClass();
            Program program = new Program();
            char[,] boardGrid = program.CreateLvl();

            while (!Program.loseGame)
            {
                Player.PlayerMovement(boardGrid, Board);
                playerUsedActions++;
                Draw.DrawScreen(boardGrid);
            }
            Draw.DrawGameOver(highscore);
            Console.ReadLine();
        }
    }
}

        /*public void DrawInnerWalls(WallClass wall) 
        {

            int r = Program.r(40);
            for (int i = 0; i < r; i++)
            {
                //Console.ForegroundColor = (ConsoleColor)(RandomNumb(15) + 1);
                //direction = entities.RandomNumb(100) % 2;
                //lenght = entities.Board.GetLength(direction);
                int start = 2 + RandomNumb(lenght - 2);
                int end = start + RandomNumb(lenght - start);
                int pos = RandomNumb(entities.Board.GetLength((direction + 1) % 2));
                if (direction == 1)
                {
                    Y = pos;
                    for (int j = start; j < end; j++)
                    {
                        entities.Board[Y, j] = Rutor.Wall;
                        //if (Y + 1 <= lenght && entities.Board[j, Y + 1] != Rutor.Wall ) entities.Board[j, Y + 1] = Rutor.Room;
                        //if (Y - 1 >= 0 && entities.Board[j, Y - 1] != Rutor.Wall ) entities.Board[j, Y - 1] = Rutor.Room;
                        //if (j == end - 1) entities.Board[j + 1, Y] = Rutor.Room;
                    }
                }
                else
                {
                    X = pos;
                    for (int j = start; j < end; j++)
                    {
                        entities.Board[j, X] = Rutor.Wall;
                        //if ( X + 1 <= lenght && entities.Board[X + 1, j] != Rutor.Wall) entities.Board[j, X + 1] = Rutor.Room;
                        //if (X - 1 >= 0 && entities.Board[X - 1, j] != Rutor.Wall ) entities.Board[j, X - 1] = Rutor.Room;
                        //if (j == end - 1) entities.Board[X, j + 1] = Rutor.Room;
                    }
                }
            }
        }*/
    

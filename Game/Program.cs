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
            RoomCreator.CreateOuterWalls(boardGrid);
            Draw.DrawScreen(boardGrid,Player);

            while (!Program.loseGame)
            {

                Player.PlayerMovement(boardGrid);
                playerUsedActions++;
                Draw.DrawScreen(boardGrid,Player);
            }
            Draw.DrawGameOver(highscore);
            Console.ReadLine();
        }
    }
}

        
    

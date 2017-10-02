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
        public static Key Key = new Key();
        public static Empty Empty = new Empty();

        static void Main(string[] args)
        {
            //The first room in created 
            Empty.NewBoard();
            Wall.CreateRoom();
            Wall.DrawWalls();
            Door.CreateExit();
            Key.SpawnKey();
            
            //The local variables is created
            Entities.Ruta[,] boardGrid = Entities.Board;
            bool loseGame = false, roomComplete = false;
            Draw.DrawScreen(boardGrid);
            Draw.Plot(Player.X, Player.Y, Entities.Ruta.Player);

            int highscore = 0, playerUsedActions = 0, roomCount = 0;
            
            while (!loseGame && roomCount < 10)
            {
                if (roomComplete)
                {
                    Player.X = 50;
                    Player.Y = 20;
                    Key.KeyCount = 0;
                    Empty.NewBoard();
                    Wall.CreateRoom();
                    Wall.DrawWalls();
                    Door.CreateExit();
                    Key.SpawnKey();
                    Draw.DrawScreen(boardGrid);
                    Draw.Plot(Player.X, Player.Y, Entities.Ruta.Player);
                    roomComplete = false;
                }
                
                Player.MovePlayer();
                playerUsedActions++;
                roomComplete = Player.UpdatePlayerPosititon();
                
                if (Player.PrevX != Player.X || Player.PrevY != Player.Y)
                {
                    Draw.Plot(Player.PrevX, Player.PrevY, Entities.Ruta.Empty);
                    Draw.Plot(Player.X, Player.Y, Entities.Ruta.Player);
                }
                if (Player.Health <=0)
                {
                    highscore = 1000 - playerUsedActions;
                    loseGame = true;
                }
            }
            Draw.DrawGameOver(highscore);
            Console.ReadLine();
        }

        
        
    }
}

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
        public enum Ruta { Player = 'P', Door = 'D', Key = 'K', Wall = '#', Enemie = 'E', Empty = ' ' }
        public static Player Player = new Player();
        public static Wall Wall = new Wall();
        public static Door Door = new Door();
        public static Key Key = new Key();
        public static Empty Empty = new Empty();

        static void Main(string[] args)
        {
            Empty.NewBoard();
            Wall.CreateRoom();
            Wall.DrawWalls();
            Door.CreateExit();
            Key.SpawnKey();
            
            Entities.Ruta[,] boardGrid = Entities.Board;
            bool loseGame = false;
            Draw.DrawScreen(boardGrid);
            Draw.Plot(Player.X, Player.Y, Entities.Ruta.Player);

            int highscore = 0, playerUsedActions = 0;
            
            while (!loseGame)
            {
                
                Player.MovePlayer();
                playerUsedActions++;
                Door.TryToUnlock(Player.X, Player.Y);
                Player.UpdatePlayerPosititon();
                
                if (Player.PrevX != Player.X || Player.PrevY != Player.Y)
                {
                    Draw.Plot(Player.PrevX, Player.PrevY, Entities.Ruta.Empty);
                    Draw.Plot(Player.X, Player.Y, Entities.Ruta.Player);
                }
                if (Player.X == 2 && Player.Y == 2 || Player.Health <=0)
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

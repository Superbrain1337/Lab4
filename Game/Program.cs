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
        public static Enemy Enemy = new Enemy();
        public static Treasure Treasure = new Treasure();

        static void Main(string[] args)
        {
            //Local variables is created
            bool loseGame = false, roomComplete = false;
            int highscore = 0, playerUsedActions = 0, roomCount = 1;
            Random rnd = new Random();

            //The first room in created 
            Empty.NewBoard();
            Wall.CreateRoom();
            Wall.CreateMaze();
            Door.CreateExit();
            Key.SpawnKey();
            Treasure.GenerateTreasures();
            Enemy.CreateEnemies(roomCount);
            

            
            //Board is created
            Entities.Ruta[,] boardGrid = Entities.Board;
            
            //Board is drawn on the Console
            Draw.DrawScreen(boardGrid);
            Draw.DrawControls(boardGrid, highscore);
            for (int i = 0; i < Treasure.TreasureList.GetLength(1); i++)
            {
                Draw.Plot(Treasure.TreasureList[0, i], Treasure.TreasureList[1, i], Entities.Ruta.Treasure, (ConsoleColor)Treasure.TreasureList[3, i]);
            }
            Draw.Plot(Player.X, Player.Y, Entities.Ruta.Player, ConsoleColor.Green);
            Draw.Plot(Enemy.X, Enemy.Y, Entities.Ruta.Enemie, ConsoleColor.Red);

            while (!loseGame && roomCount < 10)
            {
                if (roomComplete)
                {
                    highscore += (1000 - playerUsedActions) * roomCount;
                    playerUsedActions = 0;
                    roomCount++;
                    Wall.WallCount = 0;
                    Entities.NumbOfKeys = 0;
                    Enemy.NumberOfEnemies = 0;
                    Player.X = 1 + rnd.Next(boardGrid.GetLength(1)-2);
                    Player.Y = 1 + rnd.Next(boardGrid.GetLength(0)-2);
                    Key.KeyCount = 0;
                    Empty.NewBoard();
                    Wall.CreateRoom();
                    Wall.CreateMaze();
                    Door.CreateExit();
                    Key.SpawnKey();
                    Enemy.CreateEnemies(roomCount);
                    Draw.DrawScreen(boardGrid);
                    Draw.DrawControls(boardGrid, highscore);
                    for (int i = 0; i < Treasure.TreasureList.GetLength(1); i++)
                    {
                        Draw.Plot(Treasure.TreasureList[0, i], Treasure.TreasureList[1,i], Entities.Ruta.Treasure, (ConsoleColor) Treasure.TreasureList[3,i]);
                    }
                    Draw.Plot(Player.X, Player.Y, Entities.Ruta.Player, ConsoleColor.Green);
                    Draw.Plot(Enemy.X, Enemy.Y, Entities.Ruta.Enemie, ConsoleColor.Red);
                    roomComplete = false;
                }
                
                Player.MovePlayer();
                playerUsedActions++;
                roomComplete = Player.UpdatePlayerPosititon();
                highscore += Treasure.FoundTreasure(Player.X, Player.Y);
                
                if (Player.PrevX != Player.X || Player.PrevY != Player.Y)
                {
                    Draw.Plot(Player.PrevX, Player.PrevY, Entities.Board[Player.PrevY, Player.PrevX], ConsoleColor.Black);
                    Draw.Plot(Player.X, Player.Y, Entities.Ruta.Player, ConsoleColor.Green);
                }

                for (int i = 0; i < roomCount * 2; i++)
                {
                    Enemy.MoveEnemy(i);
                    Enemy.UpdateEnemyPosititon(i);
                    if (Enemy.PrevX != Enemy.X || Enemy.PrevY != Enemy.Y)
                    {
                        Draw.Plot(Enemy.PrevX, Enemy.PrevY, Entities.Ruta.Empty, ConsoleColor.Black);
                        if (Enemy.PrevX == Player.X && Enemy.PrevY == Player.Y)
                        {
                            Draw.Plot(Player.X, Player.Y, Entities.Ruta.Player, ConsoleColor.Green);
                        }
                        Draw.Plot(Enemy.X, Enemy.Y, Entities.Ruta.Enemie, ConsoleColor.Red);
                    }
                }
                Console.SetCursorPosition(0, boardGrid.GetLength(0) + 1);
                Console.WriteLine(playerUsedActions);

                if (Player.Health <=0)
                {
                    loseGame = true;
                }
            }
            Draw.DrawGameOver(highscore);
            Console.ReadLine();
        }

        
        
    }
}

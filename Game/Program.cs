using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace Game
{
    //Samuel 31466
    //Oscar 27548
    //Fredrik 30350
    class Program
    {
        public static Player Player = new Player();
        public static Wall Wall = new Wall();
        public static Door Door = new Door();
        public static Key Key = new Key();
        public static Empty Empty = new Empty();
        public static Enemy Enemy = new Enemy();
        public static Treasure Treasure = new Treasure();
        public static Bomb Bomb = new Bomb();

        static void Main(string[] args)
        {
            //Local variables is created
            bool loseGame = false, roomComplete = false, bombActivated = false, shotVisible = false;
            int highscore = 0, playerUsedActions = 0, roomCount = 1, movementEvent = 0, bombCount = 0;
            Random rnd = new Random();

            //The first room is created 
            Empty.NewBoard();
            Wall.CreateRoom();
            Wall.CreateMaze();
            Door.CreateExit();
            Key.SpawnKey();
            Treasure.GenerateTreasures();
            Treasure.SpawnAmmo();
            Bomb.CreateBombs();
            Enemy.CreateEnemies(roomCount);

            //The board is created gets its values
            Entities.Ruta[,] boardGrid = Entities.Board;
            Entities.UpdateVisibilityBoard();
            Player.PlayerUpdateVisibility();
            
            
            //Board is drawn on the Console
            Draw.DrawScreen(boardGrid, Entities.IsVisible);
            Draw.DrawControls(boardGrid, highscore, Player.Health, bombCount, Player.Ammo);
            /*for (int i = 0; i < Treasure.TreasureList.GetLength(1); i++)
            {
                Draw.Plot(Treasure.TreasureList[0, i], Treasure.TreasureList[1, i], Entities.Ruta.Treasure, (ConsoleColor)Treasure.TreasureList[3, i]);
            }*/
            Draw.Plot(Player.X, Player.Y, Entities.Ruta.Player, ConsoleColor.Green);
            Draw.Plot(Key.X, Key.Y, Entities.Ruta.Key, ConsoleColor.Cyan);
            //Draw.Plot(Enemy.X, Enemy.Y, Entities.Ruta.Enemie, ConsoleColor.Red);

            while (!loseGame && roomCount < 15)
            {
                Entities.BoardCopy = boardGrid;
                if (roomComplete)    //Resets some values and creates a new random room but with more enemies
                {
                    Entities.UpdateVisibilityBoard();
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
                    Treasure.GenerateTreasures();
                    Treasure.SpawnAmmo();
                    Bomb.CreateBombs();
                    Enemy.CreateEnemies(roomCount);
                    Draw.DrawScreen(boardGrid, Entities.IsVisible);
                    Draw.DrawControls(boardGrid, highscore, Player.Health, bombCount, Player.Ammo);
                    /*for (int i = 0; i < Treasure.TreasureList.GetLength(1); i++)
                    {
                        Draw.Plot(Treasure.TreasureList[0, i], Treasure.TreasureList[1,i], Entities.Ruta.Treasure, (ConsoleColor) Treasure.TreasureList[3,i]);
                    }*/
                    Draw.Plot(Player.X, Player.Y, Entities.Ruta.Player, ConsoleColor.Green);
                    //Draw.Plot(Enemy.X, Enemy.Y, Entities.Ruta.Enemie, ConsoleColor.Red);
                    roomComplete = false;
                }

                if (Player.MovePlayer())
                {
                    Bomb.BombSetOf(Player.Y, Player.X);
                }
                Player.PlayerUpdateVisibility();
                playerUsedActions++;
                movementEvent = Player.UpdatePlayerPosititon();
                if (movementEvent == 1)
                {
                    roomComplete = true;
                }
                else if (movementEvent == 2)
                {
                    Bomb.BombCount++;
                }

                highscore += Treasure.FoundTreasure(Player.X, Player.Y);

                for (int i = 0; i < roomCount * 10; i++)
                {
                    Enemy.MoveEnemy(i, Player.X, Player.Y);
                    Player.Health -= Enemy.UpdateEnemyPosititon(i);
                }

                for (int i = 0; i < boardGrid.GetLength(0); i++)
                {
                    for (int j = 0; j < boardGrid.GetLength(1); j++)
                    {
                        if (Entities.Board[i, j] == Entities.Ruta.Shot && shotVisible)
                        {
                            Entities.Board[i, j] = Entities.Ruta.Empty;
                            shotVisible = false;
                        }
                        if (Entities.Board[i, j] == Entities.Ruta.Shot)
                        {
                            shotVisible = true;
                        }
                        Player.PlayerUpdateVisibility();

                        if (Entities.Board[i, j] != Entities.BoardCopy[i, j] || Entities.IsVisible[i, j])
                        {
                            if (Entities.Board[i, j] == Entities.Ruta.Player)
                            {
                                Draw.Plot(j, i, Entities.Ruta.Player, ConsoleColor.Green);
                            }
                            else if (Entities.Board[i, j] == Entities.Ruta.Enemie)
                            {
                                Draw.Plot(j, i, Entities.Ruta.Enemie, ConsoleColor.Red);
                            }
                            else if (Entities.Board[i, j] == Entities.Ruta.Key)
                            {
                                Draw.Plot(j, i, Entities.Ruta.Key, ConsoleColor.Cyan);
                            }
                            else if (Entities.Board[i, j] == Entities.Ruta.Treasure)
                            {
                                Draw.Plot(j, i, Entities.Ruta.Treasure, ConsoleColor.Yellow);
                            }
                            else if (Entities.Board[i, j] == Entities.Ruta.Bomb)
                            {
                                Draw.Plot(j, i, Entities.Ruta.Bomb, ConsoleColor.Gray);
                            }
                            else
                            {
                                Draw.Plot(j, i, Entities.Board[i, j], ConsoleColor.White);
                            }
                        }
                    }
                }
                /*
                if (Player.PrevX != Player.X || Player.PrevY != Player.Y)
                {
                    Draw.Plot(Player.PrevX, Player.PrevY, Entities.Board[Player.PrevY, Player.PrevX], ConsoleColor.Black);
                    Draw.Plot(Player.X, Player.Y, Entities.Ruta.Player, ConsoleColor.Green);
                }*/

                /*
                for (int i = 0; i < roomCount * 2; i++)
                {
                    Enemy.MoveEnemy(i, Player.X, Player.Y);
                    Player.Health -= Enemy.UpdateEnemyPosititon(i);
                    if (Enemy.PrevX != Enemy.X || Enemy.PrevY != Enemy.Y)
                    {
                        Draw.Plot(Enemy.PrevX, Enemy.PrevY, Entities.Ruta.Empty, ConsoleColor.Black);
                        if (Enemy.PrevX == Player.X && Enemy.PrevY == Player.Y)
                        {
                            Draw.Plot(Player.X, Player.Y, Entities.Ruta.Player, ConsoleColor.Green);
                        }
                        else
                        {
                            Draw.Plot(Enemy.X, Enemy.Y, Entities.Ruta.Enemie, ConsoleColor.Red);
                        }
                    }
                }
                */
                bombCount = Bomb.BombCount;
                Draw.DrawControls(boardGrid, highscore, Player.Health, bombCount, Player.Ammo);
                Console.SetCursorPosition(0, boardGrid.GetLength(0) + 2);
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

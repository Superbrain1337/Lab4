﻿using System;
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

        static void Main(string[] args)
        {
            //Local variables is created
            bool loseGame = false, roomComplete = false;
            int highscore = 0, playerUsedActions = 0, roomCount = 1;

            //The first room in created 
            Empty.NewBoard();
            Wall.CreateRoom();
            Wall.DrawWalls();
            Door.CreateExit();
            Key.SpawnKey();
            Enemy.CreateEnemies(roomCount);
            
            //Board is created
            Entities.Ruta[,] boardGrid = Entities.Board;
            
            //Board is drawn on the Console
            Draw.DrawScreen(boardGrid);
            Draw.Plot(Player.X, Player.Y, Entities.Ruta.Player);
            
            while (!loseGame && roomCount < 10)
            {
                if (roomComplete)
                {
                    roomCount++;
                    Player.X = 50;
                    Player.Y = 20;
                    Key.KeyCount = 0;
                    Empty.NewBoard();
                    Wall.CreateRoom();
                    Wall.DrawWalls();
                    Door.CreateExit();
                    Key.SpawnKey();
                    Enemy.CreateEnemies(roomCount);
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

                for (int i = 0; i < roomCount * 2; i++)
                {
                    Enemy.MoveEnemy(i);
                    Enemy.UpdateEnemyPosititon(i);
                    if (Enemy.PrevX != Enemy.X || Enemy.PrevY != Enemy.Y)
                    {
                        Draw.Plot(Enemy.PrevX, Enemy.PrevY, Entities.Ruta.Empty);
                        Draw.Plot(Enemy.X, Enemy.Y, Entities.Ruta.Enemie);
                    }
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

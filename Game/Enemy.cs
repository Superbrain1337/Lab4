﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Enemy:Entities
    {
        public override int X { get; set; }
        public override int Y { get; set; }
        public int PrevX { get; set; }
        public int PrevY { get; set; }
        public int NumberOfEnemies { get; set; }
        public int[,] EnemyList { get; set; }
        public int WalkDirection { get; set; }

        public Enemy()  //A new list of enemies is created
        {
            EnemyList = new int[2,150];
        }

        public void CreateEnemies(int difficulty)
        {
            while (NumberOfEnemies < 10 * difficulty)    //Enemies are added to the board and the enemyList
            {
                Y = 1 + Rnd.Next(Board.GetLength(0) - 1);
                X = 1 + Rnd.Next(Board.GetLength(1) - 1);
                if (Board[Y, X] == Ruta.Empty)
                {
                    Board[Y, X] = Ruta.Enemie;
                    EnemyList[0, NumberOfEnemies] = Y;
                    EnemyList[1, NumberOfEnemies] = X;
                    NumberOfEnemies++;
                }
            }
        }

        public void MoveEnemy(int currentEnemy, int playerX, int playerY)   //The enemies are moved in a rondom direction
        {                                                                   //If they are close to to player they moves towards him/her
            PrevY = EnemyList[0, currentEnemy];
            PrevX = EnemyList[1, currentEnemy];     
            if (EnemyList[0, currentEnemy] != 0 && EnemyList[1, currentEnemy] != 0 && Board[PrevY, PrevX] != Ruta.Shot)
            {
                if (EnemyList[1, currentEnemy] - playerX <= 5 && EnemyList[1, currentEnemy] - playerX >= -5 &&
                    EnemyList[0, currentEnemy] - playerY <= 5 && EnemyList[0, currentEnemy] - playerY >= -5)
                {
                    if (EnemyList[0, currentEnemy] == playerY)
                    {
                        if (EnemyList[1, currentEnemy] < playerX)
                        {
                            EnemyList[1, currentEnemy]++;
                        }
                        else if (EnemyList[1, currentEnemy] > playerX)
                        {
                            EnemyList[1, currentEnemy]--;
                        }
                    }
                    else if (EnemyList[1, currentEnemy] == playerX)
                    {
                        if (EnemyList[0, currentEnemy] < playerY)
                        {
                            EnemyList[0, currentEnemy]++;
                        }
                        else if (EnemyList[0, currentEnemy] > playerY)
                        {
                            EnemyList[0, currentEnemy]--;
                        }
                    }
                    else if (EnemyList[1, currentEnemy] < playerX && EnemyList[0, currentEnemy] < playerY)
                    {
                        EnemyList[1, currentEnemy]++;
                        EnemyList[0, currentEnemy]++;
                    }
                    else if (EnemyList[1, currentEnemy] < playerX && EnemyList[0, currentEnemy] > playerY)
                    {
                        EnemyList[1, currentEnemy]++;
                        EnemyList[0, currentEnemy]--;
                    }
                    else if (EnemyList[1, currentEnemy] > playerX && EnemyList[0, currentEnemy] < playerY)
                    {
                        EnemyList[1, currentEnemy]--;
                        EnemyList[0, currentEnemy]++;
                    }
                    else
                    {
                        EnemyList[1, currentEnemy]--;
                        EnemyList[0, currentEnemy]--;
                    }
                }
                else
                {               //The random direction part
                    WalkDirection = Rnd.Next(4);

                    if (WalkDirection == 0)
                    {
                        EnemyList[1, currentEnemy]--;
                    }
                    else if (WalkDirection == 1)
                    {
                        EnemyList[0, currentEnemy]++;
                    }
                    else if (WalkDirection == 2)
                    {
                        EnemyList[1, currentEnemy]++;
                    }
                    else
                    {
                        EnemyList[0, currentEnemy]--;
                    }
                }
            }
            X = EnemyList[1, currentEnemy];
            Y = EnemyList[0, currentEnemy];
            if (Board[Y, X] != Ruta.Shot)
            {
                Board[PrevY, PrevX] = Ruta.Empty;
            }
        }

        public int UpdateEnemyPosititon(int currentEnemy)   //Checks if the enemy is in an ok position or it is reset to its previus one
        {
            X = EnemyList[1, currentEnemy];
            Y = EnemyList[0, currentEnemy];
            if (Board[Y, X] == Ruta.Player)
            {
                EnemyList[1, currentEnemy] = 0;
                EnemyList[0, currentEnemy] = 0;
                return 50;
            }
            if (Board[Y, X] == Ruta.Shot)
            {
                EnemyList[1, currentEnemy] = 0;
                EnemyList[0, currentEnemy] = 0;
            }
            else if (Board[Y, X] != Ruta.Empty) 
            {
                EnemyList[1, currentEnemy] = PrevX;
                X = PrevX;
                EnemyList[0, currentEnemy] = PrevY;
                Y = PrevY;
                Board[Y, X] = Ruta.Enemie;
            }
            else
            {
                Board[Y, X] = Ruta.Enemie;
            }
            return 0;
        }
    }
}

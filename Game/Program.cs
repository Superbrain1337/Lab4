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

        public static PlayerClass Player = new PlayerClass();
        public static Room Room = new Room();
        public static Entities Board = new Entities();

        static void Main(string[] args)
        {
            Entities B = new Entities();
            Door D = new Door();
            Room.CreateRoom(B);
            Room.DrawWalls(B);
            D.CreateExit(B);
            Random rnd = new Random();
            Entities[,] board = new Entities[20, 50];
            board = B.Board;
            bool loseGame = false;
            
            Player.X = 25;
            Player.Y = 18;
            int highscore = 0, playerUsedActions = 0;
            ConsoleKeyInfo userMovementInput = new ConsoleKeyInfo();
            Console.CursorVisible = false;
            boarGrid[Player.Y, Player.X] = Rutor.Player;
            Draw.DrawScreen(boarGrid);
            while (!loseGame)
            {
                userMovementInput = Console.ReadKey(true);
                Player.PrevX = Player.X;
                Player.PrevY = Player.Y;
                playerUsedActions++;
                switch (userMovementInput.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:

                        if (boarGrid[Player.Y - 1, Player.X] != Rutor.Wall)
                            Player.Y--;
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (boarGrid[Player.Y + 1, Player.X] != Rutor.Wall)
                            Player.Y++;
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (boarGrid[Player.Y, Player.X - 1] != Rutor.Wall)
                            Player.X--;
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (boarGrid[Player.Y, Player.X + 1] != Rutor.Wall)
                            Player.X++;
                        break;
                    default:
                        break;
                }
                if (Player.PrevX != Player.X || Player.PrevY != Player.Y)
                {
                    Draw.Plot(Player.PrevX, Player.PrevY, ' ');
                    Draw.Plot(Player.X, Player.Y, Rutor.Playe);
                }
                if (Player.X == 2 && Player.Y == 2)
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

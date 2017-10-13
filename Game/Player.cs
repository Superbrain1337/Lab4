using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player:Entities
    {
        
        public override int X { get; set; }
        public override int Y { get; set; }
        public int PrevX { get; set; }
        public int PrevY { get; set; }
        public ConsoleKeyInfo UserMovementInput { get; set; }
        public int Health { get; set; }
        public int Ammo { get; set; }

        public Player()     //Sets the start values for the player
        {
            X = 50; 
            Y = 20; 
            Health = 1000;
            Ammo = 10;
            UserMovementInput = new ConsoleKeyInfo();
            Console.CursorVisible = false;
            Board[Y, X] = Ruta.Player;
        }

        public int UpdatePlayerPosititon() //Checks the player position and resets it to the previus location if nessesary
        {
            Board[PrevY, PrevX] = Ruta.Empty;
            if (Board[Y, X] == Ruta.Wall)
            {
                X = PrevX;
                Y = PrevY;
            }
            else if (Board[Y, X] == Ruta.Door)
            {
                if (NumbOfKeys <= 0)
                {
                    X = PrevX;
                    Y = PrevY;
                }
                else
                {
                    Board[Y, X] = Ruta.Player;
                    return 1;
                }
            }
            else if (Board[Y, X] == Ruta.Enemie)
            {
                Health -= 50;
            }
            else if (Board[Y, X] == Ruta.Key)
            {
                NumbOfKeys++;
            }
            else if (Board[Y, X] == Ruta.Bomb)
            {
                return 2;
            }
            else if (Board[Y, X] == Ruta.Ammo)
            {
                Ammo += 5;
            }
            
            Board[Y, X] = Ruta.Player;
            return 0;
        }

        public bool MovePlayer()    //Moves the player in the diretion that is pressed
        {
            UserMovementInput = Console.ReadKey(true);

            PrevX = X;
            PrevY = Y;

            switch (UserMovementInput.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    Y--;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    Y++;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    X--;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    X++;
                    break;
                case ConsoleKey.Q:
                    X--;
                    Y--;
                    break;
                case ConsoleKey.E:
                    X++;
                    Y--;
                    break;
                case ConsoleKey.Z:
                    X--;
                    Y++;
                    break;
                case ConsoleKey.X:
                    X++;
                    Y++;
                    break;
                case ConsoleKey.U:
                    if (Ammo > 0)
                    {
                        Fire(2);
                        Ammo--;
                    }
                    break;
                case ConsoleKey.K:
                    if (Ammo > 0)
                    {
                        Fire(1);
                        Ammo--;
                    }
                    break;
                case ConsoleKey.J:
                    if (Ammo > 0)
                    {
                        Fire(0);
                        Ammo--;
                    }
                    break;
                case ConsoleKey.H:
                    if (Ammo > 0)
                    {
                        Fire(3);
                        Ammo--;
                    }
                    break;
                case ConsoleKey.M:
                    if (Ammo > 0)
                    {
                        Fire(4);
                        Ammo--;
                    }
                    break;
                case ConsoleKey.N:
                    if (Ammo > 0)
                    {
                        Fire(5);
                        Ammo--;
                    }
                    break;
                case ConsoleKey.Y:
                    if (Ammo > 0)
                    {
                        Fire(6);
                        Ammo--;
                    }
                    break;
                case ConsoleKey.I:
                    if (Ammo > 0)
                    {
                        Fire(7);
                        Ammo--;
                    }
                    break;
                case ConsoleKey.B:
                    return true;
                case ConsoleKey.Spacebar:
                    if (Health < 1000)
                    {
                        Health += 2;
                    }
                    break;
            }
            return false;
        }

        public void PlayerUpdateVisibility()
        {
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    if (Y - 8 + i > 0 && X - 20 + j > 0 && Y - 8 + i < IsVisible.GetLength(0) &&
                        X - 20 + j < IsVisible.GetLength(1))
                    {
                        if (IsVisible[Y - 8 + i, X - 20 + j] == false)
                        {
                            IsVisible[Y - 8 + i, X - 20 + j] = true;
                        }
                    }
                }
            }
        }

        public void Fire(int direction)
        {
            int i = 1;
            switch (direction)
            {
                case 0: // J
                    while (Board[Y + i, X] == Ruta.Empty)
                    {
                        i++;
                    }
                    if (Board[Y + i, X] == Ruta.Enemie)
                    {
                        Board[Y + i, X] = Ruta.Shot;
                    }
                    break;
                case 1: // K
                    while (Board[Y, X + i] == Ruta.Empty)
                    {
                        i++;
                    }
                    if (Board[Y, X + i] == Ruta.Enemie)
                    {
                        Board[Y, X + i] = Ruta.Shot;
                    }
                    break;
                case 2: // U
                    while (Board[Y - i, X] == Ruta.Empty)
                    {
                        i++;
                    }
                    if (Board[Y - i, X] == Ruta.Enemie)
                    {
                        Board[Y - i, X] = Ruta.Shot;
                    }
                    break;
                case 3: // H
                    while (Board[Y, X - i] == Ruta.Empty)
                    {
                        i++;
                    }
                    if (Board[Y, X - i] == Ruta.Enemie)
                    {
                        Board[Y, X - i] = Ruta.Shot;
                    }
                    break;
                case 4: // M
                    while (Board[Y + i, X + i] == Ruta.Empty)
                    {
                        i++;
                    }
                    if (Board[Y + i, X + i] == Ruta.Enemie)
                    {
                        Board[Y + i, X + i] = Ruta.Shot;
                    }
                    break;
                case 5: // N
                    while (Board[Y + i, X - i] == Ruta.Empty)
                    {
                        i++;
                    }
                    if (Board[Y + i, X - i] == Ruta.Enemie)
                    {
                        Board[Y + i, X - i] = Ruta.Shot;
                    }
                    break;
                case 6: // Y
                    while (Board[Y - i, X - i] == Ruta.Empty)
                    {
                        i++;
                    }
                    if (Board[Y - i, X - i] == Ruta.Enemie)
                    {
                        Board[Y - i, X - i] = Ruta.Shot;
                    }
                    break;
                case 7: // I
                    while (Board[Y - i, X + i] == Ruta.Empty)
                    {
                        i++;
                    }
                    if (Board[Y - i, X + i] == Ruta.Enemie)
                    {
                        Board[Y - i, X + i] = Ruta.Shot;
                    }
                    break;
            }
        }
    }
}

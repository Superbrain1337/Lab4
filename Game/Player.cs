using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player:Entities, ILetter
    {

        public override int X { get; set; }
        public override int Y { get; set; }
        public int PrevX { get; set; }
        public int PrevY { get; set; }
        public char Letter { get; set; }
        public ConsoleKeyInfo UserMovementInput { get; set; }
        public int Health { get; set; }

        public Player()
        {
            Letter = 'P';
            X = 25;
            Y = 18;
            Health = 100;
            UserMovementInput = new ConsoleKeyInfo();
            Console.CursorVisible = false;
            Board[Y, X] = Ruta.Player;
        }

        public void UpdatePlayerPosititon()
        {
            if (Board[Y, X] == Ruta.Wall)
            {
                X = PrevX;
                Y = PrevY;
            }
            else if (Board[Y, X] == Ruta.Door)
            {
                if (!CanMoveTo)
                {
                    X = PrevX;
                    Y = PrevY;
                }
            }
            else if (Board[Y, X] == Ruta.Enemie)
            {
                Health -= 50;
            }
        }

        public void MovePlayer()
        {
            UserMovementInput = Console.ReadKey(true);

            PrevX = X;
            PrevY = Y;

            switch (UserMovementInput.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    Y--;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    Y++;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    X--;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    X++;
                    break;
            }
        }
    }
}

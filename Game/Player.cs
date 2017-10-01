using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player:Entities
    {
        private int x;
        private int y;
        private int prevX = 0;
        private int prevY = 0;
        private char letter = 'P';
        private ConsoleKeyInfo userMovementInput;

        public override int X { get; set; }
        public override int Y { get; set; }
        public int PrevX { get; set; }
        public int PrevY { get; set; }
        public override char Letter { get; set; }
        public ConsoleKeyInfo UserMovementInput { get; set; }

        public Player()
        {
            Letter = 'P';
            X = 25;
            Y = 18;
            UserMovementInput = new ConsoleKeyInfo();
            Console.CursorVisible = false;
            Board[Y, X] = Entities.Ruta.Player;
        }

        public void UpdatePlayer()
        {
            UserMovementInput = Console.ReadKey(true);
            PrevX = X;
            PrevY = Y;

            switch (UserMovementInput.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:

                    if (Board[Y - 1, X] != Ruta.Wall)
                        Y--;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (Board[Y + 1, X] != Ruta.Wall)
                        Y++;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (Board[Y, X - 1] != Ruta.Wall)
                        X--;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (Board[Y, X + 1] != Ruta.Wall)
                        X++;
                    break;
                default:
                    break;
            }
        }
    }
}

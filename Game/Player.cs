using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PlayerClass : Entities
    {
        ConsoleKeyInfo userMovementInput = new ConsoleKeyInfo();
        public int PrevX { get; set; }
        public int PrevY { get; set; }

        public PlayerClass()
        {
            Letter = 'P';
            X = 25;
            Y = 18;
            PrevX = 0;
            PrevY = 0;
        }

        public PlayerClass(int x, int y, char letter, Random rnd, char[,] board, int prevX, int prevY)
        {
            this.X = x;
            this.Y = y;
            this.Letter = letter;

            this.PrevX = prevX;
            this.PrevY = prevY;
        }

        public char[,] PlayerMovement(char[,] boardGrid, BoardClass board)
        {
            userMovementInput = Console.ReadKey(true);
            PlayerClass player = new PlayerClass();
            EmptyClass empty = new EmptyClass();
            PrevX = X;
            PrevY = Y;
            switch (userMovementInput.Key)
            {
                
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (boardGrid[Y - 1,  X] != board.Letter)
                        Y--;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (boardGrid[Y + 1, X] != board.Letter)
                        Y++;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (boardGrid[Y, X - 1] != board.Letter)
                        X--;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (boardGrid[Y, X + 1] != board.Letter)
                        X++;
                    break;
                default:
                    break;
            }
            if (PrevX != X || PrevY != Y)
            {
                Draw.Plot(PrevX, PrevY, empty.Letter);
                Draw.Plot(X, Y, player.Letter);
            }

            if (X == board.exitX && Y == board.exitY)
            {
                ExitRoom(true);
            }
            return (boardGrid);
        }
        public void ExitRoom(bool exitedRoom)
        {
            Program.loseGame = true;
        }
    }
}

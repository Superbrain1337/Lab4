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
        public EnemyClass enemy = new EnemyClass();
        public DoorClass door = new DoorClass();
        public KeyClass key = new KeyClass();
        public EmptyClass empty = new EmptyClass();
        public BoardClass board = new BoardClass();
        public WallClass wall = new WallClass();

        public int PrevX { get; set; }
        public int PrevY { get; set; }
        public char PrevLetter { get; set; }
        public int AmountOfKeys { get; set; }

        public PlayerClass()
        {
            Letter = 'P';
            X = 25;
            Y = 18;
            PrevX = 0;
            PrevY = 0;
            PrevLetter = ' ';
            AmountOfKeys = 0;
        }

        public PlayerClass(int x, int y, char letter, Random rnd, char[,] board, int prevX, int prevY, int amountOfKeys, char prevLetter)
        {
            this.X = x;
            this.Y = y;
            this.Letter = letter;

            this.PrevX = prevX;
            this.PrevY = prevY;
            this.AmountOfKeys = amountOfKeys;
            this.PrevLetter = prevLetter;
        }

        public char[,] PlayerMovement(char[,] boardGrid)
        {
            userMovementInput = Console.ReadKey(true);
            int DX=0, DY=0;
            switch (userMovementInput.Key)
            {
                
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    DY--;
                    PlayerAction(boardGrid, DX, DY++);
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    DY++;
                    PlayerAction(boardGrid, DX, DY++);
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    PlayerAction(boardGrid, DX, DY++);
                    DX--;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    PlayerAction(boardGrid, DX, DY++);
                    DX++;
                    break;
                default:
                    break;
            }
            if (PrevX != X || PrevY != Y)
            {
                Draw.Plot(PrevX, PrevY, PrevLetter);
                Draw.Plot(X, Y, Letter);
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

        public char[,] PlayerAction(char[,] boardGrid, int DX, int DY)
        {
            if (boardGrid[Y + DY, X + DX] != wall.Letter ||
                boardGrid[Y + DY, X + DX] != enemy.Letter||
                boardGrid[Y + DY, X + DX] != door.Letter||
                boardGrid[Y + DY, X + DX] != key.Letter)
            {
                Y += DY;
                X += DY;
            }
            else if (boardGrid[Y + DY, X + DX] == enemy.Letter)
            {
                Y += DY;
                X += DY;
                boardGrid[Y-DY, X-DX] = empty.Letter;
                //add turns to the score
            }
            else if (boardGrid[Y + DY, X + DX] == door.Letter)
            {
                if (AmountOfKeys <= 1)
                {
                    //open door
                    Y += DY;
                    X += DY;
                    AmountOfKeys--;
                }
            }
            else if (boardGrid[Y + DY, X + DX] == key.Letter)
            {
                AmountOfKeys++;
                Y += DY;
                X += DY;
            }
            else if (boardGrid[Y + DY, X + DX] == wall.Letter)
            {
                X = X;
                Y = Y;
            }
            
            return (boardGrid);
        }
    }
}

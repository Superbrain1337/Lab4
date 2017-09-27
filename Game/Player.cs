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
        public int prevX { get; set; }
        public int prevY { get; set; }

        public PlayerClass()
        {
            Letter = 'P';
            X = 25;
            Y = 18;
            prevX = 0;
            prevY = 0;
        }

        public PlayerClass(int x, int y, char letter, Random rnd, char[,] board, int prevX, int prevY)
        {
            this.X = x;
            this.Y = y;
            this.Letter = letter;

            this.prevX = prevX;
            this.prevY = prevY;
        }

        public void PlayerMovement()
        {
            userMovementInput = Console.ReadKey(true);
            prevX = X;
            prevY = Y;
            
                
            switch (userMovementInput.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:

                    if (boarGrid[Player.Y - 1, Player.X] != )
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
                Draw.Plot(Player.PrevX, Player.PrevY, Rutor.Room);
                Draw.Plot(Player.X, Player.Y, Rutor.Player);
            }

            if (Player.X == 2 && Player.Y == 2)
            {
                highscore = 100 - playerUsedActions;
                loseGame = true;
            }
        }
    }
}

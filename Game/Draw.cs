using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Game
{
    public class Draw
    {

        static string controls = "P = Player, E = Enemy, # = Wall, D = Door, K = Key, B = Bomb, T = Treasure, A = Ammo";

        //Draws what CreateScreen set as output
        public static void DrawScreen(Entities.Ruta[,] boardArray, bool[,] visibilityBoard)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(CreateScreen(boardArray, visibilityBoard));
        }

        //Sets what to be printed in DrawScreen
        public static string CreateScreen(Entities.Ruta[,] boardArray, bool[,] visibilityBoard)
        {
            string[] boardArrayLine = new string[boardArray.GetLength(0)];
            string output = "";

            //Loops thru the boardArray placing all collums of the first row, secon row and so forth in a string
            for (int i = 0; i < boardArray.GetLength(0); i++)
            {
                for (int j = 0; j < boardArray.GetLength(1); j++)
                {
                    if (visibilityBoard[i, j])
                    {
                        boardArrayLine[i] += (char)boardArray[i, j];
                    }
                    else
                    {
                        boardArrayLine[i] += " ";
                    }
                }
            }

            //All the rows are made into a string
            foreach (string t in boardArrayLine)
            {
                output += t + "\n";
            }

            //adds information for the player into the output
            output += "\n";

            return output;
        }

        public static void DrawControls(Entities.Ruta[,] boardArray, int highscore, int playerHealth, int bombCount, int ammo)
        {
            Console.SetCursorPosition(0, boardArray.GetLength(0));
            Console.WriteLine($"{controls} \nHighscore: {highscore}, Health: {playerHealth} Bombs: {bombCount} Ammo: {ammo}\n");
        }

        public static void DrawGameOver(int highscore)
        {
            Console.WriteLine($"Game Over! You got the score: {highscore}");
        }

        //This is called each time the player or the enemies moves on the board. Also sets the position for the treasures
        public static void Plot(int x, int y, Entities.Ruta c, ConsoleColor f)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = f;
            Console.Write((char)c);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

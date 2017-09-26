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

        static string controls = $"{Program.Player.Letter} = Player, E = Enemy, # = Wall, D = Door, K = Key";

        //Draws what CreateScreen set as output
        public static void DrawScreen(Rutor[,] boardArray)
        {
            Console.Clear();
            
            Console.WriteLine(CreateScreen(boardArray));
        }

        //Sets what to be printed in DrawScreen
        public static string CreateScreen(char[,] boardArray)
        {
            string[] boardArrayLine = new string[boardArray.GetLength(0)];
            string output = "";

            //Loops thru the boardArray placing all collums of the first row, secon row and so forth in a string
            for (int i = 0; i < boardArray.GetLength(0); i++)
            {
                for (int j = 0; j < boardArray.GetLength(1); j++)
                {
                  boardArrayLine[i] += (char)boardArray[i, j];
                }
            }

            //All the rows are made into a string
            for (int i = 0; i < boardArrayLine.Length; i++)     
            {
                output += boardArrayLine[i] + "\n";
            }

            //adds information for the player into the output
            output += "\n" + controls;

            return output;
        }

        public static void DrawGameOver(int highscore)
        {
            Console.WriteLine($"Game Over! You got the score: {highscore}");
        }

        //This is called each time the player moves on the board
        public static void Plot(int x, int y, char c)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }
    }
}

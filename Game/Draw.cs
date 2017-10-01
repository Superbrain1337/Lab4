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
        public static PlayerClass player = new PlayerClass();
        public static EnemyClass enemy = new EnemyClass();
        public static WallClass wall = new WallClass();
        public static DoorClass door = new DoorClass();
        public static KeyClass key = new KeyClass();
        static string controls = $" {player.Letter}= Player, {enemy.Letter} = Enemy, {wall.Letter} = Wall, {door.Letter} = Door, {key.Letter} = Key";

        //Draws what CreateScreen set as output
        public static void DrawScreen(char[,] boardArrayDrawScreen, PlayerClass player)
        {
            Console.Clear();
            Console.WriteLine(CreateScreen(boardArrayDrawScreen));
        }

        //Sets what to be printed in DrawScreen
        private static string CreateScreen(char[,] boardArrayCreateScreen)
        {
            int debug = boardArrayCreateScreen.GetLength(0);
            string[] boardArrayLine = new string[debug];
            string output = "";

            //Loops thru the boardArray placing all collums of the first row, secon row and so forth in a string
            for (int i = 0; i < boardArrayCreateScreen.GetLength(0); i++)
            {
                for (int j = 0; j < boardArrayCreateScreen.GetLength(1); j++)
                {
                  boardArrayLine[i] += boardArrayCreateScreen[i, j];
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

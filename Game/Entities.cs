using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    
    //public enum Rutor { Player = 80, Enemie = 69, Wall = 35, Room = 32, Door = 68, Stairs = 83, Key = 75 };
    public abstract class Entities
    {
        public enum Ruta { Player = 'P', Door = 'D', Key = 'K', Wall = '#', Enemie = 'E', Empty = ' ' }
        private Random rnd = new Random();

        public abstract int X { get; set; }
        public abstract int Y { get; set; }
        public bool CanMoveTo { get; set; }
        public static Ruta[,] Board { get; set; } = new Ruta[40,100];
        public int NumbOfKeys { get; set; }
        public Random Rnd => rnd;
    }
    public class Empty:Entities, ILetter
    {
        public override int X { get; set; }
        public override int Y { get; set; }
        public char Letter { get; set; }

        public Empty()
        {
            CanMoveTo = true;
            Letter = ' ';
            Board[Y, X] = Ruta.Empty;
        }

        public void NewBoard()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Board[i, j] = Ruta.Empty;
                }
            }
        }
        
    }
}

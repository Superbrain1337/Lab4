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
        private int x = 0;
        private int y = 0;
        private char letter = ' ';
        private static Ruta[,] board = new Ruta[40,100];
        private Random rnd = new Random();
        private int numbOfKeys = 0;


        public abstract int X { get; set; }
        public abstract int Y { get; set; }
        public abstract char Letter { get; set; }
        public static Ruta[,] Board { get => board; set => board = value; }
        public int NumbOfKeys { get { return numbOfKeys; } set { numbOfKeys = value; } }
        public Random Rnd { get => rnd; set => rnd = value; }
        
    }
    public class Empty:Entities
    {
        public override int X { get; set; }
        public override int Y { get; set; }
        public override char Letter { get; set; }

        public Empty()
        {
            Letter = ' ';
            Entities.Board[Y, X] = Ruta.Empty;
        }
        
    }
}

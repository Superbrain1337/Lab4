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
        public static Ruta[,] Board { get; set; } = new Ruta[40,100];
        public static int NumbOfKeys { get; set; }
        public Random Rnd => rnd;
    }
}

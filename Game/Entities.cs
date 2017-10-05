using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
   
    public abstract class Entities:ICoordinates
    {
        public enum Ruta { Player = 'P', Door = 'D', Key = 'K', Wall = '#', Enemie = 'E', Empty = ' ', Treasure = 'T'}
        private Random rnd = new Random();
        private const int BoardX = 100;
        private const int BoardY = 40;

        public abstract int X { get; set; }
        public abstract int Y { get; set; }
        public static Ruta[,] Board { get; set; } = new Ruta[BoardY,BoardX];
        public static int NumbOfKeys { get; set; }
        public Random Rnd => rnd;
        public bool[,] IsVisible { get; set; } = new bool[BoardY - 2, BoardX - 2];

    }
}

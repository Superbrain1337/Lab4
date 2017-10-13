using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
   
    public abstract class Entities:ICoordinates
    {
        public enum Ruta { Player = 'P', Door = 'D', Key = 'K', Wall = '#', Enemie = 'E', Empty = ' ', Treasure = 'T', Bomb = 'B', Shot = '*', Ammo = 'A'}
        private Random rnd = new Random();
        private const int BoardX = 100;
        private const int BoardY = 40;

        public abstract int X { get; set; }
        public abstract int Y { get; set; }
        public static Ruta[,] Board { get; set; } = new Ruta[BoardY, BoardX];
        public static int NumbOfKeys { get; set; }
        public Random Rnd => rnd;
        public static bool[,] IsVisible { get; set; } = new bool[BoardY, BoardX];
        public static Ruta[,] BoardCopy { get; set; } = Board;

        public static void UpdateVisibilityBoard()
        {
            for (int i = 0; i < IsVisible.GetLength(0); i++)
            {
                for (int j = 0; j < IsVisible.GetLength(1); j++)
                {
                    if (i == 0 || j == 0 || i == IsVisible.GetLength(0) - 1 || j == IsVisible.GetLength(1) - 1)
                    {
                        IsVisible[i, j] = true;
                    }
                    else
                    {
                        IsVisible[i, j] = false;
                    }
                }
            }
        }
    }
}

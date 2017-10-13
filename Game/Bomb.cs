using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Bomb:Entities
    {
        public override int X { get; set; }
        public override int Y { get; set; }

        public int Countdown { get; set; } = 5;
        public int BombCount { get; set; }
        public int[,] BombList { get; set; }

        public Bomb()
        {
            BombList = new int[2, 5];
        }


        public void CreateBombs()
        {
            for (int i = 0; i < 5; i++)
            {
                X = 1 + Rnd.Next(Board.GetLength(1) - 2);
                Y = 1 + Rnd.Next(Board.GetLength(0) - 2);
                BombList[0, i] = Y;
                BombList[1, i] = X;
                Board[Y, X] = Ruta.Bomb;
            }
        }

        public void BombSetOf(int y, int x)
        {
            X = x;
            Y = y;
            if (BombCount > 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (Y - 2 + i < Board.GetLength(0) - 1 && Y - 2 > 0 && X - 2 + j < Board.GetLength(1) - 1 && X - 2 > 0)
                        {
                            if (i != 2 || j != 2)
                            {
                                Board[Y - 2 + i, X - 2 + j] = Ruta.Empty;
                            }
                        }
                    }
                }
                BombCount--;
            }
        }
    }
}

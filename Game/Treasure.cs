using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Treasure:Entities, ILetter
    {
        public override int X { get; set; }
        public override int Y { get; set; }

        public char Letter { get; set; }

        public int[,] TreasureList { get; set; }

        public Treasure()
        {
            Letter = 'T';
            TreasureList = new int[5,5];
        }

        public void GenerateTreasures()
        {
            for (int i = 0; i < 5; i++)
            {
                X = 5 + Rnd.Next(Board.GetLength(1) - 6);
                Y = 2 + Rnd.Next(Board.GetLength(0) - 3);
                Board[Y, X] = Ruta.Treasure;
                TreasureList[0, i] = X;
                TreasureList[1, i] = Y;
                TreasureList[2, i] = 0;
                TreasureList[3, i] = 5 + i;
            }
        }

        public int FoundTreasure(int playerX, int playerY)
        {
            for (int i = 0; i < TreasureList.GetLength(0); i++)
            {
                if (playerX == TreasureList[0, i] && playerY == TreasureList[1, i] && TreasureList[2, i] != 1)
                {
                    TreasureList[2, i] = 1;
                    return 100 * i;
                }
            }
            return 0;
        }
    }
}

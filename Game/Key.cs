﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Key:Entities
    {
        public override int X { get; set; }
        public override int Y { get; set; }
        public int KeyCount { get; set; }
        
        public void SpawnKey()  //A new key is spawned somewhere on the board
        {
            while (KeyCount < 1)
            {
                Y = 2 + Rnd.Next(Board.GetLength(0) - 4);
                X = 5 + Rnd.Next(Board.GetLength(1) - 10);
                if (Board[Y, X] == Ruta.Empty)
                {
                    Board[Y, X] = Ruta.Key;
                    IsVisible[Y, X] = true;
                    KeyCount++;
                }
            }
        }
    }
}

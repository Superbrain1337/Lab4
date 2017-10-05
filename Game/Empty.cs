﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Empty:Entities, ILetter
    {
        public override int X { get; set; }
        public override int Y { get; set; }
        public char Letter { get; set; }

        public Empty()
        {
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

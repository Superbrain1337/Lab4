using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player:Entities
    {
        
        private int prevX = 0;
        private int prevY = 0;
        private char letter = 'P';

        public int PrevX { get; set; }
        public int PrevY { get; set; }

        public Player()
        {
            Letter = 'P';
        }
    }
}

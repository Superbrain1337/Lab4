using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Enemy:Entities, ILetter
    {
        public override int X { get; set; }
        public override int Y { get; set; }
        public int PrevX { get; set; }
        public int PrevY { get; set; }
        public char Letter { get; set; }
        public int NumberOfEnemies { get; set; }
        public int[,] EnemyList { get; set; }
        public int WalkDirection { get; set; }

        public Enemy()
        {
            Letter = 'E';
            EnemyList = new int[2,20];
        }

        public void CreateEnemies(int difficulty)
        {
            while (NumberOfEnemies < 2 * difficulty)
            {
                Y = Rnd.Next(Board.GetLength(0));
                X = Rnd.Next(Board.GetLength(1));
                if (Board[Y, X] == Ruta.Empty)
                {
                    Board[Y, X] = Ruta.Enemie;
                    EnemyList[0, NumberOfEnemies] = Y;
                    EnemyList[1, NumberOfEnemies] = X;
                    NumberOfEnemies++;
                }
            }
        }

        public void MoveEnemy(int currentEnemy)
        {
            PrevY = EnemyList[0, currentEnemy];
            PrevX = EnemyList[1, currentEnemy];

            WalkDirection = Rnd.Next(4);

            if (WalkDirection == 0)
            {
                EnemyList[1, currentEnemy]--;
            }
            else if (WalkDirection == 1)
            {
                EnemyList[0, currentEnemy]++;
            }
            else if (WalkDirection == 2)
            {
                EnemyList[1, currentEnemy]++;
            }
            else
            {
                EnemyList[0, currentEnemy]--;
            }
            X = EnemyList[1, currentEnemy];
            Y = EnemyList[0, currentEnemy];
        }

        public void UpdateEnemyPosititon(int currentEnemy)
        {
            if (Board[Y, X] != Ruta.Empty)
            {
                EnemyList[1, currentEnemy] = PrevX;
                X = PrevX;
                EnemyList[0, currentEnemy] = PrevY;
                Y = PrevY;
            }
        }
    }
}

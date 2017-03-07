using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_puzzle
{
    class Game2 : Puzzle
    {
        public Game2(params int[] numberedSquare) : base(numberedSquare)
        {  
        }
        private void IllegalShift(int value1, int value2)
        {
            Coordinate temporal1 = coor[value1];
            this[coor[value1].X, coor[value1].Y] = value2;
            this[coor[value2].X, coor[value2].Y] = value1;
            coor[value1] = coor[value2];
            coor[value2] = temporal1;
        }
        public virtual void Randomize()
        {
            var n = new Random().Next(SizeOfSide * SizeOfSide);
            var val = new Random();
            for (int i = 0; i < n; i++)
                IllegalShift(val.Next(SizeOfSide * SizeOfSide - 1),
                             val.Next(SizeOfSide * SizeOfSide - 1));
        }

        public static Game2 CreateRandom(int sizeOfSide)
        {
            int[] numberedSquare = new int[sizeOfSide * sizeOfSide];
            for (int i = 0; i < sizeOfSide * sizeOfSide; i++)
                numberedSquare[i] = i;
            var randomPuzzle = new Game2(numberedSquare);
            randomPuzzle.Randomize();
            return randomPuzzle;
        }
        public bool Victory
        {
            get
            {
                for (int i = 0; i < SizeOfSide; i++)
                {
                    for (int j = 0; j < SizeOfSide; j++)
                    {
                        if (i == SizeOfSide - 1 && j == SizeOfSide - 1 && this[i, j] == 0)
                            continue;
                        else if (this[i, j] == i * SizeOfSide + j + 1 && (i != SizeOfSide - 1 || j != SizeOfSide - 1))
                            continue;
                        else return false;
                    }
                }
                return true;
            }
        }
    }
}

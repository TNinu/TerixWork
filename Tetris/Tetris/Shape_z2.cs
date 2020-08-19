using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Shape_z2 : BaseShape
    {
        int[,] arr = new int[,] {
        { 0,1,0,0},
        { 0,1,1,0},
        { 0,0,1,0},
        { 0,0,0,0}
        };

        public override int[,] ArrayShape
        {
            get { return arr; }
            set { ArrayShape = value; }
        }
        public Shape_z2()
        {
            InitArray(arr);
        }
        public override void Up(int[,] ArraySum) {
            for (int i = 1; i < 19; i++)
            {
                for (int j = 1; j < 19; j++)
                {
                    if (ArraySum[i, j] == 1 && ArraySum[i + 1, j] == 1
                        && ArraySum[i + 1, j + 1] == 1 &&
                        ArraySum[i, j + 1] == 0 && ArraySum[i + 2, j] == 0
                        )
                    {
                        ArraySum[i, j] = 0;
                        ArraySum[i + 2, j + 1] = 0;
                        ArraySum[i, j + 1] = 1;
                        ArraySum[i + 2, j] = 1;
                        return;
                    }
                    if (ArraySum[i, j] == 1 && ArraySum[i + 1, j] == 1
                       && ArraySum[i + 1, j - 1] == 1 && ArraySum[i, j - 1] == 0
                       && ArraySum[i + 2, j] == 0
                       )
                    {
                        ArraySum[i, j] = 0;
                        ArraySum[i + 2, j - 1] = 0;
                        ArraySum[i, j - 1] = 1;
                        ArraySum[i + 2, j] = 1;
                        return;
                    }
                }
            }
        }
        //public override void Left() { }
       // public override void Right() { }
       // public override void AutoDown() { }
    }
}

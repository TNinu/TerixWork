using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Shape_i : BaseShape
    {
        int[,] arr = new int[,] {
        { 0,1,0,0},
        { 0,1,0,0},
        { 0,1,0,0},
        { 0,1,0,0}
        };

        public override int[,] ArrayShape
        {
            get { return arr; }
            set { ArrayShape = value; }
        }
        public Shape_i() {
            InitArray(arr);
        }

        public override void Up(int[,] ArraySum) {

             for (int i = 1; i < 17; i++)
             {
                for (int j = 1; j < 17; j++)
                {
                    //竖着
                    if (ArraySum[i,j] == 1 && ArraySum[i, j + 1] == 0 &&
                        ArraySum[i + 1, j - 1] == 0 && ArraySum[i + 1, j + 1] == 0 &&
                         ArraySum[i + 1, j + 2] == 0
                        )
                    {
                        ArraySum[i, j] = 0;
                        ArraySum[i + 2, j] = 0;
                        ArraySum[i + 3, j] = 0;
                        ArraySum[i + 1, j - 1] = 1;
                        ArraySum[i + 1, j + 1] = 1;
                        ArraySum[i + 1, j + 2] = 1;
                        return;
                    }
                    //横着
                    if (ArraySum[i,j] == 1 && ArraySum[i,j+1] == 1 &&
                        ArraySum[i - 1, j + 1] ==0 && ArraySum[i + 1, j + 1] == 0 &&
                        ArraySum[i + 2, j + 1] == 0 && ArraySum[i - 1, j] == 0
                        )
                    {
                        ArraySum[i, j] = 0;
                        ArraySum[i, j + 2] = 0;
                        ArraySum[i, j + 3] = 0;
                        ArraySum[i - 1, j + 1] = 1;
                        ArraySum[i + 1, j + 1] = 1;
                        ArraySum[i + 2, j + 1] = 1;
                        return;
                    }
                }
            }
        }
    }
}

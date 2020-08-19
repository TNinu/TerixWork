using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Shape_L : BaseShape
    {
        int[,] arr = new int[,] {
        { 0,1,0,0},
        { 0,1,0,0},
        { 0,1,1,0},
        { 0,0,0,0}
        };
   
        public override int[,] ArrayShape
        {
            get { return arr; }
            set { ArrayShape = value; }
        }
        public Shape_L()
        {
            InitArray(arr);
        }
        // public override void Down() { }
        public override void Up(int[,] ArraySum) {
            for (int i = 1; i < 18; i++)
            {
                for (int j = 1; j < 18; j++)
                {
                    //无旋转->逆时针旋转90度
                    if (ArraySum[i,j] == 1 && ArraySum[i + 1, j] == 1 
                        && ArraySum[i + 2, j] == 1 &&
                        ArraySum[i + 1, j + 2] == 0 && ArraySum[i + 2, j + 2] == 0
                        )
                    {
                        ArraySum[i, j] = 0;
                        ArraySum[i + 1, j] = 0;
                        ArraySum[i + 1, j + 2] = 1;
                        ArraySum[i + 2, j + 2] = 1;
                        return;
                    }
                    //90度->180度
                    if (ArraySum[i, j] == 1 && ArraySum[i + 1, j] == 1 
                        && ArraySum[i + 1, j - 1] == 1 &&
                        ArraySum[i - 1, j] == 0 && ArraySum[i - 1, j - 1] == 0
                        )
                    {
                        ArraySum[i + 1, j - 1] = 0;
                        ArraySum[i + 1, j - 2] = 0;
                        ArraySum[i - 1, j] = 1;
                        ArraySum[i - 1, j - 1] = 1;
                        return;
                    }
                    //180度->270度
                    if (ArraySum[i, j] == 1 && ArraySum[i, j + 1] == 1
                        && ArraySum[i + 1, j + 1] == 1 &&
                        ArraySum[i, j - 1] == 0 && ArraySum[i + 1, j - 1] == 0
                        )
                    {
                        ArraySum[i + 2, j + 1] = 0;
                        ArraySum[i + 1, j + 1] = 0;
                        ArraySum[i, j - 1] = 1;
                        ArraySum[i + 1, j - 1] = 1;
                        return;
                    }
                    //270度->正常
                    if (ArraySum[i, j] == 1 && ArraySum[i, j + 1] == 1
                        && ArraySum[i + 1, j] == 1 && ArraySum[i + 2, j] == 0 &&
                        ArraySum[i + 2, j + 1] == 0
                        )
                    {
                        ArraySum[i, j + 1] = 0;
                        ArraySum[i, j + 2] = 0;
                        ArraySum[i + 2, j] = 1;
                        ArraySum[i + 2, j + 1] = 1;
                        return;
                    }
                }
            }
        
        }
        //public override void Left() { }
       //public override void Right() { }
        //public override void AutoDown() { }
    }
}

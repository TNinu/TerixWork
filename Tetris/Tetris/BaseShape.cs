using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class BaseShape
    {
        public int[,] ArrayBox = new int[ConstClass.BackGroundBoxHeight, ConstClass.BackGroundBoxWith];
        public virtual int[,] ArrayShape { get; set; }
        public BaseShape() {
            InitArrayBox(); 
        }
        private void InitArrayBox() {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (i == 0 || i == 19)
                    {
                        ArrayBox[i, j] = 3;
                    }
                    if (j == 0 || j == 19)
                    {
                        ArrayBox[i, j] = 3;
                    }
                }
            }

        }
        public void InitArray(int[,] ArrayShape) {
            for (int i = 1; i < 5; i++)
            {
                for (int j = 6; j < 10; j++)
                {
                    ArrayBox[i, j] = ArrayShape[i - 1, j - 6];
                }
            }
        }
        public virtual void Down(int[,] ArraySum) {
            for (int i = 18; i > 0; i--)
            {
                for (int j = 1; j < 19; j++)
                {
                    if (ArraySum[i, j] == 1 && ArraySum[i+1, j] == 2
                        || ArraySum[i, j] == 1 && ArraySum[i+1, j] == 3
                        )
                    {
                        return;
                    }
                }
            }
            for (int i = 18; i > 0; i--)
            {
                for (int j = 0; j < 19; j++)
                {
                    if (ArraySum[i,j] == 1 )
                    {
                        ArraySum[i + 1, j] = 1;
                        ArraySum[i, j] = 0;
                    }
                }
            }
        }
        public virtual void Up(int[,] ArraySum) { }
        public virtual void Left(int[,] ArraySum) {
            for (int i = 1; i < 19; i++)
            {
                for (int j = 1; j < 19; j++)
                {
                    if (j == 1 && ArraySum[i,j] == 1)
                    {
                        return;
                    }
                    if (ArraySum[i, j - 1] == 2 && ArraySum[i, j] == 1)
                    {
                        return;
                    }
                }
            }
            for (int i = 1; i < 19; i++)
            {
                for (int j = 1; j < 19; j++)
                {
                    if (ArraySum[i, j] == 1)
                    {
                        ArraySum[i, j - 1] = 1;
                        ArraySum[i, j] = 0;
                    }

                }
            }
        }
        public virtual void Right(int[,] ArraySum) {
            for (int i = 1; i < 19; i++)
            {
                for (int j = 18; j > 0; j--)
                {
                    if (j == 18 && ArraySum[i,j] == 1)
                    {
                        return;
                    }
                    if (ArraySum[i,j] == 1 && ArraySum[i,j+1] == 2)
                    {
                        return;
                    }
                }
            }
            for (int i = 1; i < 19; i++)
            {
                for (int j = 18; j > 0; j--)
                {
                    if (ArraySum[i, j] == 1)
                    {
                        ArraySum[i, j + 1] = 1;
                        ArraySum[i, j] = 0;
                    }
                }
            }
        }
    }
}

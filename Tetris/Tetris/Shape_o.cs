using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Shape_o : BaseShape
    {
        int[,] arr = new int[,] {
        { 0,1,1,0},
        { 0,1,1,0},
        { 0,0,0,0},
        { 0,0,0,0}
        };

        public override int[,] ArrayShape
        {
            get { return arr; }
            set { ArrayShape = value; }
        }
        public Shape_o()
        {
            InitArray(arr);
        }
        //public override void Down() { }
        public override void Up(int[,] ArraySum) { }
       //public override void Left() { }
       // public override void Right() { }
        //public override void AutoDown() { }
    }
}

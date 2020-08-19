using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class BackGroundBox
    {

        public static void DisplayBox(int[,] box) {
            Console.SetCursorPosition(0, 0);
           Console.WriteLine("提示：R重玩、Q退出");
            for (int i = 0; i < ConstClass.BackGroundBoxHeight; i++)
            {
                for (int j = 0; j < ConstClass.BackGroundBoxWith; j++)
                {
                    if (i == 0 || i == ConstClass.BackGroundBoxHeight - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        box[i, j] = 3;
                        Console.Write("■");
                    }
                    else if (j == 0 || j == 19 || j == ConstClass.BackGroundBoxWith - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        box[i, j] = 3;
                        Console.Write("■");
                    }
                    else if (box[i, j] == 1 || box[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("■");
                    }
                    else if (j == 22 && i == 14) {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("分数:");
                        Console.Write(box[i, j]);
                        if (box[i,j] == 0)
                        {
                            j += 2;
                        }
                        if (box[i,j] > 0 && box[i,j] < 100)
                        {
                            j += 3;
                            Console.Write(" ");
                        }
                        if (box[i,j] >= 100 && box[i,j] < 1000)
                        {
                            j += 4;
                            Console.Write("  ");
                        }
                        if (box[i, j] >= 1000)
                        {
                            j += 4;
                            Console.Write(" ");
                        }
                    }
                    else {
                            Console.Write("  ");
                    }
                    
                }
                Console.WriteLine();
            }

            /*for (int i = 0; i < 20; i++)
             {
                 for (int j = 0; j < 20; j++)
                 {
                     Console.Write(box[i, j]);
                 }
                 Console.WriteLine();
             }*/
          // Console.SetCursorPosition(0, 0);
        }
        
        

       

    }
}

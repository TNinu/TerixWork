using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Timers;

namespace Tetris
{
    public delegate void KeyDownEventHander(ConsoleKey key);
    class GameProcess
    {
        //产生图形并做预显示
        bool f = true;
        //分数
        int Score = 0;
        //是否产生新图形的标志
        int Flag = 0;
        //获取产生的图形
        BaseShape temp;
        int[,] ArraySum;
        BaseShape baseshape;
       public GameProcess() {

            //初始化
            baseshape = CreateShape.Create();
            ArraySum = baseshape.ArrayBox;
            temp = baseshape;

        }
        public event KeyDownEventHander KeyDown;
        //键盘按下线程，监听用户输入
        Thread keyDownThread;
        //定时器刷新事件
        System.Timers.Timer timer;
       

        public void StartGame() {
            //注册键盘监听线程
            keyDownThread = new Thread(KeyDownThread);
            //显示图形线程
            Thread thread = new Thread(Display);
            //注册键盘触发事件对应的函数
            KeyDown += KeyDownEvent;
            //启动线程
            keyDownThread.Start();
            //开启定时器
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            thread.Start();
        }
        //一个用于接收键盘输入的线程
        private void KeyDownThread() {
            while (true)
            {
                KeyDown(Console.ReadKey(true).Key);  //触发事件
            }
        }
        private void KeyDownEvent(ConsoleKey key) {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    baseshape.Up(ArraySum);
                    break;
                case ConsoleKey.LeftArrow:
                    baseshape.Left(ArraySum);
                    break;
                case ConsoleKey.DownArrow:
                    baseshape.Down(ArraySum); 
                    break;
                case ConsoleKey.RightArrow:
                    baseshape.Right(ArraySum);
                    break;
                case ConsoleKey.R:
                    ResetArray();
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
                default:
                    return;     
            }
        }
        private void Timer_Elapsed(object Source,
            System.Timers.ElapsedEventArgs e)
        { 
            AutoDown();
        }
        //更新数组数据
        private void Get() {
            for (int i = 1; i < 19; i++)
            {
                for (int j = 1; j < 19; j++)
                {
                    if (baseshape.ArrayBox[i, j] == 1 && Flag == 1)
                    {
                        ArraySum[i, j] = 1;
                    }
                }
            }
            Flag = 0;
            ArraySum[14, 22] = Score;
          
            for (int i = 3; i < 7; i++)
            {
                for (int j = 23; j < 27; j++)
                {
                    //当已经到底的图形到达产生图形的区域
                    if (ArraySum[i, j] == 2 && temp.ArrayShape[i - 3, j - 23] == 1)
                    {
                        for (int ii = 3; ii < 7; ii++)
                        {
                            for (int jj = 23; jj < 27; jj++)
                            {
                                if (temp.ArrayShape[ii - 3, jj - 23] == 1)
                                    ArraySum[ii, jj] = 2;
                            }
                        }
                        return;
                    }
                }
            }
                    //将新产生的图形值赋给显示数组
                    for (int i = 3; i < 7; i++)
                    {
                        for (int j = 23; j < 27; j++)
                        {
                              if(ArraySum[i,j] != 2) 
                                    ArraySum[i, j] = temp.ArrayShape[i - 3, j - 23];
                        }
                    }
        }
        //自动下降
        private void AutoDown()
        {
            //当图形到低，重新赋值
            for (int i = 18; i > 0; i--)
            {
                for (int j = 1; j < 19; j++)
                {
                    if (f)
                    {
                        temp = CreateShape.Create();
                        f = false;
                    }
                    if (ArraySum[i, j] == 1 && ArraySum[i + 1, j] == 3 ||
                        ArraySum[i, j] == 1 && ArraySum[i + 1, j] == 2
                        )
                    {
                        for (int ii = 1; ii < 19; ii++)
                        {
                            for (int jj = 1; jj < 19; jj++)
                            {
                                if (ii >= i && ArraySum[ii, jj] == 1)
                                {
                                    ArraySum[ii, jj] = 2;
                                }
                            }
                        }
                        //产生图形
                        if (Judge())
                        {
                            f = true;
                            baseshape = temp;
                            Flag = 1;
                        }
                           
                       
                    }
                }

            }
            for (int i = 18; i > 0; i--)
            {
                for (int j = 1; j < 19; j++)
                {
                    if (ArraySum[i, j] == 1 && ArraySum[i + 1, j] == 2
                        || ArraySum[i, j] == 1 && ArraySum[i + 1, j] == 3
                        )
                    {
                        return;
                    }
                }
            }
            for (int i = 18; i > 0; i--)
            {
                for (int j = 1; j < 19; j++)
                {
                    if (ArraySum[i, j] == 1)
                    {
                        ArraySum[i + 1, j] = 1;
                        ArraySum[i, j] = 0;
                    }
                }
            }
            
        }
        //消除一行并加分
        private void Eliminate() {
            for (int i = 1; i < 19; i++)
            {
                int flag = 0;
                for (int j = 1; j < 19; j++)
                {
                    if (ArraySum[i,j] == 2)
                    {
                        flag++;
                    }
                    //满一行可以消除
                    if (flag == 18)
                    {
                        for (int jj = 1; jj < 19; jj++)
                        {
                            ArraySum[i, jj] = 0;
                        }
                        for (int x = 18; x > 0; x--)
                        {
                            for (int y = 1; y < 19; y++)
                            {
                                if (ArraySum[x,y] == 2 && x < i)
                                {
                                    ArraySum[x + 1, y] = ArraySum[x,y];
                                    ArraySum[x, y] = 0;
                                } 
                            }
                        }
                        Score += 10;
                        //消除一行后上面悬空的方块要下降
                        for (int x = i; x > 0; x--)
                        {
                            for (int y = 0; y < 19; y++)
                            {
                                if (ArraySum[x,y] == 2 && ArraySum[x+1,y] == 0)
                                {
                                    ArraySum[x, y] = 0;
                                    ArraySum[x + 1, y] = 1;
                                }
                            }
                        }
                        return;
                    }
                }
            }
        }
        //判断游戏是否结束
        private void GameOver() {
            for (int i = 1; i < 2; i++)
            {
                for (int j = 1; j < 19; j++)
                {
                    if (ArraySum[i,j] == 2)
                    {
                       Console.WriteLine("GameOver!");
                        Console.WriteLine("你的分数：{0}",Score);
                        Environment.Exit(0);
                       
                    }
                }
            }
        }
        //重置游戏
        private void ResetArray() {
            Score = 0;
            for (int i = 1; i < 19; i++)
            {
                for (int j = 1; j < 30; j++)
                {
                    if (ArraySum[i,j] == 1 || ArraySum[i,j] == 2)
                    {
                        ArraySum[i, j] = 0;
                    }
                }
            }
            baseshape = CreateShape.Create();
            ArraySum = baseshape.ArrayBox;
        }
        private bool Judge() {
            for (int i = 1; i < 19; i++)
            {
                for (int j = 1; j < 19; j++)
                {
                    if (ArraySum[i,j] == 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void Display() {
            while (true)
            {
                GameOver();
                Eliminate();
                BackGroundBox.DisplayBox(ArraySum);
                Get();
            }
        }

    }

 }


using System;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(Console.WindowWidth,Console.WindowHeight);
            Console.CursorVisible = false;

            GameProcess gameProcess = new GameProcess();
            gameProcess.StartGame();
                      
        }
    }
}

using Life.Models;
using System;
using System.Threading;

namespace BackgroundThreadTest
{
    class Program
    {
        static void Main()
        {
            Thread[] threads = new Thread[2];
            threads[0] = new Thread(() =>
            {
                Gamer gamer = new Gamer("First", 10, 10);
                gamer.Run();
            });
            threads[1] = new Thread(() =>
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    threads[0].Abort();
                }
            });
            threads[0].Start();
            threads[1].Start();
            Console.ReadKey();
        }
    }
}
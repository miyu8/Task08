using System;
using Life.Models;
using System.Threading;
using Life.BaseData;
using User;
using System.Linq;
using Life.Gaming;

namespace Life.Initialization
{
    public class Move
    {
        public Cell[,] gameField;
        public Cell[,] gameFieldNext;
        public Thread[] threads = new Thread[2];
        public EventWaitHandle ew;
        Game1 game1;
        Options options;
        int iterationNumber;
        public Move()
        {
            StartConsole console = new StartConsole();
            console.Run();
            Console.Clear();
            End(console.Id);
            threads[1].Start();
            Begin(console.Id);
            threads[0].Start();
            ew = new EventWaitHandle(false, EventResetMode.AutoReset);
            ew.WaitOne();
            if (threads[1] != null)
                threads[1].Abort();
            Console.Clear();
        }

        public void Begin(int id)
        {
            threads[0] = new Thread(() =>
            {
                RecordBase recordBase = new RecordBase();
                MyConsole myConsole;
                using (var db = new DataModelContainer())
                {
                    Game game;
                    game = (Game)db.GameSet.Where(x => x.Id == id).FirstOrDefault();
                    options = new Options();
                    game1 = new Game1();
                    if (game != null)
                    {
                        game1.gameField = recordBase.TakeList(id);
                        game1.gameProperty = options.gameProperty;
                        iterationNumber = game.Iteration;
                    }
                    else
                    {
                        game1.InitRnd(options.gameProperty);
                        iterationNumber = 0;
                    }
                    myConsole = new MyConsole(options.gameProperty.SizeX, options.gameProperty.SizeY);
                    myConsole.DrawConsole(game1.gameField, 0);
                    while (game1.Step())
                    {
                        myConsole.DrawConsole(game1.gameField, 0);
                        iterationNumber++;
                        Thread.Sleep(500);
                    }

                    recordBase.RemoveList(id);
                    Program.thread.Abort();
                    if (threads[1] != null)
                        threads[1].Abort();
                    Program.thread = new Thread(() =>
                    {
                        Move move = new Move();
                        Console.ReadKey();
                    });
                    Program.thread.Start();
                }
            });
        }

        public void End(int typeGame)
        {
            threads[1] = new Thread(() =>
            {
                while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    Thread.Sleep(500);
                }
                RecordBase recordBase = new RecordBase();
                using (var db = new DataModelContainer())
                {
                    recordBase.AddList(game1.gameField, typeGame, iterationNumber);
                }
                if (threads[0] != null)
                    threads[0].Abort();
                Program.thread.Abort();
                Program.thread = new Thread(() =>
                 {
                     Move move = new Move();
                     Console.ReadKey();
                 });
                Program.thread.Start();
            });
        }
    }
}

using System;
using Life.Models;
using System.Threading;
using Life.BaseData;
using User;
using System.Linq;

namespace Life.Initialization
{
    public class Move
    {
        public Thread[] threads = new Thread[2];
        public EventWaitHandle ew;
        Gamer gamer;
        public Move()
        {
            StartConsole console = new StartConsole();
            console.Run();
            End(console.Man, console.ManToy);
            threads[1].Start();
            Begin(console.Man, console.ManToy);
            threads[0].Start();
            ew = new EventWaitHandle(false, EventResetMode.AutoReset);
            ew.WaitOne();
            if (threads[1] != null)
                threads[1].Abort();
            Console.Clear();
        }

        public void Begin(string Man, string ManToy)
        {
            threads[0] = new Thread(() =>
            {
                RecordBase recordBase = new RecordBase();
                MyConsole myConsole;
                using (var db = new DataModelContainer())
                {
                    if (db.CoordsSet.FirstOrDefault(x => x.Play.Toy == Man && x.Play.Player.Name == ManToy) != null)
                    {
                        gamer = new Gamer(Man, ManToy, 10, 10, 3, 2);
                        recordBase.TakeList(gamer.listAll, gamer.NamePlayer, gamer.NamePlay);
                        myConsole = new MyConsole(gamer.CoordX, gamer.CoordY);
                        myConsole.DrawConsole(gamer.cells, 0);
                        while (gamer.NextGeneration())
                        {
                            myConsole.DrawConsole(gamer.cells, (gamer.CoordX + 2) * (gamer.listAll.Count - 1));
                            Thread.Sleep(500);
                        }
                    }
                    else
                    {
                        gamer = new Gamer(Man, ManToy, 10, 10, 3, 2);
                        gamer.Init();
                        myConsole = new MyConsole(gamer.CoordX, gamer.CoordY);
                        myConsole.DrawConsole(gamer.cells, 0);
                        while (gamer.NextGeneration())
                        {
                            myConsole.DrawConsole(gamer.cells, (gamer.CoordX + 2) * (gamer.listAll.Count - 1));
                            Thread.Sleep(500);
                        }
                    }
                    recordBase.RemoveList(gamer.NamePlayer, gamer.NamePlay);
                    Program.thread.Abort();
                    Program.thread = new Thread(() =>
                    {
                        Move move = new Move();
                        Console.ReadKey();
                    });
                    Program.thread.Start();
                }
            });
        }

        public void End(string Man, string ManToy)
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
                    if (db.CoordsSet.FirstOrDefault(x => x.Play.Toy == Man && x.Play.Player.Name == ManToy) != null)
                    {
                        recordBase.AddList(gamer.listAll, gamer.NamePlayer, gamer.NamePlay);
                    };
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

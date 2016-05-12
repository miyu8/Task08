using System;
using User;

namespace Life.Models
{
    class StartConsole
    {
        public int Id { get; private set; }
        public int Type { get; private set; }
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Список команд:");
            Console.WriteLine("---");

            Console.WriteLine("b : запускает новую игру");
            Console.WriteLine("s : запускает сохранённую игру");
            Console.WriteLine("escape : приостанавливает с сохранением");
            Console.WriteLine("e : закрывает программу");

            Console.WriteLine("---");
            Console.WriteLine("---");
            string s = Console.ReadLine();
            if (s == "e")
                Program.thread.Abort();
            if (s == "b")
            {
                Console.WriteLine("Введите тип игры:");
                Type = int.Parse(Console.ReadLine());
            }
            if (s == "s")
            {
                Console.WriteLine("Введите Id:");
                Id = int.Parse(Console.ReadLine());
            }
        }
    }
}

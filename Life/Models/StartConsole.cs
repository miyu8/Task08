using System;
using User;

namespace Life.Models
{
    class StartConsole
    {
        public string Man { get; private set; }
        public string ManToy { get; private set; }
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Список команд:");
            Console.WriteLine("---");

            Console.WriteLine("b : запускает игру");
            Console.WriteLine("escape : приостанавливает с сохранением");
            Console.WriteLine("e : закрывает программу");

            Console.WriteLine("---");
            Console.WriteLine("---");
            string s = Console.ReadLine();
            if (s == "e")
                Program.thread.Abort();
            if (s == "b")
            {
                Console.WriteLine("Введите имя:");
                Man = Console.ReadLine();
                Console.WriteLine("Если вы хотите продолжить игру наберите название игры. Если вы хотите начать новую игру наберите название новой игры");
                ManToy = Console.ReadLine();
            }
        }
    }
}

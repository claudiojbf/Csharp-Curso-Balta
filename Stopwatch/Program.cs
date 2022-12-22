using System;
using System.Threading;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            System.Console.WriteLine("S = Segundos => 10s = 10 segundos");
            System.Console.WriteLine("M = Minuto => 10m = 10 minutos");
            System.Console.WriteLine("0 = Sair");
            System.Console.WriteLine("Quanto tempo deseja contar?");

            string opcao = Console.ReadLine().ToLower();
            char type = char.Parse(opcao.Substring((opcao.Length - 1), 1));
            int time = int.Parse(opcao.Substring(0, opcao.Length - 1));
            int multiplier = 1;
            if (type == 'm')
                multiplier = 60;
            if (time == 0)
                Environment.Exit(time);

            PreStart(time * multiplier);

        }

        static void PreStart(int time)
        {
            Console.Clear();

            System.Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            System.Console.WriteLine("Set...");
            Thread.Sleep(1000);
            System.Console.WriteLine("Go...");
            Thread.Sleep(2500);

            Start(time);
        }

        static void Start(int time)
        {
            Console.Clear();
            int currentTime = 0;
            while (currentTime != time)
            {
                Console.Clear();
                currentTime++;
                Console.WriteLine(currentTime);
                Thread.Sleep(1000);
            }
            Console.Clear();
            System.Console.WriteLine("Stopwatch finalizado");
            Thread.Sleep(2500);
            Menu();
        }
    }
}
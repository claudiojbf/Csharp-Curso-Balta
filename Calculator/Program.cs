using System;

namespace Calculator
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

            System.Console.WriteLine("O que deseja fazer?");
            System.Console.WriteLine("1 - Soma");
            System.Console.WriteLine("2 - Subtracao");
            System.Console.WriteLine("3 - Multiplicacao");
            System.Console.WriteLine("4 - Divisao");
            System.Console.WriteLine("5 - Sair");
            System.Console.WriteLine("---------------");
            System.Console.WriteLine("Selecione uma opcao");
            short opcao = short.Parse(Console.ReadLine());
            System.Console.WriteLine();
            switch (opcao)
            {
                case 1: Soma(); break;
                case 2: Subtracao(); break;
                case 3: Multiplicacao(); break;
                case 4: Divisao(); break;
                case 5: Environment.Exit(0); break;
                default: Menu(); break;
            }


        }

        static void Soma()
        {
            Console.Clear();
            Console.WriteLine("Primeiro Valor");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo Valor");
            float v2 = float.Parse(Console.ReadLine());

            System.Console.WriteLine();

            float resultado = v1 + v2;
            System.Console.WriteLine("O resultado da soma e: " + resultado);
            Console.ReadKey();
            Menu();
        }

        static void Subtracao()
        {
            System.Console.WriteLine("Primeiro Valor");
            float v1 = float.Parse(Console.ReadLine());
            System.Console.WriteLine("Segungo Valor");
            float v2 = float.Parse(Console.ReadLine());

            float resultado = v1 - v2;
            System.Console.WriteLine();

            System.Console.WriteLine("O resultado e: " + resultado);
            Console.ReadKey();
            Menu();
        }

        static void Multiplicacao()
        {
            Console.Clear();
            System.Console.WriteLine("Primeiro valor");
            float v1 = float.Parse(Console.ReadLine());
            System.Console.WriteLine("Segundo Valor");
            float v2 = float.Parse(Console.ReadLine());
            float resultado = v1 * v2;
            System.Console.WriteLine();
            System.Console.WriteLine("O resultado e: " + resultado);
            Console.ReadKey();
            Menu();
        }

        static void Divisao()
        {
            Console.Clear();
            System.Console.WriteLine("Primeiro Valor");
            float v1 = float.Parse(Console.ReadLine());
            System.Console.WriteLine("Segundo Valor");
            float v2 = float.Parse(Console.ReadLine());
            float resultado = v1 / v2;
            System.Console.WriteLine();
            System.Console.WriteLine("O resultado e: " + resultado);
            Console.ReadKey();
            Menu();
        }
    }
}
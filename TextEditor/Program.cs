using System;
using System.IO;

namespace TextEditor
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
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir Arquivo");
            Console.WriteLine("2 - Criar Novo Arquivo");
            Console.WriteLine("0 - Sair");
            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("Qual a sua escolha?");
            short opc = short.Parse(Console.ReadLine());

            switch (opc)
            {
                case 0: Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: CriarArquivo(); break;
                default: Menu(); break;
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo que você deseja acessar?");
            var path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                System.Console.WriteLine(text);
            }

            System.Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void CriarArquivo()
        {
            Console.Clear();
            Console.WriteLine("Digite seu Texto: (ESC para sair)");
            System.Console.WriteLine("-----------------------------");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(text);
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.ReadLine();
            System.Console.WriteLine($"Arquivo {path} Salvo com sucesso.");
            Menu();
        }
    }
}
using System;
using System.IO;
using System.Text;

namespace EditorHtml
{
    public static class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            System.Console.WriteLine("MODO EDITOR");
            System.Console.WriteLine("----------------");
            Start();
        }

        public static void Start()
        {
            var file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            System.Console.WriteLine("-------------------");

            System.Console.WriteLine("Deseja salvar o arquivo? (s/n)");
            char opt = char.Parse(Console.ReadLine().ToLower());

            switch (opt)
            {
                //case 's': Texto(file.ToString()); break;
                case 's': Viewer.Show(file.ToString()); break;
                case 'n':
                    {
                        System.Console.WriteLine("Texto descartado!");
                        Console.ReadLine();
                        Menu.Show();
                        break;
                    }
                default: Editor.Show(); break;
            }

        }

        public static void Texto(string text)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            System.Console.WriteLine("Digite o caminho para salvar o arquivo: ");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            System.Console.WriteLine("Texto Salvo com sucesso!");
            Console.ReadLine();
            Menu.Show();
        }
    }
}
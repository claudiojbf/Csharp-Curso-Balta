using Blog.Screans.TagScreans;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STIRNG = @"Server=localhost,1433;Database=blog;User ID=sa; PASSWORD=1q2w3e4r@#$;TrustServerCertificate=True";
        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(CONNECTION_STIRNG);
            Database.Connection.Open();
            Load();

            Console.ReadKey();
            Database.Connection.Close();
        }

        private static void Load()
        {
            Console.Clear();
            System.Console.WriteLine("Meu Blog");
            System.Console.WriteLine("-------------");
            System.Console.WriteLine("O que deseja fazer?");
            System.Console.WriteLine();
            System.Console.WriteLine("1 - Gestão de Usuário");
            System.Console.WriteLine("2 - Gestão de Perfil");
            System.Console.WriteLine("3 - Gestão de Categoria");
            System.Console.WriteLine("4 - Gestão de Tag");
            System.Console.WriteLine("5 - Vincular perfil/usuario");
            System.Console.WriteLine("6 - Vincular post/tag");
            System.Console.WriteLine("7 - Relatorios");
            System.Console.WriteLine();
            System.Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 4:
                    MenuTagScreen.Load(); break;
                default:
                    Load(); break;
            }
        }
    }
}
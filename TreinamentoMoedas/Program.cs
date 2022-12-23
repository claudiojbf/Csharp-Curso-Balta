using System;
using System.Globalization;

namespace TreinamentoMoedas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            //Melhor tipo para trabalhar com moedas
            decimal valor = 10324.25m;
            System.Console.WriteLine(valor.ToString("G", CultureInfo.CreateSpecificCulture("pt-BR")));
            System.Console.WriteLine(valor.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR")));
            System.Console.WriteLine(valor.ToString("F", CultureInfo.CreateSpecificCulture("pt-BR")));
            System.Console.WriteLine(valor.ToString("E04", CultureInfo.CreateSpecificCulture("pt-BR")));
            System.Console.WriteLine(valor.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR")));
            System.Console.WriteLine(valor.ToString("P", CultureInfo.CreateSpecificCulture("pt-BR")));
            System.Console.WriteLine(Math.Round(valor));
            System.Console.WriteLine(Math.Ceiling(valor));
            System.Console.WriteLine(Math.Floor(valor));
        }
    }
}
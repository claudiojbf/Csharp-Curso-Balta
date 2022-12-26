using System;

namespace TreinamentoArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var meuArray = new int[5] { 10, 20, 30, 40, 50 };
            // meuArray[0] = 12;
            // System.Console.WriteLine(meuArray[0]);

            for (int item = 0; item < meuArray.Length; item++)
                System.Console.WriteLine(meuArray[item]);

            foreach (var item in meuArray)
                System.Console.WriteLine(item);


        }
    }
}
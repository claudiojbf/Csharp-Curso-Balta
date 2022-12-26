using System;

namespace TreinamentoExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[3];

            // try
            // {
            //     for (var index = 0; index < 10; index++)
            //         System.Console.WriteLine(arr[index]);
            // }
            // catch
            // {
            //     System.Console.WriteLine("Ops, algo deu errado!!");
            // }
            try
            {
                // for (var index = 0; index < 10; index++)
                //     System.Console.WriteLine(arr[index]);

                Salvar("");
            }
            catch (IndexOutOfRangeException ex)
            {
                System.Console.WriteLine(ex.InnerException);
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine("Não encontrei o indice");
            }
            catch (ArgumentNullException ex)
            {
                System.Console.WriteLine(ex.InnerException);
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine("Falha ao cadastrar texto");
            }
            catch (MinhaException ex)
            {
                System.Console.WriteLine(ex.InnerException);
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine(ex.QuandoAconteceu);
                System.Console.WriteLine("Ex customizada");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.InnerException);
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine("Ops, algo deu errado!!");
            }
            finally
            {
                System.Console.WriteLine("Chegou ao fim");
            }
        }

        static void Salvar(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                throw new MinhaException(DateTime.Now);
            }
        }

        public class MinhaException : Exception
        {
            public MinhaException(DateTime data)
            {
                QuandoAconteceu = data;
            }
            public DateTime QuandoAconteceu { get; set; }
        }
    }
}
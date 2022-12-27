using System;
using BaltaOO.ContentContext;

namespace BaltaOO
{
    class Program
    {
        static void Main(string[] args)
        {
            var articles = new List<Article>();
            articles.Add(new Article("Artigo sobre OOP", "orientacao-objetos"));
            articles.Add(new Article("Artigo sobre C#", "csharp"));
            articles.Add(new Article("Artigo sobre DotNet", "dotnet"));

            foreach (var article in articles)
            {
                System.Console.WriteLine(article.Id);
                System.Console.WriteLine(article.Title);
                System.Console.WriteLine(article.Url);
            }
        }
    }
}
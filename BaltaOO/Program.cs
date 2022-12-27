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
            var Courses = new List<Course>();
            var CourseOOP = new Course("Fundamentos OOP", "fundamentos-oop");
            var CourseCsharp = new Course("Fundamentos c#", "fundamentos-c#");
            var CourseDotnet = new Course("Fundamentos dotnet", "fundamentos-dotnet");

            Courses.Add(CourseOOP);
            Courses.Add(CourseCsharp);
            Courses.Add(CourseDotnet);

            var careers = new List<Career>();
            var Career = new Career("Especialista Dotnet", "especialista-dotnet");
            var careerItem2 = new CareerItem(2, "Aprenda .Net", "", CourseDotnet);
            var careerItem = new CareerItem(1, "Comece por aqui", "", CourseCsharp);
            var careerItem3 = new CareerItem(3, "OOP", "", CourseOOP);

            Career.Items.Add(careerItem2);
            Career.Items.Add(careerItem);
            Career.Items.Add(careerItem3);
            careers.Add(Career);

            foreach (var c in careers)
            {
                System.Console.WriteLine(c.Title);
                foreach (var item in c.Items.OrderBy(x => x.Ordem))
                {
                    System.Console.WriteLine($"{item.Ordem} - {item.Title}");
                    System.Console.WriteLine(item.Course.Title);
                    System.Console.WriteLine(item.Course.Level);
                }
            }
        }
    }
}
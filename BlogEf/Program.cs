using System;
using BlogEf.Data;
using BlogEf.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogEf
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BlogDataContext())
            {
                // var tag = new Tag {Name = "ASP.NET", Slug="aspnet"};
                // context.Tags.Add(tag);
                // context.SaveChanges();
                
                // var tag2 = new Tag {Name = ".NET", Slug="dotnet"};
                // context.Tags.Add(tag2);
                // context.SaveChanges();

                // var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
                // tag.Name = ".NET";
                // tag.Slug = "dotnet";
                // context.Update(tag);
                // context.SaveChanges();

                // var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
                // context.Remove(tag);
                // context.SaveChanges();

                // .Where(x => x.Name == ".NET")
                // var tags = context
                // .Tags
                // .AsNoTracking()
                // .ToList()
                // ;
                // foreach (var item in tags)
                // {
                //     System.Console.WriteLine($"{item.Id} - {item.Name}");
                // }

                // Update or Delete não é recomendado utilizar o .AsNoTracking()
                // var tag = context.Tags.AsNoTracking().FirstOrDefault(x => x.Id == 2);
                // tag.Name = ".NET";
                // tag.Slug = "dotnet";
                // context.Update(tag);
                // context.SaveChanges();

                var tag = context.Tags
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == 3)
                ;
                System.Console.WriteLine(tag?.Name);
            }
        }
    }
}
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
            // using var context = new BlogDataContext();
            // context.Users.Add(new User(){
            //     Name = "Claudio Filho",
            //     Email = "brosson123@gmail.com",
            //     Bio = "Dev BackEnd",
            //     Image = "https://",
            //     PasswordHash = "1234",
            //     Slug = "claudio-filho"
            // });

            // context.SaveChanges();

            // using var context = new BlogDataContext();
            // var user = context.Users.Where(x => x.Id == 2).FirstOrDefault();
            // var post = new Post()
            // {
            //     Author = user,
            //     Body = "Meu Artigo",
            //     Category = new Category
            //     {
            //         Name = "BackEnd",
            //         Slug = "backend2"
            //     },
            //     CreateDate = DateTime.Now,
            //     Slug = "meu-artigo",
            //     Summary = "Neste artigo vamos conferir...",
            //     Title = "Meu Artigo"
            // };
            // context.Posts.Add(post);
            // context.SaveChanges();

            var user = new User
            {
                Bio="a",
                Email = "a@a.com",
                GitHub = "addc",
                Image = "https://",
                Name = "Aaaasaa",
                PasswordHash = "123",
                Slug = "aaaa-aaaa"
            };

            using var context = new BlogDataContext();

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
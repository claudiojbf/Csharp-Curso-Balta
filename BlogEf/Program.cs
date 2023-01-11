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
            using var context = new BlogDataContext();
        }
    }
}
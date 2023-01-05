using Blog.Models;
using Blog.Repositories;

namespace Blog.Screans.TagScreans
{
    public static class ListTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            System.Console.WriteLine("Lista de tags");
            System.Console.WriteLine("---------------");
            List();
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<Tag>(Database.Connection);
            var tags = repository.Get();

            foreach (var item in tags)
                System.Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }
    }
}
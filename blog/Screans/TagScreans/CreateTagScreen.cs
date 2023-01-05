using Blog.Models;
using Blog.Repositories;

namespace Blog.Screans.TagScreans
{
    public static class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            System.Console.WriteLine("Nova tag");
            System.Console.WriteLine("---------------");
            System.Console.WriteLine("Nome: ");
            var name = Console.ReadLine();
            System.Console.WriteLine("Slug: ");
            var slug = Console.ReadLine();
            Create(new Tag
            {
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Create(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Create(tag);
                System.Console.WriteLine("Tag cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Não foi possivel salvar a tag");
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
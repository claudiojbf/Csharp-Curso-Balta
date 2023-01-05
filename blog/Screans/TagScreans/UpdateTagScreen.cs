using Blog.Models;
using Blog.Repositories;

namespace Blog.Screans.TagScreans
{
    public static class UpdateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            System.Console.WriteLine("Atualizando uma tag");
            System.Console.WriteLine("---------------");
            System.Console.WriteLine("Id");
            var id = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Nome: ");
            var name = Console.ReadLine();
            System.Console.WriteLine("Slug: ");
            var slug = Console.ReadLine();
            Update(new Tag
            {
                Id = id,
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Update(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Update(tag);
                System.Console.WriteLine("Tag atulizada com sucesso!");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Não foi possivel atualizar a tag");
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
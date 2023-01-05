using Blog.Models;
using Blog.Repositories;

namespace Blog.Screans.TagScreans
{
    public static class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            System.Console.WriteLine("Excluir uma tag");
            System.Console.WriteLine("---------------");
            System.Console.WriteLine("Qual o id da tag que deseja excluir?");
            var id = int.Parse(Console.ReadLine());
            Delete(id);
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Delete(id);
                System.Console.WriteLine("Tag deletada com sucesso!");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Não foi possivel deletar a tag");
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
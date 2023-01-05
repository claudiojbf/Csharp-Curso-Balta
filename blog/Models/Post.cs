using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Post]")]
    class Post
    {
        public int Id { get; set; }
        public Category CategoryId { get; set; }
        public User AuthorId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public DateTime CreateData { get; set; }
        public DateTime LastUpdateDate { get; set; }

        [Write(false)]
        public List<Category> Categories { get; set; }

        public Post()
        {
            Categories = new List<Category>();
        }
    }
}
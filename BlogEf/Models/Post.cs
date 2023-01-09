using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEf.Models
{
    // CREATE TABLE [Post] (
    // [Id] INT NOT NULL IDENTITY(1, 1),
    // [CategoryId] INT NOT NULL,
    // [AuthorId] INT NOT NULL,
    // [Title] VARCHAR(160) NOT NULL,
    // [Summary] VARCHAR(255) NOT NULL,
    // [Body] TEXT NOT NULL,
    // [Slug] VARCHAR(80) NOT NULL,
    // [CreateDate] DATETIME NOT NULL DEFAULT(GETDATE()),
    // [LastUpdateDate] DATETIME NOT NULL DEFAULT(GETDATE()),

    // CONSTRAINT [PK_Post] PRIMARY KEY([Id]),
    // CONSTRAINT [FK_Post_Category] FOREIGN KEY([CategoryId]) REFERENCES [Category]([Id]),
    // CONSTRAINT [FK_Post_Author] FOREIGN KEY([AuthorId]) REFERENCES [User]([Id]),
    // CONSTRAINT [UQ_Post_Slug] UNIQUE([Slug])
    // )
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Body { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public Category Category { get; set; } = null!;
        public User Author { get; set; } = null!;

        public List<Tag> Tags { get; set; }
    }
}